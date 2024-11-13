using Microsoft.Maui.Controls;
namespace TeamSpace_Mobile.Pages;

public partial class ResetPasswordPage : ContentPage
{
	public ResetPasswordPage()
	{
		InitializeComponent();
	}

    private void BtnClicked_GoBack(object sender, EventArgs e)
    {
        Application.Current.MainPage = new LoginPage();
    }
    
    private void BtnClicked_GoSecurityPin(object sender, EventArgs e)
    {
        Application.Current.MainPage = new SecurityPin();
    }
}