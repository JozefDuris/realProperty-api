using CopilotDemo.Domain.Models;

namespace CopilotDemo.Application.Interfaces
{
    public interface IActivityLogService
    {
        void Log(string username, string action, string? details = null);
        IEnumerable<ActivityLog> GetLogs();
    }
}
