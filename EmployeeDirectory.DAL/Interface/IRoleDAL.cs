using EmployeeDirectory.Models.ModelDAL;

namespace EmployeeDirectory.DAL.Interface.roleDAL
{
  
   public  interface IRoleDAL
    {
        public List<Role> GetAll();
        public bool Add(Role employee);
        public string GetRoleName(int id);
        public int GetRoleId(string roleName);
    }
}
