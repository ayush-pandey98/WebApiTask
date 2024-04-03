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
        static List<string> employeeManagmentOption = new List<string>() { "Go Back", "Add Employee", "Display all", "Display one", "Edit Employee", "Delete Employee" };

        static List<string> mainMenueOption = new List<string>() { "Exit", "Employee Management", "Role Management", "Location Managment", "DepartmentManagment" };
        
        static List<string> roleManagmentOption = new List<string> { "Go Back", "Add Role", "Display All" };
        static List<string> locationManagmentOption = new List<string> { "Go Back", "Add Location", "View All Location" };
        static List<string> departmentManagmentOption = new List<string>
        {
            "Go Back", "Add Department", "View All Department"
        };
        static List<string> editEmpOptions = new List<string>() { "Save", "First Name", "Last Name", "Date Of Birth", "Email", "Phone Number", "Joining Dat", "Location", "Role", "Department", "Manager", "Project" };
    }
}
