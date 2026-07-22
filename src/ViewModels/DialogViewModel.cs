using CommunityToolkit.Mvvm.Input;
using SukiUI.Dialogs;
using SukiUI_Demo.Configs;

namespace SukiUI_Demo.ViewModels;

public partial class DialogViewModel(ISukiDialog dialog) : ViewModelBase
{
    [RelayCommand]
    private void CloseDialog()
    {
        dialog.Dismiss();
    }
}