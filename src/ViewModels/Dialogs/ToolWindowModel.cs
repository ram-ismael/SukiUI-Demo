using CommunityToolkit.Mvvm.ComponentModel;
using SukiUI_Demo.Configs;

namespace SukiUI_Demo.ViewModels.Dialogs;

public partial class ToolWindowModel : ViewModelBase
{
    [ObservableProperty]
    private double _maxWidthScreenRatio;

    [ObservableProperty]
    private double _maxHeightScreenRatio;

    [ObservableProperty]
    private bool _canResize;

    [ObservableProperty]
    private bool _canMaximize;

    [ObservableProperty]
    private string _header = string.Empty;

    [ObservableProperty]
    private string _message = string.Empty;
}