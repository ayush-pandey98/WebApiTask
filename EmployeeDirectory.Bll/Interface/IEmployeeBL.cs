using EmployeeDirectory.Models;

namespace EmployeeDirectory.BLL.Interface.employeeBL
{
    public interface IEmployeeBL
    {
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        Employee GetEmployee(string id);
        void DeleteEmployee(string id);
        void EditEmployee(Employee employee, string id);
    }
}
