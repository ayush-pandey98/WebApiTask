using System.Globalization;
using System.Text.RegularExpressions;
using EmployeeDirectory.Presentation.Interface;


namespace EmployeeDirectory.Presentation.Validations
{
    public class Validation: IValidation
    {
        public bool ValidateId(string id)
        {
            return Regex.IsMatch(id!, @"^TZ\d{4}$") || id != "";
        }
        public bool ValidateName(string name)
        {
            return Regex.IsMatch(name, @"/^[A-Z][a-z0-9_-]{3,19}$/");
        }
        public bool ValidatePhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }
        public bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email!, @"^[a-zA-Z0-9._%+-]+([^a-zA-Z]*[A-Za-z]){4}.com$") || email != "";
        }
        public bool ValidateLocation(string location)
        {
           return Regex.IsMatch(location, @"/^[A-Z][a-z0-9_-]{3,19}$/");
        }
        public bool ValidateDepartment(string department)
        {
           return Regex.IsMatch(department, @"/^[A-Z][a-z0-9_-]{3,19}$/");
        }
        public bool ValidateDob(string dob)
        {
            DateTime date;
            return DateTime.TryParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) || dob == "";
        }
        public bool ValidateJoiningDate(string joiningDate)
        {
            DateTime date;
            return DateTime.TryParseExact(joiningDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) || joiningDate!= "";
        }
        public bool ValidateRole(string role)
        {
            return Regex.IsMatch(role, @"/^[A-Z][a-z0-9_-]{3,19}$/");
        }
    }
}
