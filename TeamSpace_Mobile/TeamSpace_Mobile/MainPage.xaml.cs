using TeamSpace_Mobile.Pages;

namespace TeamSpace_Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        Application.Current.MainPage = new LoginPage();
    }
}
