using CopilotDemoApi.Models;

namespace CopilotDemoApi.Services.Interfaces
{
    public interface IActivityLogService
    {
        void Log(string username, string action, string? details = null);
        IEnumerable<ActivityLog> GetLogs();
    }
}
