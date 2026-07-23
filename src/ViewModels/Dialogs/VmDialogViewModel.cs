using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SukiUI.Dialogs;
using SukiUI_Demo.Configs;

namespace SukiUI_Demo.ViewModels.Dialogs;

public partial class VmDialogViewModel(ISukiDialog dialog) : ViewModelBase
{
    [RelayCommand]
    private void CloseDialog() => dialog.Dismiss();
}