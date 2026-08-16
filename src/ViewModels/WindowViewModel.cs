/*
next = PROPERTYGRID    &   THEMING (NAVBAR)
*/


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
using SukiUI;
using SukiUI.Enums;
using SukiUI.Models;
using System;

namespace SukiUI_Demo.ViewModels;

public partial class WindowViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isDarkMode;
    public MaterialIconKind ThemeIcon => IsDarkMode 
        ? MaterialIconKind.WeatherNight 
        : MaterialIconKind.WeatherSunny;


    [ObservableProperty] private SukiBackgroundStyle _backgroundStyle = SukiBackgroundStyle.GradientSoft;
    [ObservableProperty] private bool _animationsEnabled;
    [ObservableProperty] private string? _customShaderFile;
    [ObservableProperty] private bool _transitionsEnabled;
    [ObservableProperty] private double _transitionTime;
    [ObservableProperty] private ThemeVariant? _baseTheme;
    [ObservableProperty] private bool _windowLocked;
    [ObservableProperty] private bool _titleBarVisible = true;

    public ISukiToastManager ToastManager { get; }
    public ISukiDialogManager DialogManager { get; }

    private readonly SukiTheme _theme;
    private readonly ThemingViewModel _theming;
    public IAvaloniaReadOnlyList<SukiBackgroundStyle> BackgroundStyles { get; }

    [ObservableProperty] private bool _showTitleBar = true;
    [ObservableProperty] private bool _showBottomBar = true;

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

        _theming = (ThemingViewModel)DemoPages.First(x => x is ThemingViewModel);
        _theming.BackgroundStyleChanged += style => BackgroundStyle = style;
        _theming.BackgroundAnimationsChanged += enabled => AnimationsEnabled = enabled;
        _theming.CustomBackgroundStyleChanged += shader => CustomShaderFile = shader;
        _theming.BackgroundTransitionsChanged += enabled => TransitionsEnabled = enabled;

        BackgroundStyles = new AvaloniaList<SukiBackgroundStyle>(Enum.GetValues<SukiBackgroundStyle>());
        _theme = SukiTheme.GetInstance();

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

    [RelayCommand]
    private void ToggleBaseTheme() =>
        _theme.SwitchBaseTheme();

    [RelayCommand]
    private void ToggleAnimations()
    {
        AnimationsEnabled = !AnimationsEnabled;
        ToastManager.CreateSimpleInfoToast()
            .WithTitle(AnimationsEnabled ? "Animation Enabled" : "Animation Disabled")
            .WithContent(AnimationsEnabled ? "Background animations are now enabled." : "Background animations are now disabled.")
            .Queue();
    }

    [RelayCommand]
    private void ToggleTransitions()
    {
        TransitionsEnabled = !TransitionsEnabled;
        ToastManager.CreateSimpleInfoToast()
            .WithTitle(TransitionsEnabled ? "Transitions Enabled" : "Transitions Disabled")
            .WithContent(TransitionsEnabled ? "Background transitions are now enabled." : "Background transitions are now disabled.")
            .Queue();
    }

    public void ChangeTheme(SukiColorTheme theme) =>
        _theme.ChangeColorTheme(theme);

    [RelayCommand]
    private void ToggleTitleBar()
    {
        TitleBarVisible = !TitleBarVisible;
        ToastManager.CreateSimpleInfoToast()
            .WithTitle($"Title Bar {(TitleBarVisible ? "Visible" : "Hidden")}")
            .WithContent($"Window title bar has been {(TitleBarVisible ? "shown" : "hidden")}.")
            .Queue();
    }

    [RelayCommand]
    private void ToggleTitleBackground()
    {
        ShowTitleBar = !ShowTitleBar;
        ShowBottomBar = !ShowBottomBar;
    }

    [RelayCommand]
    private void ToggleRightToLeft() => _theme.IsRightToLeft = !_theme.IsRightToLeft;

    [RelayCommand]
    private void ToggleWindowLock()
    {
        WindowLocked = !WindowLocked;
        ToastManager.CreateSimpleInfoToast()
            .WithTitle($"Window {(WindowLocked ? "Locked" : "Unlocked")}")
            .WithContent($"Window has been {(WindowLocked ? "locked" : "unlocked")}.")
            .Queue();
    }
}