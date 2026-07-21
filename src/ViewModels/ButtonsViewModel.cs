using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;
using SukiUI_Demo.Configs;

namespace SukiUI_Demo.ViewModels;

public partial class ButtonsViewModel() : DemoPageBase("Buttons", MaterialIconKind.CursorDefaultClick)
{
    [ObservableProperty] private bool _isBusy;
    [ObservableProperty] private bool _isEnabled = true;

    [RelayCommand]
    private Task ButtonClicked()
    {
        if (IsBusy)
            return Task.CompletedTask;

        return Task.Run(async () =>
        {
            IsBusy = true;
            await Task.Delay(3000);
            IsBusy = false;
        });
    }
}