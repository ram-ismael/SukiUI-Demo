using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SukiUI_Demo.Views;

public partial class ThemingView : UserControl
{
    public ThemingView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}