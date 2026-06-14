using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientApp.Views
{
    public partial class TemperaturePage : ContentPage
    {

        public TemperaturePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetAllTemperature();
        }

      


        async void OnButtonClicked(object sender, EventArgs e)
        {

            
            await Shell.Current.GoToAsync(nameof(NewTempPage));

          

            collectionView.ItemsSource = await
               App.Database.GetAllTemperature();

        }
        int IdInt;

        private async void OnDetailButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Models.Temperature)collectionView.SelectedItem;

                var idt = Convert.ToInt32(obj.temp_id);
                IdInt = Convert.ToInt32(idt);
                string date = obj.temp_date.ToString();
                string temp = obj.temperature.ToString();
                string info = obj.info.ToString();


                await Navigation.PushAsync(new TempDetail(IdInt, date, temp,info));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Uwaga!", "Wybierz prawidłowo pomiar!", "OK");
                return;
            }
        }
       

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Models.Temperature)collectionView.SelectedItem;

                var idt = Convert.ToInt32(obj.temp_id);
                IdInt = Convert.ToInt32(idt);


                await App.Database.DeleteTemperature<Models.Temperature>(IdInt);

                collectionView.ItemsSource = await
                 App.Database.GetAllTemperature();
            }
            catch (Exception)
            {
                await DisplayAlert("Uwaga!", "Wybierz prawidłowo pomiar, który ma zostać usunięty", "OK");
                return;
            }
        }

        private  async void Filtr(object sender, EventArgs e)
        {
            try
            {
                if (picker.SelectedItem.ToString() == "Wszystkie")
                {
                    collectionView.ItemsSource = await
                App.Database.GetAllTemperature();
                }
                else
                {
                    collectionView.ItemsSource = await App.Database.FiltrTemperature(picker.SelectedItem.ToString()); ;
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Allert", ex.Message, "OK");
            }
        }



    }
}