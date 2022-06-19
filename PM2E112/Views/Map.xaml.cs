using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PM2E112.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Map : ContentPage
    {
        public Map()
        {
            InitializeComponent();
 
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
          
            var lat = mtxtLat.Text;
            var lon = mtxtLon.Text;


            var pin = new Pin()
            {
                Position = new Position(Convert.ToDouble(lat), Convert.ToDouble(lon)),
                Label = "Mi casa"
            };

            Mapa.Pins.Add(pin);
            Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(lat), Convert.ToDouble(lon)), Distance.FromMeters(100.00)));


        }
    }
}