using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2.Data.Models;

namespace WinFormsApp2.Services
{
    public class DatabaseService
    {
        public void SaveIncident(Incident incident)
        {
            // Тук би се намирал ADO.NET или Entity Framework код за връзка с SQL Server
            Console.WriteLine($"[Database]: Инцидент '{incident.Name}' е записан в базата данни.");
        }

        public void UpdateIncidentStatus(int id, bool resolved)
        {
            Console.WriteLine($"[Database]: Статусът на инцидент {id} е обновен.");
        }
    }
}
