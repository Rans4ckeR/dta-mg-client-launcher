﻿namespace DTALauncherStub;

using System;
using System.Diagnostics;
using System.Windows.Forms;

internal sealed partial class XNAFrameworkMissingMessageForm : Form
{
    public XNAFrameworkMissingMessageForm()
    {
        InitializeComponent();
    }

    private void LblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
        using var _ = Process.Start(new ProcessStartInfo
        {
            FileName = "https://www.microsoft.com/en-us/download/details.aspx?id=27598",
            UseShellExecute = true
        });
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
    }

    private void BtnExit_Click(object sender, EventArgs e)
    {
        Close();
    }
}