using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.DAL.Interface.roleDAL;
using EmployeeDirectory.Model.ModelDAL;

namespace EmployeeDirectory.Bll
{
    public class RoleBL: IRoleBL
    {
       private readonly IRoleDAL _roleDAL;
       
        public RoleBL(IRoleDAL roleDAL)
        {
          _roleDAL = roleDAL;
        }

        public void AddRole(Role role)
        {
            _roleDAL.Add(role);
        }

        public int GetRoleId(string roleName)
        {
            return _roleDAL.GetRoleId(roleName);
        }
    }
}
