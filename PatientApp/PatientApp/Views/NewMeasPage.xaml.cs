using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMeasPage : ContentPage
    {
        public NewMeasPage()
        {
            InitializeComponent();
        }

        double bmi;

        protected override void OnAppearing()
        {
            measTimePicker.Time = DateTime.Now.TimeOfDay;

        }

        private void Calculate()
        {
            double height = 0;
            double weight = 0;

            height = double.Parse(heightEntry.Text);
      
             weight = double.Parse(weightEntry.Text);


            bmi = weight / (height * height) * 10000;
            bmi = Math.Round(bmi, 2);

            bmiEntry.Text = bmi.ToString();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {

            if(heightEntry.Text == null || weightEntry.Text == null || bmiEntry.Text == null)
            {
                await DisplayAlert("Uwaga", "Wypełnij wszystkie pola", "OK");
                return;
            }

            if(Convert.ToInt32(heightEntry.Text) < 0 || Convert.ToInt32(heightEntry.Text) > 300)
            {
                await DisplayAlert("Uwaga!", "Podaj prawidłowy wzrost!", "OK");
                return;
            }

            if (Convert.ToInt32(weightEntry.Text) < 0 || Convert.ToInt32(weightEntry.Text) > 1000)
            {
                await DisplayAlert("Uwaga!", "Podaj prawidłową wagę", "OK");
                return;
            }

            try
            { 
                string bmi_info;

                if (bmi < 16)
                {
                    bmi_info = "wygłodzenie";
                }

                else if (bmi < 16.9)
                {
                    bmi_info = "wychudzenie";
                }

                else if (bmi < 18.5)
                {
                    bmi_info = "niedowaga";
                }

                else if (bmi < 24.9)
                {
                    bmi_info = "prawidłowo";
                }

                else if (bmi < 29.9)
                {
                    bmi_info = "nadwaga";
                }

                else if (bmi < 34.9)
                {
                    bmi_info = "otyłość I";
                }

                else if (bmi < 39.9)
                {
                    bmi_info = "otyłość II";
                }

                else
                {
                    bmi_info = "otyłość III";
                }
                 
                await App.Database.SaveMeasurement(new Models.Measurement
                {

                    height = double.Parse(heightEntry.Text),
                    weight = double.Parse(weightEntry.Text),
                    bmi = double.Parse(bmiEntry.Text),
                    meas_date = measDataPicker.Date + measTimePicker.Time,
                    meas_info = bmi_info,



                }); ;


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

        private async void OnBMIButtonClicked(object sender, EventArgs e)
        {
            if (heightEntry.Text == null || weightEntry.Text == null)
            {
                await DisplayAlert("Uwaga", "Podaj wzrost i wagę", "OK");
                return;
            }
            if (Convert.ToInt32(heightEntry.Text) < 0 || Convert.ToInt32(heightEntry.Text) > 300)
            {
                await DisplayAlert("Uwaga!", "Podaj prawidłowy wzrost!", "OK");
                return;
            }

            if (Convert.ToInt32(weightEntry.Text) < 0 || Convert.ToInt32(weightEntry.Text) > 1000)
            {
                await DisplayAlert("Uwaga!", "Podaj prawidłową wagę", "OK");
                return;
            }

            Calculate();
        }

       
    }
}