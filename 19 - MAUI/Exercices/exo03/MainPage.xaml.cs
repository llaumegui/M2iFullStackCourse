namespace exo03;

public partial class MainPage : ContentPage
{
    private HashSet<string> quoteSet = new();
    public MainPage() { InitializeComponent(); }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await LoadQuotes();

        DisplayNewQuote();
    }

    private async Task LoadQuotes()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
        using var reader = new StreamReader(stream);
        
        while (reader.Peek() >= 0)
        {
            // Pour chaque ligne, on va ajouter le texte à notre Set de chaines de caractères
            var lineToAdd = await reader.ReadLineAsync();
            if (!String.IsNullOrEmpty(lineToAdd)) quoteSet.Add(lineToAdd);
        }
    }
    
    private void Button_OnPressed(object? sender, EventArgs e)
    {
        DisplayNewQuote();
    }
    
    private void DisplayNewQuote()
    {
        var rdm = new Random();
        string quote = quoteSet.ElementAt(rdm.Next(0, quoteSet.Count));
        QuoteLabel.Text = quote.ToUpper();
        
        Color start = Color.FromRgb(rdm.NextDouble(), rdm.NextDouble(), rdm.NextDouble());
        Color end = Color.FromRgb(rdm.NextDouble(), rdm.NextDouble(), rdm.NextDouble());

        GradientStart.Color = start;
        GradientEnd.Color = end;
    }
}
