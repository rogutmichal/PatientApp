using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientApp
{
    public class Event
    {
       [NotNull]
        public string Subject { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string AllDay { get; set; }
        public string Color { get; set; }
    }
}
