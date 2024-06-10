
namespace EmployeeDirectory.Models.Presentation.Employee
{
    public class EmployeeDto
    {
        public required string Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? Dob { get; set; }
        public string? PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
        public int LocationId { get; set; }
        public required string LocationName { get; set; }
        public required string DepartmentName { get; set; }
        public required string JoiningDate { get; set; }
        public required int  DepartmentId { get; set; }
        public string? ManagerId { get; set; }
        public string? ManagerName {  get; set; }
        public int? Project { get; set; }
    }
}
