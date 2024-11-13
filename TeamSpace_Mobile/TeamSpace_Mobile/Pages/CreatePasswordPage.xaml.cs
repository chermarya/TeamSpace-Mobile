namespace TeamSpace_Mobile.Pages;

public partial class CreatePasswordPage : ContentPage
{
    ImageButton imgBtnEyeCreate = new ImageButton
    {
        Source = "eye_invis_icon.png",
        HorizontalOptions = LayoutOptions.Center,
        WidthRequest = 24,
        HeightRequest = 24
    };
    ImageButton imgBtnEyeConfirm = new ImageButton
    {
        Source = "eye_invis_icon.png",
        HorizontalOptions = LayoutOptions.Center,
        WidthRequest = 24,
        HeightRequest = 24
    };

    Entry createPassEntry = new Entry
    {
        FontFamily = "TiltNeon",
        FontSize = 18,
        TextColor = Color.FromArgb("#262626"),
        Margin = new Thickness(10, 0),
        HorizontalOptions = LayoutOptions.FillAndExpand,
        BackgroundColor = Colors.Transparent,
        IsPassword = true
    };
    Entry confirmPassEntry = new Entry
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
        { 1, ["user", "Username", "username"]},
        { 2, ["pass", "Password", "pass_create"]},
        { 3, ["pass", "Confirm Password", "pass_confirm"]},
    };
    Dictionary<int, double[]> frameParameters = new Dictionary<int, double[]>()
    {
        { 1, [24, 24]},
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

            if (frameNames[i][2] == "pass_create")
            {
                content.Children.Add(createPassEntry);
                createPassEntry.Placeholder = frameNames[i][1];
                content.Children.Add(imgBtnEyeCreate);
            }
            else
            {
                if (frameNames[i][2] == "pass_confirm")
                {
                    content.Children.Add(confirmPassEntry);
                    confirmPassEntry.Placeholder = frameNames[i][1];
                    content.Children.Add(imgBtnEyeConfirm);
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
        Application.Current.MainPage = new ContainerStartPage();
    }
}