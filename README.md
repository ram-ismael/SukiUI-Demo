![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)
![Avalonia](https://img.shields.io/badge/Avalonia-12-8A2BE2)
![SukiUI](https://img.shields.io/badge/SukiUI-7.x-orange)
![License](https://img.shields.io/badge/license-MIT-green)

# SukiUI-Demo

A reference project for building desktop applications with **Avalonia** and **SukiUI** — showcasing a clean, opinionated project structure, reusable patterns, and small implementation examples (buttons, infobars, expanders, toasts, and more).

This isn't a production app. It's a living playground I use to work out architecture decisions, folder organization, and SukiUI usage patterns before reusing them in real projects — kept public and open source so anyone else building with Avalonia + SukiUI can use it as a starting template or reference.

## ✨ What's inside

- A pragmatic **MVVM** project layout (`ViewModels`, `Views`, `Helpers`, `Configs`)
- SukiUI theming setup (`Theme/TouchStyles`)
- Working examples of common SukiUI controls: buttons, infobars, expanders, toasts, etc...
- A structure meant to scale cleanly as a project grows, without over-engineering

## 🧱 Tech stack

| | |
|---|---|
| Framework | [Avalonia](https://avaloniaui.net/) 12 |
| UI toolkit | [SukiUI](https://github.com/kikipoulet/SukiUI) / SukiUI.Dock |
| Runtime | .NET 10 |
| Pattern | MVVM (CommunityToolkit.Mvvm) |

## 📁 Project structure

```
src/
├── Assets/              # Images, icons, fonts
├── Configs/             # App-level configuration
├── Helpers/             # Utility / helper classes
├── Theme/TouchStyles/   # SukiUI theming & custom styles
├── ViewModels/          # MVVM view models
├── Views/               # Avalonia views (.axaml)
├── App.axaml
└── App.axaml.cs
```

## 🚀 Getting started

**Prerequisites:** [.NET 10 SDK](https://dotnet.microsoft.com/download)

```bash
git clone https://github.com/ram-ismael/SukiUI-Demo.git
cd SukiUI-Demo
dotnet restore
dotnet run --project SukiUI-Demo.csproj
```

## 🤝 Contributing

This project exists to be shared and improved. If you like the organization, have a cleaner way of structuring something, or want to add another SukiUI pattern:

- Open a **pull request** with your change, or
- Start a **discussion** if you'd rather talk through an idea first

All contributions, big or small, are welcome — this is meant to grow with input from anyone using Avalonia + SukiUI.

## 📄 License

This project is licensed under the [MIT License](LICENSE) — use it, fork it, adapt it freely.

## 🙏 Acknowledgments

- [Avalonia](https://avaloniaui.net/) — the cross-platform .NET UI framework
- [SukiUI](https://github.com/kikipoulet/SukiUI) by [@kikipoulet](https://github.com/kikipoulet) — the theming library this project is built around
