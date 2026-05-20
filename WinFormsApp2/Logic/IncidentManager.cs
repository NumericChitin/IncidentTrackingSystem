using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2.Data.Models;
using WinFormsApp2.EventArgsClasses;

namespace WinFormsApp2.Logic
{
    public class IncidentManager
    {
        // Дефиниране на събитията
        public event EventHandler<IncidentEventArgs> IncidentCreated;
        public event EventHandler<IncidentEventArgs> IncidentAssigned;
        public event EventHandler<IncidentEventArgs> IncidentResolved;
        public event EventHandler<IncidentEventArgs> CriticalIncidentDetected;

        public void CreateIncident(Incident incident)
        {
            // Логика за запис в базата (чрез DatabaseService) би дошла тук
            OnIncidentCreated(new IncidentEventArgs(incident, $"Нов инцидент: {incident.Name}"));

            // Примерна проверка за критичност (напр. ако типът е 999 или съдържа ключова дума)
            if (incident.Description.Contains("CRITICAL") || incident.Type == 1)
            {
                OnCriticalIncidentDetected(new IncidentEventArgs(incident, "ВНИМАНИЕ: Открит критичен инцидент!"));
            }
        }

        public void AssignTechnician(Incident incident, Technician tech)
        {
            OnIncidentAssigned(new IncidentEventArgs(incident, $"Инцидентът е зачислен на техник: {tech.Name}"));
        }

        public void ResolveIncident(Incident incident)
        {
            incident.DateResolved = DateOnly.FromDateTime(DateTime.Now);
            OnIncidentResolved(new IncidentEventArgs(incident, $"Инцидентът '{incident.Name}' е успешно разрешен."));
        }

        // Защитени методи за вдигане на събитията
        protected virtual void OnIncidentCreated(IncidentEventArgs e) => IncidentCreated?.Invoke(this, e);
        protected virtual void OnIncidentAssigned(IncidentEventArgs e) => IncidentAssigned?.Invoke(this, e);
        protected virtual void OnIncidentResolved(IncidentEventArgs e) => IncidentResolved?.Invoke(this, e);
        protected virtual void OnCriticalIncidentDetected(IncidentEventArgs e) => CriticalIncidentDetected?.Invoke(this, e);
    }
}
