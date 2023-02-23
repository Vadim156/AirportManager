using FinalProj.Models;

namespace Logic.logicModels
{
    public class ComplexObject
    {
        public Flight? Flight { get; set; }
        public int? previousTerminal { get; set; }
        public Terminal? Terminal1 { get; set; }
        public Terminal? Terminal2 { get; set; }
    }
}
