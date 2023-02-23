using FinalProj.Models;
using Logic.Repositories;

namespace SimulatorEngine
{
    public class FlightDto
    {
        public string FlightId { get; set; } = Guid.NewGuid().ToString();
        public int? TerminalNumber { get; set; }

        public string? TerminalId { get; set; }

        static int number;

        public int Number { get; set; }
        public string SerialNumber { get; set; } = Guid.NewGuid().ToString();
        public int PassengersCount { get; set; }
        public BrandTypeDto Brand { get; set; }
        public bool IsDeparture { get; set; }
        public virtual Terminal? Terminal { get; set; }
        public ITerminal? Iterminal
        {
            get => Terminal;
        }

        public FlightDto() => Number = ++number;
    }
    public enum BrandTypeDto
    {
        ElAl,
        Arkia,
        Israir,
        SunDor
    }
}
