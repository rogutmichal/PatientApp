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
    public partial class TempDetail : ContentPage
    {
        int idDetail;
        string dateDetail;
        string tempDetail;
        string infoDetail;
        public TempDetail(int id, string date, string temp, string info)
        {
            InitializeComponent();
            idDetail = id;
            dateDetail = date;
            tempDetail = temp;
            infoDetail = info;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            labelID.Text = idDetail.ToString();
            labelDate.Text = dateDetail;
            labelTemp.Text = tempDetail+ " C°";
            labelInfo.Text = infoDetail;

        }
    }
}