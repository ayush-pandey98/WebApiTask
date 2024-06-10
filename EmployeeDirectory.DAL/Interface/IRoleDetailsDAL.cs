using EmployeeDirectory.Model.ModelDAL;

namespace EmployeeDirectory.DAL.Interface
{
    public interface IRoleDetailsDAL
    {
        public bool Add(RoleDetail roleDetail);
        public int  GetRoleDetailId(RoleDetail roleDetail);
        public RoleDetail GetRoleDetailById(int id);
        public List<RoleDetail> GetAllRoleDetails();
    }
}
