using EmployeeDirectory.Presentation.Presentation;
namespace EmployeeDirectory.Presentation
{
    public partial class PresentationLayer
    {
        private Constants.Constants _constants;
        private EmployeeManagment _empMangment;
        private RoleManagment _roleManagment;
        private DepartmentMangment _departmentMangment;
        private LocationManagment _locationManagment;
        public PresentationLayer(Constants.Constants _constants, EmployeeManagment _empMangment,RoleManagment _roleManagment, DepartmentMangment _departmentMangment,LocationManagment _locationManagment)
        {
            this._constants = _constants;
            this._empMangment = _empMangment;
            this._roleManagment = _roleManagment;
            this._departmentMangment = _departmentMangment;
            this._locationManagment = _locationManagment;
        }

        public void Run()
        {

            Console.WriteLine("Employee Directory");
            Console.WriteLine("------------------");
            while (true)
            {
                Console.WriteLine();
                for (int i=0;i<_constants.mainMenuOption.Count;i++)
                {
                    Console.WriteLine($"{i}.{_constants.mainMenuOption[i]}");
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
                        _empMangment.Managment();
                        break;
                    case "2":
                        _roleManagment.Managment();
                        break;
                    case "3":
                        _locationManagment.Managment();
                        break;
                    case "4":
                        _departmentMangment.Managment();
                        break;
                    default:
                        Console.WriteLine("Enter valid _input");
                        break;
                }
            }

        }
        
    }
}
