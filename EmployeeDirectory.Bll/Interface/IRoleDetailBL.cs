

using EmployeeDirectory.Model.ModelDAL;
using EmployeeDirectory.Models.Presentation.Role;

namespace EmployeeDirectory.BLL.Interface
{
    public  interface IRoleDetailBL
    {
        public bool AddRoleDetail(RoleDto roleDto);
        public int  GetRoleDetailsId(int department,int location,int roleName);
        public RoleDto GetRoleDetailById(int id);
        public List<RoleDto> GetAllRoleDetails();

    }
}
