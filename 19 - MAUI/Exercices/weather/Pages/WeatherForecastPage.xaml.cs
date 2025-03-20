using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SkiaSharp.Extended.UI.Controls;

namespace weather.Pages;

public partial class WeatherForecastPage : ContentPage
{
    public WeatherForecastPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await UpdateValues("Paris");
    }

    private void Entry_OnCompleted(object? sender, EventArgs e)=>UpdateValues(((Entry)sender).Text);
    
    private void SearchButton_OnPressed(object? sender, EventArgs e)=> UpdateValues(CityEntry.Text);
    
    private void DeleteButton_OnPressed(object? sender, EventArgs e)=>CityEntry.Text = string.Empty;
    
    private async Task<Tuple<Location,string>> GetCoordinatesAsync(string address)
    {
        IEnumerable<Location> locations = await Geocoding
            .Default.GetLocationsAsync(address);
        var location = locations.FirstOrDefault();
        IEnumerable<Placemark> placemarks = await Geocoding.
            Default.GetPlacemarksAsync(location);

        return new Tuple<Location,string>(location,placemarks.FirstOrDefault().Locality);
    }

    async Task<JObject> RequestAPI(Location location)
    {
        var client = new HttpClient();
        string weatherUri = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m,wind_speed_10m,weather_code&timeformat=unixtime&timezone=auto";
        
        //data
        var weatherData = await client.GetAsync(weatherUri);
        var content = await weatherData.Content.ReadAsStringAsync();
        
        
        return JObject.Parse(content);
    }

    async Task UpdateValues(string location)
    {
        var coordinates = await GetCoordinatesAsync(location);
        var json = await RequestAPI(coordinates.Item1);
        var data = json["current"];
        string city = coordinates.Item2;
        DateTime date = new(1970, 1, 1, 0, 0, 0);
        date = date.AddSeconds(long.Parse(data["time"].ToString())
                               + long.Parse(json["utc_offset_seconds"].ToString()));
        
        CityLabel.Text = city;
        DateLabel.Text = date.ToString("g");
        TemperatureLabel.Text = data["temperature_2m"].ToString();
        WindLabel.Text = $"{data["wind_speed_10m"]}km/h";
        WeatherLabel.Text = data["weather_code"].ToString();

        SKLottieImageSource imgPath = GetPictureFromCode(data["weather_code"].ToString());
        WeatherImage.Source = imgPath;
    }

    private SKLottieImageSource GetPictureFromCode(string weatherCode)
    {
        SKFileLottieImageSource sKLottieImageSource = new SKFileLottieImageSource();
        sKLottieImageSource.File = weatherCode switch
        {
            "0"=>"sunny.json",
            "1" or "2" or "3"=>"partlycloudy.json",
            "45" or "48" => "foggy.json",
            "51" or "53" or "55" or "56" or "57" => "mist.json",
            "61" or "63" or "65" or "66" or "67" or "80" or "81" or "82" =>"partlyshower.json",
            "71" or "73" or "75" or "77" or "85" or "86" => "snow.json",
            "95" or "96" or "99" => "thunder.json",
            _ => "sunglasses.json"
        };
            
        return sKLottieImageSource;
    }
}