using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;
using SukiUI_Demo.Configs;

namespace SukiUI_Demo.ViewModels;

public partial class HelpersViewModel() : DemoPageBase("Helpers", MaterialIconKind.PaletteOutline, -2)
{
        
    [ObservableProperty] private bool myBool;
    [ObservableProperty] private int counter = 8;
        
    public void IncreaseCounter()
    {
        Counter++;
    }
    
    public void DecreaseCounter()
    {
        Counter--;
    }
        
    public void InvertBool()
    {
        MyBool = !MyBool;
    }
}