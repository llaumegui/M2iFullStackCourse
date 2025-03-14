using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorMaker.Pages;

public partial class ColorMakerPage : ContentPage
{
    double _red, _green, _blue;

    public ColorMakerPage()
    {
        InitializeComponent();
        OnRandomColorButtonClicked(null, null);
    }

    void sliderR_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        _red = e.NewValue;
        UpdateColor();
    }

    void sliderG_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        _green = e.NewValue;
        UpdateColor();
    }

    void sliderB_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        _blue = e.NewValue;
        UpdateColor();
    }

    void UpdateColor()
    {
        _color.BackgroundColor = Color.FromRgb(_red, _green, _blue);
        _hexColor.Text = _color.BackgroundColor.ToHex();
        _page.BackgroundColor = _color.BackgroundColor;
    }

    void OnRandomColorButtonClicked(object sender, EventArgs e)
    {
        _red = Random.Shared.NextDouble();
        _green = Random.Shared.NextDouble();
        _blue = Random.Shared.NextDouble();
        
        _sliderR.Value = _red;
        _sliderG.Value = _green;
        _sliderB.Value = _blue;
        UpdateColor();
    }
}