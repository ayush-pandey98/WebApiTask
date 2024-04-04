namespace EmployeeDirectory.Models
{
        public class Employee
        {
            public  string Id { get; set; }
            public  string FirstName { get; set; }
            public  string LastName { get; set; }
            public  string Email { get; set; }
            public  string Dob { get; set; }
            public  string PhoneNumber { get; set; }
            public  string Role { get; set; }
            public  int City { get; set; }
            public  string JoiningDate { get; set; }
            public  int Department { get; set; }
            public  string Manager { get; set; }
            public  string Project { get; set; }
        }
}
