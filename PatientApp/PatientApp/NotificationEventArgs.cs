using System;

namespace PatientApp
{
    public class NotificationEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}
