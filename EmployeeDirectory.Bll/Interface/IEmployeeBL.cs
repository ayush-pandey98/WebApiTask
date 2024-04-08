using EmployeeDirectory.Models;
using EmployeeDirectory.Models.Presentation.Employee;

namespace EmployeeDirectory.BLL.Interface.employeeBL
{
    public interface IEmployeeBL
    {
        List<EmployeeModelPresentation> GetAllEmployees();
        void AddEmployee(EmployeeModelPresentation employee);
        EmployeeModelPresentation GetEmployee(string id);
        void DeleteEmployee(string id);
        void EditEmployee(EmployeeModelPresentation employee, string id);
    }
}
