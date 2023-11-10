namespace CnCNet.LauncherStub;

partial class ComponentMissingMessageForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblDescription = new System.Windows.Forms.Label();
        lblLink = new System.Windows.Forms.LinkLabel();
        btnExit = new System.Windows.Forms.Button();
        lblDownload = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // lblDescription
        // 
        lblDescription.AutoSize = true;
        lblDescription.Location = new System.Drawing.Point(12, 14);
        lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new System.Drawing.Size(166, 15);
        lblDescription.TabIndex = 0;
        lblDescription.Text = "Your system is missing the {0}.";
        // 
        // lblLink
        // 
        lblLink.AutoSize = true;
        lblLink.LinkArea = new System.Windows.Forms.LinkArea(0, 62);
        lblLink.Location = new System.Drawing.Point(13, 56);
        lblLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblLink.Name = "lblLink";
        lblLink.Size = new System.Drawing.Size(0, 18);
        lblLink.TabIndex = 2;
        lblLink.TabStop = true;
        lblLink.LinkClicked += LblDotNetLink_LinkClicked;
        // 
        // btnExit
        // 
        btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        btnExit.Location = new System.Drawing.Point(90, 89);
        btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnExit.Name = "btnExit";
        btnExit.Size = new System.Drawing.Size(114, 27);
        btnExit.TabIndex = 3;
        btnExit.Text = "Exit";
        btnExit.UseVisualStyleBackColor = true;
        btnExit.Click += BtnExit_Click;
        // 
        // lblDownload
        // 
        lblDownload.AutoSize = true;
        lblDownload.Location = new System.Drawing.Point(12, 41);
        lblDownload.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblDownload.Name = "lblDownload";
        lblDownload.Size = new System.Drawing.Size(296, 15);
        lblDownload.TabIndex = 1;
        lblDownload.Text = "You can download the installer from the following link:\r\n";
        // 
        // ComponentMissingMessageForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoSize = true;
        AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        ClientSize = new System.Drawing.Size(320, 128);
        ControlBox = false;
        Controls.Add(lblDownload);
        Controls.Add(btnExit);
        Controls.Add(lblLink);
        Controls.Add(lblDescription);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ComponentMissingMessageForm";
        ShowIcon = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Component Missing";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private System.Windows.Forms.Button btnExit;
    internal System.Windows.Forms.Label lblDescription;
    internal System.Windows.Forms.Label lblDownload;
    internal System.Windows.Forms.LinkLabel lblLink;
}