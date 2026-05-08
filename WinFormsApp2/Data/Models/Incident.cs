using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Data.Models
{
    public class Incident
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; } // Външен ключ към IncidentTypes
        public DateTime DateCreated { get; set; }
        public DateTime? DateResolved { get; set; } // Nullable, защото може още да не е решен
        public string Description { get; set; }
    }
}
