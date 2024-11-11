namespace TeamSpace_Mobile.Pages;

public partial class LoginPage : ContentPage
{
    ImageButton imgBtnEye = new ImageButton
    {
        Source = "eye_invis_icon.png",
        HorizontalOptions = LayoutOptions.Center,
        WidthRequest = 24,
        HeightRequest = 24
    };

    Entry passEntry = new Entry
    {
        FontFamily = "TiltNeon",
        FontSize = 18,
        TextColor = Color.FromArgb("#262626"),
        Margin = new Thickness(10, 0),
        HorizontalOptions = LayoutOptions.FillAndExpand,
        BackgroundColor = Colors.Transparent,
        IsPassword = true
    };

    Dictionary<int, string[]> frameNames = new Dictionary<int, string[]>()
    {
        { 2, ["user", "Username"]},
        { 3, ["pass", "Password"]}
    };
    Dictionary<int, double[]> frameParameters = new Dictionary<int, double[]>()
    {
        { 2, [24, 24]},
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


        for (int i = 2; i <= 3; i++)
        {
            StackLayout content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Image
                    {
                        Source = frameNames[i][0] + "_icon.png",
                        HorizontalOptions = LayoutOptions.Center,
                        WidthRequest = frameParameters[i][0],
                        HeightRequest = frameParameters[i][1]
                    }
                }
            };

            Frame mainFrame = new Frame
            {
                CornerRadius = 45,
                BorderColor = Colors.Transparent,
                Padding = new Thickness(10, 0),
                Content = content
            };

            if (frameNames[i][0] == "pass")
            {
                content.Children.Add(passEntry);
                passEntry.Placeholder = frameNames[i][1];
                content.Children.Add(imgBtnEye);
            }
            else
            {
                content.Children.Add(new Entry
                {
                    Placeholder = frameNames[i][1],
                    FontFamily = "TiltNeon",
                    FontSize = 18,
                    TextColor = Color.FromArgb("#262626"),
                    Margin = new Thickness(10, 0),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Colors.Transparent
                });
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
        Application.Current.MainPage = new UserProfilePage();
    }
}