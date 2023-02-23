using FinalProj.Models;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data.Repositories
{
    public interface IFlightRepository : IGenericRepository<Flight>
    {
    }
}
