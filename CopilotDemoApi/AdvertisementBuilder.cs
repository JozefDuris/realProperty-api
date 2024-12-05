using CopilotDemoApi.Models;
using System.Text;

namespace CopilotDemoApi.Services
{
    public class AdvertisementBuilder
    {
        private readonly StringBuilder _result;

        public AdvertisementBuilder()
        {
            _result = new StringBuilder();
        }

        public AdvertisementBuilder AddHeader()
        {
            _result.AppendLine("Property Advertisement");
            return this;
        }

        public AdvertisementBuilder AddPropertySummary(RealPropertyVersionDetails versionDetails)
        {
            _result.AppendLine($"Awesome {Enum.GetName<RealPropertyType>(versionDetails.PropertyType)} with {versionDetails.Rooms} rooms covering {versionDetails.Area} m2");
            return this;
        }

        public AdvertisementBuilder AddPropertyLocationSummary(RealPropertyVersionDetails versionDetails)
        {
            _result.AppendLine($"Property can be found at {versionDetails.Address}");
            return this;
        }

        public AdvertisementBuilder AddParkingOptions(RealPropertyVersionDetails versionDetails)
        {
            _result.AppendLine("Parking options: Public underground parking within walking distance");
            return this;
        }

        public AdvertisementBuilder AddContactInfo()
        {
            _result.AppendLine("Contact us at 555-555-5555");
            return this;
        }

        public string Build()
        {
            return _result.ToString();
        }
    }
}
