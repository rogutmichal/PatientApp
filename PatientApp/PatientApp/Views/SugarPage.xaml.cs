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
    public partial class SugarPage : ContentPage
    {
        public SugarPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetAllSugar();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NewSugarPage));

            collectionView.ItemsSource = await
               App.Database.GetAllSugar();

        }
        int IdInt;

        private async void OnDetailButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (Models.Sugar)collectionView.SelectedItem;

                var idt = Convert.ToInt32(obj.sugar_id);
                IdInt = Convert.ToInt32(idt);
                string date = obj.sugar_date.ToString();
                string sugar = obj.sugar.ToString();
                string info = obj.sugar_info.ToString();


                await Navigation.PushAsync(new SugarDetailPage(IdInt, date, sugar, info));
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
                var obj = (Models.Sugar)collectionView.SelectedItem;

                var idt = Convert.ToInt32(obj.sugar_id);
                IdInt = Convert.ToInt32(idt);


                await App.Database.DeleteSugar<Models.Sugar>(IdInt);

                collectionView.ItemsSource = await
                 App.Database.GetAllSugar();
            }
            catch (Exception)
            {
                await DisplayAlert("Uwaga!", "Wybierz prawidłowo pomiar, który ma zostać usunięty", "OK");
                return;
            }

        }

    }
}