using CopilotDemoApi.InfrastructureAdapters.Interfaces;
using CopilotDemoApi.Models;
using CopilotDemoApi.Services;
using LiteDB;
using Microsoft.Extensions.Logging;
using Moq;

namespace CopilotDemoApiTests.Services
{
    public class RealPropertyServiceTests
    {
        private readonly RealPropertyService _sut;
        private readonly Mock<ILogger<RealPropertyService>> _loggerMock;
        private readonly Mock<ILiteDbService> _liteDbServiceMock;

        public RealPropertyServiceTests()
        {
            _loggerMock = new Mock<ILogger<RealPropertyService>>();
            _liteDbServiceMock = new Mock<ILiteDbService>();
            _sut = new(_liteDbServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetPropertyById_When_PropertyExists_Then_ReturnsProperty()
        {
            // Arrange
            int id = 1;
            var expectedProperty = new RealProperty { Id = id };

            var liteCollectionMock = new Mock<ILiteCollection<RealProperty>>();
            liteCollectionMock.Setup(x => x.FindById(id)).Returns(expectedProperty);
            _liteDbServiceMock.Setup(x => x.GetRealProperties()).Returns(liteCollectionMock.Object);

            // Act
            var actualProperty = _sut.GetPropertyById(id);

            // Assert
            Assert.NotNull(actualProperty);
            Assert.Equal(expectedProperty.Id, actualProperty.Id);
        }

        [Fact]
        public void GetPropertyById_When_PropertyNotFound_Then_ReturnsNull()
        {
            // Arrange
            int id = 1;

            var liteCollectionMock = new Mock<ILiteCollection<RealProperty>>();
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            liteCollectionMock.Setup(x => x.FindById(id)).Returns((RealProperty?)null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            _liteDbServiceMock.Setup(x => x.GetRealProperties()).Returns(liteCollectionMock.Object);

            // Act
            var actualProperty = _sut.GetPropertyById(id);

            // Assert
            Assert.Null(actualProperty);
        }
    }
}