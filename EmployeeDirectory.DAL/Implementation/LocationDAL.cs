using EmployeeDirectory.DAL.Interface.location;
using EmployeeDirectory.Model.ModelDAL;

namespace EmployeeDirectory.DAL.Implementation.location
{
    public class LocationDAL : IlocationDAL
    {
        EmployeeDirectoryDbContext _context;
        public LocationDAL(EmployeeDirectoryDbContext context)
        {
            _context = context;
        }

        public bool AddLocation(Location location)
        {
            _context.Locations.Add(location);
            return Save();
        }

        public List<Location> GetAll()
        {
            var locations  = _context.Locations.ToList();
            return locations;
        }

        public string GetLocationById(int id)
        {
            string locationName = "";
            var location = _context.Locations.Where(loc=>loc.Id == id).FirstOrDefault();    
            if(location != null)
            {
                locationName = location.LocationName;
            }
            return locationName;
        }

        public int GetLocationId(string locationName)
        {
            int id = -1;
            var location = _context.Locations.Where(loc => loc.LocationName == locationName).FirstOrDefault();
            if(location != null)
            {
                id = location.Id;
            }
            return id;
        }

        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false; 
        }
    }
}
