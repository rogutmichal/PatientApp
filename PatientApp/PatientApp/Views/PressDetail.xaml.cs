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
    public partial class PressDetail : ContentPage
    {
        int idDetail;
        string dateDetail;
        string systolicDetail;
        string diasystolicDetail;
        string heartDetail;
        string infoDetail;
        public PressDetail(int id, string date, string systolic, string diasystolic, string hearth, string info)
        {
            InitializeComponent();
            idDetail = id;
            dateDetail = date;
            systolicDetail = systolic;
            diasystolicDetail = diasystolic; ;
            heartDetail = hearth;
            infoDetail = info;


        }

        protected override void OnAppearing()
        {
           base.OnAppearing();
           labelID.Text = idDetail.ToString();
            labelDate.Text = dateDetail;
            labelSys.Text = systolicDetail;
            labelDia.Text = diasystolicDetail;
            labelHearth.Text = heartDetail;
            labelInfo.Text = infoDetail;

        }

    }
}