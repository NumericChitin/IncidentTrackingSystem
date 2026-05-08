using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Data.Models
{
    public class Technician
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? TypeSpecialised { get; set; } // Nullable според схемата
    }
}
