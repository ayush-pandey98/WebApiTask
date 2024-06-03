using EmployeeDirectory.DAL.Interface.location;
using EmployeeDirectory.Models.ModelDAL;

namespace EmployeeDirectory.DAL.Implementation.location
{
    public class LocationDAL:IlocationDAL
    {
        EmployeeEfContext _context;
        public LocationDAL(EmployeeEfContext context)
        {
            _context = context;
        }
        public List<Location> GetAll()
        {
                return _context.Locations.ToList();   
        }
        public bool Add(Location location)
        {
            _context.Locations.Add(location);
            return Save();

        }
        public string GetNameById(int id)
        {
            var location = _context.Locations.Where(loc => loc.Id == id).FirstOrDefault();
            if (location == null) return "";
            return location.Value;
        }
        public int GetIdByName(string name)
        {
            var location = _context.Locations.FirstOrDefault(l => l.Value == name);
            return location != null ? location.Id : -1;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false; 
        }
    }
}
