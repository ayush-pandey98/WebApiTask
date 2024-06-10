using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.DAL.Interface.location;
using EmployeeDirectory.Model.ModelDAL;
using EmployeeDirectory.Models.ModelPresentation;

namespace EmployeeDirectory.BLL.Implementation.LocationBL
{
    public class LocationBL : ILocationBL
    {
        private readonly IlocationDAL _locationDAL;
        public LocationBL(IlocationDAL locationDAL)
        {
            _locationDAL = locationDAL;
        }
        public bool AddLocation(LocationDto location)
        {
            Location locationDAL = new Location()
            {
                LocationName = location.Value,
            };
            return _locationDAL.AddLocation(locationDAL);
        }
        public List<Location> GetAllLocation()
        {
            return _locationDAL.GetAll();
        }

        public string GetLocationById(int id)
        {
            return _locationDAL.GetLocationById(id);
        }
    }
}
