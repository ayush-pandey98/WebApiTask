using EmployeeDirectory.DAL.Interface.departmentDAL;
using EmployeeDirectory.Model.ModelDAL;

namespace EmployeeDirectory.DAL.Implementation.departmentDAL
{
    public class DepartmentDAL : IDepartmentDAL
    {
        private readonly EmployeeDirectoryDbContext _context;
        public DepartmentDAL()
        {
            
        }
        public DepartmentDAL(EmployeeDirectoryDbContext context)
        {
            _context = context;
        }

        public bool Add(Department department)
        {
            _context.Add(department);
            return Save();
        }

        public List<Department> GetAll()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }

        public int GetDepartmentId(string departmentName)
        {
            int id = -1; 
            var dept  = _context.Departments.Where(dep=>dep.DepartmentName == departmentName).FirstOrDefault();
            if (dept != null)
            {
                id = dept.Id;
            }
            return id;
        }
        private bool Save()
        {
            var saved  =  _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
