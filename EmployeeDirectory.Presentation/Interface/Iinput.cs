
namespace EmployeeDirectory.Presentation.Interface
{
    public interface Iinput
    {
        int GetRoleSpecificLocation(string roleName);
        string GetRole();
        int GetRoleSpecificDepartment(string roleName);
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
