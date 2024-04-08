using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Models.Presentation.Employee
{
    public class EmployeeModelPresentation
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string City { get; set; }
        public string JoiningDate { get; set; }
        public string  Department { get; set; }
        public string Manager { get; set; }
        public string Project { get; set; }
    }
}
