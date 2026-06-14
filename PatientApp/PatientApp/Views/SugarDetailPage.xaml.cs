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
    public partial class SugarDetailPage : ContentPage
    {
        int idDetail;
        string dateDetail;
        string sugarDetail;
        string infoDetail;
        public SugarDetailPage(int id, string date, string sugar, string info)
        {
            InitializeComponent();
            idDetail = id;
            dateDetail = date;
            sugarDetail = sugar;
            infoDetail = info;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            labelID.Text = idDetail.ToString();
            labelDate.Text = dateDetail;
            labelSugar.Text = sugarDetail;
            labelInfo.Text = infoDetail;

        }

    }
}