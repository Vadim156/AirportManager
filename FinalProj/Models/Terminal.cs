namespace FinalProj.Models
{
    public class Terminal
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int PlaneCapacity { get; set; }
        public int CrossingTime { get; set; }
        public bool Departure { get; set; }
        public bool Landing { get; set; }
        public Terminal()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
