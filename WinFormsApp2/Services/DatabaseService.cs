using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WinFormsApp2.Data.Models;

namespace WinFormsApp2
{
    public class DatabaseService
    {
        public List<Incident> GetAllIncidents()
        {
            using var context = new IncidentDbContext();
            return context.Incidents.Include(i => i.TypeNavigation).ToList();
        }

        public List<Technician> GetAllTechnicians()
        {
            using var context = new IncidentDbContext();
            return context.Technicians.Include(t => t.DepartmentTechnicians).ToList();
        }

        public List<Department> GetDepartments()
        {
            using var context = new IncidentDbContext();
            return context.Departments.ToList();
        }

        public void AddIncident(Incident incident)
        {
            using var context = new IncidentDbContext();
            context.Incidents.Add(incident);
            context.SaveChanges();
        }

        public void UpdateIncident(Incident incident)
        {
            using var context = new IncidentDbContext();
            var existing = context.Incidents.Find(incident.Id);
            if (existing != null)
            {
                existing.DateResolved = incident.DateResolved;
                context.SaveChanges();
            }
        }
    }
}