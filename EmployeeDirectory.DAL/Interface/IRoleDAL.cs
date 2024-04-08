
using EmployeeDirectory.Models.Roles;
namespace EmployeeDirectory.DAL.Interface.roleDAL
{
  
   public  interface IRoleDAL
    {
        public List<RoleModelDAL> GetAll();
        public void Add(RoleModelDAL employee);
        public void Set(List<RoleModelDAL> roles);
    }
}
