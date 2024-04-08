using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDirectory.Presentation.Interface;

namespace EmployeeDirectory.Presentation
{
    public partial class PresentationLayer
    {
        readonly List<string> employeeManagmentOption = new List<string>() { "Go Back", "Add Employee", "Display all", "Display one", "Edit Employee", "Delete Employee" };

        readonly List<string> mainMenuOption = new List<string>() { "Exit", "Employee Management", "Role Management", "Location Managment", "DepartmentManagment" };
        
        readonly List<string> roleManagmentOption = new List<string> { "Go Back", "Add Role", "Display All" };

        readonly List<string> locationManagmentOption = new List<string> { "Go Back", "Add Location", "View All Location" };

        readonly List<string> departmentManagmentOption = new List<string>
        {
            "Go Back", "Add Department", "View All Department"
        };

        readonly List<string> editEmpOptions = new List<string>() { "Save", "First Name", "Last Name", "Date Of Birth", "Email", "Phone Number", "Joining Dat", "Location", "Role", "Department", "Manager", "Project" };
    }
}
