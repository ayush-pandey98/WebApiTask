using EmployeeDirectory.Bll.Interface.roleBL;
using EmployeeDirectory.Models.Presentation.Role;
using EmployeeDirectory.Presentation.Interface;

namespace EmployeeDirectory.Presentation.Presentation
{
    public class RoleManagment
    {
        private Iinput _input;
        IRoleBL _roleBL;
        private Helper _helper;
        private Constants.Constants _constants;
        public RoleManagment(Iinput _input,IRoleBL _roleBL,Helper _helper, Constants.Constants _constants) { 
            this._input = _input;
            this._roleBL = _roleBL;
            this._helper = _helper;
            this._constants = _constants;
            }
        public void Managment()
        {
            Console.WriteLine("\nRole Managment");
            Console.WriteLine("------------------");
            while (true)
            {
                for (int i = 0; i < _constants.roleManagmentOption.Count; i++)
                {
                    if (i == 0) { Console.WriteLine(); }
                    Console.WriteLine($"{i}.{_constants.roleManagmentOption[i]}");
                }
                Console.Write("Enter your choice : ");
                string choice = Console.ReadLine()!;
                switch (choice)
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

        private Dictionary<string, Func<string>> GetRoleInputDetails()
        {
            Dictionary<string, Func<string>> roleDetails = new Dictionary<string, Func<string>>
        {
                {"Name" ,()=>_input.GetAlpabetInput("Role Name") },
                {"Description",()=>_input.GetAlpabetInput("Desciption") } ,
                {"Location" ,()=>_input.GetAllLocation() },
                {"Department",()=> _input.GetAllDepartment()}
        };
            return roleDetails;
        }
        private void DisplayAllRole()
        {
            List<RoleModelPresentation> roles = _roleBL.GetAllRoles();
            if (roles == null || roles.Count == 0)
            {
                Console.WriteLine("There is no data available");
                return;
            }
            string table = _helper.BuildRoleTable(roles);
            Console.WriteLine(table.ToString());
        }
       private void AddRole()
        {
            var roleDetails = GetRoleInputDetails();
            Console.WriteLine("To exit the option between selection press '0'");
            Console.WriteLine("Enter Role Details");
            RoleModelPresentation role = new RoleModelPresentation();
            foreach (var roleInfo in typeof(RoleModelPresentation).GetProperties())
            {
                var input = roleDetails[roleInfo.Name]();
                if (input.Equals("exit") || input.Equals(-1)) return;
                roleInfo.SetValue(role, input);

            }
            _roleBL.AddRole(role);
        }
    }
}
