using System.Threading;
using Avalonia.Controls;

namespace SukiUI_Demo.Views;
public partial class HelpersView : UserControl
{
    private readonly CancellationTokenSource token = new();
    
    public HelpersView()
    {
        InitializeComponent();
    }
}