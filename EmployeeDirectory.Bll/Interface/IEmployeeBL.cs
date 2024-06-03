using EmployeeDirectory.Models.ModelDAL;
using EmployeeDirectory.Models.Presentation.Employee;

namespace EmployeeDirectory.BLL.Interface.employeeBL
{
    public interface IEmployeeBL
    {
        List<EmployeeDto> GetAllEmployees();
        bool AddEmployee(Employee employee);
        EmployeeDto GetEmployee(string id);
        bool DeleteEmployee(EmployeeDto employee);
        bool EditEmployee(EmployeeDto employee, string id);
    }
}
