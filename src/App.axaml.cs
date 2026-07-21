using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using SukiUI.Dialogs;
using SukiUI.Toasts;
using SukiUI_Demo.Configs;
using SukiUI_Demo.ViewModels;
using SukiUI_Demo.Views;

namespace SukiUI_Demo;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var services = new ServiceCollection();
            services.AddSingleton(desktop);
            var views = ConfigureViews(services);
            var provider = ConfigureServices(services);
            desktop.MainWindow = views.CreateView<WindowViewModel>(provider) as Window;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static SukiViews ConfigureViews(ServiceCollection services)
    {
        return new SukiViews()

            // Add main view
            .AddView<WindowView, WindowViewModel>(services)
            .AddView<ButtonsView, ButtonsViewModel>(services);
    }

    private static ServiceProvider ConfigureServices(ServiceCollection services)
    {
        //services.AddSingleton<ClipboardService>();
        services.AddSingleton<PageNavigationConfig>();
        services.AddSingleton<ISukiToastManager, SukiToastManager>();
        services.AddSingleton<ISukiDialogManager, SukiDialogManager>();

        return services.BuildServiceProvider();
    }
}