using CopilotDemoApi.Models;
using LiteDB;

namespace CopilotDemoApi.Services
{
    public class LiteDbService : ILiteDbService
    {
        private readonly LiteDatabase _database;
        private readonly ILiteCollection<RealProperty> _realProperties;

        public LiteDbService()
        {
            _database = new LiteDatabase(":memory:");
            _realProperties = _database.GetCollection<RealProperty>();

            var realProperties = new List<RealProperty>
                {
                    new RealProperty { Id = 1, Area = 1000, Rooms = 3, PropertyType = RealPropertyType.House, Address = "123 Main St", Price = 200000 },
                    new RealProperty { Id = 2, Area = 800, Rooms = 2, PropertyType = RealPropertyType.Apartment, Address = "456 Elm St", Price = 300000 },
                    new RealProperty { Id = 3, Area = 1200, Rooms = 4, PropertyType = RealPropertyType.House, Address = "789 Oak St", Price = 250000 },
                    new RealProperty { Id = 4, Area = 1500, Rooms = 5, PropertyType = RealPropertyType.House, Address = "321 Pine St", Price = 400000 },
                    new RealProperty { Id = 5, Area = 900, Rooms = 2, PropertyType = RealPropertyType.Apartment, Address = "654 Maple St", Price = 350000 },
                    new RealProperty { Id = 6, Area = 1100, Rooms = 3, PropertyType = RealPropertyType.House, Address = "987 Birch St", Price = 275000 },
                    new RealProperty { Id = 7, Area = 950, Rooms = 2, PropertyType = RealPropertyType.Apartment, Address = "135 Cedar St", Price = 325000 },
                    new RealProperty { Id = 8, Area = 1300, Rooms = 4, PropertyType = RealPropertyType.House, Address = "864 Walnut St", Price = 375000 },
                    new RealProperty { Id = 9, Area = 750, Rooms = 1, PropertyType = RealPropertyType.Apartment, Address = "246 Spruce St", Price = 225000 },
                    new RealProperty { Id = 10, Area = 1000, Rooms = 3, PropertyType = RealPropertyType.House, Address = "579 Ash St", Price = 275000 }
                };

            _realProperties.InsertBulk(realProperties);

        }

        public ILiteCollection<RealProperty> GetRealProperties()
        {
            return _realProperties;
        }
    }
}
