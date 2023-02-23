using FinalProj.Models;
using Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProj.Dal
{
    public class AirportDbContext : DbContext
    {
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }
        public virtual DbSet<Logger> Loggers { get; set; }
        public AirportDbContext()
        {
        }
        public AirportDbContext(DbContextOptions<AirportDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FinalProjDb");
            }
        }
    }
}
