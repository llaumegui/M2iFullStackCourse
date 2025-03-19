using weather.Pages;

namespace weather;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new WeatherForecastPage();
    }
}