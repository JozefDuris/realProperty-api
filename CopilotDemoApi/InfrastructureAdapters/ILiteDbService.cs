using CopilotDemoApi.Models;
using LiteDB;

namespace CopilotDemoApi.Services
{
    public interface ILiteDbService
    {
        ILiteCollection<RealProperty> GetRealProperties();
    }
}