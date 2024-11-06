namespace TeamSpace_Mobile.Pages;

public partial class CreateAccountPage : ContentPage
{
	public CreateAccountPage()
	{
		InitializeComponent();
	}

    private void BtnClicked_Back(object sender, EventArgs e)
    {
        Application.Current.MainPage = new LoginPage();
    }
}