﻿using System;
using System.Collections.Generic;

namespace EmployeeDirectory.Model.ModelDAL;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<RoleDetail> RoleDetails { get; set; } = new List<RoleDetail>();
}
