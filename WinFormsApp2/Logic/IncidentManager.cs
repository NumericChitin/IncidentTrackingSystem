using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsApp2.Data.Models;

namespace WinFormsApp2
{
    public class IncidentManager
    {
        public event EventHandler<IncidentEventArgs>? IncidentCreated;
        public event EventHandler<IncidentEventArgs>? IncidentAssigned;
        public event EventHandler<IncidentEventArgs>? IncidentResolved;
        public event EventHandler<IncidentEventArgs>? CriticalIncidentDetected;

        // Пазим връзката Инцидент(ID) -> Техник(ID) в паметта
        public Dictionary<int, int> ActiveAssignments { get; } = new();
        // Пазим колко инцидента е разрешил всеки техник
        public Dictionary<int, int> ResolvedStats { get; } = new();

        public void CreateIncident(Incident incident)
        {
            OnIncidentCreated(new IncidentEventArgs(incident, $"Създаден е нов инцидент: {incident.Name}"));

            if (incident.Type == 1 || incident.Description.Contains("Критичен", StringComparison.OrdinalIgnoreCase))
            {
                OnCriticalIncidentDetected(new IncidentEventArgs(incident, "ВНИМАНИЕ: Открит е критичен инцидент!"));
            }
        }

        public void AssignTechnician(Incident incident, Technician tech)
        {
            if (ActiveAssignments.ContainsKey(incident.Id))
                throw new InvalidOperationException("Този инцидент вече има назначен техник.");

            if (ActiveAssignments.ContainsValue(tech.Id))
                throw new InvalidOperationException("Този техник вече работи по друг инцидент.");

            ActiveAssignments[incident.Id] = tech.Id;
            OnIncidentAssigned(new IncidentEventArgs(incident, $"Инцидент '{incident.Name}' е назначен на '{tech.Name}'."));
        }

        public void ResolveIncident(Incident incident)
        {
            incident.DateResolved = DateOnly.FromDateTime(DateTime.Now);

            // Обновяваме статистиката
            if (ActiveAssignments.TryGetValue(incident.Id, out int techId))
            {
                if (!ResolvedStats.ContainsKey(techId)) ResolvedStats[techId] = 0;
                ResolvedStats[techId]++;
                ActiveAssignments.Remove(incident.Id); // Освобождаваме техника
            }

            OnIncidentResolved(new IncidentEventArgs(incident, $"Инцидент '{incident.Name}' е маркиран като разрешен."));
        }

        protected virtual void OnIncidentCreated(IncidentEventArgs e) => IncidentCreated?.Invoke(this, e);
        protected virtual void OnIncidentAssigned(IncidentEventArgs e) => IncidentAssigned?.Invoke(this, e);
        protected virtual void OnIncidentResolved(IncidentEventArgs e) => IncidentResolved?.Invoke(this, e);
        protected virtual void OnCriticalIncidentDetected(IncidentEventArgs e) => CriticalIncidentDetected?.Invoke(this, e);
    }
}