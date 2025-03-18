using exo04.ViewModels;

namespace exo04;

public partial class MainPage : ContentPage
{
    HashSet<string> _wordSet = new();
    
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new BindingHangedManViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadWords();
    }

    private async Task LoadWords()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
        using var reader = new StreamReader(stream);
        
        while (reader.Peek() >= 0)
        {
            // Pour chaque ligne, on va ajouter le texte à notre Set de chaines de caractères
            var lineToAdd = await reader.ReadLineAsync();
            if (!String.IsNullOrEmpty(lineToAdd)) _wordSet.Add(lineToAdd);
        }
    }

    private void btnLetter_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button == null) return;
        var letter = button.Text;
    }
}