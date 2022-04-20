using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMICalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedRecord : TabbedPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        string selectedFindBmiStatus;

        async override protected void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            if (CurrentPage is ContentPage OverallRecordsTab)
            {
                base.OnAppearing();
                displayRecord.ItemsSource = await firebaseHelper.GetAllBmiRecord();
            }
            else if (CurrentPage is ContentPage FindStatusTab)
            {
                base.OnAppearing();
            }

        }
        async void OnFindRecord(object sender, EventArgs e)
        {
            showFindRecord.ItemsSource = await firebaseHelper.GetFindRecord(selectedFindBmiStatus);
        }


        public TabbedRecord()
        {
            InitializeComponent();

            findBmiStatus.Items.Add("Underweight");
            findBmiStatus.Items.Add("Normal");
            findBmiStatus.Items.Add("Overweight");
            findBmiStatus.Items.Add("Obese");

            findBmiStatus.SelectedIndexChanged += (sender, args) =>
            {
                if (findBmiStatus.SelectedIndex == -1)
                {
                }
                else
                {
                    selectedFindBmiStatus = findBmiStatus.Items[findBmiStatus.SelectedIndex];
                }
            };


        }
    }
}