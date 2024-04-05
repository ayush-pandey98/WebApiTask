using ConsoleTables;
using EmployeeDirectory.Models;


namespace EmployeeDirectory.Presentation
{
    public partial class PresentationLayer
    {
        string role;

        Dictionary<string, Func<object>> GetEmployeeInputDetails()
        {
            Dictionary<string, Func<object>> EmployeeDetails = new Dictionary<string, Func<object>>
        {  
            { "Id", () => GetIdInput("add") },
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
            Employee emp=new Employee();
            foreach (var propertyInfo in typeof(Employee).GetProperties())
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
        public void EditEmployeeDetails(Employee employee)
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
            foreach (var detail in employeeDetails.Keys)
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
        public void DisplayAllEmployees()
        {
            List<Employee> employees = _employeeBL.GetAllEmployees();
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("There is no data available");
                return;
            }
            var table = new ConsoleTable("ID", "Name", "Role", "Department", "Location", "Joining Date", "Manager", "Project");
            foreach (Employee emp in employees)
            {
                table.AddRow(emp.Id, emp.FirstName + " " + emp.LastName, emp.Role, _departmentBL.GetDepartmentById(emp.Department), _locationBL.GetLocationById(emp.City), emp.JoiningDate, emp.Manager, emp.Project);
            }
            Console.WriteLine(table.ToString());
        }
        public void showAvailableId()
        {
            List<Employee> employees = _employeeBL.GetAllEmployees();
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("No ids avilable");
                return;
            }
            Console.WriteLine("\nThe avilable ids are:");
            Console.Write("|");
            foreach (Employee emp in employees)
            {
                Console.Write(" " + emp.Id + " " + "|");
            }
        }
        public void displaySpecific(Employee emp)
        {
            var table = new ConsoleTable("Name", "ID", "Role", "Department", "Location", "Joining Date", "Manger", "Date Of Birth", "Phone Number", "Project");
            table.AddRow(emp.FirstName + " " + emp.LastName, emp.Id, emp.Role, _departmentBL.GetDepartmentById(emp.Department), _locationBL.GetLocationById(emp.City), emp.JoiningDate, emp.Manager, emp.Dob, emp.PhoneNumber, emp.Project);
            Console.WriteLine(table.ToString());
        }
    }
}
