using TeamSpace_Mobile.Contents;

namespace TeamSpace_Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        MainContentView.Content = new LoginContentView();
    }
}
