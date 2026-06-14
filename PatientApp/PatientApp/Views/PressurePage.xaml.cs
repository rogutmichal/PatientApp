using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientApp.Views
{
    public partial class PressurePage : ContentPage
    {
        public PressurePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetAllPressure();
        }




        async void OnButtonClicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync(nameof(NewPressPage));

            collectionView.ItemsSource = await
             App.Database.GetAllTemperature();


        }

   
        int IdInt;

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            try
            {

                var obj = (Models.Pressure)collectionView.SelectedItem;

                var idt = Convert.ToInt32(obj.press_id);
                IdInt = Convert.ToInt32(idt);


                await App.Database.DeletePressure<Models.Pressure>(IdInt);

                

                collectionView.ItemsSource = await
                App.Database.GetAllPressure();

            }

            catch (Exception)
            {
                await DisplayAlert("Uwaga!", "Wybierz prawidłowo pomiar, który ma zostać usunięty", "OK");
                return;
            }
        }

        private async void Filtr(object sender, EventArgs e)
        {
            try
            {
                if (picker.SelectedItem.ToString() == "Wszystkie")
                {
                    collectionView.ItemsSource = await
                App.Database.GetAllPressure();
                }
                else
                {
                    collectionView.ItemsSource = await App.Database.FiltrPress(picker.SelectedItem.ToString()); ;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Allert!", ex.Message, "OK");
            }
        }

        private async void DetailButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Models.Pressure)collectionView.SelectedItem;

                var idt = Convert.ToInt32(obj.press_id);
                IdInt = Convert.ToInt32(idt);
                string date = obj.press_date.ToString();
                string systolic = obj.systolic_pressure.ToString();
                string diasystolic = obj.diastolic_pressure.ToString();
                string hearth = obj.heart_rate.ToString();
                string info = obj.press_info.ToString();


                await Navigation.PushAsync(new PressDetail(IdInt, date, systolic, diasystolic, hearth, info));
            }
            catch(Exception ex)
            {
                await DisplayAlert("Uwaga!", "Wybierz prawidłowo pomiar!", "OK");
                return;
            }
        }
    }
}