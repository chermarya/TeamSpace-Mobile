using Microsoft.Maui.Controls;
namespace TeamSpace_Mobile.Pages;

public partial class SecurityPin : ContentPage
{
    public SecurityPin()
    {
        InitializeComponent();
    }

    private void BtnClicked_GoBack(object sender, EventArgs e)
    {
        Application.Current.MainPage = new ResetPasswordPage();
    }

    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && entry.Text.Length == 1)
        {
            switch (entry)
            {
                case var _ when entry == Entry1: Entry2.Focus(); break;
                case var _ when entry == Entry2: Entry3.Focus(); break;
                case var _ when entry == Entry3: Entry4.Focus(); break;
                case var _ when entry == Entry4: Entry5.Focus(); break;
                case var _ when entry == Entry5: Entry6.Focus(); break;
            }
        }
    }
}