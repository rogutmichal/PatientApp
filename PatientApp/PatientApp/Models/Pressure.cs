using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PatientApp.Models
{
    public  class Pressure
    {
        [PrimaryKey, AutoIncrement]
        public int press_id { get; set; }

        public int systolic_pressure { get; set; }

        public int diastolic_pressure { get; set; }

        public int heart_rate { get; set; }

        public DateTime press_date { get; set; }

        public string press_info { get; set; }
    }
}
