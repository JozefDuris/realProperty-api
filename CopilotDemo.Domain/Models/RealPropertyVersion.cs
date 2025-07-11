namespace CopilotDemo.Domain.Models;

public class RealPropertyVersion
{
    public int VersionNumber { get; set; }
    public int Area { get; set; }
    public int Rooms { get; set; }
    public RealPropertyType PropertyType { get; set; }
    public string Address { get; set; } = string.Empty;
    public int Price { get; set; }
}
