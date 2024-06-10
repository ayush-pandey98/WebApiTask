using EmployeeDirectory.Model.ModelDAL;
using EmployeeDirectory.Models.ModelPresentation;

namespace EmployeeDirectory.BLL.Interface.location
{
    public interface ILocationBL
    {
        public bool AddLocation(LocationDto location);
        public List<Location> GetAllLocation();
        public string GetLocationById(int id);

        
    }
}
