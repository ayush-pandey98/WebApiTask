using EmployeeDirectory.Models.Roles;
using EmployeeDirectory.Bll.Interface;
using EmployeeDirectory.DAL.Interface;
namespace EmployeeDirectory.Bll
{
    public class RoleBL:IRoleBL
    {
       private IRoleDAL roles;
        public RoleBL(IRoleDAL roles)
        {
          this.roles = roles;
        } 
        public void AddRole(Role role)
        {
            roles.Add(role);
        }
        public List<Role> GetAllRoles()
        {
            return roles.GetAll();
        }
        public List<string> GetLocation()
        {
            List<string> locations = new List<string>();
            var allRoles= roles.GetAll();
            foreach(Role role in allRoles) {
              locations.Add(role.Location);  
            }
            return locations;
        }
        public List<string> GetRoleName()
        {
            List<string> roleName = new List<string>();
            var allRoles = roles.GetAll();
            foreach (Role role in allRoles)
            {
                roleName.Add(role.Name);
            }
            return roleName;
        }
        public List <string> GetDepartment()
        {
            List<string> department = new List<string>();
            var allRoles = roles.GetAll();
            foreach (Role role in allRoles)
            {
                if (!department.Contains(role.Department))
                {
                    department.Add(role.Department);
                }
            }
            return department;
        }
    }
}
