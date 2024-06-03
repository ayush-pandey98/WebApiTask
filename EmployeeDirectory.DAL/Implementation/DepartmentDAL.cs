using EmployeeDirectory.DAL.Interface.departmentDAL;
using EmployeeDirectory.Models.ModelDAL;

namespace EmployeeDirectory.DAL.Implementation.departmentDAL
{
    public class DepartmentDAL:IDepartmentDAL
    {
        private readonly EmployeeEfContext _context;
        public DepartmentDAL(EmployeeEfContext context)
        {
            _context = context;
        }
        public List<Department> GetAll()
        {
            return _context.Departments.ToList(); 
        }
        public bool Add(Department department)
        { 
           _context.Departments.Add(department);
            return Save();
        }
        public string GetNameById(int id)
        {
            var dept =  _context.Departments.Where(dep=>dep.Id==id).FirstOrDefault();
            if (dept == null) return "";
            return dept.Value;
        }
        public int GetIdByName(string name)
        {
            var dept = _context.Departments.FirstOrDefault(l => l.Value == name);
            return dept != null ? dept.Id : -1;
        }
        public bool Save()
        {
            var saved  =  _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
