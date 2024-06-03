using EmployeeDirectory.Models.ModelDAL;

namespace EmployeeDirectory.DAL.Interface.location
{
    public interface IlocationDAL
    {
        public List<Location> GetAll();
        public bool Add(Location location);
        public int GetIdByName(string name);
        public string GetNameById(int id);

    }
}
