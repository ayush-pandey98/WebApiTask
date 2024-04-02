using EmployeeDirectory.Models.location;

namespace EmployeeDirectory.BLL.Interface.location
{
    public interface ILocationBL
    {
        public void AddLocation(Location location);
        public List<Location> GetAllLocation();
        string GetLocationById(int id);
    }
}
