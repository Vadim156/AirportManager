namespace SimulatorEngine
{
    public class PlaneDto
    {
        public PlaneDto() { Id = Guid.NewGuid().ToString(); }
        public string Id;
        public string Name;
        public string Description;
        public int Num;
        public int code;
        public int type;

    }
}
