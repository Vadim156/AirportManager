using FinalProj.Models;
using Logic.Data_Structures;
using Logic.logicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data.Data_Structures_Imp.data_implement
{
    public interface IGraghAirport 
    {
        public Task CreateTerminals(Terminal[] terminals);
        public Task AddFlight(Flight flight);
        public Task<ComplexObject> Timer(Flight flight1);
        public Task<ComplexObject> MoveNext(Flight flight);
        public Task<ComplexObject> NextTerminal(Flight flight);
        public Task<ComplexObject> TryToDeparture(Flight flight2);
        public Task<Terminal> Departure();
        public int Counter();


    }
}
