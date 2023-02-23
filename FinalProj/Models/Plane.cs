namespace FinalProj.Models
{
    public class Plane
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Passengers { get; set; }
        public string BrandName { get; set; }
        public string CurrentTerminal { get; set; }
        public bool Landing { get; set; }
        public bool Departure { get; set; }
        public Plane()
        {
            Id = Guid.NewGuid().ToString();

            if (Landing) { Departure = false; }
            else { Departure = true; }

            if (Departure) { Landing = false; }
            else { Landing = true; }

        }
    }
}
