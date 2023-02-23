using FinalProj.Dal;
using FinalProj.Models;
using Logic.Repositories;

namespace Airport.Data.Repositories
{
    public class TerminalRepository : GenericRepository<Terminal>, ITerminalRepository
    {
        private readonly AirportDbContext _terminalRepository;
        public TerminalRepository(AirportDbContext context) : base(context)
        {
            _terminalRepository = context;

        }

        
    }
}
