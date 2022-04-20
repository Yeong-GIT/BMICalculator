using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace BMICalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Information : ContentPage
    {
        public Information()
        {
            InitializeComponent();
        }

        async void OnYogaClicked(object sender, EventArgs args)
        {

            await Browser.OpenAsync(" https://youtu.be/hJbRpHZr_d0", BrowserLaunchMode.SystemPreferred);
        }

        async void OnFoodClicked(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new FoodPage());

        }

        async void OnGymClicked(object sender, EventArgs args)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                await Launcher.OpenAsync("http://maps.apple.com/?daddr=Dewan+Seri+Sarjana");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                await Launcher.OpenAsync("http://maps.google.com/?daddr=Dewan+Seri+Sarjana");
            }


        }

    }
}