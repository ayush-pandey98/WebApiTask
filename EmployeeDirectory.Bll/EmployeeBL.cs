using EmployeeDirectory.Models;
using EmployeeDirectory.DAL;
using EmployeeDirectory.Bll.Interface;
using EmployeeDirectory.DAL.Interface;
namespace EmployeeDirectory.Bll
{
    public class EmployeeBL: IEmployeeBL
    {
        private IEmployeeDAL employees;
        public EmployeeBL(IEmployeeDAL employees)
        {
            this.employees=employees;
        }
        public List<Employee> GetAllEmployees()
        {
            return employees.GetAll();
        }
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        public Employee GetEmployee(string id)
        {
            return employees.GetById(id);
        }
        public void DeleteEmployee(string id)
        {
            if (employees.Delete(id))
            {
                Console.WriteLine("Employee deleted succesfully");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }
        public void EditEmployee()
        {

        }

    }
}

