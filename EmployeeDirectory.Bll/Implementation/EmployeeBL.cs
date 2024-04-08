using EmployeeDirectory.Models;
using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.DAL.Interface.employeeDAL;
using EmployeeDirectory.Models.Presentation.Employee;
using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.BLL.Interface.departmentBL;
namespace EmployeeDirectory.Bll
{
    public class EmployeeBL:IEmployeeBL
    {
        private IEmployeeDAL _employeeDAL;
        private ILocationBL _locationBL;
        private IDepartmentBL _departmentBL;
        public EmployeeBL(IEmployeeDAL _employeeDAL,ILocationBL _locationBL,IDepartmentBL _departmentBL)
        {
            this._employeeDAL=_employeeDAL;
            this._locationBL=_locationBL;
            this._departmentBL = _departmentBL;

        }
        public List<EmployeeModelPresentation> GetAllEmployees()
        {

            List<EmployeeModelDAL> employeeDALList = _employeeDAL.GetAll();
            List<EmployeeModelPresentation> employeePresentationList = employeeDALList.Select(employeeDAL =>
                new EmployeeModelPresentation
                {
                    Id = employeeDAL.Id,
                    FirstName = employeeDAL.FirstName,
                    LastName = employeeDAL.LastName,
                    Email = employeeDAL.Email,
                    Dob = employeeDAL.Dob,
                    PhoneNumber = employeeDAL.PhoneNumber,
                    Role = employeeDAL.Role,
                    City = _locationBL.GetLocationById(employeeDAL.City), 
                    JoiningDate = employeeDAL.JoiningDate,
                    Department = _departmentBL.GetDepartmentById(employeeDAL.Department), 
                    Manager = employeeDAL.Manager,
                    Project = employeeDAL.Project
                }).ToList();

            return employeePresentationList;
        }
        public void AddEmployee(EmployeeModelPresentation employee)
        {
            EmployeeModelDAL employeeDAL = new EmployeeModelDAL {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Dob = employee.Dob,
                PhoneNumber = employee.PhoneNumber,
                Role = employee.Role,
                City = _locationBL.GetLocationId(employee.City),
                JoiningDate = employee.JoiningDate,
                Department = _departmentBL.GetDepartmentId(employee.Department),
                Manager = employee.Manager,
                Project = employee.Project
            };

            _employeeDAL.Add(employeeDAL);
        }
        public EmployeeModelPresentation GetEmployee(string id)
        {
            List<EmployeeModelPresentation> employees = GetAllEmployees();
            return employees.Find(emp=>emp.Id==id);
        }
        public void DeleteEmployee(string id)
        {
            if (_employeeDAL.Delete(id))
            {
                Console.WriteLine("Employee deleted succesfully");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }
        public void EditEmployee(EmployeeModelPresentation employee,string id)
        {
            var employees=_employeeDAL.GetAll();
            foreach (var empp in employees.Where(emp=>emp.Id==id))
            {
                empp.FirstName = employee.FirstName;
                empp.LastName = employee.LastName;
                empp.PhoneNumber = employee.PhoneNumber;
                empp.Email = employee.Email;
                empp.City= _locationBL.GetLocationId(employee.City);
                empp.Role= employee.Role;
                empp.JoiningDate = employee.JoiningDate;
                empp.Department = _departmentBL.GetDepartmentId(employee.Department);
                empp.Dob= employee.Dob;
                empp.JoiningDate= employee.JoiningDate;
                empp.Manager= employee.Manager;
                empp.Project= employee.Project;
            }
            _employeeDAL.Set(employees);
        }

    }
}

