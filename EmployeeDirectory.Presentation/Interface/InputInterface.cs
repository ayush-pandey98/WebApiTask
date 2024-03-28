
namespace EmployeeDirectory.Presentation.Interface
{
    public interface Iinput
    {
        string GetLocation();
        string GetRole(string location);
        string GetDepartment(string location);
        string GetProject();
        string GetManager();
        public string GetId();
        public string GetAlpabetInput(string input);
        public string GetEmail();
        public string GetPhone();
        public string GetDate(string type);

    }
}
