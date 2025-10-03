using CopilotDemo.Application.Interfaces;
using CopilotDemo.Domain.Models;
using System.Text;

namespace CopilotDemo.Application.Services
{
    public class AdvertisementGenerationService : IAdvertisementGenerationService
    {
        public string GenerateAdvertisement(RealProperty data)
        {
            var latestVersion = data.GetLatestVersion()!;
            return BuildAdvertisement(latestVersion);
        }

        public string GenerateAdvertisement(RealProperty property, int? versionNumber)
        {
            if (!versionNumber.HasValue)
            {
                return GenerateAdvertisement(property);
            }

            var match = property.Versions.FirstOrDefault(v => v.VersionNumber == versionNumber.Value);

            return match != null
                ? BuildAdvertisement(match)
                : throw new KeyNotFoundException($"Version {versionNumber.Value} not found for property {property.Id}.");
        }

        private static string BuildAdvertisement(RealPropertyVersion version)
        {
            var result = new StringBuilder();
            result.AppendLine(GenerateHeader());
            result.AppendLine(GetPropertySummary(version));
            result.AppendLine(GetPropertyLocationSummary(version));
            if (version.PropertyType == RealPropertyType.Apartment)
            {
                result.AppendLine(GetParkingOptions(version));
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
            // Price formatting per requirements: use en-US culture; if price not provided or <= 0, show fallback text
            var culture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            string pricePart = version.Price > 0
                ? $" for {version.Price.ToString("C", culture)}"
                : " (Price on request)";

            return $"Awesome {Enum.GetName(version.PropertyType)} with {version.Rooms} rooms covering {version.Area} m2{pricePart}";
        }

        private static string GetPropertyLocationSummary(RealPropertyVersion version)
        {
            return $"Property can be found at {version.Address}";
        }
    }
}
