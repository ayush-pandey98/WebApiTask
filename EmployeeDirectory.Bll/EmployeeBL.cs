using EmployeeDirectory.Models;
using EmployeeDirectory.Bll.Interface;
using EmployeeDirectory.DAL.Interface;
namespace EmployeeDirectory.Bll
{
    public class EmployeeBL: IEmployeeBL
    {
        private IEmployeeDAL empData;
        public EmployeeBL(IEmployeeDAL empData)
        {
            this.empData=empData;
        }
        public List<Employee> GetAllEmployees()
        {
            return empData.GetAll();
        }
        public void AddEmployee(Employee employee)
        {
            empData.Add(employee);
        }
        public Employee GetEmployee(string id)
        {
            return empData.GetById(id);
        }
        public void DeleteEmployee(string id)
        {
            if (empData.Delete(id))
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
            var employees=empData.GetAll();
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
            empData.Set(employees);
        }

    }
}

