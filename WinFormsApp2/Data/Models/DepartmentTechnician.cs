using System;
using System.Collections.Generic;

namespace WinFormsApp2.Data.Models;

public partial class DepartmentTechnician
{
    public int Id { get; set; }

    public int TechnicianId { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Technician Technician { get; set; } = null!;
}
