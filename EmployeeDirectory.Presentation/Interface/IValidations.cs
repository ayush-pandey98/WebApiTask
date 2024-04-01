using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Presentation.Interface
{
    interface IValidation
    {
        public bool ValidateId(string id);
        public bool ValidateName(string name);
        public bool ValidatePhoneNumber(string lastName);
        public bool ValidateEmail(string email);
        public bool ValidateLocation(string location);
        public bool ValidateDepartment(string department);
        public bool ValidateDob(string dob);
        public bool ValidateJoiningDate(string joiningDate);
        public bool ValidateRole(string role);
        
    }
}
