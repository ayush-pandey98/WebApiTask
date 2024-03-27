
using EmployeeDirectory.Models;
using EmployeeDirectory.Models.Roles;

namespace EmployeeDirectory.DAL.Interface
{
   public interface IEmployeeDAL
    {
        public List<Employee> GetAll();
        public void Add(Employee employee);
        public Employee GetById(string id);
        public bool Delete(string id);
        public void Set(List<Employee> employees);
    }
   public  interface IRoleDAL
    {
        public List<Role> GetAll();
        public void Add(Role employee);
        public void Set(List<Role> roles);
    }
}
