using Avalonia;
using Avalonia.Controls.Notifications;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;
using SukiUI_Demo.Configs;
using SukiUI_Demo.Helpers;
using SukiUI.Toasts;
using SukiUI.Dialogs;
using System.Collections.Generic;
using Avalonia.Collections;
using System.Linq;

namespace SukiUI_Demo.ViewModels;

public partial class WindowViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isDarkMode;
    public MaterialIconKind ThemeIcon => IsDarkMode 
        ? MaterialIconKind.WeatherNight 
        : MaterialIconKind.WeatherSunny;

    public ISukiToastManager ToastManager { get; }
    public ISukiDialogManager DialogManager { get; }

    public IAvaloniaReadOnlyList<DemoPageBase> DemoPages { get; }
    public PageNavigationConfig PageNavigationConfig { get; }
    [ObservableProperty] private DemoPageBase? _activePage;

    public WindowViewModel(IEnumerable<DemoPageBase> demoPages, PageNavigationConfig pageNavigationService, ISukiToastManager toastManager, ISukiDialogManager dialogManager)
    {
        ToastManager = toastManager;
        DialogManager = dialogManager;
        DemoPages = new AvaloniaList<DemoPageBase>(demoPages.OrderBy(x => x.Index).ThenBy(x => x.DisplayName));
        PageNavigationConfig = pageNavigationService;
        PageNavigationConfig.NavigationRequested += pageType =>
        {
            var page = DemoPages.FirstOrDefault(x => x.GetType() == pageType);
            if (page is null || ActivePage?.GetType() == pageType) return;
            ActivePage = page;
        };

        var settings = ThemeHelper.Load();
        IsDarkMode = settings.IsDarkMode;
        ApplyTheme(IsDarkMode);
    }

    partial void OnIsDarkModeChanged(bool value)
    {
        ApplyTheme(value);
        OnPropertyChanged(nameof(ThemeIcon));
        ThemeHelper.Save(new ThemeSettings { IsDarkMode = value });
    }

    private static void ApplyTheme(bool isDark)
    {
        if (Application.Current is { } app)
        {
            app.RequestedThemeVariant = isDark ? ThemeVariant.Dark : ThemeVariant.Light;
        }
    }

    [RelayCommand]
    private void ToggleTheme()
    {
        IsDarkMode = !IsDarkMode;
    }

    [RelayCommand]
    private void ShowToast()
    {
        ToastManager.CreateToast()
            .OfType(NotificationType.Success)
            .WithTitle("Welcome")
            .WithContent("Content: SukiUI Demo Ready...")
            .Dismiss().ByClicking()
            .Queue();
    }

    [RelayCommand]
    private static void OpenUrl(string url) => UrlHelper.OpenUrl(url);
}





/*
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls.Notifications;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;
using SukiUI_Demo.Configs;
using SukiUI_Demo.Helpers;
using SukiUI.Toasts;
using SukiUI.Dialogs;

namespace SukiUI_Demo.ViewModels;

public partial class WindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<PageModel> _pages = new();

    [ObservableProperty]
    private PageModel? _selectedPage;

    [ObservableProperty]
    private bool _isDarkMode;

    public MaterialIconKind ThemeIcon => IsDarkMode 
        ? MaterialIconKind.WeatherNight 
        : MaterialIconKind.WeatherSunny;

    public SukiToastManager ToastManager { get; } = new();
    public SukiDialogManager DialogManager { get; } = new();

    public WindowViewModel()
    {
        var settings = ThemeHelper.Load();
        _isDarkMode = settings.IsDarkMode;
        ApplyTheme(IsDarkMode);

        // Pass the ViewModel instance as Content — ViewLocator will resolve the view
        Pages.Add(new PageModel("Dashboard", MaterialIconKind.ViewDashboard, new DashboardViewModel()));
        Pages.Add(new PageModel("Enrolment", MaterialIconKind.ClipboardText, new EnrolmentViewModel()));
        Pages.Add(new PageModel("Students", MaterialIconKind.School, new StudentsViewModel()));
        Pages.Add(new PageModel("Users", MaterialIconKind.AccountGroup, new UsersViewModel()));
        Pages.Add(new PageModel("Payments", MaterialIconKind.CashMultiple, new PaymentsViewModel()));
        Pages.Add(new PageModel("Financial", MaterialIconKind.ChartLine, new FinancialViewModel()));
        Pages.Add(new PageModel("Settings", MaterialIconKind.Cog, new SettingsViewModel()));*

        //SelectedPage = Pages[0];
    }

    partial void OnIsDarkModeChanged(bool value)
    {
        ApplyTheme(value);
        OnPropertyChanged(nameof(ThemeIcon));
        ThemeHelper.Save(new ThemeSettings { IsDarkMode = value });
    }

    private static void ApplyTheme(bool isDark)
    {
        if (Application.Current is { } app)
        {
            app.RequestedThemeVariant = isDark ? ThemeVariant.Dark : ThemeVariant.Light;
        }
    }

    [RelayCommand]
    private void ToggleTheme()
    {
        IsDarkMode = !IsDarkMode;
    }

    [RelayCommand]
    private void ShowToast()
    {
        ToastManager.CreateToast()
            .OfType(NotificationType.Success)
            .WithTitle("Welcome")
            .WithContent("Content: SukiUI Demo Ready...")
            .Dismiss().ByClicking()
            .Queue();
    }

    [RelayCommand]
    private static void Exit()
    {
        if (Application.Current?.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }
}

public partial class PageModel : ObservableObject
{
    [ObservableProperty]
    private string _title;

    [ObservableProperty]
    private MaterialIconKind _icon;

    [ObservableProperty]
    private object? _content;

    public PageModel(string title, MaterialIconKind icon, object? content = null)
    {
        Title = title;
        Icon = icon;
        Content = content;
    }
}
*/