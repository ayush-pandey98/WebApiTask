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
                        string jTitle = input.GetRole(location);
                        string department = input.GetDepartment(location);
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
                        Console.WriteLine("Edit \n----");
                        showAvailableId();
                        empId = input.GetId();
                        var employee = empOperation.GetEmployee(empId);
                        while (employee == null)
                        {
                            Console.WriteLine("This employee is not available");
                            empId = input.GetId();
                            employee = empOperation.GetEmployee(empId);
                        }
                        editEmployee(employee,empId);
                        break;
                    case "5":
                        Console.WriteLine("Delete \n------");
                        showAvailableId();
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
        public void showAvailableId()
        {
            List<Employee> employees= empOperation.GetAllEmployees();
            if(employees==null || employees.Count==0)
            {
                Console.WriteLine("No ids avilable");
                return;
            }
            Console.WriteLine("The avilable ids are:");
            Console.Write("|");
            foreach(Employee emp in employees)
            {
             Console.Write(" "+emp.Id+" "+"|");
            }
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
            var table = new ConsoleTable("Role", "Location", "Description", "Department");
            foreach (Models.Roles.Role role in roles)
            {
                table.AddRow(role.Name,role.Location, role.Description,role.Department);
            }
            Console.WriteLine(table.ToString());
        }
        public void editEmployee(Employee employee,string id)
        {
            while (true)
            {
                Console.Write("Choose the informations your want change :");
                Console.WriteLine("\n0.Save  \n1.First Name \n2.Last Name \n3.Date Of Birth \n4.Email \n5.Phone Number \n6.Joining Date \n7.Location \n8.Role \n9.Department \n10.Manager \n11.Project");
                string choice=Console.ReadLine()!;
                switch(choice)
                {
                    case "0":  break;
                    case "1":string firstName = input.GetAlpabetInput("First Name");
                        employee.FirstName = firstName;
                        break;
                    case "2":string lastName = input.GetAlpabetInput("Last Name");
                        employee.LastName= lastName;
                        break;
                    case "3":string dob = input.GetDate("Date of birth");
                        employee.Dob = dob;
                        break;
                    case "4":string email = input.GetEmail(); 
                        employee.Email = email;
                        break;
                    case "5":string pNumber = input.GetPhone();
                        employee.PhoneNumber = pNumber;
                        break;
                    case "6":string joiningDate = input.GetDate("Joining date");
                        employee.JoiningDate= joiningDate;
                        break;
                    case "7": string city = input.GetLocation();
                        employee.City = city;
                        break;
                    case "8":string role = input.GetRole(employee.City);
                        employee.Role = role;
                        break;
                    case "9":string department = input.GetDepartment(employee.City); 
                        employee.Department = department;
                        break;
                    case "10":string manager = input.GetManager();
                        employee.Manager = manager;
                        break;
                    case "11": string project = input.GetProject();
                        employee.Project = project;
                        break;
                     default: Console.WriteLine("Invalid Input"); break;
            }
                if(choice == "0") { break; }
            }
            empOperation.EditEmployee(employee,id);
        }
    }
}
