using TeamSpace_Mobile.Pages.Contents;

namespace TeamSpace_Mobile.Pages;

public partial class ContainerStartPage : ContentPage
{
    Button overviewBtn = new Button();
    Button filesBtn = new Button();
    Button scheduleBtn = new Button();
    Button recruitersBtn = new Button();
    Button profileBtn = new Button();
    Button[] navigateBtns;

    Image overviewImg = new Image();
    Image filesImg = new Image();
    Image scheduleImg = new Image();
    Image recruitersImg = new Image();
    Image profileImg = new Image();
    Image[] navigateImgs;
    string[] imgNames = ["Overview", "Files", "Schedule", "Recruiters", "Profile"];

    Label overviewLbl = new Label();
    Label filesLbl = new Label();
    Label scheduleLbl = new Label();
    Label recruitersLbl = new Label();
    Label profileLbl = new Label();
    Label[] navigateLbls;

    BoxView overviewBox = new BoxView();
    BoxView filesBox = new BoxView();
    BoxView scheduleBox = new BoxView();
    BoxView recruitersBox = new BoxView();
    BoxView profileBox = new BoxView();
    BoxView[] navigateBoxes;

    VerticalStackLayout overviewLay = new VerticalStackLayout();
    VerticalStackLayout filesLay = new VerticalStackLayout();
    VerticalStackLayout scheduleLay = new VerticalStackLayout();
    VerticalStackLayout recruitersLay = new VerticalStackLayout();
    VerticalStackLayout profileLay = new VerticalStackLayout();
    VerticalStackLayout[] navigateLays;

    public ContainerStartPage()
    {
        InitializeComponent();
        CreateIcons();

        overviewBtn.Clicked += BtnClicked_Overview;
        filesBtn.Clicked += BtnClicked_Files;
        scheduleBtn.Clicked += BtnClicked_Schedule;
        recruitersBtn.Clicked += BtnClicked_Recruiters;
        profileBtn.Clicked += BtnClicked_Profile;

        MainContentView.Content = new OverviewContent();

        for (int i = 0; i < navigateImgs.Length; i++)
        {
            navigateImgs[i].Source = imgNames[i] + "_icon_default";
        }
        overviewImg.Source = "overview_icon_selected";
        overviewLbl.TextColor = Colors.Black;
        overviewBox.Margin = new Thickness(0, -20, 0, 0);
        overviewLay.Margin = 0;
    }

    private void BtnClicked_Overview(object sender, EventArgs e)
    {
        MainContentView.Content = new OverviewContent();

        for (int i = 0; i < navigateImgs.Length; i++)
        {
            navigateImgs[i].Source = imgNames[i] + "_icon_default";
        }
        overviewImg.Source = "overview_icon_selected";

        for (int i = 0; i < navigateLbls.Length; i++)
        {
            navigateLbls[i].TextColor = Color.FromHsla(0, 0, 0, 0.5);
        }
        overviewLbl.TextColor = Colors.Black;

        for (int i = 0; i < navigateBoxes.Length; i++)
        {
            navigateBoxes[i].Margin = new Thickness(0, 10, 0, 0);
        }
        overviewBox.Margin = new Thickness(0, -20, 0, 0);

        for (int i = 0; i < navigateLays.Length; i++)
        {
            navigateLays[i].Margin = new Thickness(0, 17, 0, 0);
        }
        overviewLay.Margin = 0;
    }

    private void BtnClicked_Files(object sender, EventArgs e)
    {
        MainContentView.Content = new FilesContent();

        for (int i = 0; i < navigateImgs.Length; i++)
        {
            navigateImgs[i].Source = imgNames[i] + "_icon_default";
        }
        filesImg.Source = "files_icon_selected";

        for (int i = 0; i < navigateLbls.Length; i++)
        {
            navigateLbls[i].TextColor = Color.FromHsla(0, 0, 0, 0.5);
        }
        filesLbl.TextColor = Colors.Black;

        for (int i = 0; i < navigateBoxes.Length; i++)
        {
            navigateBoxes[i].Margin = new Thickness(0, 10, 0, 0);
        }
        filesBox.Margin = new Thickness(0, -20, 0, 0);

        for (int i = 0; i < navigateLays.Length; i++)
        {
            navigateLays[i].Margin = new Thickness(0, 17, 0, 0);
        }
        filesLay.Margin = 0;
    }

