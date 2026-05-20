using System;
using System.Collections.Generic;

namespace WinFormsApp2.Data.Models;

public partial class IncidentType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();

    public virtual ICollection<Technician> Technicians { get; set; } = new List<Technician>();
}
