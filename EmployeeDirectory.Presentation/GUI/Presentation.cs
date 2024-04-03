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
    public partial class PresentationLayer
    {
        private IDepartmentBL _departmentBL;
        private IEmployeeBL _employeeBL;
        private Iinput _input;
        private IRoleBL _roleBL;
        private ILocationBL _locationBL;
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
                    if (i == 0) { Console.WriteLine(); }
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
                    if (i == 0) { Console.WriteLine(); }
                    Console.WriteLine($"{i}.{employeeManagmentOption[i]}");
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
        public void RoleManagment()
        {
            Console.WriteLine("\nRole Managment");
            Console.WriteLine("------------------");
            while (true)
            {
                for(int i = 0; i < roleManagmentOption.Count; i++)
                {
                    if (i == 0) { Console.WriteLine(); }
                    Console.WriteLine($"{i}.{roleManagmentOption[i]}");
                }
                Console.Write("Enter your choice : ");
                string choice=Console.ReadLine()!;
                switch(choice)
                {
                    case "0":
                        return;
                    case "1":
                        AddRole();
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
        public void editEmployee(Employee employee,string id)
        {
            while (true)
            {
                Console.Write("Choose the informations your want change :");
                Console.WriteLine("\nTo exit the option between selection press '0'");
                for(int i = 0;i<editEmpOptions.Count;i++)
                {
                    if (i == 0) { Console.WriteLine(); }
                    Console.WriteLine($"{i}.{editEmpOptions[i]}");
                }
                string choice=Console.ReadLine()!;
                editEmployeeOptions(employee,choice);
                if(choice == "0") { break;}
            }
            Console.WriteLine("Employee Edited Sucessfully");
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
                        int id = GetNextLocationId();
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
        int GetNextLocationId()
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
                        int id = GetNextDepartmentId();
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
        int GetNextDepartmentId()
        {
            var departments = _departmentBL.GetAllDepartment();
            if (departments == null) return 0;
            return departments[departments.Count - 1].Id + 1;
        }
        
    }
}
