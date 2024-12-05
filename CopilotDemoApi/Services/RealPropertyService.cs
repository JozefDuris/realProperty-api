using CopilotDemoApi.Models;

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
    }
}
