using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace weather.Pages;

public partial class WeatherForecastPage : ContentPage
{
    public WeatherForecastPage()
    {
        InitializeComponent();
        UpdateValues("Paris");
    }
    
    
    private void Entry_OnCompleted(object? sender, EventArgs e)=>UpdateValues(((Entry)sender).Text);
    
    private void SearchButton_OnPressed(object? sender, EventArgs e)=> UpdateValues(CityEntry.Text);
    
    private void DeleteButton_OnPressed(object? sender, EventArgs e)=>CityEntry.Text = string.Empty;
    
    private async Task<Location> GetCoordinatesAsync(string address)
    {
        IEnumerable<Location> locations = await Geocoding
            .Default.GetLocationsAsync(address);

        Location location = locations?.FirstOrDefault();

        return location;
    }

    async Task<JObject> RequestAPI(Location location)
    {
        string uri = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m,wind_speed_10m,weather_code&timeformat=unixtime";
        var client = new HttpClient();
        
        var response = await client.GetAsync(uri);
        var content = await response.Content.ReadAsStringAsync();
        return JObject.Parse(content);
    }

    async Task UpdateValues(string location)
    {
        var coordinates = await GetCoordinatesAsync(location);
        var data = await RequestAPI(coordinates);
        
        CityLabel.Text = $"todo apiLocation: {location}";
    }
}