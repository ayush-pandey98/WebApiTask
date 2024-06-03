using ConsoleTables;
using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.Models.Presentation.Employee;
using EmployeeDirectory.Models.Presentation.Role;
using EmployeeDirectory.Presentation.Interface;

namespace EmployeeDirectory.Presentation.Presentation
{
    public class Helper
    {
        private Iinput _input;
        private IEmployeeBL _employeeBL;
        public Helper(Iinput _input,IEmployeeBL _employeeBL) { 
            this._input = _input;
            this._employeeBL = _employeeBL;
        }
        public string BuildAllEmployeeTable(List<EmployeeModelPresentation> employees)
        {
            var table = new ConsoleTable("ID", "Name", "Role", "Department", "Location", "Joining Date", "Manager", "Project");
            foreach (EmployeeModelPresentation emp in employees)
            {
                table.AddRow(emp.Id, emp.FirstName + " " + emp.LastName, emp.Role, emp.Department, emp.City, emp.JoiningDate, emp.Manager, emp.Project);
            }
            return table.ToString();
        }
        public string BuildSpecificEmployeeTable(EmployeeModelPresentation emp)
        {
            var table = new ConsoleTable("Name", "ID", "Role", "Department", "Location", "Joining Date", "Manger", "Date Of Birth", "Phone Number", "Project");
            table.AddRow(emp.FirstName + " " + emp.LastName, emp.Id, emp.Role, emp.City, emp.Department, emp.JoiningDate, emp.Manager, emp.Dob, emp.PhoneNumber, emp.Project);
            return table.ToString();
        }

       public string GetNewIdInput()
        {
            string id = _input.GetId();
            var employee = _employeeBL.GetEmployee(id);

            while (employee != null)
            {
                Console.WriteLine("This employee already available");
                id = _input.GetId();
                employee = _employeeBL.GetEmployee(id);
            }
            return id;
        }
        public string GetAvailableIdInput()
        {
            string id = _input.GetId();
            var employee = _employeeBL.GetEmployee(id);
            while (employee == null)
            {
                Console.WriteLine("This employee is not available");
                id = _input.GetId();
                employee = _employeeBL.GetEmployee(id);
            }
            return id;
        }
        public string BuildRoleTable(List<RoleModelPresentation> roles)
        {
            var table = new ConsoleTable("ID","Role", "Location", "Description", "Department");
            foreach (RoleModelPresentation role in roles)
            {
                table.AddRow(role.Id,role.Name, role.Location, role.Description, role.Department);
            }
            return table.ToString();
        }
    }

}

