using CopilotDemoApi.Models;

namespace CopilotDemoApi.Services.Interfaces
{
    public interface IAdvertisementGenerationService
    {
        string GenerateAdvertisement(RealProperty data);
    }
}