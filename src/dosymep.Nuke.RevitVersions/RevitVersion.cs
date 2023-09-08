using System.ComponentModel;
using System.Reflection;

using Nuke.Common.Tooling;

namespace dosymep.Nuke.RevitVersions;

/// <summary>
/// Revit version configurations.
/// </summary>
[TypeConverter(typeof(TypeConverter<RevitVersion>))]
public class RevitVersion : Enumeration {
    /// <summary>
    /// Autodesk Revit 2016 version configuration.
    /// </summary>
    public static readonly RevitVersion Rv2016 = new() {Value = "2016", TargetFramework = "net45"};

    /// <summary>
    /// Autodesk Revit 2017 version configuration.
    /// </summary>
    public static readonly RevitVersion Rv2017 = new() {Value = "2017", TargetFramework = "net452"};

    /// <summary>
    /// Autodesk Revit 2018 version configuration.
    /// </summary>
    public static readonly RevitVersion Rv2018 = new() {Value = "2018", TargetFramework = "net452"};

    /// <summary>
    /// Autodesk Revit 2019 version configuration.
    /// </summary>
    public static readonly RevitVersion Rv2019 = new() {Value = "2019", TargetFramework = "net47"};

    /// <summary>
    /// Autodesk Revit 2020 version configuration.
    /// </summary>
    public static readonly RevitVersion Rv2020 = new() {Value = "2020", TargetFramework = "net47"};

    /// <summary>
    /// Autodesk Revit 2021 version configuration.
    /// </summary>
    public static readonly RevitVersion Rv2021 = new() {Value = "2021", TargetFramework = "net48"};

    /// <summary>
    /// Autodesk Revit 2022 version configuration.
    /// </summary>
    public static readonly RevitVersion Rv2022 = new() {Value = "2022", TargetFramework = "net48"};

    /// <summary>
    /// Autodesk Revit 2023 version configuration.
    /// </summary>
    public static readonly RevitVersion Rv2023 = new() {Value = "2023", TargetFramework = "net48"};

    /// <summary>
    /// Autodesk Revit 2024 version configuration.
    /// </summary>
    public static readonly RevitVersion Rv2024 = new() {Value = "2024", TargetFramework = "net48"};

    /// <summary>
    /// Target framework.
    /// </summary>
    public string TargetFramework { get; set; } = default!;

    /// <summary>
    /// String implicit operator.
    /// </summary>
    /// <param name="revitVersion">Revit version.</param>
    /// <returns>Returns a string representation of the version.</returns>
    public static implicit operator string(RevitVersion revitVersion) => revitVersion.Value;

    /// <summary>
    /// Int32 implicit operator.
    /// </summary>
    /// <param name="revitVersion">Revit version.</param>
    /// <returns>Returns a Int32 representation of the version.</returns>
    public static implicit operator int(RevitVersion revitVersion) => int.Parse(revitVersion.Value);

    /// <summary>
    /// Returns revit version by
    /// <paramref name="minVersion"/> and <paramref name="maxVersion"/>.
    /// </summary>
    /// <param name="minVersion">Min Revit version.</param>
    /// <param name="maxVersion">Max Revit version.</param>
    /// <returns>
    /// Returns list Revit versions by
    /// <paramref name="minVersion"/> and <paramref name="maxVersion"/>.
    /// </returns>
    public static IEnumerable<RevitVersion> GetRevitVersions(int minVersion = 2016, int maxVersion = 2024) =>
        typeof(RevitVersion).GetFields(BindingFlags.Static | BindingFlags.Public)
            .Where(item => item.Name.StartsWith("Rv"))
            .Select(item => item.GetValue(null))
            .OfType<RevitVersion>()
            .Where(item => item >= minVersion && item <= maxVersion);
}