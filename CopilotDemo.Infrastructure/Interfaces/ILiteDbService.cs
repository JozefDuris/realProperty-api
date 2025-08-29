using CopilotDemo.Domain.Models;
using LiteDB;

namespace CopilotDemo.Infrastructure.Interfaces
{
    public interface ILiteDbService
    {
        ILiteCollection<RealProperty> GetRealProperties();
        ILiteCollection<User> GetUsers();
        ILiteCollection<ActivityLog> GetActivityLogs();
    }
}
