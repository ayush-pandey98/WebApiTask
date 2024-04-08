using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.DAL.Interface.roleDAL;
using EmployeeDirectory.Models.Presentation.Role;
using EmployeeDirectory.Models.Roles;
using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.BLL.Interface.departmentBL;
namespace EmployeeDirectory.Bll
{
    public class RoleBL: IRoleBL
    {
       private IRoleDAL _roleDAL;
       private ILocationBL _locationBL;
        private IDepartmentBL _departmentBL;
        public RoleBL(IRoleDAL _roleDAL,ILocationBL _locationBL,IDepartmentBL _departmentBL)
        {
          this._roleDAL = _roleDAL;
          this._locationBL = _locationBL;
          this._departmentBL = _departmentBL;
        } 
        public void AddRole(RoleModelPresentation role)
        {
            RoleModelDAL roleModelDAL = new RoleModelDAL
            {
                Name = role.Name,
                Department=_departmentBL.GetDepartmentId(role.Department),
                Location=_locationBL.GetLocationId(role.Location),
                Description=role.Description
            };

            _roleDAL.Add(roleModelDAL);
        }
        public List<RoleModelPresentation> GetAllRoles()
        {
            List<RoleModelDAL> roleDALList = _roleDAL.GetAll();
            List<RoleModelPresentation> rolePresentationList = roleDALList.Select(roleDAL =>
                new RoleModelPresentation
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
            foreach (RoleModelPresentation role in allRoles) {
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
            foreach (RoleModelDAL role in allRoles)
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
            foreach (RoleModelPresentation role in allRoles)
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
