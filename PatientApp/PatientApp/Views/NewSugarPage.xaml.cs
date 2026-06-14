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
    public partial class NewSugarPage : ContentPage
    {
        public NewSugarPage()
        {
            InitializeComponent();
            sugarTimePicker.Time = DateTime.Now.TimeOfDay;

        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {

            if (sugarEntry.Text == null)
            {
                await DisplayAlert("Uwaga", "Wypełnij wszystkie pola", "OK");
                return;
            }

            if (Convert.ToInt32(sugarEntry.Text) <= 0 || Convert.ToInt32(sugarEntry.Text) > 300)
            {
                await DisplayAlert("Uwaga!", "Podaj prawidłowy poziom cukru!", "OK");
                return;
            }

            

            try
            {

                int sug = int.Parse(sugarEntry.Text);
                string sugar_info;

                if (sug < 99)
                {
                    sugar_info = "prawidłowe";
                }

                
                else
                {
                    sugar_info = "wysoki";
                }

                await App.Database.SaveSugar(new Models.Sugar
                {
                    sugar = int.Parse(sugarEntry.Text),
                    sugar_date = sugarDataPicker.Date + sugarTimePicker.Time,
                    sugar_info = sugar_info
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