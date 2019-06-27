using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTestXam.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherTestXam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitysPage : ContentPage
    {
        public CitysPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var cityWeather = new List<CityWeather>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.citys.txt");
            foreach (var filename in files)
            {
                cityWeather.Add(new CityWeather
                {
                    Filename = filename,
                    Title = File.ReadAllText(filename),
                    Temperature = File.ReadAllText(filename),
                    Wind = File.ReadAllText(filename)
                }); ;
            }

            listView.ItemsSource = cityWeather
                .OrderBy(d => d.Title)
                .ToList();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CityEntryPage
            {
                BindingContext = new CityWeather()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new CityEntryPage
                {
                    BindingContext = e.SelectedItem as CityWeather
                });
            }
        }
    }
}