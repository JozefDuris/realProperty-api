using CopilotDemoApi.Models;

namespace CopilotDemoApi.Services
{
    public interface IAdvertisementGenerationService
    {
        string GenerateAdvertisement(RealProperty data);
    }
}