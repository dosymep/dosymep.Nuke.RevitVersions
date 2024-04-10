# dosymep.Nuke.RevitVersions

[![JetBrains Rider](https://img.shields.io/badge/JetBrains-Rider-blue.svg)](https://www.jetbrains.com/rider)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE.md)
[![Revit 2016-2024](https://img.shields.io/badge/Revit-2016--2024-blue.svg)](https://www.autodesk.com/products/revit/overview)

This package contains Autodesk Revit versions configurations.

## Usage

```csharp
/// <summary>
/// Min Revit version.
/// </summary>
[Parameter("Min Revit version.")] readonly RevitVersion MinVersion = RevitVersion.Rv2016;

/// <summary>
/// Max Revit version.
/// </summary>
[Parameter("Max Revit version.")] readonly RevitVersion MaxVersion = RevitVersion.Rv2025;
    
DotNetBuild(s => s
    .EnableForce()
    .DisableNoRestore()
    .SetProjectFile(<ProjectName>)
    .SetConfiguration(<Configuration>)
    .When(IsServerBuild, _ => _
        .EnableContinuousIntegrationBuild())
    // HACK: enable restore to set TargetFramework property
    .SetProcessArgumentConfigurator(a => a.Add("--restore"))
    .CombineWith(RevitVersion.GetRevitVersions(), (settings, version) => {
        return settings
            .SetOutputDirectory(OutputDirectory / version)
            .SetProperty("RevitVersion", (int) version)
            .SetProperty("TargetFramework", version.TargetFramework);
    }));
```