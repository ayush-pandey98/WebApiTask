using ConsoleTables;
using EmployeeDirectory.Models;
using EmployeeDirectory.Presentation.Interface;

namespace EmployeeDirectory.Presentation
{
    public partial class PresentationLayer
    {
        //Employees
        public void DisplayAllEmployees()
        {
            List<Employee> employees = _employeeBL.GetAllEmployees();
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("There is no data available");
                return;
            }
            var table = new ConsoleTable("ID", "Name", "Role", "Department", "Location", "Joining Date", "Manager", "Project");
            foreach (Employee emp in employees)
            {
                table.AddRow(emp.Id, emp.FirstName + " " + emp.LastName, emp.Role, _departmentBL.GetDepartmentById(emp.Department), _locationBL.GetLocationById(emp.City), emp.JoiningDate, emp.Manager, emp.Project);
            }
            Console.WriteLine(table.ToString());
        }
        public void showAvailableId()
        {
            List<Employee> employees = _employeeBL.GetAllEmployees();
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("No ids avilable");
                return;
            }
            Console.WriteLine("\nThe avilable ids are:");
            Console.Write("|");
            foreach (Employee emp in employees)
            {
                Console.Write(" " + emp.Id + " " + "|");
            }
        }
        public void displaySpecific(Employee emp)
        {
            var table = new ConsoleTable("Name", "ID", "Role", "Department", "Location", "Joining Date", "Manger", "Date Of Birth", "Phone Number", "Project");
            table.AddRow(emp.FirstName + " " + emp.LastName, emp.Id, emp.Role, _departmentBL.GetDepartmentById(emp.Department), _locationBL.GetLocationById(emp.City), emp.JoiningDate, emp.Manager, emp.Dob, emp.PhoneNumber, emp.Project);
            Console.WriteLine(table.ToString());
        }
        //Roles
        public void DisplayAllRole()
        {
            List<Models.Roles.Role> roles = _roleBL.GetAllRoles();
            if (roles == null || roles.Count == 0)
            {
                Console.WriteLine("There is no data available");
                return;
            }
            var table = new ConsoleTable("Role", "Location", "Description", "Department");
            foreach (Models.Roles.Role role in roles)
            {
                table.AddRow(role.Name, _locationBL.GetLocationById(role.Location), role.Description, _departmentBL.GetDepartmentById(role.Department));
            }
            Console.WriteLine(table.ToString());
        }

        //Location
        void DisplayAllLocation()
        {
            var locations = _locationBL.GetAllLocation();
            foreach (var location in locations)
            {
                Console.WriteLine(location.Id + " " + location.Value);
            }
        }

        //Departments
        void DisplayAllDepartments()
        {
            _input.GetAllLocation();
            var departments = _departmentBL.GetAllDepartment();
            if (departments == null)
            {
                Console.WriteLine("No departments available");
                return;
            }
            foreach (var department in departments)
            {
                Console.WriteLine(department.Id + " " + department.Value);
            }
        }
    }
}
