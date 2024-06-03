
namespace EmployeeDirectory.Models.ModelDAL;

public partial class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Location { get; set; }
    public int Department { get; set; }
}
