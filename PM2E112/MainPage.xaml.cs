using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace PM2E112
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            var sitio = new Models.Sitios
            {
                id = 0,
                latitud = txtLat.Text,
                longitud = txtLon.Text,
                descripcion = txtDescripcion.Text,
                //foto
            };

            //await DisplayAlert("Aviso", "Sitio Adicionado"+sitio, "OK");
            var result = await App.DBase.SitioSave(sitio);
            if (result > 0)//se usa como una super clase
            {
                await DisplayAlert("Aviso", "Sitio Adicionado",  "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Error al Registrar",  "OK");
            }

        }

        private void btnList_Clicked(object sender, EventArgs e)
        {

        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {
            var fotografia = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MisFotos",
                Name = "test.jpg",
                SaveToAlbum = true,
            });


            await DisplayAlert("path directorio", fotografia.Path, "ok");

            if (fotografia != null)
            {
                fotoSitio.Source = ImageSource.FromStream(() =>
                {
                    return fotografia.GetStream();
                });
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

           var location = await Geolocation.GetLastKnownLocationAsync();

           if (location != null)
           {
            //    await DisplayAlert("AVISO", "lATITUD" + location.Latitude + " Longitude" + location.Longitude, "OK");
                var lon = location.Longitude;
                var lat = location.Latitude;
              
                txtLat.Text = lat.ToString();
                txtLon.Text = lon.ToString();
           }  
        }
    }
}