    private void BtnClicked_Schedule(object sender, EventArgs e)
    {
        MainContentView.Content = new ScheduleContent();

        for (int i = 0; i < navigateImgs.Length; i++)
        {
            navigateImgs[i].Source = imgNames[i] + "_icon_default";
        }
        scheduleImg.Source = "schedule_icon_selected";

        for (int i = 0; i < navigateLbls.Length; i++)
        {
            navigateLbls[i].TextColor = Color.FromHsla(0, 0, 0, 0.5);
        }
        scheduleLbl.TextColor = Colors.Black;

        for (int i = 0; i < navigateBoxes.Length; i++)
        {
            navigateBoxes[i].Margin = new Thickness(0, 10, 0, 0);
        }
        scheduleBox.Margin = new Thickness(0, -20, 0, 0);

        for (int i = 0; i < navigateLays.Length; i++)
        {
            navigateLays[i].Margin = new Thickness(0, 17, 0, 0);
        }
        scheduleLay.Margin = 0;
    }

    private void BtnClicked_Recruiters(object sender, EventArgs e)
    {
        MainContentView.Content = new RecruitersContent();

        for (int i = 0; i < navigateImgs.Length; i++)
        {
            navigateImgs[i].Source = imgNames[i] + "_icon_default";
        }
        recruitersImg.Source = "recruiters_icon_selected";

        for (int i = 0; i < navigateLbls.Length; i++)
        {
            navigateLbls[i].TextColor = Color.FromHsla(0, 0, 0, 0.5);
        }
        recruitersLbl.TextColor = Colors.Black;

        for (int i = 0; i < navigateBoxes.Length; i++)
        {
            navigateBoxes[i].Margin = new Thickness(0, 10, 0, 0);
        }
        recruitersBox.Margin = new Thickness(0, -20, 0, 0);

        for (int i = 0; i < navigateLays.Length; i++)
        {
            navigateLays[i].Margin = new Thickness(0, 17, 0, 0);
        }
        recruitersLay.Margin = 0;
    }

    private void BtnClicked_Profile(object sender, EventArgs e)
    {
        MainContentView.Content = new ProfileContent();

        for (int i = 0; i < navigateImgs.Length; i++)
        {
            navigateImgs[i].Source = imgNames[i] + "_icon_default";
        }
        profileImg.Source = "profile_icon_selected";

        for (int i = 0; i < navigateLbls.Length; i++)
        {
            navigateLbls[i].TextColor = Color.FromHsla(0, 0, 0, 0.5);
        }
        profileLbl.TextColor = Colors.Black;

        for (int i = 0; i < navigateBoxes.Length; i++)
        {
            navigateBoxes[i].Margin = new Thickness(0, 10, 0, 0);
        }
        profileBox.Margin = new Thickness(0, -20, 0, 0);

        for (int i = 0; i < navigateLays.Length; i++)
        {
            navigateLays[i].Margin = new Thickness(0, 17, 0, 0);
        }
        profileLay.Margin = 0;
    }

    private void CreateBtns()
    {
        navigateBtns = [overviewBtn, filesBtn, scheduleBtn, recruitersBtn, profileBtn];
        int[] navigateBtnSizes = [67, 38, 70, 73, 47];

        for (int i = 0; i < navigateBtns.Length; i++)
        {
            navigateBtns[i].BackgroundColor = Colors.Transparent;
            navigateBtns[i].BorderColor = Colors.Transparent;
            navigateBtns[i].HeightRequest = 50;
            navigateBtns[i].WidthRequest = navigateBtnSizes[i];
            navigateBtns[i].Padding = 0;
            navigateBtns[i].HorizontalOptions = LayoutOptions.Center;
            navigateBtns[i].VerticalOptions = LayoutOptions.Center;
        }
    }

