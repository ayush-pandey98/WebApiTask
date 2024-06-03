using System.Text.RegularExpressions;
using EmployeeDirectory.Presentation.Interface;
using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.BLL.Interface.departmentBL;

namespace EmployeeDirectory.Presentation
{
    public class Input : Iinput
    {
        private IRoleBL _roleBL;
        private ILocationBL _locationBL;
        private IDepartmentBL _departmentBL;

        public Input(IRoleBL _roleBL, ILocationBL _locationBL, IDepartmentBL _departmentBL)
        {
            this._roleBL = _roleBL;
            this._locationBL = _locationBL;
            this._departmentBL = _departmentBL;
        }
        private string GetValidatedInput(string message, string pattern, bool required, string emptyMessage)
        {
            Console.WriteLine(message);
            string input;
            do
            {
                input = Console.ReadLine()!;
                if (input == "0") return "exit";
                if (input == "" && required)
                {
                    Console.WriteLine(emptyMessage);
                }
                else if (input == "" && !required) break;
                else if (!Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("Invalid input. Please enter a valid value:");
                }
            } while (!Regex.IsMatch(input, pattern) || input == "");
            return input;
        }
        public string ChooseOption(string message, string[] options)
        {
            Console.WriteLine(message);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            int optionIndex;
            while (true)
            {
                string option = Console.ReadLine()!;
                if (int.TryParse(option, out optionIndex) && optionIndex >= 1 && optionIndex <= options.Length)
                {
                    return options[optionIndex - 1];
                }
                if ((message == "Choose Project" || message == "Choose Manager") && option == "") { return "N/A"; }
                if (option == "0") return "exit";
                Console.WriteLine("Enter Valid input");
            }
        }
        public string GetRoleSpecificLocation(string roleName) =>
            ChooseOption("Choose Location", _roleBL.GetLocation(roleName).ToArray());

        public string GetRole() => ChooseOption("Choose Role", _roleBL.GetRoleName().ToArray());

        public string GetRoleSpecificDepartment(string roleName) =>
            ChooseOption("Choose Department", _roleBL.GetDepartment(roleName).ToArray());

        public string GetProject() => ChooseOption("Choose Project", new string[] { "Project 1", "Project 2", "Project 3" });

        public string GetManager() => ChooseOption("Choose Manager", new string[] { "Manager 1", "Manager 2", "Manager 3" });

        public string GetId() => GetValidatedInput("\nEnter id(TZxxxx):", @"^TZ\d{4}$",true, "Id cannot be empty");
        public string GetName(string type)=>
          GetValidatedInput($"Enter {type}", @"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$",true, $"{type} cannot be empty");
        public string GetDescription()=>
             GetValidatedInput($"Enter Description", @"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$",false, "");
        public string GetRoleName() => GetValidatedInput($"Enter Role Name", @"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$",true, "Role name cannot be empty");
        public string GetEmail() => GetValidatedInput("Enter email(name@tezo.com):", @"^[a-zA-Z0-9._%+-]+([^a-zA-Z]*[A-Za-z]){4}.com$", true,"Email cannot be empty");
        public string GetLocation() =>
             GetValidatedInput($"Enter Location", @"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$", true, "Location cannot be empty");
        public string GetDepartment()=>
            GetValidatedInput($"Enter Department", @"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$", true, "Department cannot be empty");
        public string GetAllLocation()
        {
            var locations = _locationBL.GetAllLocation();
            Console.WriteLine("Choose Location");
            int index = 1;
            foreach (var location in locations)
            {
                Console.WriteLine($"{index++}. {location.Value}");
            }

            while (true)
            {
                string option = Console.ReadLine()!;
                int optionIndex;
                if (int.TryParse(option, out optionIndex) && optionIndex >= 1 && optionIndex <= locations.Count())
                {
                    return locations[optionIndex - 1].Value;
                }
                if (optionIndex == 0) return "exit";
                Console.WriteLine("Invalid input");
            }
        }
        public string GetAllDepartment()
        {
            var departments = _departmentBL.GetAllDepartment();
            Console.WriteLine("Choose Department");
            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {departments[i].Value}");
            }
            while (true)
            {
                string option = Console.ReadLine()!;
                int optionIndex;

                if (int.TryParse(option, out optionIndex) && optionIndex >= 1 && optionIndex <= departments.Count)
                {
                    return departments[optionIndex - 1].Value;
                }
                if (optionIndex == 0) return "exit";
                Console.WriteLine("Invalid input");
            }
        }
        public string GetPhone() => GetValidatedInput("Enter phone number:", @"^\d{10}$",false,"");
        public string GetJoiningDate() => GetValidatedInput("Enter joining date(dd/mm/yyyy):", @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/((19|20)\d\d)$", true, "Joining Date cannot be empty");
        public string GetBirthDate() => GetValidatedInput("Enter birth date(dd/mm/yyyy):", @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/((19|20)\d\d)$", false, "");
        
    }
}
