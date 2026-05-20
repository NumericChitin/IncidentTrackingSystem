using System;
using System.Collections.Generic;

namespace WinFormsApp2.Data.Models;

public partial class Incident
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Type { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly? DateResolved { get; set; }

    public string Description { get; set; } = null!;

    public virtual IncidentType TypeNavigation { get; set; } = null!;
}
