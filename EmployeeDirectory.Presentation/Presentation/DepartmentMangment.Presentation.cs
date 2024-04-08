using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.Models.department;
using EmployeeDirectory.Presentation.Interface;

namespace EmployeeDirectory.Presentation.Presentation
{
    public class DepartmentMangment
    {
        private Iinput _input;
        private Constants.Constants _constants;
        private IDepartmentBL _departmentBL;
        public DepartmentMangment(Iinput _input,Constants.Constants _constants,IDepartmentBL _departmentBL) { 
            this._input = _input;
            this._constants = _constants;
            this._departmentBL = _departmentBL;
        }

       public void Managment()
        {
            while (true)
            {
                for (int i = 0; i < _constants.departmentManagmentOption.Count; i++)
                {
                    if (i == 0) { Console.WriteLine(); }
                    Console.WriteLine($"{i}.{_constants.departmentManagmentOption[i]}");
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
       private int GetNextDepartmentId()
        {
            var departments = _departmentBL.GetAllDepartment();
            if (departments == null) return 0;
            return departments[departments.Count - 1].Id + 1;
        }
        private void DisplayAllDepartments()
        {
            _input.GetAllLocation();
            var departments = _departmentBL.GetAllDepartment();
            if (departments == null)
            {
                Console.WriteLine("No departments available");
                return;
            }
            foreach (var department in departments)
            {
                Console.WriteLine(department.Id + " " + department.Value);
            }
        }

    }
}
