
namespace EmployeeDirectory.Presentation.Constants
{
    public class Constants
    {
        public readonly List<string> employeeManagmentOption = new List<string>() { "Go Back", "Add Employee", "Display all", "Display one", "Edit Employee", "Delete Employee" };

        public readonly List<string> mainMenuOption = new List<string>() { "Exit", "Employee Management", "Role Management", "Location Managment", "DepartmentManagment" };

        public readonly List<string> roleManagmentOption = new List<string> { "Go Back", "Add Role", "Display All" };

        public readonly List<string> locationManagmentOption = new List<string> { "Go Back", "Add Location", "View All Location" };

        public readonly List<string> departmentManagmentOption = new List<string>
        {
            "Go Back", "Add Department", "View All Department"
        };

        public readonly List<string> editEmpOptions = new List<string>() { "Save", "First Name", "Last Name", "Date Of Birth", "Email", "Phone Number", "Joining Dat", "Location", "Role", "Department", "Manager", "Project" };
    }
}
