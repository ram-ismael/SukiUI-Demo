using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using SukiUI.Helpers;

namespace SukiUI_Demo.Views;

public partial class ButtonsView : UserControl
{
    public ButtonsView()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button mybutton)
            return;

        mybutton.Animate(OpacityProperty).WithDuration(TimeSpan.FromSeconds(2)).To(0.5)
            .And().Animate(WidthProperty).To(20)
            .Then().Animate(OpacityProperty).WithDuration(TimeSpan.FromSeconds(2)).To(1)
            .And().Animate(WidthProperty).To(200)
            .ContinueWith(() => Console.WriteLine("Done."));
    }
}

