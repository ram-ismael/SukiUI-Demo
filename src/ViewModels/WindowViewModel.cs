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

        /* Pass the ViewModel instance as Content — ViewLocator will resolve the view
        Pages.Add(new PageModel("Dashboard", MaterialIconKind.ViewDashboard, new DashboardViewModel()));
        Pages.Add(new PageModel("Enrolment", MaterialIconKind.ClipboardText, new EnrolmentViewModel()));
        Pages.Add(new PageModel("Students", MaterialIconKind.School, new StudentsViewModel()));
        Pages.Add(new PageModel("Users", MaterialIconKind.AccountGroup, new UsersViewModel()));
        Pages.Add(new PageModel("Payments", MaterialIconKind.CashMultiple, new PaymentsViewModel()));
        Pages.Add(new PageModel("Financial", MaterialIconKind.ChartLine, new FinancialViewModel()));
        Pages.Add(new PageModel("Settings", MaterialIconKind.Cog, new SettingsViewModel()));*/

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