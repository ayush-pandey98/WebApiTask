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
         void EditEmployee();
    }
    public interface IRoleBL
    {
        public void AddRole(Role role);
        public List<Role> GetAllRoles();
        public List<string> GetLocation();
        public List<string> GetRoleName();
        public List<string> GetDepartment();
    }
}
