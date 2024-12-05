using CopilotDemoApi.Models;

namespace CopilotDemoApi.Services
{
    public class AdvertisementDirector
    {
        private readonly AdvertisementBuilder _builder;

        public AdvertisementDirector(AdvertisementBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructAdvertisement(RealPropertyVersionDetails versionDetails)
        {
            _builder.AddHeader()
                    .AddPropertySummary(versionDetails)
                    .AddPropertyLocationSummary(versionDetails);

            if (versionDetails.PropertyType == RealPropertyType.Apartment)
            {
                _builder.AddParkingOptions(versionDetails);
            }

            _builder.AddContactInfo();
        }
    }
}
