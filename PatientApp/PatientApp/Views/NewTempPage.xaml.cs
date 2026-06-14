using PatientApp.Models;
using PatientApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientApp.Views
{
    public partial class NewTempPage : ContentPage 
    {

        public NewTempPage()
        {
            InitializeComponent();
            tempTimePicker.Time = DateTime.Now.TimeOfDay;

        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            
            if (temperatureEntry.Text == null)
            {
                await DisplayAlert("Uwaga", "Wypełnij wszystkie pola", "OK");
                return;
            }

            if (Convert.ToInt32(temperatureEntry.Text) <= 0 || Convert.ToInt32(temperatureEntry.Text) > 50)
            {
                await DisplayAlert("Uwaga!", "Podaj prawidłowy pomiar temperatury", "OK");
                return;
            }

            try
            {

                double temp = double.Parse(temperatureEntry.Text);
                string temp_info;

                if (temp <= 37)
                {
                    temp_info = "prawidłowo";
                }

                else if (temp < 38)
                {
                    temp_info = "podgorączkowy";
                }


                else
                {
                    temp_info = "gorączka";
                }

                await App.Database.SaveTemperature(new Models.Temperature
                {
                    temperature = double.Parse(temperatureEntry.Text),
                    temp_date = tempDataPicker.Date + tempTimePicker.Time,
                    info = temp_info
                });


            }
            catch (Exception ex)
            {
                await DisplayAlert("Allert", ex.Message, "OK");
            }
            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");

        }

    }
}