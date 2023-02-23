using Logic.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProj.Models
{
    public class Terminal : ITerminal
    {

        public string TerminalId { get; set; } = null!;
        [ForeignKey("Flight")]
        public string? FlightId { get; set; }

        [Required]
        public int TerminalNumber { get; set; }
        [Required]
        public double CrossingTime { get; set; }
        [Required]
        public bool IsFree { get; set; } = true;

        public Flight? Flight { get; set; }
        static int number;
        public Terminal()
        {
            TerminalId = Guid.NewGuid().ToString();
            TerminalNumber = ++number;
        }
        public Terminal(Terminal terminal)
        {
            this.CrossingTime = terminal.CrossingTime;
            this.Flight = terminal.Flight;
            this.TerminalNumber = terminal.TerminalNumber;
            this.IsFree = terminal.IsFree;
            this.FlightId = terminal.FlightId;
            this.TerminalId = terminal.TerminalId;
        }
    }
}
