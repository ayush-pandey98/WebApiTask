using EmployeeDirectory.DAL.Interface.roleDAL;
using EmployeeDirectory.Model.ModelDAL;

namespace EmployeeDirectory.DAL.Roles
{
    public class RoleDAL:IRoleDAL
    {
        private readonly EmployeeDirectoryDbContext _context;
        public RoleDAL(EmployeeDirectoryDbContext context)
        {
            _context = context; 
        }
        public bool Add(Role role)
        {
            _context.Roles.Add(role);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public int GetRoleId(string roleName)
        {
            var role = _context.Roles.Where(
                rol => rol.RoleName == roleName
            ).FirstOrDefault();
            if(role == null)
            {
                return -1;
            }
            return role.Id;
        }
    }
}
