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

        for (int i = 0; i < navigateLbls.Length; i++)
        {
            navigateLbls[i].TextColor = Color.FromHsla(0, 0, 0, 0.5);
        }
        overviewLbl.TextColor = Colors.Black;
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

    private void CreateIcons()
    {
        CreateBtns();
        CreateLbls();
        CreateImgs();

        for (int i = 0; i < imgNames.Length; i++)
        {
            NavigateStack.Add(new VerticalStackLayout
            {
                navigateBtns[i],
                new VerticalStackLayout
                {
                    Margin = new Thickness(20,-50,20,0),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        navigateImgs[i],
                        navigateLbls[i]
                    }
                }
            });
        }
    }
}