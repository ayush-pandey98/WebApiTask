
namespace EmployeeDirectory.Models.Roles
{
    public class Role
    {
        public required string Name {  get; set; }
        public required string Description { get; set; }
        public required int Location {  get; set; }
        public required int Department {  get; set; } 
    }
}
