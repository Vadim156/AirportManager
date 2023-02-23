namespace FinalProj.Models
{
    public class BaseTerminal : Terminal
    {
        public string TerminalId { get; set; }
        public int Number { get; set; } = 1;
        public double CrossingTime { get; set; } = 1;
        public bool IsFree { get; set; } = true;
        public BaseTerminal()
        {

        }
        public BaseTerminal(Flight flight)
        {

        }
    }
}
