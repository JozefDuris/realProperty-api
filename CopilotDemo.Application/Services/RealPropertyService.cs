using CopilotDemo.Application.Interfaces;
using CopilotDemo.Domain.Models;
using Microsoft.Extensions.Logging;

namespace CopilotDemo.Application.Services
{
    public class RealPropertyService : IRealPropertyService
    {
        private readonly ILiteDbService _liteDbService;
        private readonly ILogger<RealPropertyService> _logger;

        public RealPropertyService(ILiteDbService liteDbService, ILogger<RealPropertyService> logger)
        {
            _liteDbService = liteDbService;
            _logger = logger;
        }

        public RealProperty? GetPropertyById(int id)
            => _liteDbService.GetRealPropertyById(id);

        public RealPropertyVersion? GetPropertyVersionById(int id, int versionNumber)
        {
            var property = GetPropertyById(id);
            return property?.Versions.FirstOrDefault(v => v.VersionNumber == versionNumber);
        }

        public void AddProperty(RealProperty property)
            => _liteDbService.CreateRealProperty(property);

        public bool UpdateProperty(int id, RealProperty property)
        {
            property.Id = id;
            _liteDbService.UpdateRealProperty(property);
            return true;
        }

        public bool DeleteProperty(int id)
        {
            _liteDbService.DeleteRealProperty(id);
            return true;
        }

        public IEnumerable<RealProperty> GetAllProperties()
            => _liteDbService.GetRealProperties();
    }
}
