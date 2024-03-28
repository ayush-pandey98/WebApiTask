using EmployeeDirectory.Models;
using EmployeeDirectory.Models.Roles;
namespace EmployeeDirectory.Bll.Interface
{
   public interface IEmployeeBL
    {
         List<Employee> GetAllEmployees();
         void AddEmployee(Employee employee);
         Employee GetEmployee(string id);
         void DeleteEmployee(string id);
         void EditEmployee(Employee employee, string id);
    }
    public interface IRoleBL
    {
        public void AddRole(Role role);
        public List<Role> GetAllRoles();
        public List<string> GetLocation();
        public List<string> GetRoleName(string location);
        public List<string> GetDepartment(string location);
    }
}
