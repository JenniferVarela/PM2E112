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
          
            var lat = Convert.ToDouble(mtxtLat.Text);
            var lon = Convert.ToDouble(mtxtLon.Text);
            var Nomsitio = nomSitio.Text;

            var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

            var placemark = placemarks?.FirstOrDefault();
            if (placemark != null)
            {
                var geocodeAddress =
                    $"Pais:     {placemark.CountryName}\n" +
                    $"Depto:       {placemark.AdminArea}\n" +
                    $"Ciudad:    {placemark.SubAdminArea}\n" +
                    $"Colonia:        {placemark.Locality}\n" +
                    $"Direccion:    {placemark.Thoroughfare}\n";

                DisplayAlert("Ubicacion", geocodeAddress, "ok");
                var pin = new Pin()
                {
                    Position = new Position(lat, lon),
                    Label = Nomsitio,

                };

                Mapa.Pins.Add(pin);
                Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(lat), Convert.ToDouble(lon)), Distance.FromMeters(100.00)));

            }
        }
    }
}