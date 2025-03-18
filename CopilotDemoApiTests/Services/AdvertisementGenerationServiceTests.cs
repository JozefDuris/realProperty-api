using CopilotDemoApi.Models;
using CopilotDemoApi.Services;

namespace CopilotDemoApiTests.Services
{
    public class AdvertisementGenerationServiceTests
    {
        [Fact]
        public void GenerateAdvertisement_ShouldReturnCorrectAdvertisement()
        {
            // Arrange
            var data = new RealProperty
            {
                Id = 1,
                Versions = new List<RealPropertyVersion>
                {
                    new RealPropertyVersion
                    {
                        VersionNumber = 1,
                        PropertyType = RealPropertyType.Apartment,
                        Rooms = 3,
                        Area = 100,
                        Address = "123 Main St",
                        Price = 500000
                    }
                }
            };

            var advertisementGenerationService = new AdvertisementGenerationService();

            // Act
            var advertisement = advertisementGenerationService.GenerateAdvertisement(data);

            // Assert
            Assert.Contains("Property Advertisement", advertisement);
            Assert.Contains("Awesome Apartment with 3 rooms covering 100 m2", advertisement);
            Assert.Contains("Property can be found at 123 Main St", advertisement);
            Assert.Contains("Contact us at 555-555-5555", advertisement);
        }

        [Fact]
        public void GenerateAdvertisement_ShouldIncludeParkingOptionsForApartment()
        {
            // Arrange
            var data = new RealProperty
            {
                Id = 2,
                Versions = new List<RealPropertyVersion>
                {
                    new RealPropertyVersion
                    {
                        VersionNumber = 1,
                        PropertyType = RealPropertyType.Apartment,
                        Rooms = 2,
                        Area = 80,
                        Address = "456 Elm St",
                        Price = 300000
                    }
                }
            };

            var advertisementGenerationService = new AdvertisementGenerationService();

            // Act
            var advertisement = advertisementGenerationService.GenerateAdvertisement(data);

            // Assert
            Assert.Contains("Property Advertisement", advertisement);
            Assert.Contains("Awesome Apartment with 2 rooms covering 80 m2", advertisement);
            Assert.Contains("Property can be found at 456 Elm St", advertisement);
            Assert.Contains("Contact us at 555-555-5555", advertisement);
            Assert.Contains("Public underground parking within walking distance", advertisement);
        }
    }
}
