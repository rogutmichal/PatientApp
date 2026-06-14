using PatientApp.ViewModels;
using PatientApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PatientApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewTempPage), typeof(NewTempPage));
            Routing.RegisterRoute(nameof(NewPressPage), typeof(NewPressPage));
            Routing.RegisterRoute(nameof(NewSugarPage), typeof(NewSugarPage));
            Routing.RegisterRoute(nameof(NewMeasPage), typeof(NewMeasPage));
            Routing.RegisterRoute(nameof(CalendarPage), typeof(CalendarPage));




            Routing.RegisterRoute(nameof(TemperaturePage), typeof(TemperaturePage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
