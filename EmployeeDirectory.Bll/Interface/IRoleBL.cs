using EmployeeDirectory.Model.ModelDAL;
using EmployeeDirectory.Models.Presentation.Role;

namespace EmployeeDirectory.Bll.Interface.roleBL
{
    public interface IRoleBL
    {
     public int GetRoleId(string roleName);
     public void AddRole(Role role);
     

    }
}
