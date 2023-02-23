namespace FinalProj.Models
{
    public class BaseTerminal
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int PlaneCapacity { get; set; }
        public int CrossingTime { get; set; }
        public bool Departure { get; set; }
        public bool Landing { get; set; }
        public BaseTerminal()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
