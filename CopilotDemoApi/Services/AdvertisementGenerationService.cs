using CopilotDemoApi.Models;
using System.Text;

namespace CopilotDemoApi.Services
{
    public class AdvertisementGenerationService : IAdvertisementGenerationService
    {
        public string GenerateAdvertisement(RealProperty data)
        {
            var result = new StringBuilder();

            result.AppendLine(GenerateHeader());
            result.AppendLine(GetPropertySummary(data));
            result.AppendLine(GetPropertyLocationSummary(data));
            if (data.PropertyType == RealPropertyType.Apartment)
            {
                result.AppendLine(GetParkingOptions(data));
            }
            result.AppendLine(GenerateContactInfo());

            return result.ToString();
        }

        private string GetParkingOptions(RealProperty data)
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

        private string GetPropertySummary(RealProperty data)
        {
            return $"Awesome {Enum.GetName<RealPropertyType>(data.PropertyType)} with {data.Rooms} rooms covering {data.Area} m2";
        }

        private string GetPropertyLocationSummary(RealProperty data)
        {
            return $"Property can be found at {data.Address}";
        }
    }
}
