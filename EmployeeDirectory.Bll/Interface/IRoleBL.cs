using EmployeeDirectory.Models;
using EmployeeDirectory.Models.Roles;
namespace EmployeeDirectory.Bll.Interface.roleBL
{
  
    public interface IRoleBL
    {
        public void AddRole(Role role);
        public List<Role> GetAllRoles();
        public List<string> GetLocation();
        public List<string> GetRoleName(string location);
        public List<string> GetDepartment(string location);
    }
}
