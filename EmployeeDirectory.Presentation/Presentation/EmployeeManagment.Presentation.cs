using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.Models.Presentation.Employee;
using EmployeeDirectory.Presentation.Interface;

namespace EmployeeDirectory.Presentation.Presentation
{
    public class EmployeeManagment
    {
        string role;
        Iinput _input;
        IEmployeeBL _employeeBL;
        Helper _helper;
        EmployeeManagment(Iinput _input,IEmployeeBL _employeeBL, Helper helper)
        {
            this._input = _input;
            this._employeeBL = _employeeBL;
            _helper = helper;
        }
        Dictionary<string, Func<object>> GetEmployeeInputDetails()
        {
            Dictionary<string, Func<object>> EmployeeDetails = new Dictionary<string, Func<object>>
            {
            { "Id", () => _helper.GetNewIdInput() },
            { "FirstName", () => _input.GetAlpabetInput("First Name") },
            { "LastName", () => _input.GetAlpabetInput("Last Name") },
            { "Dob", () => _input.GetDate("Date of birth") },
            { "Email", () =>_input.GetEmail() },
            { "PhoneNumber", _input.GetPhone },
            {"City",()=>_input.GetRoleSpecificLocation(role) },
            {"Department",()=>_input.GetRoleSpecificDepartment(role) },
            { "JoiningDate", () => _input.GetDate("Joining date") },
            { "Role", () => _input.GetRole() },
            { "Manager", () => _input.GetManager() },
            { "Project", () => _input.GetProject() }
        };
            return EmployeeDetails;
        }
        void AddEmployee()
        {
            var EmployeeDetails = GetEmployeeInputDetails();
            Console.WriteLine("To exit the option between selection press '0'");
            Console.WriteLine("Enter Employee Details");
            EmployeeModelPresentation emp = new EmployeeModelPresentation();
            foreach (var propertyInfo in typeof(EmployeeModelPresentation).GetProperties())
            {
                var input = EmployeeDetails[propertyInfo.Name]();
                if (input.Equals("exit") || input.Equals(-1)) return;
                propertyInfo.SetValue(emp, input);
                if (propertyInfo.Name.Equals("Role"))
                {
                    role = input.ToString();
                }

            }
            _employeeBL.AddEmployee(emp);
        }
        public void EditEmployeeDetails(EmployeeModelPresentation employee)
        {
            role = employee.Role;
            Dictionary<string, Func<object>> employeeDetails = GetEmployeeInputDetails();
            while (true)
            {

                int choice = GetSelectedOptions(employeeDetails);

                if (choice == 0)
                {
                    break;
                }

                if (choice > 0 && choice <= employeeDetails.Count)
                {
                    string detailName = employeeDetails.ElementAt(choice - 1).Key;
                    object newValue = employeeDetails[detailName]();
                    if (newValue.Equals("exit") || newValue.Equals(-1)) return;
                    employee.GetType().GetProperty(detailName).SetValue(employee, newValue);
                    Console.WriteLine($"Employee {detailName} updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
        }
        int GetSelectedOptions(Dictionary<string, Func<object>> employeeDetails)
        {
            Console.WriteLine("Select the detail to edit:");
            int choice = 0;
            Console.WriteLine($"{choice}. Save");
            for(int i = 1; i < employeeDetails.Count; i++)
            {
                string item = employeeDetails.ElementAt(i).Key;
                Console.WriteLine($"{i}.{item}");
            }
           /* foreach (string detail in employeeDetails.Keys)
            {
                choice++;
                Console.WriteLine($"{choice}. {detail}");
            }*/
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {

                choice = -1;
            }
            return choice;
        }
        public void DisplayAllEmployees(List<EmployeeModelPresentation> employees)
        {
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("There is no data available");
                return;
            }
            var table = _helper.BuildAllEmployeeTable(employees);
            Console.WriteLine(table.ToString());
        }
        public void showAvailableId()
        {
            List<EmployeeModelPresentation> employees = _employeeBL.GetAllEmployees();
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("No ids avilable");
                return;
            }
            Console.WriteLine("\nThe avilable ids are:");
            Console.Write("|");
            foreach (EmployeeModelPresentation emp in employees)
            {
                Console.Write(" " + emp.Id + " " + "|");
            }
        }
        public void displaySpecific(EmployeeModelPresentation emp)
        {
            var table = _helper.BuildSpecificEmployeeTable(emp);
            Console.WriteLine(table);
        }
    }
}
