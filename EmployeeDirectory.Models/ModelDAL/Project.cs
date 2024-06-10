using System;
using System.Collections.Generic;

namespace EmployeeDirectory.Model.ModelDAL;
public partial class Project
{
    public int Id { get; set; }

    public string? ProjectName { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
