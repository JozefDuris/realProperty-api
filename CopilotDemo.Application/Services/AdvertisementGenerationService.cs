using CopilotDemo.Application.Interfaces;
using CopilotDemo.Domain.Models;
using System.Text;

namespace CopilotDemo.Application.Services
{
    public class AdvertisementGenerationService : IAdvertisementGenerationService
    {
        public string GenerateAdvertisement(RealProperty data)
        {
            var result = new StringBuilder();

            var latestVersion = data.GetLatestVersion()!;

            result.AppendLine(GenerateHeader());
            result.AppendLine(GetPropertySummary(latestVersion));
            result.AppendLine(GetPropertyLocationSummary(latestVersion));
            if (latestVersion.PropertyType == RealPropertyType.Apartment)
            {
                result.AppendLine(GetParkingOptions(latestVersion));
            }
            result.AppendLine(GenerateContactInfo());

            return result.ToString();
        }

        private static string GetParkingOptions(RealPropertyVersion version)
        {
            return "Public underground parking within walking distance";
        }

        private static string GenerateContactInfo()
        {
            return "Contact us at 555-555-5555";
        }

        private static string GenerateHeader()
        {
            return "Property Advertisement";
        }

        private static string GetPropertySummary(RealPropertyVersion version)
        {
            return $"Awesome {Enum.GetName(version.PropertyType)} with {version.Rooms} rooms covering {version.Area} m2";
        }

        private static string GetPropertyLocationSummary(RealPropertyVersion version)
        {
            return $"Property can be found at {version.Address}";
        }
    }
}
