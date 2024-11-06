using Microsoft.Maui.Layouts;

namespace TeamSpace_Mobile.Controls;

public class SlideToConfirm : ContentView
{
    private readonly Slider _slider;
    private readonly Frame _startFrame;
    private readonly Frame _endFrame;
    private readonly Frame _circle;
    private readonly Image _confirmed;
    private readonly Image _arrows;
    private readonly double _maxValue = 100;

    private readonly Label _startText;
    private readonly Label _endText;

    public event EventHandler SlideConfirmed;

    public SlideToConfirm()
    {
        var gradientBrushStart = new LinearGradientBrush(
            new GradientStopCollection
            {
                new GradientStop(Color.FromArgb("#F97794"), 0.0f),
                new GradientStop(Colors.Transparent, 0.3f),
                new GradientStop(Colors.Transparent, 1.0f)
            },
            new Point(0, 0),
            new Point(1, 1)
        );

        var gradientBrushEnd = new LinearGradientBrush(
            new GradientStopCollection
            {
                new GradientStop(Color.FromArgb("#F97794"), 0.0f),
                new GradientStop(Color.FromArgb("#623AA2"), 1.0f)
            },
            new Point(0, 1),
            new Point(1, 0)
        );

        _startFrame = new Frame
        {
            Background = gradientBrushStart,
            CornerRadius = 50,
            HeightRequest = 37,
            WidthRequest = 300,
            BorderColor = Colors.Black,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Padding = new Thickness(10),
            Opacity = 1
        };

        _endFrame = new Frame
        {
            Background = gradientBrushEnd,
            CornerRadius = 50,
            HeightRequest = 37,
            WidthRequest = 300,
            BorderColor = Colors.Black,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Padding = new Thickness(10),
            Opacity = 0
        };

        _startText = new Label
        {
            Text = "Slide to confirm",
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Center,
            TextColor = Color.FromArgb("#262626"),
            FontFamily = "TiltNeon",
            FontSize = 15,
            Margin = new Thickness(0, -5, 30, 0),
            Opacity = 1
        };

        _endText = new Label
        {
            Text = "Confirmed!",
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            TextColor = Color.FromArgb("#262626"),
            FontFamily = "TiltNeon",
            FontSize = 15,
            Margin = new Thickness(30, -5, 0, 0),
            Opacity = 0
        };

        _slider = new Slider
        {
            Minimum = 0,
            Maximum = _maxValue,
            Value = 0,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 300,
            BackgroundColor = Colors.Transparent,
            ThumbColor = Colors.Transparent,
            MinimumTrackColor = Colors.Transparent,
            MaximumTrackColor = Colors.Transparent
        };
        _slider.ValueChanged += OnSliderValueChanged;

        _arrows = new Image
        {
            Source = "circle.png",
            WidthRequest = 35,
            HeightRequest = 35,
            Aspect = Aspect.AspectFill,
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill
        };

        _confirmed = new Image
        {
            Source = "check_mark.gif",
            WidthRequest = 35,
            HeightRequest = 35,
            Aspect = Aspect.AspectFill,
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill,
            IsAnimationPlaying = true
        };

        _circle = new Frame
        {
            WidthRequest = 35,
            HeightRequest = 35,
            CornerRadius = 50,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Start,
            BackgroundColor = Color.FromHsla(255, 255, 255, 0.5),
            Content = _arrows
        };

        var layout = new AbsoluteLayout
        {
            WidthRequest = 300,
            HeightRequest = 37,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };

        AbsoluteLayout.SetLayoutFlags(_startFrame, AbsoluteLayoutFlags.All);
        AbsoluteLayout.SetLayoutBounds(_startFrame, new Rect(0, 0, 1, 1));

        AbsoluteLayout.SetLayoutFlags(_endFrame, AbsoluteLayoutFlags.All);
        AbsoluteLayout.SetLayoutBounds(_endFrame, new Rect(0, 0, 1, 1));

        AbsoluteLayout.SetLayoutFlags(_slider, AbsoluteLayoutFlags.All);
        AbsoluteLayout.SetLayoutBounds(_slider, new Rect(0, 0, 1, 1));

        AbsoluteLayout.SetLayoutFlags(_circle, AbsoluteLayoutFlags.PositionProportional);
        AbsoluteLayout.SetLayoutBounds(_circle, new Rect(0, 0.5, 35, 35));

        _startFrame.Content = _startText;
        _endFrame.Content = _endText;
        layout.Children.Add(_startFrame);
        layout.Children.Add(_endFrame);
        layout.Children.Add(_slider);
        layout.Children.Add(_circle);

        Content = layout;

        UpdateCirclePosition();
    }

    private async void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        double newPosition = _slider.Value / _maxValue;

        AbsoluteLayout.SetLayoutBounds(_circle, new Rect(newPosition, 0.5, 35, 35));

        if (_slider.Value <= 20)
        {
            _startText.Opacity = 1;
            _startFrame.Opacity = 1;
            _endText.Opacity = 0;
            _endFrame.Opacity = 0;
        }
        else if (_slider.Value >= _maxValue - 20)
        {
            _startText.Opacity = 0;
            _startFrame.Opacity = 0;
            _endText.Opacity = 1;
            _endFrame.Opacity = 1;
        }
        else
        {
            double midPosition = (_slider.Value - 20) / (_maxValue - 40);
            _startText.Opacity = 1 - midPosition;
            _startFrame.Opacity = 1 - midPosition;
            _endText.Opacity = midPosition;
            _endFrame.Opacity = midPosition;
        }

        if (_slider.Value >= _maxValue)
        {
            _circle.BackgroundColor = Colors.Transparent;
            _circle.Content = _confirmed;
            await Task.Delay(1000);
            _confirmed.IsAnimationPlaying = false;
            SlideConfirmed?.Invoke(this, EventArgs.Empty);
        }
    }

    private void UpdateCirclePosition()
    {
        double sliderWidth = _slider.Width - _circle.WidthRequest;
        double percentage = _slider.Value / _maxValue;
        double circlePosition = percentage * sliderWidth;

        AbsoluteLayout.SetLayoutBounds(_circle, new Rect(circlePosition, 0.5, _circle.WidthRequest, _circle.HeightRequest));
    }
}