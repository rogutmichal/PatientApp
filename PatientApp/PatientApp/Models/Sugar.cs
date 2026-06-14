using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientApp.Models
{
    public  class Sugar
    {

        [PrimaryKey, AutoIncrement]
        public int sugar_id { get; set; }

        public int sugar { get; set; }

        public DateTime sugar_date { get; set; }

        public string sugar_info { get; set; }
    }
}
