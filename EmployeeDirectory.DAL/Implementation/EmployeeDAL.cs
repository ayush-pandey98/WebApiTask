using EmployeeDirectory.DAL.Interface.employeeDAL;
using EmployeeDirectory.Model.ModelDAL;
namespace EmployeeDirectory.DAL
{
    public class EmployeeDAL:IEmployeeDAL
    {
        private readonly EmployeeDirectoryDbContext _context;
        public EmployeeDAL(EmployeeDirectoryDbContext context)
        {
            _context = context;
        }
        public List<Employee> GetAll()
        {
                return _context.Employees.ToList();   
        }
        public bool Add(Employee employee)
        {
                _context.Employees.Add(employee);
                return Save();
            
        }
        public Employee GetById(string id)
        {
                var employee = _context.Employees.Find(id);
                if (employee == null) return null;
                return employee;
            
        }
        public bool Delete(Employee employee)
        {
            var emp = _context.Employees.SingleOrDefault(e => e.Id == employee.Id);
            if (emp != null)
            {
                emp.StatusId = employee.StatusId;
                return Save();
            }
            return false;
        }

        public bool Update(Employee employee,string id)
        {
            var emp = _context.Employees.SingleOrDefault(e => e.Id == employee.Id);
            if (emp != null)
            {
                emp.FirstName = employee.FirstName;
                emp.ProfilePic = employee.ProfilePic;
                emp.LastName = employee.LastName;
                emp.PhoneNumber = employee.PhoneNumber;
                emp.Dob = employee.Dob;
                emp.Email = employee.Email;
                emp.JoiningDate = employee.JoiningDate;
                emp.ManagerId = employee.ManagerId;
                emp.ProjectId = employee.ProjectId;
                emp.RoleDetailId = employee.RoleDetailId;
                return Save();
            }
            return false;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges(); ;
            return saved > 0 ? true : false;
        }
    }
}
