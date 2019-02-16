using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WeatherApp
{
    //public class MapPage : ContentPage
    //{
    //	public MapPage ()
    //	{
    //		Content = new StackLayout {
    //			Children = {
    //				new Label { Text = "Welcome to Xamarin.Forms!" }
    //			}
    //		};
    //	}
    //}

    public class MapPage : ContentPage
    {
        private static Page page=new ContentPage();
        public MapPage()
        {

            
           //DisplayAlert("Sensor",$"The latitude is {location.Latitude} and Longitude={location.Longitude}","ok");

            var map = new Map(
                 MapSpan.FromCenterAndRadius(
                         new Position(37, -122), Distance.FromMiles(0.3)))
                {
                    IsShowingUser = true,
                    HeightRequest = 100,
                    WidthRequest = 960,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                var stack = new StackLayout { Spacing = 0 };
                stack.Children.Add(map);
                Content = stack;
              
            }
           // Content = stack;
            
        }
}