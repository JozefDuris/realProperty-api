using CopilotDemo.Domain.Models;

namespace CopilotDemo.Application.Interfaces;

public interface ILiteDbService
{
    IEnumerable<RealProperty> GetRealProperties();

    RealProperty? GetRealPropertyById(int id);

    int CreateRealProperty(RealProperty realProperty);

    void UpdateRealProperty(RealProperty realProperty);

    void DeleteRealProperty(int id);

    IEnumerable<User> GetUsers();

    User? GetUser(string username, string password);

    IEnumerable<ActivityLog> GetActivityLogs();

    int CreateActivityLog(ActivityLog activityLog);
}