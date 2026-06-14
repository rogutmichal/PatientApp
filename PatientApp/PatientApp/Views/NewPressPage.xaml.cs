using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPressPage : ContentPage
    {
        public NewPressPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            pressTimePicker.Time = DateTime.Now.TimeOfDay;

        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (gorneEntry.Text == null || dolneEntry.Text == null || heartEntry.Text == null)
            {
                await DisplayAlert("Uwaga", "Wypełnij wszystkie pola", "OK");
                return;
            }

            if (Convert.ToInt32(gorneEntry.Text) <= 0 || Convert.ToInt32(gorneEntry.Text) > 300)
            {
                await DisplayAlert("Uwaga!", "Podaj prawidłowe ciśnienie górne!", "OK");
                return;
            }

            if (Convert.ToInt32(dolneEntry.Text) <= 0 || Convert.ToInt32(dolneEntry.Text) > 300)
            {
                await DisplayAlert("Uwaga!", "Podaj prawidłowe ciśnienie dolne", "OK");
                return;
            }
            if (Convert.ToInt32(heartEntry.Text) <= 0 || Convert.ToInt32(heartEntry.Text) > 300)
            {
                await DisplayAlert("Uwaga!", "Podaj prawidłowy puls", "OK");
                return;
            }

            try
            {               
                    int sys = int.Parse(gorneEntry.Text);
                    int dia = int.Parse(dolneEntry.Text);

                    string press_info;

                    if (sys <= 120 && dia <=80)
                    {
                        press_info = "optymalne";
                    }

                    else if (sys < 129 && dia <84 )
                    {
                        press_info = "prawidłowe";
                    }

                    else if (sys < 139 && dia < 89)
                    {
                        press_info = "wysokie";
                    }

                else if (sys < 159 && dia < 99)
                {
                    press_info = "nadciśnienie 1";
                }

                else if(sys < 179 && dia < 109)
                    {
                        press_info = "nadciśnienie 2";
                    }

                else
                {
                    press_info = "nadciśnienie 3";
                }

                await App.Database.SavePressure(new Models.Pressure
                {

                    systolic_pressure = int.Parse(gorneEntry.Text),
                    diastolic_pressure = int.Parse(dolneEntry.Text),
                    heart_rate = int.Parse(heartEntry.Text),
                    press_date = pressDataPicker.Date + pressTimePicker.Time,
                    press_info = press_info,

                }) ; ;


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