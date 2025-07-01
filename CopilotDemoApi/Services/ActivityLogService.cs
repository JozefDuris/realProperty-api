using CopilotDemoApi.InfrastructureAdapters.Interfaces;
using CopilotDemoApi.Models;
using CopilotDemoApi.Services.Interfaces;

namespace CopilotDemoApi.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly ILiteDbService _liteDbService;

        public ActivityLogService(ILiteDbService liteDbService)
        {
            _liteDbService = liteDbService;
        }

        public void Log(string username, string action, string? details = null)
        {
            var log = new ActivityLog
            {
                Username = username,
                Action = action,
                Timestamp = DateTime.UtcNow,
                Details = details
            };
            _liteDbService.GetActivityLogs().Insert(log);
        }

        public IEnumerable<ActivityLog> GetLogs()
        {
            return _liteDbService.GetActivityLogs().FindAll();
        }
    }
}
