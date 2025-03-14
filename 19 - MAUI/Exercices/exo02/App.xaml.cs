using exo02.Pages;
namespace exo02;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new TricountPage();
    }
}