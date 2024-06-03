
namespace EmployeeDirectory.Presentation.Interface
{
    public interface Iinput
    {
        public string GetRoleName();
        public string GetDescription();
        string GetName(string type);
        string GetRoleSpecificLocation(string roleName);
        string GetRole();
        string GetRoleSpecificDepartment(string roleName);
        string GetProject();
        string GetManager();
        string GetId();
        string GetEmail();
        public string GetLocation();
        public string GetDepartment();
        public string GetJoiningDate();
        public string GetBirthDate();
        public string GetPhone();
        string GetAllLocation();
        string GetAllDepartment();

    }
}
