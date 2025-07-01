using CopilotDemoApi.Models;
using LiteDB;

namespace CopilotDemoApi.InfrastructureAdapters.Interfaces
{
    public interface ILiteDbService
    {
        ILiteCollection<RealProperty> GetRealProperties();
        ILiteCollection<User> GetUsers();
        ILiteCollection<ActivityLog> GetActivityLogs();
    }
}