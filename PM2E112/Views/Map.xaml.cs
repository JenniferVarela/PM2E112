using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.IO;
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

        Plugin.Media.Abstractions.MediaFile Filefoto = null;

        public object FOTO { get; private set; }

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
                Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lon), Distance.FromMeters(100.00)));

            }

           
        }

        private async void btn_Compartir_Clicked(object sender, EventArgs e)
        {
           
            //var fn = "Attachment.txt";
            //var file = Path.Combine(FileSystem.CacheDirectory, fn);
            //File.WriteAllText(file, "Hello World");

            //await Share.RequestAsync(new ShareFileRequest
            //{
            //    Title = Title,
            //    File = new ShareFile(file)
            //});

        }

    }
}