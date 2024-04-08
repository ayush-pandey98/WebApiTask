
namespace EmployeeDirectory.Presentation.Interface
{
    public interface Iinput
    {
        string GetRoleSpecificLocation(string roleName);
        string GetRole();
        string GetRoleSpecificDepartment(string roleName);
        string GetProject();
        string GetManager();
        public string GetId();
        public string GetAlpabetInput(string input);
        public string GetEmail();
        public string GetPhone();
        public string GetDate(string type);
        public string GetAllLocation();
        public string GetAllDepartment();

    }
}
