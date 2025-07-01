using CopilotDemoApi.InfrastructureAdapters.Interfaces;
using CopilotDemoApi.Models;
using LiteDB;

namespace CopilotDemoApi.InfrastructureAdapters
{
    public class LiteDbService : ILiteDbService
    {
        private readonly LiteDatabase _database;
        private readonly ILiteCollection<RealProperty> _realProperties;
        private readonly ILiteCollection<User> _users;
        private readonly ILiteCollection<ActivityLog> _activityLogs;

        public LiteDbService()
        {
            _database = new LiteDatabase(":memory:");
            _realProperties = _database.GetCollection<RealProperty>();
            _users = _database.GetCollection<User>();
            _activityLogs = _database.GetCollection<ActivityLog>();

            var realProperties = new List<RealProperty>
            {
                new()
                {
                    Id = 1,
                    Versions =
                    [
                        new()
                        {
                            VersionNumber = 1,
                            Area = 1000,
                            Rooms = 3,
                            PropertyType = RealPropertyType.House,
                            Price = 200000,
                            Address = "123 Main St"
                        },
                        new()
                        {
                            VersionNumber = 2,
                            Area = 1000,
                            Rooms = 3,
                            PropertyType = RealPropertyType.House,
                            Price = 210000,
                            Address = "123 Main St"
                        },
                    ]
                },
                new()
                {
                    Id = 2,
                    Versions =
                    [
                        new()
                        {
                            VersionNumber = 1,
                            Area = 800,
                            Rooms = 2,
                            PropertyType = RealPropertyType.Apartment,
                            Price = 300000,
                            Address = "456 Elm St"
                        },
                    ]
                },
                new()
                {
                    Id = 3,
                    Versions =
                    [
                        new()
                        {
                            VersionNumber = 1,
                            Area = 1200,
                            Rooms = 4,
                            PropertyType = RealPropertyType.House,
                            Price = 250000,
                            Address = "789 Oak St"
                        },
                    ]
                },
                new()
                {
                    Id = 4,
                    Versions =
                    [
                        new()
                        {
                            VersionNumber = 1,
                            Area = 1500,
                            Rooms = 5,
                            PropertyType = RealPropertyType.House,
                            Price = 400000,
                            Address = "321 Pine St"
                        },
                    ]
                },
                new()
                {
                    Id = 5,
                    Versions =
                    [
                        new()
                        {
                            VersionNumber = 1,
                            Area = 900,
                            Rooms = 2,
                            PropertyType = RealPropertyType.Apartment,
                            Price = 350000,
                            Address = "654 Maple St"
                        },
                    ]
                },
                new()
                {
                    Id = 6,
                    Versions =
                    [
                        new()
                        {
                            VersionNumber = 1,
                            Area = 1100,
                            Rooms = 3,
                            PropertyType = RealPropertyType.House,
                            Price = 275000,
                            Address = "987 Birch St"
                        },
                    ]
                },
            };

            _realProperties.InsertBulk(realProperties);

            // Seed users
            var users = new List<User>
            {
                new User { Id = 1, Username = "admin", Password = "pass", Role = "Admin" },
                new User { Id = 2, Username = "user", Password = "pass", Role = "User" }
            };
            _users.InsertBulk(users);
        }

        public ILiteCollection<RealProperty> GetRealProperties()
        {
            return _realProperties;
        }

        public ILiteCollection<User> GetUsers()
        {
            return _users;
        }

        public ILiteCollection<ActivityLog> GetActivityLogs()
        {
            return _activityLogs;
        }
    }
}