    private void CreateLbls()
    {
        navigateLbls = [overviewLbl, filesLbl, scheduleLbl, recruitersLbl, profileLbl];
        string[] lblTexts = ["Overview", "Files", "Schedule", "Recruiters", "Profile"];

        for (int i = 0; i < navigateLbls.Length; i++)
        {
            navigateLbls[i].FontFamily = "TiltNeon";
            navigateLbls[i].FontSize = 15;
            navigateLbls[i].TextColor = Color.FromHsla(0, 0, 0, 0.5);
            navigateLbls[i].HorizontalTextAlignment = TextAlignment.Center;
            navigateLbls[i].Text = lblTexts[i];
        }
    }

    private void CreateImgs()
    {
        navigateImgs = [overviewImg, filesImg, scheduleImg, recruitersImg, profileImg];

        for (int i = 0; i < navigateImgs.Length; i++)
        {
            navigateImgs[i].WidthRequest = 24;
            navigateImgs[i].HeightRequest = 24;
            navigateImgs[i].HorizontalOptions = LayoutOptions.Center;
        }
    }

    private void CreateBoxes()
    {
        navigateBoxes = [overviewBox, filesBox, scheduleBox, recruitersBox, profileBox];

        for (int i = 0; i < navigateBoxes.Length; i++)
        {
            navigateBoxes[i].CornerRadius = 100;
            navigateBoxes[i].WidthRequest = 70;
            navigateBoxes[i].HeightRequest = 70;
            navigateBoxes[i].Shadow = new Shadow { Brush = Colors.Black, Offset = new Point(0, 0) };
            navigateBoxes[i].Margin = new Thickness(0, 10, 0, 0);
            navigateBoxes[i].BackgroundColor = Colors.White;
            navigateBoxes[i].HorizontalOptions = LayoutOptions.Center;
        }
    }

    private void CreateLays()
    {
        navigateLays = [overviewLay, filesLay, scheduleLay, recruitersLay, profileLay];

        for (int i = 0; i < navigateLays.Length; i++)
        {
            navigateLays[i].WidthRequest = 70;
            navigateLays[i].Margin = new Thickness(0, 17, 0, 0);
        }
    }

    private void CreateIcons()
    {
        CreateBtns();
        CreateLbls();
        CreateImgs();
        CreateBoxes();
        CreateLays();

        BoxViewBorder.Shadow = new Shadow { Brush=Colors.Black, Offset = new Point(0, 0) };

        for (int i = 0; i < imgNames.Length; i++)
        {
            var box = new BoxView
            {
                CornerRadius = 0,
                WidthRequest = 100,
                HeightRequest = 90,
                Margin = new Thickness(-20, 0, 0, 0),
                BackgroundColor = Colors.White
            };

            if (i == 0)
            {
                box.Margin = new Thickness(-10, 0, 0, 0);
                box.CornerRadius = 15;
            }
            else if (i == imgNames.Length - 1)
            {
                box.Margin = new Thickness(-20, 0, 0, 0);
                box.CornerRadius = 15;
            }

            navigateLays[i].Children.Add(navigateBtns[i]);
            navigateLays[i].Children.Add(
                new VerticalStackLayout
                {
                    WidthRequest = 70,
                    BackgroundColor = Colors.Transparent,
                    Margin = new Thickness(20, -50, 20, 0),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        navigateImgs[i],
                        navigateLbls[i]
                    }
                }
            );

            BgNavStack.Add(new AbsoluteLayout
            {
                WidthRequest = 95,
                Padding = 0,
                Children = {
                    navigateBoxes[i],
                    box,
                    navigateLays[i]
                }
            });

            //NavigateLayout.Children.Add(navigateBoxes[i]);
        }
    }
}