using System;
using WinFormsApp2.Data.Models;

namespace WinFormsApp2
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