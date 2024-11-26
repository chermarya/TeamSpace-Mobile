using TeamSpace_Mobile.Controls;

namespace TeamSpace_Mobile.Pages;

public partial class LoginPage : ContentPage
{
    ImageButton imgBtnEye = new ImageButton
    {
        Source = "eye_invis_icon.png",
        HorizontalOptions = LayoutOptions.Center,
        WidthRequest = 24,
        HeightRequest = 24,
        Margin = new Thickness(0, 0, 0, -3)
    };

    BorderlessEntry passEntry = new BorderlessEntry
    {
        Placeholder = "Password",
        FontFamily = "TiltNeon",
        FontSize = 18,
        TextColor = Color.FromArgb("#262626"),
        Margin = new Thickness(10, 0, 10, -3),
        HorizontalOptions = LayoutOptions.FillAndExpand,
        IsPassword = true
    };
    BorderlessEntry usernameEntry = new BorderlessEntry
    {
        Placeholder = "Username",
        FontFamily = "TiltNeon",
        FontSize = 18,
        TextColor = Color.FromArgb("#262626"),
        Margin = new Thickness(10, 0, 10, -3),
        HorizontalOptions = LayoutOptions.FillAndExpand,
    };

    Dictionary<int, double[]> frameParameters = new Dictionary<int, double[]>()
    {
        { 2, [14.19, 18]},
        { 3, [15.44, 19.32]}
    };

    public LoginPage()
    {
        InitializeComponent();
        CreateFrames();

        imgBtnEye.Clicked += (s, e) =>
        {
            if (imgBtnEye.Source.ToString().Contains("eye_invis_icon"))
            {
                imgBtnEye.Source = "eye_vis_icon.png";
                passEntry.IsPassword = false;
            }
            else
            {
                imgBtnEye.Source = "eye_invis_icon.png";
                passEntry.IsPassword = true;
            }
        };
    }

    private void CreateFrames()
    {
        var gradientBrush = new LinearGradientBrush
        {
            GradientStops = new GradientStopCollection
            {
                new GradientStop { Color = Colors.Transparent, Offset = 0.0f },
                new GradientStop { Color = Colors.Transparent, Offset = 0.6f },
                new GradientStop { Color = Colors.Black, Offset = 1.0f }
            },
            StartPoint = new Point(0, 0),
            EndPoint = new Point(0, 1),
        };

        string[] iconNames = ["user", "pass"];
        BorderlessEntry[] entryNames = [passEntry, usernameEntry];

        for (int i = 2; i <= 3; i++)
        {
            StackLayout content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Image
                    {
                        Source = iconNames[i - 2] + "_icon.png",
                        HorizontalOptions = LayoutOptions.Center,
                        WidthRequest = frameParameters[i][0],
                        HeightRequest = frameParameters[i][1]
                    }
                }
            };

            content.Children.Add(entryNames[i - 2]);

            Frame mainFrame = new Frame
            {
                CornerRadius = 45,
                BorderColor = Colors.Transparent,
                Padding = new Thickness(10, 0),
                Content = content
            };

            if (i == 3)
            {
                content.Children.Add(imgBtnEye);
            }
            

            Frame borderFrame = new Frame
            {
                CornerRadius = 45,
                HeightRequest = 50,
                BorderColor = Colors.Transparent,
                Padding = new Thickness(0, 0, 0, 0.5),
                VerticalOptions = LayoutOptions.Center,
                Background = gradientBrush,
                Content = mainFrame
            };

            Grid.SetRow(borderFrame, i);
            Grid.SetColumn(borderFrame, 1);
            ContentGrid.Children.Add(borderFrame);
        }
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

    private void BtnClicked_LogIn(object sender, EventArgs e)
    {
        Application.Current.MainPage = new ContainerStartPage();
    }
}