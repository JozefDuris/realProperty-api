using CopilotDemoApi.Models;

namespace CopilotDemoApi.Services
{
    public interface IRealPropertyService
    {
        RealProperty? GetPropertyById(int id);
    }
}