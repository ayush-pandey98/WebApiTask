using ConsoleTables;
using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.Models;
using EmployeeDirectory.Presentation.Interface;
using EmployeeDirectory.BLL.Interface.employeeBL;
using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.Models.location;
using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.Models.department;
namespace EmployeeDirectory.Presentation
{
    public class PresentationLayer
    {
        private IDepartmentBL _departmentBL;
        private IEmployeeBL _employeeBL;
        private Iinput _input;
        private IRoleBL _roleBL;
        private ILocationBL _locationBL;
        static List<string> employeeManagmentOption=new List<string>() {"Go Back", "Add Employee", "Display all", "Display one", "Edit Employee", "Delete Employee"};
        static List<string> mainMenueOption = new List<string>() { "Exit", "Employee Management", "Role Management","Location Managment", "DepartmentManagment"};
        static List<string> roleManagmentOption = new List<string> { "Go Back", "Add Role", "Display All" };
        static List<string> locationManagmentOption = new List<string> { "Go Back", "Add Location", "View All Location" };
        static List<string> departmentManagmentOption = new List<string>
        {
            "Go Back", "Add Department", "View All Department"
        };
        static List<string> editEmpOptions = new List<string>() {"Go Back", "Save", "First Name", "Last Name", "Date Of Birth", "Email", "Phone Number", "Joining Dat", "Location", "Role", "Department", "Manager", "Project" };
        public PresentationLayer(IEmployeeBL _employeeBL,Iinput _input,IRoleBL _roleBL,ILocationBL _locationBL,IDepartmentBL _departmentBL) {
            this._departmentBL = _departmentBL;
            this._roleBL = _roleBL;
            this._employeeBL = _employeeBL;
            this._input = _input;
            this._locationBL = _locationBL;
        }

