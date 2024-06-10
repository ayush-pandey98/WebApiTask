using System;
using System.Collections.Generic;

namespace EmployeeDirectory.Model.ModelDAL;

public partial class Employee
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Dob { get; set; }

    public string? JoiningDate { get; set; }

    public int RoleDetailId { get; set; }

    public int? ProjectId { get; set; }

    public string? ManagerId { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? ProfilePic { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Employee? Manager { get; set; }

    public virtual Project? Project { get; set; }

    public virtual RoleDetail? RoleDetail { get; set; }

    public virtual Status? Status { get; set; }
}
