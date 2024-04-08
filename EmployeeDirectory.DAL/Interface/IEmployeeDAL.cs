using EmployeeDirectory.Models;

namespace EmployeeDirectory.DAL.Interface.employeeDAL
{
    public interface IEmployeeDAL
    {
        public List<EmployeeModelDAL> GetAll();
        public void Add(EmployeeModelDAL employee);
        public EmployeeModelDAL GetById(string id);
        public bool Delete(string id);
        public void Set(List<EmployeeModelDAL> employees);
    }
}
