namespace CopilotDemoApi.Models
{
    public class RealProperty
    {
        public int Id { get; set; }
        public int Area { get; set; }
        public int Rooms { get; set; }
        public RealPropertyType PropertyType { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }
    }

    public enum RealPropertyType
    {
        House,
        Apartment,
        Office
    }
}
