
using EmployeeDirectory.Models.location;

namespace EmployeeDirectory.DAL.Interface.location
{
    public interface IlocationDAL
    {
        public List<Location> GetAll();
        public void Add(Location location);
        public void Set(List<Location> locations);
    }
}
