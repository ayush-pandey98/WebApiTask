using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDirectory.Bll;
using EmployeeDirectory.Models;
using EmployeeDirectory.Presentation.Interface;

namespace EmployeeDirectory.Presentation
{
    public partial class PresentationLayer
    {
       void AddEmployee() {
            Console.WriteLine("To exit the option between selection press '0'");
            Console.WriteLine("Enter Employee Details");
            string id = IsAvailableId("add");
            if (id == "exit") return;
            string firstName = _input.GetAlpabetInput("First Name");
            if (firstName == "exit") return;
            string lastName = _input.GetAlpabetInput("Last Name");
            if (lastName == "exit") return;
            string dob = _input.GetDate("Date of birth");
            if (dob == "exit") return;
            string mail = _input.GetEmail();
            if (mail == "exit") return;
            string pNumber = _input.GetPhone();
            if (pNumber == "exit") return;
            string jDate = _input.GetDate("Joining date");
            if (jDate == "exit") return;
            string jTitle = _input.GetRole();
            if (jTitle == "exit") return;
            int location = _input.GetRoleSpecificLocation(jTitle);
            if (location == -1) return;
            int department = _input.GetRoleSpecificDepartment(jTitle);
            if (department == -1) return;
            string manager = _input.GetManager();
            if (manager == "exit") return;
            string project = _input.GetProject();
            if (project == "exit") return;
            _employeeBL.AddEmployee(new Employee { Id = id, City = location, Role = jTitle, JoiningDate = jDate, Department = department, FirstName = firstName, LastName = lastName, Dob = dob, Email = mail, Manager = manager, PhoneNumber = pNumber, Project = project });
            return;
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
