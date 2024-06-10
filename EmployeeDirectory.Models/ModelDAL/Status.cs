using System;
using System.Collections.Generic;

namespace EmployeeDirectory.Model.ModelDAL;

public partial class Status
{
    public int Id { get; set; }

    public string? Value { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
