
using EmployeeDirectory.DAL.Interface.location;
using EmployeeDirectory.Models.location;
using Newtonsoft.Json;

namespace EmployeeDirectory.DAL.Implementation.location
{
    public class LocationDAL:IlocationDAL
    {
        public List<Location> GetAll()
        {
            string locationData = File.ReadAllText(@"C:\Users\ayush.p\source\repos\EmployeeDirectory.Start\location.json");
            List<Location> locations = JsonConvert.DeserializeObject<List<Location>>(locationData)!;
            return locations;
        }
        public void Add(Location location)
        {
            var locations = GetAll();
            if(locations == null) {
                locations= new List<Location>();
            }
            locations.Add(location);
            Set(locations);

        }
        public void Set(List<Location> locations)
        {
            string json = JsonConvert.SerializeObject(locations);
            File.WriteAllText(@"C:\Users\ayush.p\source\repos\EmployeeDirectory.Start\location.json", json);
        }
    }
}
