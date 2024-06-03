using EmployeeDirectory.Models.Presentation.Role;

namespace EmployeeDirectory.Bll.Interface.roleBL
{
    public interface IRoleBL
    {
        public bool AddRole(RoleDto role);
        public List<RoleDto> GetAllRoles();
        public List<string> GetLocation(string roleName);
        public List<string> GetRoleName();
        public List<string> GetDepartment(string roleName);
        public string GetRoleById(int roleId);
        public int GetIdByRole(string roleName);
    }
}
