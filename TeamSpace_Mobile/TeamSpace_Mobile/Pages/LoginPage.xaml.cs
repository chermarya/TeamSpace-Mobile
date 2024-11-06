namespace TeamSpace_Mobile.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void BtnClicked_ResetPassword(object sender, EventArgs e)
    {
        Application.Current.MainPage = new ResetPasswordPage();
    }

    private void BtnClicked_GoogleSignIn(object sender, EventArgs e) //TODO
    {
        return;
    }

    private void BtnClicked_CreateAccount(object sender, EventArgs e)
    {
        Application.Current.MainPage = new CreateAccountPage();
    }

    private void OnSlideConfirmed(object sender, EventArgs e)
    {
        Application.Current.MainPage = new UserProfilePage();
    }
}