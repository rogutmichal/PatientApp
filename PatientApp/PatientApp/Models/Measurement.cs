using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientApp.Models
{
    public class Measurement
    {
        [PrimaryKey, AutoIncrement]
        public int meas_id { get; set; }

        public double height { get; set; }

        public double weight { get; set; }

        public double bmi { get; set; }


        public DateTime meas_date { get; set; }

        public string meas_info { get; set; }
    }
}
