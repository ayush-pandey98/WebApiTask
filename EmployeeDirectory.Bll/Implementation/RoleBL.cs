using EmployeeDirectory.Models.Roles;
using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.DAL.Interface.roleDAL;
namespace EmployeeDirectory.Bll
{
    public class RoleBL: IRoleBL
    {
       private IRoleDAL _roleDAL;
        public RoleBL(IRoleDAL _roleDAL)
        {
          this._roleDAL = _roleDAL;
        } 
        public void AddRole(Role role)
        {
            _roleDAL.Add(role);
        }
        public List<Role> GetAllRoles()
        {
            return _roleDAL.GetAll();
        }
       public List<int> GetLocation(string roleName)
        {
            List<int> locations = new List<int>();
            var allRoles= _roleDAL.GetAll();
            foreach(Role role in allRoles) {
                if (!locations.Contains(role.Location)&& role.Name.Equals(roleName))
                {
                    locations.Add(role.Location);
                }
            }
            return locations;
        }
        public List<string> GetRoleName()
        {
            List<string> roleName = new List<string>();
            var allRoles = _roleDAL.GetAll();
            foreach (Role role in allRoles)
            {
                if (!roleName.Contains(role.Name))
                {
                    roleName.Add(role.Name);
                }
            }
            return roleName;
        }
        public List <int> GetDepartment(string roleName)
        {
            List<int> department = new List<int>();
            var allRoles = _roleDAL.GetAll();
            foreach (Role role in allRoles)
            {
                if (!department.Contains(role.Department)&&role.Name.Equals(roleName))
                {
                    department.Add(role.Department);
                }
            }
            return department;
        }
    }
}
