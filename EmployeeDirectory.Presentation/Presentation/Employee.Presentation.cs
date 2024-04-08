using ConsoleTables;
using EmployeeDirectory.Models.Presentation.Employee;


namespace EmployeeDirectory.Presentation
{
    public partial class PresentationLayer
    {
        string role;

        Dictionary<string, Func<object>> GetEmployeeInputDetails()
        {
            Dictionary<string, Func<object>> EmployeeDetails = new Dictionary<string, Func<object>>
        {  
            { "Id", () => GetNewIdInput() },
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
        void AddEmployee() {
            var EmployeeDetails = GetEmployeeInputDetails();
            Console.WriteLine("To exit the option between selection press '0'");
            Console.WriteLine("Enter Employee Details");
             EmployeeModelPresentation emp=new EmployeeModelPresentation();
            foreach (var propertyInfo in typeof(EmployeeModelPresentation).GetProperties())
            {
                var input = EmployeeDetails[propertyInfo.Name]();
                if (input.Equals("exit")||input.Equals(-1)) return;
                propertyInfo.SetValue(emp,input);
                if (propertyInfo.Name.Equals("Role"))
                {
                    role = input.ToString();
                }
                
            }
            _employeeBL.AddEmployee(emp);
        }
        public void EditEmployeeDetails(EmployeeModelPresentation employee)
        {
            role=employee.Role;
            Dictionary<string, Func<object>> employeeDetails = GetEmployeeInputDetails();
            while (true)
            {
                
               int choice= GetSelectedOptions(employeeDetails);

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
        public void DisplayAllEmployees(List<EmployeeModelPresentation> employees)
        {
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("There is no data available");
                return;
            }
            var table = BuildAllEmployeeTable(employees);
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
           var table = BuildSpecificEmployeeTable(emp);
            Console.WriteLine(table);
        }
        public string BuildAllEmployeeTable(List<EmployeeModelPresentation> employees)
        {
            var table = new ConsoleTable("ID", "Name", "Role", "Department", "Location", "Joining Date", "Manager", "Project");
            foreach (EmployeeModelPresentation emp in employees)
            {
                table.AddRow(emp.Id, emp.FirstName + " " + emp.LastName, emp.Role,emp.Department, emp.City, emp.JoiningDate, emp.Manager, emp.Project);
            }
            return table.ToString();
        }
        public string BuildSpecificEmployeeTable(EmployeeModelPresentation emp)
        {
            var table = new ConsoleTable("Name", "ID", "Role", "Department", "Location", "Joining Date", "Manger", "Date Of Birth", "Phone Number", "Project");
            table.AddRow(emp.FirstName + " " + emp.LastName, emp.Id, emp.Role, emp.City, emp.Department, emp.JoiningDate, emp.Manager, emp.Dob, emp.PhoneNumber, emp.Project);
            return table.ToString();
        }
    }
}
