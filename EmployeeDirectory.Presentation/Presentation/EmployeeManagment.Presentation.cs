
using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.Models.Presentation.Employee;
using EmployeeDirectory.Presentation.Interface;

namespace EmployeeDirectory.Presentation.Presentation
{
    public class EmployeeManagment
    {
        string role;
        private Iinput _input;
        private IEmployeeBL _employeeBL;
        private Helper _helper;
        private Constants.Constants _constants;
        public EmployeeManagment(Iinput _input,IEmployeeBL _employeeBL, Helper helper,Constants.Constants _constants)
        {
            this._input = _input;
            this._employeeBL = _employeeBL;
            _helper = helper;
            this._constants = _constants;
        }
        public void Managment()
        {
            Console.WriteLine("\nEmployee Managment");
            Console.WriteLine("------------------");

            while (true)
            {
                Console.WriteLine();
                for (int i = 0; i < _constants.employeeManagmentOption.Count; i++)
                {
                    Console.WriteLine($"{i}.{_constants.employeeManagmentOption[i]}");
                }
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "0":
                        return;
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        DisplayAllEmployees(_employeeBL.GetAllEmployees());
                        break;
                    case "3":
                        Console.WriteLine("Display Specific \n----");
                        Console.Write("Enter the info of employee you want to view");
                        showAvailableId();
                        string empId = _helper.GetAvailableIdInput();
                        displaySpecific(_employeeBL.GetEmployee(empId));
                        break;
                    case "4":
                        Console.WriteLine("Edit \n----");
                        Console.WriteLine("To exit the option between selection press 'e'");
                        showAvailableId();
                        empId = _helper.GetAvailableIdInput();
                        EditEmployee(_employeeBL.GetEmployee(empId), empId);
                        break;
                    case "5":
                        Console.WriteLine("Delete \n------");
                        showAvailableId();
                        string emp_id = _input.GetId();
                        if (emp_id == "exit") break;
                        _employeeBL.DeleteEmployee(emp_id);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
        private Dictionary<string, Func<string>> GetEmployeeInputDetails()
        {
            Dictionary<string, Func<string>> EmployeeDetails = new Dictionary<string, Func<string>>
            {
            { "Id", () => _helper.GetNewIdInput() },
            { "FirstName", () => _input.GetName("First Name") },
            { "LastName", () => _input.GetName("Last Name") },
            { "Dob", () => _input.GetBirthDate() },
            { "Email", () =>_input.GetEmail() },
            { "PhoneNumber", _input.GetPhone },
            {"City",()=>_input.GetRoleSpecificLocation(role) },
            {"Department",()=>_input.GetRoleSpecificDepartment(role) },
            { "JoiningDate", () => _input.GetJoiningDate() },
            { "Role", () => _input.GetRole() },
            { "Manager", () => _input.GetManager() },
            { "Project", () => _input.GetProject() }
        };
            return EmployeeDetails;
        }
        private void AddEmployee()
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
        private void EditEmployee(EmployeeModelPresentation employee, string id)
        {
            while (true)
            {
                Console.Write("Choose the informations your want change :");
                Console.WriteLine("\nTo exit the option between selection press '0'");
                EditEmployeeDetails(employee);
                break;
            }
            Console.WriteLine("Employee Edited Sucessfully");
            _employeeBL.EditEmployee(employee, id);
        }
        private void EditEmployeeDetails(EmployeeModelPresentation employee)
        {
            role = employee.Role;
            Dictionary<string, Func<string>> employeeDetails = GetEmployeeInputDetails();
            while (true)
            {

                int choice = GetSelectedOptions(employeeDetails);

                if (choice == 0)
                {
                    break;
                }

                if (choice > 0 && choice <= employeeDetails.Count)
                {
                    string detailName = employeeDetails.ElementAt(choice).Key;
                    string newValue = employeeDetails[detailName]();
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
        private int GetSelectedOptions(Dictionary<string, Func<string>> employeeDetails)
        {
            Console.WriteLine("Select the detail to edit:");
            int choice = 0;
            Console.WriteLine($"{choice}. Save");
            foreach (var detail in employeeDetails.Keys.Skip(1))
            {
                choice++;
                Console.WriteLine($"{choice}. {detail}");
            }
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
        private void DisplayAllEmployees(List<EmployeeModelPresentation> employees)
        {
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("There is no data available");
                return;
            }
            var table = _helper.BuildAllEmployeeTable(employees);
            Console.WriteLine(table.ToString());
        }
        private void showAvailableId()
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
        private void displaySpecific(EmployeeModelPresentation emp)
        {
            var table = _helper.BuildSpecificEmployeeTable(emp);
            Console.WriteLine(table);
        }
    }
}
