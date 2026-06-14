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
    public partial class MeasDetailPage : ContentPage
    {
        int idDetail;
        string dateDetail;
        string heightDetail;
        string weightDetail;
        string bmiDetail;
        string infoDetail;
        public MeasDetailPage(int id, string date, string height, string weight, string bmi, string info)
        {
            InitializeComponent();
            idDetail = id;
            dateDetail = date;
           heightDetail = height;
            weightDetail = weight;      
            bmiDetail = bmi;
            infoDetail = info;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            labelID.Text = idDetail.ToString();
            labelDate.Text = dateDetail;
            labelHeight.Text = heightDetail+" cm";
            labelWeight.Text = weightDetail+ " cm";
            labelBmi.Text = bmiDetail;
            labelInfo.Text = infoDetail;

        }
    }
}