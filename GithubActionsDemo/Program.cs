// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System;

var framework = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
Console.WriteLine($"Demo App AssemblyVersion {GetAssemblyVersion()} running with {framework}!");

Console.WriteLine($"Demo App FileVersion {GetFileVersion()} running with {framework}!");

Console.WriteLine($"Demo App Version {GetVersion()} running with {framework}!");

static string GetAssemblyVersion()
{
    var versionString = "-1.0.0+LOCALBUILD";

    var assembly = Assembly.GetEntryAssembly() ?? null;
    if ( assembly != null)
    {
        var version = assembly.GetName().Version ?? null;
        if ( version != null )
        {
            versionString = version.ToString();
        }
    }
    if (versionString.Contains('+'))
    {
        return versionString[..versionString.IndexOf('+')];
    }
    else
    {
        return versionString;
    }
}

static string GetFileVersion()
{
    var versionString = "-1.0.0+LOCALBUILD";

    var assembly = Assembly.GetEntryAssembly() ?? null;
    if (assembly != null)
    {
        var version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
        if (version != null)
        {
            versionString = version.ToString();
        }
    }

    if (versionString.Contains('+'))
    {
        return versionString[..versionString.IndexOf('+')];
    }
    else
    {
        return versionString;
    }
}

static string GetVersion()
{
    var versionString = "-1.0.0+LOCALBUILD";

    var assembly = Assembly.GetEntryAssembly() ?? null;
    if (assembly != null)
    {
        var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        if (version != null)
        {
            versionString = version.ToString();
        }
    }

    if (versionString.Contains('+'))
    {
        return versionString[..versionString.IndexOf('+')];
    }
    else
    {
        return versionString;
    }
}
