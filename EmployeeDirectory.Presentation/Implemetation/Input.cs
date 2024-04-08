using System.Globalization;
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
            public Input(IRoleBL _roleBL,ILocationBL _locationBL,IDepartmentBL _departmentBL)
             {
              this._roleBL = _roleBL;
              this._locationBL = _locationBL;
              this._departmentBL = _departmentBL;
             }
            private string ChooseOption(string message, string[] options)
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
                   if ((message == "Choose Project" || message == "Choose Manager")&&option=="") { return "N/A"; }
                    Console.WriteLine("Enter Valid input");
                   if(option== "0") return "exit";
            }
            }
            public int GetRoleSpecificLocation(string roleName)
                {
                    int[] locations = _roleBL.GetLocation(roleName).ToArray();
                    Console.WriteLine("Choose Location");
                 for (int i = 0; i < locations.Length; i++)
                   {
                     Console.WriteLine($"{i + 1}. {_locationBL.GetLocationById(locations[i])}");
                   }

                 int optionIndex;
                 while (true)
                 {
                    string option = Console.ReadLine()!;
                    if (int.TryParse(option, out optionIndex) && optionIndex >= 1 && optionIndex <= locations.Length)
                     {
                        return locations[optionIndex - 1];
                     }
                  }
               }
            public string GetRole()
            {
                string[] roles = _roleBL.GetRoleName().ToArray();
                return ChooseOption("Choose Role", roles);
            }
            public int GetRoleSpecificDepartment(string roleName)
            {
                Console.WriteLine("Choose Department");
                int[] departments = _roleBL.GetDepartment(roleName).ToArray();
                  for (int i = 0; i < departments.Length; i++)
                   {
                    Console.WriteLine($"{i + 1}. {_departmentBL.GetDepartmentById(departments[i])}");
                   }

                 int optionIndex;
                  while (true)
                   {
                    string option = Console.ReadLine()!;
                      if (int.TryParse(option, out optionIndex) && optionIndex >= 1 && optionIndex <= departments.Length)
                      {    
                         return departments[optionIndex - 1];
                      }
                 }
             }
            public string GetProject()
            {
                string[] projects = { "Project 1", "Project 2", "Project 3" };
                return ChooseOption("Choose Project", projects);
            }
            public string GetManager()
            {
                string[] managers = { "Manager 1", "Manager 2", "Manager 3" };
                return ChooseOption("Choose Manager", managers);
            }
            public string GetId()
            {
                 Console.WriteLine("\nEnter id(TZ0000):");
                 string id;
                 do
                  {
                     id = Console.ReadLine()!;
                     if (id == "0") return "exit";
                     if (id == "") Console.WriteLine("Id cannot be empty");
                     else if(!Regex.IsMatch(id!, @"^TZ\d{4}$"))
                      Console.WriteLine("Invalid input. Please enter a valid id of format TZ0000:");

                  } while (!Regex.IsMatch(id!, @"^TZ\d{4}$") || id == "");
                 return id;
            }
            public string GetAlpabetInput(string type)
            {
                Console.WriteLine("Enter "+type);
                string input = Console.ReadLine()!;
                  if (input == "0") return "exit";
            while (!Regex.IsMatch(input!, @"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$")||input=="")
                {
                if (input == "0") return "exit";
                if (type == "Desciption" && input == "") break;
                    if(input=="")Console.WriteLine(type+" cannot be empty");
                    else
                    Console.WriteLine($"Please enter a valid {type}:");
                    input = Console.ReadLine()!;
                }
                return input;
            }
            public string GetEmail()
            {
                Console.WriteLine("Enter email(name@tezo.com):");
                string email = Console.ReadLine()!;
                 if (email == "0") return "exit";
            while (!Regex.IsMatch(email!, @"^[a-zA-Z0-9._%+-]+([^a-zA-Z]*[A-Za-z]){4}.com$") ||email=="")
                {
                if (email == "0") return "exit";
                if (email == "") Console.WriteLine("Email cannot be empty");
                else
                    Console.WriteLine("Invalid email format. Please enter a valid email(name@tezo.com):");
                    email = Console.ReadLine()!;
                }
                return email;
            }
            public string GetAllLocation()
           {
             var locations=_locationBL.GetAllLocation();
            Console.WriteLine("Choose Location");
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {locations[i].Value}");
            }
            while (true)
            {
                string option = Console.ReadLine()!;
                int optionIndex;

                if (int.TryParse(option, out optionIndex) && optionIndex >= 1 && optionIndex <= locations.Count)
                {
                    return locations[optionIndex - 1].Value;
                }
                if (optionIndex == 0) return "exit";
                Console.WriteLine("Invalid input");
            }
             }
            public string GetAllDepartment()
           {
            var departments=_departmentBL.GetAllDepartment();
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
            public string GetPhone()
            {
                Console.WriteLine("Enter phone number:");
                string phoneNumber = Console.ReadLine()!;
                 if (phoneNumber == "0") return "exit";
            while (!Regex.IsMatch(phoneNumber, @"^\d{10}$"))
                {
                if (phoneNumber == "0") return "exit";
                if (phoneNumber == "") break;
                    Console.WriteLine("Invalid phone number format. Please enter a valid phone number:");
                    phoneNumber = Console.ReadLine()!;
                }
                return phoneNumber;
            }
            public string GetDate(string type)
            {
                Console.WriteLine($"Enter {type} (dd/MM/yyyy):");
                string dateStr = Console.ReadLine()!;
                if (dateStr == "0") return "exit";
                DateTime date;
                while (!DateTime.TryParseExact(dateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)||dateStr=="")
                {
                if (dateStr == "0") return "exit";
                if (type.Equals("Joining date") && dateStr == "")
                {
                    Console.WriteLine($"{type} cannot be empty");
                }
                else if (type.Equals("Date of birth") && dateStr == "")
                {
                    return "N/A";
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the joining date in dd/MM/yyyy format:");
                }
                    dateStr = Console.ReadLine()!;
                }
                string dateString = date.ToString("dd/MM/yyyy");
                return dateString;

            }
        }
    }

