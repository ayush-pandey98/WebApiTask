using EmployeeDirectory.DAL.Interface.employeeDAL;
using EmployeeDirectory.Models.ModelDAL;
namespace EmployeeDirectory.DAL
{
    public class EmployeeDAL:IEmployeeDAL
    {
        private readonly EmployeeEfContext _context;
        public EmployeeDAL(EmployeeEfContext context)
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
            var employeeToDelete = _context.Employees.Find(employee.Id);

            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                return Save();
            }
            else
            {
                return false;
            }
        }

        public bool Update(Employee employee,string id)
        {
             var employeeToUpdate = _context.Employees.Find(id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Id = id;
                employeeToUpdate.Email = employee.Email;
                employeeToUpdate.City = employee.City;
                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.Role = employee.Role;
                employeeToUpdate.Department = employee.Department;
                employeeToUpdate.PhoneNumber = employee.PhoneNumber;
                employeeToUpdate.Dob = employee.Dob;
                employeeToUpdate.JoiningDate = employee.JoiningDate;
                employeeToUpdate.Manager = employee.Manager;
                employeeToUpdate.Project = employee.Project;
                }
                return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges(); ;
            return saved > 0 ? true : false;
        }
    }
}
