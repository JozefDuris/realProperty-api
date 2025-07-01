using CopilotDemoApi.InfrastructureAdapters.Interfaces;
using CopilotDemoApi.Models;
using CopilotDemoApi.Services.Interfaces;

namespace CopilotDemoApi.Services
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
        {
            try
            {
                return _liteDbService.GetRealProperties().FindById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving property by ID.");
                return null;
            }
        }

        public RealPropertyVersion? GetPropertyVersionById(int id, int versionNumber)
        {
            var property = GetPropertyById(id);
            return property?.Versions.FirstOrDefault(v => v.VersionNumber == versionNumber);
        }

        public void AddProperty(RealProperty property)
        {
            _liteDbService.GetRealProperties().Insert(property);
        }

        public bool UpdateProperty(int id, RealProperty property)
        {
            var collection = _liteDbService.GetRealProperties();
            property.Id = id;
            return collection.Update(property);
        }

        public bool DeleteProperty(int id)
        {
            var collection = _liteDbService.GetRealProperties();
            return collection.Delete(id);
        }
    }
}
