using EmployeeDirectory.Models.ModelDAL;
using EmployeeDirectory.Models.ModelPresentation;

namespace EmployeeDirectory.BLL.Interface.location
{
    public interface ILocationBL
    {
        public bool AddLocation(LocationDto location);
        public List<Location> GetAllLocation();
        string GetLocationById(int id);
        public int GetLocationId(string location);
    }
}
