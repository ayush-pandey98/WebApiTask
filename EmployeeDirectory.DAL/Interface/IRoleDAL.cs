using EmployeeDirectory.Model.ModelDAL;

namespace EmployeeDirectory.DAL.Interface.roleDAL
{
  
   public  interface IRoleDAL
    {
        public bool Add(Role role);
        public int GetRoleId(string roleName);
    }
}
