namespace Logic.Repositories
{
    public interface ITerminal
    {
        public string TerminalId { get; set; }
        public int TerminalNumber { get; set; }
        public double CrossingTime { get; set; }
        public bool IsFree { get; set; }
    }
}
