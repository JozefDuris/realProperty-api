using CopilotDemoApi.Models;

namespace CopilotDemoApi.Services.Interfaces
{
    public interface IRealPropertyService
    {
        RealProperty? GetPropertyById(int id);
        RealPropertyVersion? GetPropertyVersionById(int id, int versionNumber);
    }
}