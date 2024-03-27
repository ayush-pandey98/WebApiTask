using EmployeeDirectory.Bll;
using ConsoleTables;
using EmployeeDirectory.Bll.Interface;
using EmployeeDirectory.Models;
using EmployeeDirectory.Presentation.Interface;
namespace EmployeeDirectory.Presentation
{
    public class PresentationLayer
    {
        private IEmployeeBL empOperation;
        private Iinput input;
        private IRoleBL roleOperation;
        public PresentationLayer(IEmployeeBL empOperation,Iinput input,IRoleBL roleOperation) { 
         this.roleOperation = roleOperation;
         this.empOperation = empOperation;
         this.input = input;
        }

      public void Run()
        {

            Console.WriteLine("Employee Directory");
            Console.WriteLine("------------------");
            while (true)
            {
                Console.WriteLine("\n1.Employee Management \n2.Role Management \n3.Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EmployeeManagment();
                        break;
                    case "2":
                        RoleManagment();
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter valid input");
                        break;
                }
            }

        }
        public void EmployeeManagment()
        {
            Console.WriteLine("\nEmployee Managment");
            Console.WriteLine("------------------");
             
            while (true)
            {
                Console.WriteLine("\n1.Add Employee\n2.Display all\n3.Display one\n4.Edit Employee\n5.Delete Employee\n6.Go Back");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter Employee Details");
                        string id = input.GetId();
                        string firstName = input.GetAlpabetInput("First Name");
                        string lastName = input.GetAlpabetInput("Last Name");
                        string dob = input.GetDate("Date of birth");
                        string mail = input.GetEmail();
                        string pNumber = input.GetPhone();
                        string jDate = input.GetDate("Joining date");
                        string location = input.GetLocation();
                        string jTitle = input.GetRole();
                        string department = input.GetDepartment();
                        string manager = input.GetManager();
                        string project = input.GetProject();
                        empOperation.AddEmployee(new Employee { Id = id, City = location, Role = jTitle, JoiningDate = jDate, Department = department, FirstName = firstName, LastName = lastName, Dob = dob, Email = mail, Manager = manager, PhoneNumber = pNumber, Project = project });
                        break;
                    case "2":
                        DisplayAllEmployees();
                        break;
                    case "3":
                        Console.Write("Enter the info of employee you want to view");
                        string empId = input.GetId();
                        displaySpecific(empId);
                        break;
                     case "4":
                        Console.WriteLine("Enter the detail of employee to edit");
                        break;
                    case "5":
                        string emp_id = input.GetId();
                        empOperation.DeleteEmployee(emp_id);
                        break;

                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
        public  void DisplayAllEmployees()
        {
            List<Employee> employees = empOperation.GetAllEmployees();
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("There is no data available");
                return;
            }
            var table = new ConsoleTable("ID", "Name", "Role", "Department", "Location", "Joining Date", "Manager", "Project");
            foreach (Employee emp in employees)
            {
                table.AddRow(emp.Id, emp.FirstName + " " + emp.LastName, emp.Role, emp.Department, emp.City, emp.JoiningDate, emp.Manager, emp.Project);
            }
            Console.WriteLine(table.ToString());
        }
        public void displaySpecific(string id)
        {
            Employee emp = empOperation.GetEmployee(id);
            Console.WriteLine($"Name : {emp.FirstName} {emp.LastName} \n Id: {emp.Id} \n:Role:{emp.Role}\nDepartment:{emp.Department}\nLocation: {emp.City} \nJoining Date: {emp.JoiningDate}\nManager:{emp.Manager}\nDate of Birth:{emp.Dob}\nMobile Number:{emp.PhoneNumber}");
        }
        public void RoleManagment()
        {
            Console.WriteLine("\nRole Managment");
            Console.WriteLine("------------------");
            while (true)
            {
                Console.WriteLine("\n1.Add Role \n2.View All \n3.Go Back");
                Console.Write("Choose your choice : ");
                string choice=Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        string roleName = input.GetAlpabetInput("Role Name");
                        string description = input.GetAlpabetInput("Desciption");
                        string location = input.GetAlpabetInput("Location");
                        string department = input.GetAlpabetInput("department");
                        roleOperation.AddRole(new Models.Roles.Role { Name=roleName,Department=department,Description=description,Location=location});
                        break;
                        case "2":
                        DisplayAllRole();
                        break;
                        case "3":
                        return;
                        default: 
                        Console.WriteLine("Enter Valid input");
                        break;
                        
                }
            }
        }
        public void DisplayAllRole()
        {
            List<Models.Roles.Role> roles = roleOperation.GetAllRoles();
            if (roles == null || roles.Count == 0)
            {
                Console.WriteLine("There is no data available");
                return;
            }
            foreach (Models.Roles.Role role in roles)
            {
                Console.WriteLine($"\nRole :{role.Name}");
                Console.WriteLine($"Location :{role.Location}");
                Console.WriteLine($"Department : {role.Department}\n");
            }
        }
    }
}
