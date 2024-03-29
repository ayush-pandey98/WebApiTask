using System.Globalization;
using System.Text.RegularExpressions;
using EmployeeDirectory.Presentation.Interface;
using EmployeeDirectory.Bll.Interface;
namespace EmployeeDirectory.Presentation
    {
    public class Input : Iinput
        {
        private IRoleBL operation;
        public Input(IRoleBL operation)
        {
            this.operation = operation;
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
                   if(option== "e") return "exit";
            }
            }

            public string GetLocation()
            {
                string[] locations = operation.GetLocation().ToArray();
                return ChooseOption("Choose Location", locations);
            }

            public string GetRole(string location)
            {
                string[] roles = operation.GetRoleName(location).ToArray();
                return ChooseOption("Choose Role", roles);
            }

            public string GetDepartment(string location)
            {
                string[] departments = operation.GetDepartment(location).ToArray();
                return ChooseOption("Choose Department", departments);
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
                string id = Console.ReadLine()!;
                if (id == "e") return "exit";
                while (!Regex.IsMatch(id!, @"^TZ\d{4}$")||id=="")
                {
                if (id == "e") return "exit";
                if (id == "") Console.WriteLine("Id cannot be empty");
                else 
                    Console.WriteLine("Invalid input. Please enter a valid id of format TZ0000:");
                    id = Console.ReadLine()!;
                }
                return id;
            }
            public string GetAlpabetInput(string type)
            {
                Console.WriteLine("Enter "+type);
                string input = Console.ReadLine()!;
                  if (input == "e") return "exit";
            while (!Regex.IsMatch(input!, @"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$")||input=="")
                {
                if (input == "e") return "exit";
                if (type == "Desciption" && input == "") break;
                    if(input=="")Console.WriteLine(type+" cannot be empty");
                    else
                    Console.WriteLine("Please enter a valid name:");
                    input = Console.ReadLine()!;
                }
                return input;
            }
            public string GetEmail()
            {
                Console.WriteLine("Enter email(name@tezo.com):");
                string email = Console.ReadLine()!;
                 if (email == "e") return "exit";
            while (!Regex.IsMatch(email!, @"^[a-zA-Z0-9._%+-]+([^a-zA-Z]*[A-Za-z]){4}.com$") ||email=="")
                {
                if (email == "e") return "exit";
                if (email == "") Console.WriteLine("Email cannot be empty");
                else
                    Console.WriteLine("Invalid email format. Please enter a valid email(name@Tezo.com):");
                    email = Console.ReadLine()!;
                }
                return email;
            }
            public string GetPhone()
            {
                Console.WriteLine("Enter phone number:");
                string phoneNumber = Console.ReadLine()!;
                 if (phoneNumber == "e") return "exit";
            while (!Regex.IsMatch(phoneNumber, @"^\d{10}$"))
                {
                if (phoneNumber == "e") return "exit";
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
                if (dateStr == "e") return "exit";
            DateTime date;
                while (!DateTime.TryParseExact(dateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)||dateStr=="")
                {
                if (dateStr == "e") return "exit";
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

