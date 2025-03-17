using exo04.ViewModels;

namespace exo04;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new BindingHangedManViewModel();
    }
}