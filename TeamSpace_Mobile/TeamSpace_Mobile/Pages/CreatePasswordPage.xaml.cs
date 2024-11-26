using TeamSpace_Mobile.Controls;

namespace TeamSpace_Mobile.Pages;

public partial class CreatePasswordPage : ContentPage
{
    ImageButton imgBtnEyeCreate = new ImageButton
    {
        Source = "eye_invis_icon.png",
        HorizontalOptions = LayoutOptions.Center,
        WidthRequest = 24,
        HeightRequest = 24,
        Margin = new Thickness(0, 0, 0, -3)
    };
    ImageButton imgBtnEyeConfirm = new ImageButton
    {
        Source = "eye_invis_icon.png",
        HorizontalOptions = LayoutOptions.Center,
        WidthRequest = 24,
        HeightRequest = 24,
        Margin = new Thickness(0, 0, 0, -3)
    };

    BorderlessEntry usernameEntry = new BorderlessEntry
    {
        Placeholder = "Username",
        FontFamily = "TiltNeon",
        FontSize = 18,
        TextColor = Color.FromArgb("#262626"),
        Margin = new Thickness(10, 0),
        HorizontalOptions = LayoutOptions.FillAndExpand,
    };
    BorderlessEntry createPassEntry = new BorderlessEntry
    {
        Placeholder = "Password",
        FontFamily = "TiltNeon",
        FontSize = 18,
        TextColor = Color.FromArgb("#262626"),
        Margin = new Thickness(10, 0, 10, -3),
        HorizontalOptions = LayoutOptions.FillAndExpand,
        IsPassword = true
    };
    BorderlessEntry confirmPassEntry = new BorderlessEntry
    {
        Placeholder = "Confirm Password",
        FontFamily = "TiltNeon",
        FontSize = 18,
        TextColor = Color.FromArgb("#262626"),
        Margin = new Thickness(10, 0, 10, -3),
        HorizontalOptions = LayoutOptions.FillAndExpand,
        IsPassword = true
    };

    Dictionary<int, string[]> frameNames = new Dictionary<int, string[]>()
    {
        { 1, ["user", "username"]},
        { 2, ["pass", "pass_create"]},
        { 3, ["pass", "pass_confirm"]},
    };
    Dictionary<int, double[]> frameParameters = new Dictionary<int, double[]>()
    {
        { 1, [14.19, 18]},
        { 2, [15.44, 19.32]},
        { 3, [15.44, 19.32]}
    };

    public CreatePasswordPage()
	{
		InitializeComponent();
        CreateFrames();

        imgBtnEyeCreate.Clicked += (s, e) =>
        {
            if (imgBtnEyeCreate.Source.ToString().Contains("eye_invis_icon"))
            {
                imgBtnEyeCreate.Source = "eye_vis_icon.png";
                createPassEntry.IsPassword = false;
            }
            else
            {
                imgBtnEyeCreate.Source = "eye_invis_icon.png";
                createPassEntry.IsPassword = true;
            }
        };

        imgBtnEyeConfirm.Clicked += (s, e) =>
        {
            if (imgBtnEyeConfirm.Source.ToString().Contains("eye_invis_icon"))
            {
                imgBtnEyeConfirm.Source = "eye_vis_icon.png";
                confirmPassEntry.IsPassword = false;
            }
            else
            {
                imgBtnEyeConfirm.Source = "eye_invis_icon.png";
                confirmPassEntry.IsPassword = true;
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

        for (int i = 1; i <= 3; i++)
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

            if (frameNames[i][1] == "pass_create")
            {
                content.Children.Add(createPassEntry);
                content.Children.Add(imgBtnEyeCreate);
            }
            else
            {
                if (frameNames[i][1] == "pass_confirm")
                {
                    content.Children.Add(confirmPassEntry);
                    content.Children.Add(imgBtnEyeConfirm);
                }
                else
                {
                    content.Children.Add(usernameEntry);
                }
            }

            Frame mainFrame = new Frame
            {
                CornerRadius = 45,
                BorderColor = Colors.Transparent,
                Padding = new Thickness(10, 0),
                Content = content
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

    private void BtnClicked_Back(object sender, EventArgs e)
	{
		Application.Current.MainPage = new CreateAccountPage();
	}

    private void OnSlideConfirmed(object sender, EventArgs e)
    {
        string user = usernameEntry.Text;
        string pass1 = createPassEntry.Text;
        string pass2 = confirmPassEntry.Text;
        Application.Current.MainPage = new ContainerStartPage();
    }
}