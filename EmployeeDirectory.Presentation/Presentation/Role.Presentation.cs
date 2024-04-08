using System.Xml.Linq;
using ConsoleTables;
using EmployeeDirectory.Models;
using EmployeeDirectory.Models.Roles;

namespace EmployeeDirectory.Presentation
{
    public partial class PresentationLayer
    {
        //Roles
        Dictionary<string, Func<object>> GetRoleInputDetails()
        {
            Dictionary<string, Func<object>> roleDetails = new Dictionary<string, Func<object>>
        {
                {"Name" ,()=>_input.GetAlpabetInput("Role Name") },
                {"Description",()=>_input.GetAlpabetInput("Desciption") } ,
                {"Location" ,()=>_input.GetAllLocation() },
                {"Department",()=> _input.GetAllDepartment()}
        };
            return roleDetails;
        }
        public void DisplayAllRole()
        {
            List<Role> roles = _roleBL.GetAllRoles();
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
        void AddRole()
        {
            var roleDetails = GetRoleInputDetails();
            Console.WriteLine("To exit the option between selection press '0'");
            Console.WriteLine("Enter Role Details");
            Role role = new Role();
            foreach (var roleInfo in typeof(Role).GetProperties())
            {
                var input = roleDetails[roleInfo.Name]();
                if (input.Equals("exit") || input.Equals(-1)) return;
                roleInfo.SetValue(role, input);

            }
            _roleBL.AddRole(role);
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
