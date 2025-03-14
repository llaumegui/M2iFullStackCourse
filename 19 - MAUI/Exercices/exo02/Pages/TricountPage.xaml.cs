using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo02.Pages;

public partial class TricountPage : ContentPage
{
    private int _tipPercent, _splitters = 1;
    double _bill, _totalpp, _subtotal, _tip;

    public TricountPage()
    {
        InitializeComponent();
        UpdateValues();
        UpdateDisplay();
    }

    private void BillEntry_OnCompleted(object? sender, EventArgs e) => UpdateValues();

    private void Tip10Button_OnPressed(object? sender, EventArgs e) => _tipSlider.Value = 10;
    private void Tip15Button_OnPressed(object? sender, EventArgs e) => _tipSlider.Value = 15;
    private void Tip20Button_OnPressed(object? sender, EventArgs e) => _tipSlider.Value = 20;

    private void TipSlider_OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        _tipPercent = (int)e.NewValue;
        UpdateValues();
    }

    private void SplitMinus_OnPressed(object? sender, EventArgs e)
    {
        if (_splitters == 1) return;
        if (_splitters > 1) _splitters--;
        UpdateValues();
    }

    private void SplitPlus_OnPressed(object? sender, EventArgs e)
    {
        _splitters++;
        UpdateValues();
    }

    void UpdateValues()
    {
        _bill = double.Parse(_billEntry.Text);
        _tip = _bill * (_tipPercent / 100.0);
        _subtotal = _bill + _tip;
        _totalpp = _subtotal / (double)_splitters;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _totalppLabel.Text = $"${_totalpp:0.00}";
        _subtotalLabel.Text = $"${_subtotal:0.00}";
        _tipLabel.Text = $"${_tip:0.00}";
        _tipPercentLabel.Text = $"Tip: ({_tipPercent}%)";
        _splittersLabel.Text = _splitters.ToString();
    }
}