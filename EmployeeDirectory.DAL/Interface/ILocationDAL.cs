using EmployeeDirectory.Model.ModelDAL;

namespace EmployeeDirectory.DAL.Interface.location
{
    public interface IlocationDAL
    {
        public List<Location> GetAll();
        public int GetLocationId(string locationName);
        public bool AddLocation (Location location);
        public string GetLocationById(int id);

    }
}
