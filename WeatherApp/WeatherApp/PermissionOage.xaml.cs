using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PermissionOage : ContentPage
	{
		public PermissionOage ()
		{
           
          
            InitializeComponent ();
		}


        private async  void Button_Clicked2(object sender, EventArgs e)
        {
            try
            {
                Vibration.Cancel();
            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("Need location", ex.Message, "OK");
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                await DisplayAlert("Need location", ex.Message, "OK");
                // Other error has occurred.
            }





        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    // Use default vibration length
                    Vibration.Vibrate();

                    // Or use specified time
                    var duration = TimeSpan.FromSeconds(1);
                    Vibration.Vibrate(duration);

                    //var location =await Geolocation.GetLastKnownLocationAsync();
                    //MyLabel.Text=$"The latitude is {location.Latitude} and Longitude={location.Longitude}";
                    // await Navigation.PushAsync(new MapPage());
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Sorry boss", ex.Message, "OK");
                //LabelGeolocation.Text = "Error: " + ex;
            }





        }

   
    }
}