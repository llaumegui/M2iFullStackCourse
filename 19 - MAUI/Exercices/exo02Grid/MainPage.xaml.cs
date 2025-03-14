namespace exo02Grid;

public partial class MainPage : ContentPage
{
    private int _tipPercent, _splitters = 1;
    double _bill, _totalpp, _subtotal, _tip;

    public MainPage()
    {
        InitializeComponent();
        BillEntry.Text = "";
        UpdateValues();
    }

    private void BillEntry_OnCompleted(object? sender, EventArgs e) => UpdateValues();

    private void Tip10Button_OnPressed(object? sender, EventArgs e) => TipSlider.Value = 10;
    private void Tip15Button_OnPressed(object? sender, EventArgs e) => TipSlider.Value = 15;
    private void Tip20Button_OnPressed(object? sender, EventArgs e) => TipSlider.Value = 20;

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
        _bill = BillEntry.Text != String.Empty ? double.Parse(BillEntry.Text) : 0;
        _tip = _bill * (_tipPercent / 100.0);
        _subtotal = _bill + _tip;
        _totalpp = _subtotal / (double)_splitters;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        TotalppLabel.Text = $"${_totalpp:0.00}";
        SubtotalLabel.Text = $"${_subtotal:0.00}";
        TipLabel.Text = $"${_tip:0.00}";
        TipPercentLabel.Text = $"Tip: ({_tipPercent}%)";
        SplittersLabel.Text = _splitters.ToString();
    }
}