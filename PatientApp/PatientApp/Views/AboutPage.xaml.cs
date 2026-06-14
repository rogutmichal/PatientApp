using PatientApp.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientApp.Views
{
    public partial class AboutPage : ContentPage
    {
        ViewModel view = new ViewModel();
    public AboutPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource =  view.GetAllEvents();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CalendarPage));

        }
    }
}