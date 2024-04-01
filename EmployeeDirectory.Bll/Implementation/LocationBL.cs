using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.DAL.Interface.location;
using EmployeeDirectory.Models.location;
namespace EmployeeDirectory.BLL.Implementation.Location
{
    public class LocationBL:ILocationBL
    {
        private IlocationDAL _locationDAL;
        public LocationBL(IlocationDAL _locationDAL)
        {
            this._locationDAL = _locationDAL;
        }
        public void AddLocation(Models.location.Location location)
        {

            _locationDAL.Add(location);
        }
        public List<Models.location.Location> GetAllLocation()
        {
            return _locationDAL.GetAll();
        }
    }
}
