﻿namespace DTALauncherStub;

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

internal sealed class Program
{
    private const string Resources = "Resources";
    private const string Binaries = "Binaries";
    private const int DotNetMajorVersion = 7;
    private const string DotNetDownloadLink = "https://dotnet.microsoft.com/download/dotnet/7.0/runtime";
    private const string XnaDownloadLink = "https://www.microsoft.com/download/details.aspx?id=27598";

    [STAThread]
    private static void Main(string[] args)
    {
        try
        {
            ApplicationConfiguration.Initialize();

            foreach (string arg in args)
            {
                if ("-XNA".Equals(arg, StringComparison.OrdinalIgnoreCase))
                {
                    RunXna();
                    return;
                }

                if ("-OGL".Equals(arg, StringComparison.OrdinalIgnoreCase))
                {
                    RunOgl();
                    return;
                }

                if ("-DX".Equals(arg, StringComparison.OrdinalIgnoreCase))
                {
                    RunDx();
                    return;
                }

                if ("-UGL".Equals(arg, StringComparison.OrdinalIgnoreCase))
                {
                    RunUgl();
                    return;
                }
            }

            AutoRun();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Client Launcher Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }
    }

    private static void RunXna()
    {
        if (!IsXnaFramework4RefreshInstalled())
            ShowMissingComponentForm("'Microsoft XNA Framework 4.0 Refresh'", XnaDownloadLink);

        StartProcess(GetClientProcessPath("XNA", "clientxna.dll"), true);
    }

    private static void RunOgl()
        => StartProcess(GetClientProcessPath("OpenGL", "clientogl.dll"));

    private static void RunDx()
        => StartProcess(GetClientProcessPath("Windows", "clientdx.dll"));

    private static void RunUgl()
        => StartProcess(GetClientProcessPath("UniversalGL", "clientogl.dll"), false, false);

    private static string GetClientProcessPath(string directory, string file)
        => FormattableString.Invariant($"{Resources}\\{Binaries}\\{directory}\\{file}");

    private static void AutoRun()
    {
        string basePath = FormattableString.Invariant($"{Environment.CurrentDirectory}\\Client\\");
        var dxFailFile = new FileInfo(FormattableString.Invariant($"{basePath}.dxfail"));
        var oglFailFile = new FileInfo(FormattableString.Invariant($"{basePath}.oglfail"));

        if (dxFailFile.Exists)
        {
            if (oglFailFile.Exists)
            {
                if (IsXnaFramework4RefreshInstalled())
                {
                    RunXna();
                    return;
                }

                var incompatibleGpuForm = new IncompatibleGPUMessageForm();

                SetLinkLabelUrl(incompatibleGpuForm.lblXNALink, XnaDownloadLink);

                switch (incompatibleGpuForm.ShowDialog())
                {
                    case DialogResult.No:
                        dxFailFile.Delete();
                        oglFailFile.Delete();
                        AutoRun();
                        break;
                    case DialogResult.Yes:
                        RunXna();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            RunOgl();
        }

        RunDx();
    }

    private static void SetLinkLabelUrl(LinkLabel linkLabel, string url)
    {
        linkLabel.Text = url;
        linkLabel.Links[0].LinkData = url;
    }

    private static void StartProcess(string relativePath, bool run32Bit = false, bool runDesktop = true)
    {
        if (!Environment.Is64BitOperatingSystem)
            run32Bit = true;

        FileInfo dotnetHost = CheckAndRetrieveDotNetHost(run32Bit ? Architecture.X86 : RuntimeInformation.OSArchitecture, runDesktop);
        string absolutePath = FormattableString.Invariant($"{Environment.CurrentDirectory}\\{relativePath}");

        if (!File.Exists(absolutePath))
        {
            MessageBox.Show(
                FormattableString.CurrentCulture($"Main client library ({relativePath}) not found!"),
                "Client Launcher Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            Environment.Exit(3);
        }

#pragma warning disable SA1312 // Variable names should begin with lower-case letter
        using var _ = Process.Start(new ProcessStartInfo
        {
            FileName = dotnetHost.FullName,
            Arguments = "\"" + absolutePath + "\"",
            CreateNoWindow = true
        });
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
    }

    private static FileInfo CheckAndRetrieveDotNetHost(Architecture architecture, bool runDesktop)
    {
        if (runDesktop && !IsDotNetDesktopInstalled(architecture))
        {
            string missingComponent = FormattableString.Invariant($"'.NET Desktop Runtime' version {DotNetMajorVersion} for platform {architecture}");

            ShowMissingComponentForm(missingComponent, DotNetDownloadLink);
        }

        FileInfo? dotnetHost = GetDotNetHost(architecture);

        if (!(dotnetHost?.Exists ?? false))
        {
            string missingComponent = FormattableString.Invariant($"'.NET Runtime' version {DotNetMajorVersion} for platform {architecture}");

            ShowMissingComponentForm(missingComponent, DotNetDownloadLink);
        }

        return dotnetHost!;
    }

    private static void ShowMissingComponentForm(string missingComponent, string downloadLink)
    {
        var messageForm = new ComponentMissingMessageForm();

        messageForm.lblDescription.Text = FormattableString.CurrentCulture($"The component {missingComponent} is missing.");

        SetLinkLabelUrl(messageForm.lblLink, downloadLink);
        Application.Run(messageForm);
        Environment.Exit(2);
    }

    private static bool IsXnaFramework4RefreshInstalled()
    {
        using var localMachine32BitRegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
        using RegistryKey? xnaKey = localMachine32BitRegistryKey.OpenSubKey("SOFTWARE\\Microsoft\\XNA\\Framework\\v4.0");

        return "1".Equals(xnaKey?.GetValue("Refresh1Installed")?.ToString(), StringComparison.OrdinalIgnoreCase);
    }

    private static FileInfo? GetDotNetHost(Architecture architecture)
    {
        if (!IsDotNetCoreInstalled(architecture))
            return null;

        using var localMachine32BitRegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
        using RegistryKey? dotnetArchitectureKey = localMachine32BitRegistryKey.OpenSubKey(
            FormattableString.Invariant($"SOFTWARE\\dotnet\\Setup\\InstalledVersions\\{architecture}"));
        string? installLocation = dotnetArchitectureKey?.GetValue("InstallLocation")?.ToString();

        return installLocation is null ? null : new FileInfo(FormattableString.Invariant($"{installLocation}\\dotnet.exe"));
    }

    private static bool IsDotNetCoreInstalled(Architecture architecture)
        => IsDotNetInstalled(architecture, "Microsoft.NETCore.App");

    private static bool IsDotNetDesktopInstalled(Architecture architecture)
        => IsDotNetInstalled(architecture, "Microsoft.WindowsDesktop.App");

    private static bool IsDotNetInstalled(Architecture architecture, string sharedFrameworkName)
    {
        using var localMachine32BitRegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
        using RegistryKey? dotnetSharedFrameworkKey = localMachine32BitRegistryKey.OpenSubKey(
            FormattableString.Invariant($"SOFTWARE\\dotnet\\Setup\\InstalledVersions\\{architecture}\\sharedfx\\{sharedFrameworkName}"));

        return dotnetSharedFrameworkKey?.GetValueNames().Any(q =>
            q.StartsWith(FormattableString.Invariant($"{DotNetMajorVersion}."), StringComparison.OrdinalIgnoreCase)
            && !q.Contains('-', StringComparison.OrdinalIgnoreCase)
            && "1".Equals(dotnetSharedFrameworkKey.GetValue(q)?.ToString(), StringComparison.OrdinalIgnoreCase)) ?? false;
    }
}