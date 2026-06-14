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
    public partial class MeasurementPage : ContentPage
    {
        public MeasurementPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetAllMeasurement();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync(nameof(NewMeasPage));
            collectionView.ItemsSource = await
             App.Database.GetAllMeasurement();

        }
        int IdInt = 0;

        private async void OnDetailButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Models.Measurement)collectionView.SelectedItem;

                var idt = Convert.ToInt32(obj.meas_id);
                IdInt = Convert.ToInt32(idt);
                string date = obj.meas_date.ToString();
                string height = obj.height.ToString();
                string weight = obj.weight.ToString();
                string bmi = obj.bmi.ToString();
                string info = obj.meas_info.ToString();


                await Navigation.PushAsync(new MeasDetailPage(IdInt, date, height, weight, bmi, info));
            }
            catch (Exception)
            {
                await DisplayAlert("Uwaga!", "Wybierz prawidłowo pomiar!", "OK");
                return;
            }
        }
     
        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            
            try
            {
                var obj = (Models.Measurement)collectionView.SelectedItem;

                var idt = Convert.ToInt32(obj.meas_id);
                IdInt = Convert.ToInt32(idt);


                await App.Database.DeleteMeasurement<Models.Measurement>(IdInt);

                collectionView.ItemsSource = await App.Database.GetAllMeasurement();

            }
            catch (Exception)
            {
                await DisplayAlert("Uwaga!", "Wybierz prawidłowo pomiar, który ma zostać usunięty", "OK");
                return;
            }
            
        }
    }
}