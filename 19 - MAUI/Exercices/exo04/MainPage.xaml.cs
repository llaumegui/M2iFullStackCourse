using exo04.ViewModels;

namespace exo04;

public partial class MainPage : ContentPage
{
    HashSet<string> _wordSet = new();
    private string _wordToFind;
    private int ErrorCount;
    
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new BindingHangedManViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadWords();

        NewGame();
    }

    private void NewGame()
    {
        Random rnd = new();
        _wordToFind = _wordSet.ElementAt(rnd.Next(_wordSet.Count));
        WordLabel.Text = new string('-', _wordToFind.Length);
    }

    private async Task LoadWords()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
        using var reader = new StreamReader(stream);
        
        while (reader.Peek() >= 0)
        {
            var lineToAdd = await reader.ReadLineAsync();
            if (!String.IsNullOrEmpty(lineToAdd)) _wordSet.Add(lineToAdd);
        }
    }

    private void btnLetter_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button == null) return;
        var letter = button.Text;

        if (_wordToFind.Contains(letter))
        {
            string updated = "";
            for (int i = 0; i < _wordToFind.Length; i++)
                updated += _wordToFind[i] == letter[0] ? _wordToFind[i] : WordLabel.Text[i];
            WordLabel.Text = updated;
        }
        else
            ErrorCount++;
        
        CheckEnd();
    }

    private void CheckEnd()
    {
        if(ErrorCount >=7)
            return;
    }
}