namespace Demo01.Classes;

public class Thermometer
{
    public UnitTemperature Unit { get; set; }
    public double TemperatureKelvin { get; set; }
    public double TemperatureCelsius { get => TemperatureKelvin - 273.15D; set => TemperatureKelvin = value + 273.15D; }
    public double TemperatureFahreneit
    {
        get => TemperatureCelsius * (9 / 5f) + 32;
        set => TemperatureCelsius = (value - 32) / (9 / 5f);
    }

    public Thermometer(double temperature, UnitTemperature unit)
    {
        Unit = unit;
        switch (unit)
        {
            case UnitTemperature.Celsius:
                TemperatureCelsius = temperature;
                break;
            case UnitTemperature.Fahreneit:
                TemperatureFahreneit = temperature;
                break;
            default:
                TemperatureKelvin = temperature;
                break;
        }
    }

    public static Thermometer operator +(Thermometer a, double b)
    {
        return a.Unit switch
        {
            UnitTemperature.Celsius => new Thermometer(a.TemperatureCelsius + b, a.Unit),
            UnitTemperature.Fahreneit => new Thermometer(a.TemperatureFahreneit + b, a.Unit),
            _ => new Thermometer(a.TemperatureKelvin + b, a.Unit),
        };
    }
}

public enum UnitTemperature
{
    Celsius,
    Fahreneit,
    Kelvin
}