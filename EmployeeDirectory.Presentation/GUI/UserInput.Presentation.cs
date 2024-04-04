
using System.Runtime.InteropServices;
using EmployeeDirectory.Models;


namespace EmployeeDirectory.Presentation
{
    public partial class PresentationLayer
    {
        Dictionary<string, Func<object>> GetEmployeeInputDetails()
        {
            Dictionary<string, Func<object>> EmployeeDetails = new Dictionary<string, Func<object>>
        {
            { "Id", () => GetIdInput("add") },
            { "FirstName", () => _input.GetAlpabetInput("First Name") },
            { "LastName", () => _input.GetAlpabetInput("Last Name") },
            { "Dob", () => _input.GetDate("Date of birth") },
            { "Email", () => _input.GetEmail() },
            { "PhoneNumber", () => _input.GetPhone() },
            { "JoiningDate", () => _input.GetDate("Joining date") },
            { "Role", () => _input.GetRole() },
            { "Manager", () => _input.GetManager() },
            { "Project", () => _input.GetProject() }
        };
            return EmployeeDetails;
        }
        void AddEmployee() {
            var EmployeeDetails = GetEmployeeInputDetails();
            Console.WriteLine("To exit the option between selection press '0'");
            Console.WriteLine("Enter Employee Details");
            Employee emp=new Employee();
            foreach (var propertyInfo in typeof(Employee).GetProperties())
            {
                var input = EmployeeDetails[propertyInfo.Name]();
                if (input.Equals("exit")||input.Equals(-1)) return;
                propertyInfo.SetValue(emp,input);
                if (propertyInfo.Name.Equals("Role"))
                {
                    EmployeeDetails.Add("City", () => _input.GetRoleSpecificLocation(input.ToString()));
                    EmployeeDetails.Add("Department", () => _input.GetRoleSpecificDepartment(input.ToString()));
                }
                
            }
            _employeeBL.AddEmployee(emp);
        }
        void editEmployeeOptions(Employee employee,string choice)
        {
            switch (choice)
            {
                case "0": break;
                case "1":
                    string firstName = _input.GetAlpabetInput("First Name");
                    if (firstName == "exit") break;
                    employee.FirstName = firstName;
                    break;
                case "2":
                    string lastName = _input.GetAlpabetInput("Last Name");
                    if (lastName == "exit") break;
                    employee.LastName = lastName;
                    break;
                case "3":
                    string dob = _input.GetDate("Date of birth");
                    if (dob == "exit") break;
                    employee.Dob = dob;
                    break;
                case "4":
                    string email = _input.GetEmail();
                    if (email == "exit") break;
                    employee.Email = email;
                    break;
                case "5":
                    string pNumber = _input.GetPhone();
                    if (pNumber == "exit") break;
                    employee.PhoneNumber = pNumber;
                    break;
                case "6":
                    string joiningDate = _input.GetDate("Joining date");
                    if (joiningDate == "exit") break;
                    employee.JoiningDate = joiningDate;
                    break;
                case "8":
                    string role = _input.GetRole();
                    if (role == "exit") break;
                    employee.Role = role;
                    break;
                case "7":
                    int city = _input.GetRoleSpecificLocation(employee.Role);
                    if (city == -1) break;
                    employee.City = city;
                    break;
                case "9":
                    int department = _input.GetRoleSpecificDepartment(employee.Role);
                    if (department == 0) break;
                    employee.Department = department;
                    break;
                case "10":
                    string manager = _input.GetManager();
                    if (manager == "exit") break;
                    employee.Manager = manager;
                    break;
                case "11":
                    string project = _input.GetProject();
                    if (project == "exit") break;
                    employee.Project = project;
                    break;
                default: Console.WriteLine("Invalid _input"); break;
            }
        }
        void AddRole()
        {
            string roleName = _input.GetAlpabetInput("Role Name");
            if (roleName == "exit") return;
            string description = _input.GetAlpabetInput("Desciption");
            if (description == "exit") return;
            int location = _input.GetAllLocation();
            if (location == -1) return;
            int department = _input.GetAllDepartment();
            if (department == -1) return;
            _roleBL.AddRole(new Models.Roles.Role { Name = roleName, Department = department, Description = description, Location = location });
        }
    }
}
