using Android.Content.PM;
using PatientApp.ViewModels;
using Java.Util;
using Newtonsoft.Json;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage

    {
       
        ViewModel viewModel = new ViewModel();
        INotificationManager notificationManager;


        public CalendarPage()
        {

            InitializeComponent();
            BindingContext = viewModel;
            notificationManager = DependencyService.Get<INotificationManager>();

        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            

        }



        private   void OnButtonClicked(object sender, EventArgs e)
        {

            notificationManager.SendNotification("Przypomnienie", TematEntry.Text, dateTimePicker.DateTime); 


        }

        void OnButtonClick(object sender, EventArgs e)
        {

            //string text = File.ReadAllText("/storage/emulated/0/Android/data/com.companyname.app2/abc.json");
            //CalendarEventCollection calendarInlineEvents = JsonConvert.DeserializeObject<CalendarEventCollection>(text);
            //CalendarEventCollection htmlAttributes = JsonConvert.DeserializeObject<CalendarEventCollection>(text);
            //calendar.DataSource = htmlAttributes;




        }
    }
}