using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;

namespace SukiUI_Demo.Configs;

public abstract partial class DemoPageBase(string displayName, MaterialIconKind icon, int index = 0) : ViewModelBase
{
    [ObservableProperty] private string _displayName = displayName;
    [ObservableProperty] private MaterialIconKind _icon = icon;
    [ObservableProperty] private int _index = index;
}