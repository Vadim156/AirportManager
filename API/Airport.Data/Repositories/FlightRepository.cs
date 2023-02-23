using FinalProj.Dal;
using FinalProj.Models;
using Logic.Repositories;

namespace Airport.Data.Repositories
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        private readonly AirportDbContext _terminalRepository;
        public FlightRepository(AirportDbContext context) : base(context)
        {
            _terminalRepository = context;
        }
    }
}
