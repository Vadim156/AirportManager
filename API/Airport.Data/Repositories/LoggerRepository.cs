using FinalProj.Dal;
using Logic.Models;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data.Repositories
{
    public class LoggerRepository : GenericRepository<Logger> , ILoggerRepository
    {
        private readonly AirportDbContext _airportDbContext;
        public LoggerRepository(AirportDbContext context) : base(context)
        {
            _airportDbContext = context;
        }
    }
}
