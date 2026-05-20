using System;
using System.Collections.Generic;

namespace WinFormsApp2.Data.Models;

public partial class Technician
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TypeSpecialised { get; set; }

    public virtual ICollection<DepartmentTechnician> DepartmentTechnicians { get; set; } = new List<DepartmentTechnician>();

    public virtual IncidentType? TypeSpecialisedNavigation { get; set; }
}
