using Logic.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProj.Models
{
    public class Flight
    {

        public string FlightId { get; set; } = null!;
        public int? TerminalNumber { get; set; }
        [ForeignKey("Terminal")]
        public string? TerminalId { get; set; }

        [Required]
        public int? Number { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public int PassengersCount { get; set; }
        public BrandType Brand { get; set; }
        [Required]
        public bool IsDeparture { get; set; } = false;

        public virtual Terminal? Terminal { get; set; }

        public Flight()
        {

        }
        public Flight(Flight flight)
        {
            this.Number = flight.Number;
            this.Terminal = flight.Terminal;
            this.TerminalNumber = flight.TerminalNumber;
            this.SerialNumber = flight.SerialNumber;
            this.Brand = flight.Brand;
            this.FlightId = flight.FlightId;
            this.IsDeparture = flight.IsDeparture;
            this.PassengersCount = flight.PassengersCount;
            this.TerminalId = flight.TerminalId;
        }
        [NotMapped]
        public ITerminal? Iterminal
        {
            get => Terminal;
        }


    }

    public enum BrandType
    {
        ElAl,
        Arkia,
        Israir,
        SunDor
    }
}
