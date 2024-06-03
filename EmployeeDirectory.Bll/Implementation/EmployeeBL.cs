using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.DAL.Interface.employeeDAL;
using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.Models.ModelDAL;
using EmployeeDirectory.Models.Presentation.Employee;

namespace EmployeeDirectory.Bll
{
    public class EmployeeBL:IEmployeeBL
    {
        private readonly IEmployeeDAL _employeeDAL;
        private readonly ILocationBL _locationBL;
        private readonly IDepartmentBL _departmentBL;
        private readonly IRoleBL _roleBL;
        public EmployeeBL(IEmployeeDAL employeeDAL,ILocationBL locationBL,IDepartmentBL departmentBL,IRoleBL roleBL)
        {
            _employeeDAL = employeeDAL;
            _locationBL = locationBL;
            _departmentBL = departmentBL;
            _roleBL = roleBL;
        }
        public List<EmployeeDto> GetAllEmployees()
        {

            List<Employee> employeeDALList = _employeeDAL.GetAll();
            List<EmployeeDto> employeePresentationList = employeeDALList.Select(employeeDAL =>
                new EmployeeDto
                {
                    Id = employeeDAL.Id,
                    FirstName = employeeDAL.FirstName,
                    LastName = employeeDAL.LastName,
                    Email = employeeDAL.Email,
                    Dob = employeeDAL.Dob,
                    PhoneNumber = employeeDAL.PhoneNumber,
                    Role = _roleBL.GetRoleById(employeeDAL.Role),
                    City = _locationBL.GetLocationById(employeeDAL.City), 
                    JoiningDate = employeeDAL.JoiningDate,
                    Department = _departmentBL.GetDepartmentById(employeeDAL.Department), 
                    Manager = employeeDAL.Manager,
                    Project = employeeDAL.Project
                }).ToList();

            return employeePresentationList;
        }
        public bool AddEmployee(Employee employee)
        {
            return _employeeDAL.Add(employee);
        }
        public EmployeeDto GetEmployee(string id)
        {
            Employee employee = _employeeDAL.GetById(id);
            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Dob = employee.Dob,
                PhoneNumber = employee.PhoneNumber,
                Role = _roleBL.GetRoleById(employee.Role),
                City = _locationBL.GetLocationById(employee.City),
                JoiningDate = employee.JoiningDate,
                Department = _departmentBL.GetDepartmentById(employee.Department),
                Manager = employee.Manager,
                Project = employee.Project
            };
        }
        public bool DeleteEmployee(EmployeeDto employee)
        {
            Employee emp = new Employee()
            {
                Id= employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                City = _locationBL.GetLocationId(employee.City),
                Role = _roleBL.GetIdByRole(employee.Role),
                Department = _departmentBL.GetDepartmentId(employee.Department),
                Dob = employee.Dob,
                JoiningDate = employee.JoiningDate,
                Manager = employee.Manager,
                Project = employee.Project
            };
            return _employeeDAL.Delete(emp);
        }
        public bool EditEmployee(EmployeeDto employee,string id)
        {
            Employee emp = new Employee()
            {
                Id = id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                City = _locationBL.GetLocationId(employee.City),
                Role = _roleBL.GetIdByRole(employee.Role),
                Department = _departmentBL.GetDepartmentId(employee.Department),
                Dob = employee.Dob,
                JoiningDate = employee.JoiningDate,
                Manager = employee.Manager,
                Project = employee.Project
            };
            return _employeeDAL.Update(emp, id);
        }

    }
}

