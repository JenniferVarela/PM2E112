using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E112.Models;
using System.Diagnostics;
using Xamarin.Forms.Maps;

namespace PM2E112.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListSitios : ContentPage
    {
        public ListSitios()
        {
            InitializeComponent();
        }

        private async void ListSitio_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var sitio = (Sitios)e.Item;

            bool answer = await DisplayAlert("AVISO", "¿Quiere ir al mapa?", "Si", "No");
            Debug.WriteLine("Answer: " + answer);

            if (answer == true)
            {

                Map map = new Map();
                map.BindingContext = sitio;
                await Navigation.PushAsync(map);
            };

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();//recargara de nuevo la lista
            Lista.ItemsSource = await App.DBase.getListSitio();//Espera coleccion de elementos para enumerar en la forma que queramos
        }
    }
}