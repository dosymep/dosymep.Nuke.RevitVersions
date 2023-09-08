# dosymep.Nuke.RevitVersions

This package contains Autodesk Revit versions configurations.

## Usage

```csharp
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