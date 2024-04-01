
using EmployeeDirectory.Models.Roles;
namespace EmployeeDirectory.DAL.Interface.roleDAL
{
  
   public  interface IRoleDAL
    {
        public List<Role> GetAll();
        public void Add(Role employee);
        public void Set(List<Role> roles);
    }
}
