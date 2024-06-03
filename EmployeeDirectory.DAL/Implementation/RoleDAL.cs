using EmployeeDirectory.DAL.Interface.roleDAL;
using EmployeeDirectory.Models.ModelDAL;

namespace EmployeeDirectory.DAL.Roles
{
    public class RoleDAL:IRoleDAL
    {
        private readonly EmployeeEfContext _context;
        public RoleDAL(EmployeeEfContext context)
        {
            _context = context; 
        }
        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
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
        public string GetRoleName(int id) {
            var role = _context.Roles.Where(rol=>rol.Id == id).FirstOrDefault();
            if(role== null)
            {
                return "";
            }
            return role.Name;
        }
        public int GetRoleId(string roleName)
        {
            var role = _context.Roles.Where(rol=>rol.Name == roleName).FirstOrDefault();
            if(role == null)
            {
                return -1;
            }
            return role.Id;
        }
    }
}
