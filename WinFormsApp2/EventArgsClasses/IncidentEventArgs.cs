using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2.Data.Models;

namespace WinFormsApp2.EventArgsClasses
{
    public class IncidentEventArgs : EventArgs
    {
        public Incident Incident { get; }
        public string Message { get; }
        public DateTime Timestamp { get; }

        public IncidentEventArgs(Incident incident, string message)
        {
            Incident = incident;
            Message = message;
            Timestamp = DateTime.Now;
        }
    }
}
