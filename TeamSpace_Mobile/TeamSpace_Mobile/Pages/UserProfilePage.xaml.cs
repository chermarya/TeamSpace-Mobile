namespace TeamSpace_Mobile.Pages;

public partial class UserProfilePage : ContentPage
{
	public UserProfilePage()
	{
		InitializeComponent();
	}

    private void BtnClicked_Back(object sender, EventArgs e)
    {
        Application.Current.MainPage = new LoginPage();
    }
}