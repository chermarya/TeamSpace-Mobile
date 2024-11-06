namespace TeamSpace_Mobile.Pages;

public partial class ResetPasswordPage : ContentPage
{
	public ResetPasswordPage()
	{
		InitializeComponent();
	}

    private void BtnClicked_Back(object sender, EventArgs e)
    {
        Application.Current.MainPage = new LoginPage();
    }
}