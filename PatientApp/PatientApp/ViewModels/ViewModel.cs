using SQLite;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PatientApp.ViewModels
{
    public class ViewModel: BaseViewModel
    {
        static SQLiteConnection database;
        string title;
        DateTime startDate;
        DateTime endDate;
        TimeSpan time;


        public CalendarEventCollection Meetings { get; set; }

            public ViewModel()
            {
            //Create connection
            database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);

            //Create table
                database.CreateTable<Event>();


            var currentDate = DateTime.Now.Date;


            //Insert data in to table 

            AddAppointments();

            SaveEvent = new Command(OnSave);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public DateTime StartDate
        {
            get => startDate;
            set => SetProperty(ref startDate, value);
        }

        public DateTime EndDate
        {
            get => endDate;
            set => SetProperty(ref endDate, value);
        }

        public TimeSpan Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }
        public Command SaveEvent { get; }
        /// <summary>
        /// Creates meetings and stores in a collection.  
        /// </summary>
        private void AddAppointments()
            {
                var table = (from i in database.Table<Event>() select i);
                Meetings = new CalendarEventCollection();
                foreach (var order in table)
                {
                    var EventName = order.Subject;
                    var From = DateTime.Parse(order.StartTime);
                    var To = DateTime.Parse(order.EndTime);
                    var AllDay = Convert.ToBoolean(order.AllDay);

                    Meetings.Add(new CalendarInlineEvent()
                    {
                        Subject = order.Subject,
                        StartTime = DateTime.Parse(order.StartTime),
                        EndTime = DateTime.Parse(order.EndTime),
                        Color = Color.FromHex(order.Color),
                        IsAllDay = Convert.ToBoolean(order.AllDay),
                    });
                }


            }
        private void OnSave()
        {
            try
            {

                Event newEvent = new Event()
                {
                    Subject = Title,
                    AllDay = "false",
                    Color = "#ffa500",
                    StartTime = StartDate.ToString(),
                    EndTime = EndDate.ToString(),



                };
                AddAppointments();
                database.Insert(newEvent);
            }
            catch(Exception)
            {
                App.Current.MainPage.DisplayAlert("Uwaga", "Podaj wszystkie dane", "OK");
                return;
            }


        }

        

        //public List<Event> GetAllEvents()
        //{
        //    return database.Table<Event>().ToList();
        //}

        public List<Event> GetAllEvents()
        {
            return database.Query<Event>("SELECT * FROM Event WHERE StartTime < DATE('now')");
        }

    }
    
}

