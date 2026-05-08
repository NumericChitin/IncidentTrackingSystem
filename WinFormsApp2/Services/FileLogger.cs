using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2.EventArgsClasses;

namespace WinFormsApp2.Services
{
    public class FileLogger
    {
        private string _filePath = "log.txt";

        public void LogEvent(object sender, IncidentEventArgs e)
        {
            string logEntry = $"[{e.Timestamp}] EVENT: {e.Message} (Incident ID: {e.Incident.ID})";

            // В реална среда тук ще записвате във файл:
            // File.AppendAllLines(_filePath, new[] { logEntry });

            Console.WriteLine($"[FileLogger]: {logEntry}");
        }
    }
}
