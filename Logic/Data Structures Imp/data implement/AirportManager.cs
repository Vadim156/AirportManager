using Airport.Data.Data_Structures_Imp.data_implement;
using FinalProj.Models;
using Logic;
using Logic.Data_Structures;
using Logic.Data_Structures_Imp.data_implement;
using Logic.logicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data
{
    public class AirportManager : GraphImp, IGraghAirport
    {
        Queue<Flight> _baseTerminal1;
        Terminal[] terminalsLogic = new Terminal[8];
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        int count = 0;

        public AirportManager()
        {
            _baseTerminal1 = new Queue<Flight>();

        }
        public int Counter()
        {
            count++;
            return count;
        }
        public async Task AddFlight(Flight flight)
        {
            _baseTerminal1.Enqueue(flight);
        }


        public async Task CreateTerminals(Terminal[] terminals)
        {
            
            Terminal[] terminalsLogic = terminals;

            for (int i = 0; i < terminalsLogic.Length; i++)
            {
                this.AddNode(terminalsLogic[i]);
            }

            for (int i = 0; i < terminalsLogic.Length - 3;)
            {
                this.AddEdge(terminalsLogic[i], terminalsLogic[++i]);
            }

            this.AddEdge(terminalsLogic[5], terminalsLogic[7]);
            this.AddEdge(terminalsLogic[6], terminalsLogic[7]);
            this.AddEdge(terminalsLogic[7], terminalsLogic[3]);

            
        }

        

        public async Task<ComplexObject> Timer(Flight flight1)
        {
            var crossTime = flight1.Terminal.CrossingTime;

            if (flight1.TerminalNumber == 8)
                crossTime = 1; //to keep faster pace in the end of the line(start of the queue)

            if (flight1.TerminalNumber == 3)
                this.Nodes[1].Value.IsFree = true;

            int time = (int)(crossTime * 1000); //3.5=>3500
            if (flight1.TerminalNumber <= 8 && flight1 != null)
            {
                await Task.Delay(time);
                var result = MoveNext(flight1);

                while (result.Result == null)
                {
                    await Task.Delay(time);
                    result = MoveNext(flight1);
                }
                return result.Result;
            }
            return null;

        }

        public async Task<ComplexObject> MoveNext(Flight flight)
        {
            int? nextTerminal = flight.TerminalNumber + 1;
            if (flight.TerminalNumber == 1)
            {
                if (_baseTerminal1 != null && _baseTerminal1.Count > 0 && this.Nodes[1].Value.IsFree == true)
                {
                    this.Nodes[1].Value.IsFree = false;

                    Flight flight1 = _baseTerminal1.Dequeue();
                    while (flight1 == null)
                        flight1 = _baseTerminal1.Dequeue();
                    ComplexObject complexObject = NextTerminal(flight1).Result;
                    return complexObject;

                }
            }

            if (flight.TerminalNumber == 7 || flight.TerminalNumber < 5)
            {
                if (this.Nodes[(int)nextTerminal - 1].Value.IsFree == true)
                {
                    this.Nodes[(int)nextTerminal - 1].Value.IsFree = false;
                    ComplexObject complexObject = NextTerminal(flight).Result;
                    return complexObject;
                }
            }
            else if (flight.TerminalNumber == 5)
            {
                if (this.Nodes[6].Value.IsFree == true)
                {
                    this.Nodes[6].Value.IsFree = false;
                    this.Nodes[6].Value.Flight = flight;
                    ComplexObject complexObject = NextTerminal(flight).Result;
                    return complexObject;

                }
                else if (this.Nodes[5].Value.IsFree == true)
                {
                    this.Nodes[5].Value.IsFree = false;
                    this.Nodes[5].Value.Flight = flight;
                    ComplexObject complexObject = NextTerminal(flight).Result;
                    return complexObject;
                }
                return null;
            }
            else if (nextTerminal == 7)
            {
                if (this.Nodes[7].Value.IsFree == true)
                {
                    this.Nodes[7].Value.IsFree = false;
                    this.Nodes[7].Value.Flight = flight;
                    ComplexObject complexObject = NextTerminal(flight).Result;
                    return complexObject;

                }
                return null;
            }
            else if (flight.TerminalNumber == 8)
            {
                if (this.Nodes[3].Value.IsFree == true)
                {
                    this.Nodes[3].Value.IsFree = false;

                    ComplexObject complexObject = TryToDeparture(flight).Result;
                    return complexObject;
                }
            }
            return null;
        }

        public async Task<ComplexObject> NextTerminal(Flight flight)
        {

            ComplexObject complexObject = new ComplexObject();

            complexObject.previousTerminal = flight.TerminalNumber;

            int? FlightTerNum = flight.TerminalNumber + 1;
            if (flight.TerminalNumber == 5)
            {
                if (this.Nodes[6].Value.Flight == flight)
                {
                    FlightTerNum = flight.TerminalNumber + 2;
                }
                else if (this.Nodes[5].Value.Flight == flight)
                {
                    FlightTerNum = flight.TerminalNumber + 1;
                }
            }
            else if (flight.TerminalNumber == 6)
            {
                if (this.Nodes[7].Value.Flight == flight)
                {
                    FlightTerNum = flight.TerminalNumber + 2;
                }
            }
            this.Nodes[(int)(complexObject.previousTerminal-1)].Value.IsFree = true;

            for (int i = 0; i < this.Nodes.Count; i++)
            {
                if (this.Nodes[i].Value.TerminalNumber == FlightTerNum)
                {
                    flight.Terminal = this.Nodes[i].Value;
                    flight.TerminalNumber = this.Nodes[i].Value.TerminalNumber;
                    flight.TerminalId = this.Nodes[i].Value.TerminalId;
                }
            }

            complexObject.Flight = flight;
            return complexObject;
        }

        public async Task<ComplexObject> TryToDeparture(Flight flight2)
        {
            Terminal t4 = this.Nodes[3].Value;
            t4.FlightId = flight2.FlightId;


            flight2.IsDeparture = true;
            flight2.TerminalNumber = 4;
            flight2.TerminalId = t4.TerminalId;


            Terminal t8 = this.Nodes[7].Value;
            t8.Flight = null;
            t8.FlightId = null;
            t8.IsFree = true;


            ComplexObject complexOnject = new ComplexObject();
            complexOnject.Flight = flight2;
            complexOnject.Terminal1 = t4;
            complexOnject.Terminal2 = t8;

            this.Nodes[7].Value.IsFree = true;
            return complexOnject;
        }

        public async Task<Terminal> Departure()
        {
            this.Nodes[3].Value.Flight = null;
            this.Nodes[3].Value.FlightId = null;
            this.Nodes[3].Value.IsFree = true;

            Terminal t4 = this.Nodes[3].Value;
            return t4;
        }
    }
}
