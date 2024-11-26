using TeamSpace_Mobile.Controls;

namespace TeamSpace_Mobile.Pages;

public partial class CreateAccountPage : ContentPage
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

    BorderlessEntry usernameEntry = new BorderlessEntry();
    BorderlessEntry emailEntry = new BorderlessEntry();
    BorderlessEntry mobileEntry = new BorderlessEntry();
    BorderlessEntry createPassEntry = new BorderlessEntry
    {
        FontFamily = "TiltNeon",
        FontSize = 18,
        TextColor = Color.FromArgb("#262626"),
        Margin = new Thickness(10, 0, 10, -3),
        HorizontalOptions = LayoutOptions.FillAndExpand,
        IsPassword = true
    };
    BorderlessEntry confirmPassEntry = new BorderlessEntry
    {
        FontFamily = "TiltNeon",
        FontSize = 18,
        TextColor = Color.FromArgb("#262626"),
        Margin = new Thickness(10, 0, 10, -3),
        HorizontalOptions = LayoutOptions.FillAndExpand,
        IsPassword = true
    };


    Dictionary<int, string[]> frameNames = new Dictionary<int, string[]>()
    {
        { 1, ["user", "Username", "username"]},
        { 2, ["email", "E-mail", "email"]},
        { 3, ["phone", "Mobile", "mobile"]},
        { 4, ["pass", "Password", "pass_create"]},
        { 5, ["pass", "Confirm Password", "pass_confirm"]},
    };
    Dictionary<int, double[]> frameParameters = new Dictionary<int, double[]>()
    {
        { 1, [14.19, 18]},
        { 2, [14, 11.2]},
        { 3, [14, 20]},
        { 4, [15.44, 19.32]},
        { 5, [15.44, 19.32]}
    };

    public CreateAccountPage()
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

        BorderlessEntry[] entryNames = [usernameEntry, emailEntry, mobileEntry];

        for (int i = 1; i <= 5; i++)
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
                    entryNames[i - 1].Placeholder = frameNames[i][1];
                    entryNames[i - 1].FontFamily = "TiltNeon";
                    entryNames[i - 1].FontSize = 18;
                    entryNames[i - 1].TextColor = Color.FromArgb("#262626");
                    entryNames[i - 1].Margin = new Thickness(10, 0, 10, -3);
                    entryNames[i - 1].HorizontalOptions = LayoutOptions.FillAndExpand;

                    content.Children.Add(entryNames[i - 1]);
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
        Application.Current.MainPage = new LoginPage();
    }

    private void BtnClicked_GoogleSignIn(object sender, EventArgs e) //TODO
    {
        return;
    }

    private void OnSlideConfirmed(object sender, EventArgs e)
    {
        //string user = usernameEntry.Text;
        //string email = emailEntry.Text;
        //string mobile = mobileEntry.Text;
        Application.Current.MainPage = new ContainerStartPage();
    }
}