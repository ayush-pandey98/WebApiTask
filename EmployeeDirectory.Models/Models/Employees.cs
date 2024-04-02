namespace EmployeeDirectory.Models
{
        public class Employee
        {
            public required string Id { get; set; }
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
            public required string Email { get; set; }
            public required string Dob { get; set; }
            public required string PhoneNumber { get; set; }
            public required string Role { get; set; }
            public required int City { get; set; }
            public required string JoiningDate { get; set; }
            public required int Department { get; set; }
            public required string Manager { get; set; }
            public required string Project { get; set; }
        }
}
