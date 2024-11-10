namespace TeamSpace_Mobile.Pages;

public partial class LoginPage : ContentPage
{

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
            Frame mainFrame = new Frame
            {
                CornerRadius = 45,
                BorderColor = Colors.Transparent,
                Padding = new Thickness(10, 0),
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                        new Image
                        {
                            Source = frameNames[i][0] + "_icon.png",
                            HorizontalOptions = LayoutOptions.Center,
                            WidthRequest = frameParameters[i][0],
                            HeightRequest = frameParameters[i][1],
                        },
                        new Entry
                        {
                            Placeholder = frameNames[i][1],
                            FontFamily = "TiltNeon",
                            FontSize = 18,
                            TextColor = Color.FromArgb("#262626"),
                            Margin = new Thickness(10, 0),
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            BackgroundColor = Colors.Transparent
                        }
                    }
                }
            };

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

    private void OnSlideConfirmed(object sender, EventArgs e)
    {
        Application.Current.MainPage = new UserProfilePage();
    }
}