using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.BLL.Interface;
using EmployeeDirectory.DAL.Interface;
using EmployeeDirectory.Model.ModelDAL;
using EmployeeDirectory.Models.Presentation.Role;

namespace EmployeeDirectory.BLL.Implementation
{
    public class RoleDetailBL : IRoleDetailBL
    {
        private readonly IRoleDetailsDAL _roleDetailDAL;
        private readonly IRoleBL _roleBL ;
        public RoleDetailBL(IRoleDetailsDAL roleDetailsDAL , IRoleBL roleBL)
        {
           _roleDetailDAL = roleDetailsDAL;
           _roleBL = roleBL;
        }
        public bool AddRoleDetail(RoleDto roleDto)
        {
            int roleId = getRoleId(roleDto.Name);
            RoleDetail roleDetail = new RoleDetail
            {
               LocationId = roleDto.LocationId,
               DepartmentId = roleDto.DepartmentId,
               RoleId = roleId,   
            };
           return _roleDetailDAL.Add(roleDetail);
        }

        public int GetRoleDetailsId(int departmentId, int locationId,int roleId)
        {
            RoleDetail roleDetail = new RoleDetail
            {
                DepartmentId = departmentId,
                LocationId = locationId,
                RoleId = roleId,
            };
            return _roleDetailDAL.GetRoleDetailId(roleDetail);

        }
        public RoleDto GetRoleDetailById(int id)
        {

            var roleDetails =  _roleDetailDAL.GetRoleDetailById(id);
            RoleDto roleDto = new RoleDto
            {
                Name = roleDetails.Role.RoleName,
                Id = roleDetails.RoleId,
                DepartmentId = roleDetails.DepartmentId,
                DepartmentName = roleDetails.Department.DepartmentName,
                LocationId = roleDetails.LocationId,
                LocationName = roleDetails.Location.LocationName

            };
            return roleDto;

        }
        public List<RoleDto> GetAllRoleDetails()
        {
            var roleDetails  = _roleDetailDAL.GetAllRoleDetails();
            List<RoleDto> roles  =  roleDetails.Select(rolD=>
            {
                int roleId = getRoleId(rolD.Role.RoleName);
                return new RoleDto
                {
                    Name = rolD.Role.RoleName,
                    Id = roleId,
                    DepartmentId = rolD.DepartmentId,
                    DepartmentName = rolD.Department.DepartmentName,
                    LocationId = rolD.LocationId,
                    LocationName = rolD.Location.LocationName,
                };

              }).ToList();
            return roles;
        }
        private int getRoleId(string roleName)
        {
            int roleId = _roleBL.GetRoleId(roleName);
            if (roleId == -1)
            {
                _roleBL.AddRole(new Role { RoleName = roleName });
                roleId = _roleBL.GetRoleId(roleName);
            }
            return roleId;
        }

       
    }
}
