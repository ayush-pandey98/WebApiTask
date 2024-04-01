using EmployeeDirectory.Models;
using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.DAL.Interface.employeeDAL;
namespace EmployeeDirectory.Bll
{
    public class EmployeeBL:IEmployeeBL
    {
        private IEmployeeDAL _employeeDAL;
        public EmployeeBL(IEmployeeDAL _employeeDAL)
        {
            this._employeeDAL=_employeeDAL;
        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeDAL.GetAll();
        }
        public void AddEmployee(Employee employee)
        {
            _employeeDAL.Add(employee);
        }
        public Employee GetEmployee(string id)
        {
            return _employeeDAL.GetById(id);
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
        public void EditEmployee(Employee employee,string id)
        {
            var employees=_employeeDAL.GetAll();
            foreach (var empp in employees.Where(emp=>emp.Id==id))
            {
                empp.FirstName = employee.FirstName;
                empp.LastName = employee.LastName;
                empp.PhoneNumber = employee.PhoneNumber;
                empp.Email = employee.Email;
                empp.City= employee.City;
                empp.Role= employee.Role;
                empp.JoiningDate = employee.JoiningDate;
                empp.Department = employee.Department;
                empp.Dob= employee.Dob;
                empp.JoiningDate= employee.JoiningDate;
                empp.Manager= employee.Manager;
                empp.Project= employee.Project;
            }
            _employeeDAL.Set(employees);
        }

    }
}

