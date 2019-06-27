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
    public partial class CityEntryPage : ContentPage
    {
        public CityEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var cityWeather = (CityWeather)BindingContext;
            if (cityWeather != null)
            {
                if (string.IsNullOrWhiteSpace(cityWeather.Filename))
                {
                    // Save
                    var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.citys.txt");
                    File.WriteAllText(filename, cityWeather.Title);
                }
                else
                {
                    // Update
                    File.WriteAllText(cityWeather.Filename, cityWeather.Title);
                }
            }

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var cityWeather = (CityWeather)BindingContext;

            if (File.Exists(cityWeather.Filename))
            {
                File.Delete(cityWeather.Filename);
            }

            await Navigation.PopAsync();
        }
    }
}

