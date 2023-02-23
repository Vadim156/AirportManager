using Airport.Data.Data_Structures_Imp.data_implement;
using Airport.Data.Repositories;
using FinalProj.Models;
using Logic.Data_Structures;
using Logic.logicModels;
using Logic.Models;
using Logic.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ILoggerRepository _loggerRepository;

        private readonly ITerminalRepository _terminalRepository;
        private readonly IGraghAirport _gragh;

        public FlightsController(IGraghAirport graph, IFlightRepository flightRepository, ILoggerRepository loggerRepository, ITerminalRepository terminalRepository)
        {
            _flightRepository = flightRepository;
            _loggerRepository = loggerRepository;
            _terminalRepository = terminalRepository;
            _gragh = graph;

            if (_gragh.Counter() == 1) //create terminals only on first instance(by the singleton attached class)
                AddTerminals();
        }


        public async Task AddTerminals()
        {
            Random rnd = new Random();
            List<Terminal> allTerminals = _terminalRepository.GetAllAsync().Result.ToList();
            var numberOfTerminals = allTerminals.Count();

            
            if (numberOfTerminals < 8)
            {
                Terminal[] terminals = new Terminal[8];

                for (int i = 0; i < terminals.Length; i++)
                {
                    int Crossingtime = rnd.Next(1, 8);
                    Terminal t = new Terminal { TerminalNumber = ++i, CrossingTime = Crossingtime };
                    i--;
                    terminals[i] = t;
                    await _terminalRepository.AddAsync(terminals[i]);

                }
                await _gragh.CreateTerminals(terminals);
            }
            else
            {
                Terminal[] terminals = allTerminals.OrderBy(x => x.TerminalNumber).ToArray();

                await _gragh.CreateTerminals(terminals);
            }
            
        }
        

        public async Task Put(Flight flight)
        {
            ComplexObject complexObject = new ComplexObject();
            complexObject = _gragh.Timer(flight).Result;
            while (complexObject == null)
            {
                complexObject = _gragh.Timer(flight).Result;
            }

            int? prevTerminalNum = complexObject.previousTerminal;
            Flight flight1 = new Flight(complexObject.Flight);

            if (flight1.TerminalNumber == 4 && flight1.IsDeparture == true)
            {
                await TryToDeparture(complexObject);
            }

            Terminal t = new Terminal(complexObject.Flight.Terminal);
            Terminal t2 = _terminalRepository.GetAsync(flight1.Terminal.TerminalId).Result;

            t2.FlightId = flight1.FlightId;
            t2.Flight = flight1;
            t2.IsFree = t.IsFree;

            await _terminalRepository.UpdateAsync(t2);


            Flight flight2 = new Flight(complexObject.Flight);
            Flight flight3 = _flightRepository.GetAsync(flight2.FlightId).Result;

            flight3.TerminalNumber = flight2.TerminalNumber;
            flight3.Terminal = flight2.Terminal;
            flight3.TerminalId = flight2.TerminalId;

            await _flightRepository.UpdateAsync(flight3);

            Logger logger = new Logger() { Flight = flight3, Terminal = t2, In = DateTime.Now };
            await _loggerRepository.AddAsync(logger);
            

            if (prevTerminalNum != null) //only from second terminal will have previous one
            {
                Terminal previous = _terminalRepository.GetAllAsync().Result.First(x => x.TerminalNumber == prevTerminalNum);
                previous.IsFree = true;
                previous.Flight = null;
                previous.FlightId = null;
                await _terminalRepository.UpdateAsync(previous);

                Logger logger2 = new Logger() { Flight = flight3, Terminal = previous, Out = DateTime.Now };
                await _loggerRepository.UpdateAsync(logger2);
            }

           
            if (flight1.TerminalNumber <= 8)
                await Put(flight1);

        }

        [HttpGet]
        public async Task<IEnumerable<Flight>> GetFlights()
        {
            var allFlights = await _flightRepository.GetAllAsync();
            return allFlights;
        }

        
        public async Task TryToDeparture(ComplexObject complex)
        {
            Terminal t4 = new Terminal();
            Terminal t8 = new Terminal();
            Flight flight3 = new Flight();

            Terminal t = new Terminal(complex.Terminal1);
            Terminal t1 = new Terminal(complex.Terminal2);
            Flight flight2 = new Flight(complex.Flight);

            flight3 = _flightRepository.GetAsync(flight2.FlightId).Result;
            t4 = _terminalRepository.GetAsync(t.TerminalId).Result;
            t8 = _terminalRepository.GetAsync(t1.TerminalId).Result;

            flight3.TerminalNumber = flight2.TerminalNumber;
            flight3.Terminal = flight2.Terminal;
            flight3.TerminalId = flight2.TerminalId;
            flight3.IsDeparture = true;
            await _flightRepository.UpdateAsync(flight3);

            t4.FlightId = flight3.FlightId;
            t4.Flight = t1.Flight;
            t4.IsFree = t.IsFree;
            await _terminalRepository.UpdateAsync(t4);

            Logger logger2 = new Logger() { Flight = flight3, Terminal = t8, Out = DateTime.Now };
            await _loggerRepository.UpdateAsync(logger2);
            Logger logger = new Logger() { Flight = flight3, Terminal = t4, In = DateTime.Now };
            await _loggerRepository.AddAsync(logger);

            t8.IsFree = t1.IsFree;
            t8.FlightId = t1.FlightId;
            t8.Flight = t1.Flight;
            await _terminalRepository.UpdateAsync(t8);

            

            await Departure(flight3);

            return;

        }


        public async Task Departure(Flight flight)
        {
            Terminal t = _gragh.Departure().Result;
            Terminal t4 = _terminalRepository.GetAsync(t.TerminalId).Result;
            t4.IsFree = t.IsFree;
            t4.Flight = t.Flight;
            t4.FlightId = t.FlightId;
            await _terminalRepository.UpdateAsync(t4);

            Flight flight2 = new Flight(flight);
            Flight flight1 = _flightRepository.GetAsync(flight2.FlightId).Result;
            flight1.Terminal = flight1.Terminal;
            flight1.TerminalNumber = flight1.TerminalNumber;
            flight1.TerminalId = flight1.TerminalId;

            Logger logger2 = new Logger() { Flight = flight1, Terminal = t4, Out = DateTime.Now };
            await _loggerRepository.UpdateAsync(logger2);

            await _flightRepository.DeleteAsync(flight1.FlightId);
        }

        [Route("Post")]
        [HttpPost]
        public async Task Post(Flight flight)
        {
            Flight flight1 = new Flight(flight);
           
            Terminal t = _terminalRepository.GetAllAsync().Result.FirstOrDefault(
                     x => x.TerminalNumber == 1);
            if (t != null)
            {
                flight1.Terminal = t;
                flight1.TerminalNumber = t.TerminalNumber;
                flight1.TerminalId = t.TerminalId;
                t.Flight = flight1;
                t.FlightId = flight1.FlightId;

                await _flightRepository.AddAsync(flight1);
                await _terminalRepository.UpdateAsync(t);

                Logger logger = new Logger() { Flight = flight1, Terminal = t, In = DateTime.Now };
                await _loggerRepository.AddAsync(logger);
                await _gragh.AddFlight(flight1);
                await Put(flight1);

            }
            else
                await Post(flight1);

        }

    }
}
