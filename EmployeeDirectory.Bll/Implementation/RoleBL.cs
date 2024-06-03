using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.DAL.Interface.roleDAL;
using EmployeeDirectory.Models.Presentation.Role;
using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.Models.ModelDAL;

namespace EmployeeDirectory.Bll
{
    public class RoleBL: IRoleBL
    {
       private readonly IRoleDAL _roleDAL;
       private readonly ILocationBL _locationBL;
        private readonly IDepartmentBL _departmentBL;
        public RoleBL(IRoleDAL roleDAL,ILocationBL locationBL,IDepartmentBL departmentBL)
        {
          _roleDAL = roleDAL;
          this._locationBL = locationBL;
          _departmentBL = departmentBL;
        } 
        public bool AddRole(RoleDto role)
        {
            Role roleModelDAL = new Role
            {
                Name = role.Name,
                Department=_departmentBL.GetDepartmentId(role.Department),
                Location=_locationBL.GetLocationId(role.Location),
                Description=role.Description
            };

            return _roleDAL.Add(roleModelDAL);
        }
        public List<RoleDto> GetAllRoles()
        {
            List<Role> roleDALList = _roleDAL.GetAll();
            List<RoleDto> rolePresentationList = roleDALList.Select(roleDAL =>
                new RoleDto
                { 
                  Name=roleDAL.Name,
                  Location=_locationBL.GetLocationById(roleDAL.Location),
                  Department=_departmentBL.GetDepartmentById(roleDAL.Department),
                  Description=roleDAL.Description 
                }).ToList();
            return rolePresentationList;
        }
       public List<string> GetLocation(string roleName)
        {

            List<string> locations = new List<string>();
            var allRoles = GetAllRoles();
            foreach (RoleDto role in allRoles)
            {
                if (!locations.Contains(role.Location) && role.Name.Equals(roleName))
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
        public List <string> GetDepartment(string roleName)
        {
            List<string> department = new List<string>();
            var allRoles = GetAllRoles();
            foreach (RoleDto role in allRoles)
            {
                if (!department.Contains(role.Department)&&role.Name.Equals(roleName))
                {
                    department.Add(role.Department);
                }
            }
            return department;
        }
        public string GetRoleById(int roleId)
        {
            return _roleDAL.GetRoleName(roleId);
        }
        public int GetIdByRole(string roleName)
        {
            return _roleDAL.GetRoleId(roleName);
        }
    }
}
