using CopilotDemoApi.Models;
using CopilotDemoApi.Services;
using LiteDB;
using Microsoft.Extensions.Logging;
using Moq;

namespace CopilotDemoApiTests
{
    public class PropertyServiceTests
    {
        private RealPropertyService _sut;
        private Mock<ILogger<RealPropertyService>> _loggerMock;
        private Mock<ILiteDbService> _liteDbServiceMock;

        public PropertyServiceTests()
        {
            _loggerMock = new Mock<ILogger<RealPropertyService>>();
            _liteDbServiceMock = new Mock<ILiteDbService>();
            _sut = new RealPropertyService(_liteDbServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetPropertyById_When_PropertyExists_Then_ReturnsProperty()
        {
            // Arrange
            int id = 1;
            RealProperty expectedProperty = new RealProperty { Id = id };

            var liteCollectionMock = new Mock<ILiteCollection<RealProperty>>();
            liteCollectionMock.Setup(x => x.FindById(id)).Returns(expectedProperty);
            _liteDbServiceMock.Setup(x => x.GetRealProperties()).Returns(liteCollectionMock.Object);

            // Act
            RealProperty actualProperty = _sut.GetPropertyById(id);

            // Assert
            Assert.Equal(expectedProperty.Id, actualProperty.Id);
        }

        [Fact]
        public void GetPropertyById_When_PropertyNotFound_Then_ReturnsNull()
        {
            // Arrange
            int id = 1;

            var liteCollectionMock = new Mock<ILiteCollection<RealProperty>>();
            liteCollectionMock.Setup(x => x.FindById(id)).Returns(default(RealProperty));
            _liteDbServiceMock.Setup(x => x.GetRealProperties()).Returns(liteCollectionMock.Object);

            // Act
            RealProperty actualProperty = _sut.GetPropertyById(id);

            // Assert
            Assert.Null(actualProperty);
        }
    }
}