        public void Run()
        {

            Console.WriteLine("Employee Directory");
            Console.WriteLine("------------------");
            while (true)
            {
                for(int i=0;i<mainMenueOption.Count;i++)
                {
                    Console.WriteLine($"{i}.{mainMenueOption[i]}");
                }
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    case "1":
                        EmployeeManagment();
                        break;
                    case "2":
                        RoleManagment();
                        break;
                    case "3":
                        LocationManagment();
                        break;
                    case "4":
                        DepartmentManagment();
                        break;
                    default:
                        Console.WriteLine("Enter valid _input");
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
                for(int i=0; i < employeeManagmentOption.Count; i++)
                {
                    Console.WriteLine($"{i}.{employeeManagmentOption[i]}");
                }
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "0":
                        return;
                    case "1":
                        Console.WriteLine("To exit the option between selection press '0'");
                        Console.WriteLine("Enter Employee Details");
                        string id = IsAvailableId("add");
                        if (id == "exit") break;
                        string firstName = _input.GetAlpabetInput("First Name");
                        if (firstName == "exit") break;
                        string lastName = _input.GetAlpabetInput("Last Name");
                        if (lastName == "exit") break;
                        string dob = _input.GetDate("Date of birth");
                        if (dob == "exit") break;
                        string mail = _input.GetEmail();
                        if (mail == "exit") break;
                        string pNumber = _input.GetPhone();
                        if (pNumber == "exit") break;
                        string jDate = _input.GetDate("Joining date");
                        if (jDate == "exit") break;
                        string location = _input.GetLocation();
                        if (location == "exit") break;
                        string jTitle = _input.GetRole(location);
                        if (jTitle == "exit") break;
                        string department = _input.GetDepartment(location);
                        if (department == "exit") break;
                        string manager = _input.GetManager();
                        if (manager == "exit") break;
                        string project = _input.GetProject();
                        if (project == "exit") break;
                        _employeeBL.AddEmployee(new Employee { Id = id, City = location, Role = jTitle, JoiningDate = jDate, Department = department, FirstName = firstName, LastName = lastName, Dob = dob, Email = mail, Manager = manager, PhoneNumber = pNumber, Project = project });
                        break;
                    case "2":
                        DisplayAllEmployees();
                        break;
                    case "3":
                        Console.WriteLine("Display Specific \n----");
                        Console.Write("Enter the info of employee you want to view");
                        showAvailableId();
                        string empId = IsAvailableId("view one");
                        displaySpecific(_employeeBL.GetEmployee(empId));
                        break;
                     case "4":
                        Console.WriteLine("Edit \n----");
                        Console.WriteLine("To exit the option between selection press 'e'");
                        showAvailableId();
                        empId = IsAvailableId("edit");
                        editEmployee(_employeeBL.GetEmployee(empId), empId);
                        break;
                    case "5":
                        Console.WriteLine("Delete \n------");
                        showAvailableId();
                        string emp_id= _input.GetId();
                        if (emp_id == "exit") break;
                        _employeeBL.DeleteEmployee(emp_id);
                        break;
                    
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
        public  void DisplayAllEmployees()
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
                table.AddRow(emp.Id, emp.FirstName + " " + emp.LastName, emp.Role, emp.Department, emp.City, emp.JoiningDate, emp.Manager, emp.Project);
            }
            Console.WriteLine(table.ToString());
        }
        public void showAvailableId()
        {
            List<Employee> employees= _employeeBL.GetAllEmployees();
            if(employees==null || employees.Count==0)
            {
                Console.WriteLine("No ids avilable");
                return;
            }
            Console.WriteLine("\nThe avilable ids are:");
            Console.Write("|");
            foreach(Employee emp in employees)
            {
             Console.Write(" "+emp.Id+" "+"|");
            }
        }
        public void displaySpecific(Employee emp)
        {
            var table = new ConsoleTable("Name","ID","Role","Department","Location","Joining Date","Manger","Date Of Birth","Phone Number","Project");
            table.AddRow(emp.FirstName+" "+emp.LastName,emp.Id,emp.Role,emp.Department,emp.City,emp.JoiningDate,emp.Manager,emp.Dob,emp.PhoneNumber,emp.Project);
            Console.WriteLine(table.ToString());
        }
        public void RoleManagment()
        {
            Console.WriteLine("\nRole Managment");
            Console.WriteLine("------------------");
            while (true)
            {
                for(int i = 0; i < roleManagmentOption.Count; i++)
                {
                    Console.WriteLine($"{i}.{roleManagmentOption}");
                }
                Console.Write("Enter your choice : ");
                string choice=Console.ReadLine()!;
                switch(choice)
                {
                    case "0":
                        return;
                    case "1":
                        string roleName = _input.GetAlpabetInput("Role Name");
                        if (roleName == "exit") break;
                        string description = _input.GetAlpabetInput("Desciption");
                        if (description == "exit") break;
                        string location = _input.GetAlpabetInput("Location");
                        if (location == "exit") break;
                        string department = _input.GetAlpabetInput("department");
                        if (department == "exit") break;
                        _roleBL.AddRole(new Models.Roles.Role { Name=roleName,Department=department,Description=description,Location=location});
                        break;
                        case "2":
                        DisplayAllRole();
                        break;
                        default: 
                        Console.WriteLine("Enter Valid input");
                        break;
                        
                }
            }
        }
        public void DisplayAllRole()
        {
            List<Models.Roles.Role> roles = _roleBL.GetAllRoles();
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
                Console.WriteLine("\nTo exit the option between selection press '0'");
                for(int i = 0;i<editEmpOptions.Count;i++)
                {
                    Console.WriteLine($"{i}.{editEmpOptions[i]}");
                }
                string choice=Console.ReadLine()!;
                if (choice == "e") return;
                switch(choice)
                {
                    case "0":  break;
                    case "1":string firstName = _input.GetAlpabetInput("First Name");
                        if (firstName == "exit") break;
                        employee.FirstName = firstName;
                        break;
                    case "2":string lastName = _input.GetAlpabetInput("Last Name");
                        if (lastName == "exit") break;
                        employee.LastName= lastName;
                        break;
                    case "3":string dob = _input.GetDate("Date of birth");
                        if (dob == "exit") break;
                        employee.Dob = dob;
                        break;
                    case "4":string email = _input.GetEmail();
                        if (email == "exit") break;
                        employee.Email = email;
                        break;
                    case "5":string pNumber = _input.GetPhone();
                        if (pNumber == "exit") break;
                        employee.PhoneNumber = pNumber;
                        break;
                    case "6":string joiningDate = _input.GetDate("Joining date");
                        if (joiningDate == "exit") break;
                        employee.JoiningDate= joiningDate;
                        break;
                    case "7": string city = _input.GetLocation();
                        if (city == "exit") break;
                        employee.City = city;
                        break;
                    case "8":string role = _input.GetRole(employee.City);
                        if (role == "exit") break;
                        employee.Role = role;
                        break;
                    case "9":string department = _input.GetDepartment(employee.City);
                        if (department == "exit") break;
                        employee.Department = department;
                        break;
                    case "10":string manager = _input.GetManager();
                        if (manager == "exit") break;
                        employee.Manager = manager;
                        break;
                    case "11": string project = _input.GetProject();
                        if (project == "exit") break;
                        employee.Project = project;
                        break;
                     default: Console.WriteLine("Invalid _input"); break;
            }
                if(choice == "0") { break; }
            }
            _employeeBL.EditEmployee(employee,id);
        }
        string IsAvailableId(string type)
        {
            string id = _input.GetId();
            var employee = _employeeBL.GetEmployee(id);
            if (type.Equals("add"))
            {
                while (employee != null)
                {
                    Console.WriteLine("This employee already available");
                    id = _input.GetId();
                    employee = _employeeBL.GetEmployee(id);
                }
            }
            else
            {
                while (employee == null)
                {
                    Console.WriteLine("This employee is not available");
                    id = _input.GetId();
                    employee = _employeeBL.GetEmployee(id);
                }
            }
            return id;
        }
        void LocationManagment()
        {
            while (true)
            {
                for (int i = 0; i < locationManagmentOption.Count; i++)
                {
                    if(i==0) { Console.WriteLine(); }
                    Console.WriteLine($"{i}.{locationManagmentOption[i]}");
                }
                Console.WriteLine("\nTo exit the option between selection press '0'"); ;
                Console.Write("Choose the option:");
                string choice = Console.ReadLine()!;
                if (choice == "e") return;
                switch (choice)
                {
                    case "0": return;
                    case "1":
                        string location = _input.GetAlpabetInput("location");
                        int id = GetPreviousLocationId();
                      _locationBL.AddLocation(new Location{Id=id,Value=location});
                        break;
                    case "2":
                        DisplayAllLocation();
                        break;
                    default: Console.WriteLine("Enter Valid Input");
                        break;
                }
                }
          
        }
        void DisplayAllLocation()
        {
           var locations= _locationBL.GetAllLocation();
            foreach (var location in locations)
            {
                Console.WriteLine(location.Id +" "+location.Value);
            }
        }
        int GetPreviousLocationId()
        {
            var locations = _locationBL.GetAllLocation();
            if(locations==null) return 0;
            return locations[locations.Count-1].Id+1;
        }
        void DepartmentManagment()
        {
            while (true)
            {
                for (int i = 0; i < departmentManagmentOption.Count; i++)
                {
                    if (i == 0) { Console.WriteLine(); }
                    Console.WriteLine($"{i}.{departmentManagmentOption[i]}");
                }
                Console.WriteLine("\nTo exit the option between selection press '0'"); ;
                Console.Write("Choose the option:");
                string choice = Console.ReadLine()!;
                if (choice == "e") return;
                switch (choice)
                {
                    case "0": return;
                    case "1":
                        string department = _input.GetAlpabetInput("department");
                        int id = GetPreviousDepartmentId();
                        _departmentBL.AddDepartment(new Department { Id = id, Value = department });
                        break;
                    case "2":
                        DisplayAllDepartments();
                        break;
                    default:
                        Console.WriteLine("Enter Valid Input");
                        break;
                }
            }

        }
        void DisplayAllDepartments()
        {
            var departments = _departmentBL.GetAllDepartment();
            if(departments==null)
            {
                Console.WriteLine("No departments available");
                return;
            }
            foreach (var department in departments)
            {
                Console.WriteLine(department.Id + " " + department.Value);
            }
        }
        int GetPreviousDepartmentId()
        {
            var departments = _departmentBL.GetAllDepartment();
            if (departments == null) return 0;
            return departments[departments.Count - 1].Id + 1;
        }
    }
}
