using CopilotDemoApi.Models;

namespace CopilotDemoApi.Services.Interfaces
{
    public interface IRealPropertyService
    {
        RealProperty? GetPropertyById(int id);
        RealPropertyVersion? GetPropertyVersionById(int id, int versionNumber);
        void AddProperty(RealProperty property);
        bool UpdateProperty(int id, RealProperty property);
        bool DeleteProperty(int id);
    }
}