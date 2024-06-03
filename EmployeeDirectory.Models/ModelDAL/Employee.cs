
namespace EmployeeDirectory.Models.ModelDAL;
public partial class Employee
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Dob { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int Role { get; set; }
    public int City { get; set; }
    public string JoiningDate { get; set; } = null!;
    public int Department { get; set; }
    public string Manager { get; set; } = null!;
    public string Project { get; set; } = null!;
}
