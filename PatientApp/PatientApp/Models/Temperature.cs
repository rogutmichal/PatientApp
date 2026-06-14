using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientApp.Models
{
    public class Temperature
    {
        [PrimaryKey, AutoIncrement]
        public int temp_id { get; set; }
        
        public double temperature { get; set; }

        public DateTime temp_date { get; set; }

        public string info { get; set; }
    }
}
