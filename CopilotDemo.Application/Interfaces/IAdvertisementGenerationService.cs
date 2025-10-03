using CopilotDemo.Domain.Models;

namespace CopilotDemo.Application.Interfaces
{
    public interface IAdvertisementGenerationService
    {
        string GenerateAdvertisement(RealProperty property);

        string GenerateAdvertisement(RealProperty property, int? versionNumber);
    }
}
