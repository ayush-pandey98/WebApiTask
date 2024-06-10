using EmployeeDirectory.DAL.Interface;
using EmployeeDirectory.Model.ModelDAL;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.DAL.Implementation
{
    public class RoleDetailDAL : IRoleDetailsDAL
    {
        private readonly EmployeeDirectoryDbContext _context;
        public RoleDetailDAL(EmployeeDirectoryDbContext context)
        {
            _context = context;
        }
        public bool Add(RoleDetail roleDetail)
        {

            _context.Add(roleDetail);
            return Save();
        }

        public RoleDetail GetRoleDetailById(int id)
        {
            var roleDetail = _context.RoleDetails
                             .Include(r => r.Role)
                             .Include(r => r.Department)
                             .Include(r => r.Location)
                             .Where(r=>r.Id == id).FirstOrDefault();

            return roleDetail;
        }
        public List<RoleDetail> GetAllRoleDetails()
        {
            var roleDetails = _context.RoleDetails
                              .Include(r=>r.Role)
                              .Include(r=>r.Department)
                              .Include(r=>r.Location)
                              .ToList();

            return roleDetails;
        }
        public int GetRoleDetailId(RoleDetail roleDetail)
        {
            int id = -1;
            var detail = _context.RoleDetails.Where(rd => rd.LocationId == roleDetail.LocationId && rd.DepartmentId == roleDetail.DepartmentId && rd.RoleId == roleDetail.RoleId).FirstOrDefault();
            if(detail != null)
            {
                id = detail.Id;
            }
            return  id;
        }

        private bool Save()
        {
            var saved  = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
