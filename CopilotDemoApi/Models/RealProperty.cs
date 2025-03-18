namespace CopilotDemoApi.Models
{
    public class RealProperty
    {
        public int Id { get; set; }
        public List<RealPropertyVersion> Versions { get; set; } = [];

        public RealPropertyVersion? GetLatestVersion()
        {
            return Versions.OrderByDescending(v => v.VersionNumber).FirstOrDefault();
        }
    }
}
