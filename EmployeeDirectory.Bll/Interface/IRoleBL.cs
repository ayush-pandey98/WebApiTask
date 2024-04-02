using EmployeeDirectory.Models;
using EmployeeDirectory.Models.Roles;
namespace EmployeeDirectory.Bll.Interface.roleBL
{
  
    public interface IRoleBL
    {
        public void AddRole(Role role);
        public List<Role> GetAllRoles();
       public List<int> GetLocation(string roleName);
        public List<string> GetRoleName();
       public List<int> GetDepartment(string roleName);
    }
}
