using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;
using SukiUI.Dialogs;
using SukiUI_Demo.Configs;

namespace SukiUI_Demo.ViewModels;

public partial class AllControlsViewModel : DemoPageBase
{
    [ObservableProperty] private ISukiDialogManager dialogManager;
    public AllControlsViewModel(ISukiDialogManager dialogManager) : base("All Controls", MaterialIconKind.ViewDashboard, 100)
    {
        DialogManager = dialogManager;
    }
}
