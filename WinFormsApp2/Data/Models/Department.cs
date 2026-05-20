using System;
using System.Collections.Generic;

namespace WinFormsApp2.Data.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DepartmentTechnician> DepartmentTechnicians { get; set; } = new List<DepartmentTechnician>();
}
