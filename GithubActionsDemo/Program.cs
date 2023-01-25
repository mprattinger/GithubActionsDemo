// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System;

var framework = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
var version = GetVersion();
Console.WriteLine($"Demo App Version {version} running with {framework}!");

static string GetVersion()
{
    var version = "1.0.0+LOCALBUILD";
    var appAssembly = typeof(Program).Assembly;
    if (appAssembly != null)
    {
        var attrs = appAssembly.GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute));
        if (attrs != null)
        {
            var infoVerAttr = (AssemblyInformationalVersionAttribute)attrs;
            if (infoVerAttr != null && infoVerAttr.InformationalVersion.Length > 6)
            {
                version = infoVerAttr.InformationalVersion;
            }
        }
    }
    if (version.Contains('+'))
    {
        return version[..version.IndexOf('+')];
    }
    else
    {
        return version;
    }
}
