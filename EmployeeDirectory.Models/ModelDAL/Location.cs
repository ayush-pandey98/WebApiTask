

namespace EmployeeDirectory.Model.ModelDAL;

public partial class Location
{
    public int Id { get; set; }

    public string LocationName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<RoleDetail> RoleDetails { get; set; } = new List<RoleDetail>();
}
