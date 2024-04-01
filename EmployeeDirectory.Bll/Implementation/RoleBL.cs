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
        public List<string> GetLocation()
        {
            List<string> locations = new List<string>();
            var allRoles= _roleDAL.GetAll();
            foreach(Role role in allRoles) {
                if (!locations.Contains(role.Location))
                {
                    locations.Add(role.Location);
                }
            }
            return locations;
        }
        public List<string> GetRoleName(string location)
        {
            List<string> roleName = new List<string>();
            var allRoles = _roleDAL.GetAll();
            foreach (Role role in allRoles)
            {
                if (!roleName.Contains(role.Name) && role.Location.Equals(location))
                {
                    roleName.Add(role.Name);
                }
            }
            return roleName;
        }
        public List <string> GetDepartment(string location)
        {
            List<string> department = new List<string>();
            var allRoles = _roleDAL.GetAll();
            foreach (Role role in allRoles)
            {
                if (!department.Contains(role.Department)&&role.Location.Equals(location))
                {
                    department.Add(role.Department);
                }
            }
            return department;
        }
    }
}
