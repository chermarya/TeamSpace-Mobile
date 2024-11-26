namespace TeamSpace_Mobile.Pages;

public partial class ConfirmEmailPage : ContentPage
{
	string username = "User";
	public ConfirmEmailPage()
	{
		InitializeComponent();

		UsernameLabel.Text = $"Hi! {username}";
	}

    private void BtnClicked_Back(object sender, EventArgs e) //TODO
    {
        return;
    }

    private void BtnClicked_Confirm(object sender, EventArgs e) //TODO
	{
		return;
	}
}