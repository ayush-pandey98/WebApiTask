using EmployeeDirectory.BLL.Interface.departmentBL;
using EmployeeDirectory.Models.ModelDAL;
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
                Console.WriteLine();
                for (int i = 0; i < _constants.departmentManagmentOption.Count; i++)
                {
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
                        string department = _input.GetDepartment();
                        _departmentBL.AddDepartment(new Department { Value = department });
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
            if (departments == null|| departments.Count==0) return 0;
            return departments[departments.Count - 1].Id + 1;
        }
        private void DisplayAllDepartments()
        {
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
