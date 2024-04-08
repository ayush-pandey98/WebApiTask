using EmployeeDirectory.Models;
using EmployeeDirectory.Models.Presentation.Role;
using EmployeeDirectory.Models.Roles;
namespace EmployeeDirectory.Bll.Interface.roleBL
{
  
    public interface IRoleBL
    {
        public void AddRole(RoleModelPresentation role);
        public List<RoleModelPresentation> GetAllRoles();
       public List<string> GetLocation(string roleName);
        public List<string> GetRoleName();
       public List<string> GetDepartment(string roleName);
    }
}
