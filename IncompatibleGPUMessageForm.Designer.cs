namespace CnCNet.LauncherStub
{
    partial class IncompatibleGPUMessageForm
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
            btnRunDX = new System.Windows.Forms.Button();
            lblDescription = new System.Windows.Forms.Label();
            lblXNALink = new System.Windows.Forms.LinkLabel();
            lblXNADescription = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            btnRunXNAOnce = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnRunDX
            // 
            btnRunDX.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnRunDX.DialogResult = System.Windows.Forms.DialogResult.No;
            btnRunDX.Location = new System.Drawing.Point(99, 299);
            btnRunDX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRunDX.Name = "btnRunDX";
            btnRunDX.Size = new System.Drawing.Size(244, 27);
            btnRunDX.TabIndex = 5;
            btnRunDX.Text = "Launch DirectX11 version";
            btnRunDX.UseVisualStyleBackColor = true;
            btnRunDX.Click += BtnExit_Click;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new System.Drawing.Point(12, 15);
            lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(376, 30);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "The client has detected an incompatibility between your graphics card\r\nand the DirectX11 and OpenGL versions of the CnCNet client.";
            // 
            // lblXNALink
            // 
            lblXNALink.AutoSize = true;
            lblXNALink.Location = new System.Drawing.Point(12, 145);
            lblXNALink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblXNALink.Name = "lblXNALink";
            lblXNALink.Size = new System.Drawing.Size(0, 15);
            lblXNALink.TabIndex = 2;
            lblXNALink.TabStop = true;
            lblXNALink.LinkClicked += LblXNALink_LinkClicked;
            // 
            // lblXNADescription
            // 
            lblXNADescription.AutoSize = true;
            lblXNADescription.Location = new System.Drawing.Point(12, 68);
            lblXNADescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblXNADescription.Name = "lblXNADescription";
            lblXNADescription.Size = new System.Drawing.Size(395, 60);
            lblXNADescription.TabIndex = 1;
            lblXNADescription.Text = "The XNA version of the client could still work on your system, but it needs\r\nMicrosoft XNA Framework 4.0 Refresh to be installed.\r\n\r\nYou can download the installer from the following link:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 182);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(387, 45);
            label1.TabIndex = 3;
            label1.Text = "Alternatively, you can retry launching the DirectX11 version of the client.\r\n\r\nWe apologize for the inconvenience.";
            // 
            // btnRunXNAOnce
            // 
            btnRunXNAOnce.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnRunXNAOnce.DialogResult = System.Windows.Forms.DialogResult.Yes;
            btnRunXNAOnce.Location = new System.Drawing.Point(99, 265);
            btnRunXNAOnce.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRunXNAOnce.Name = "btnRunXNAOnce";
            btnRunXNAOnce.Size = new System.Drawing.Size(244, 27);
            btnRunXNAOnce.TabIndex = 4;
            btnRunXNAOnce.Text = "Launch XNA version";
            btnRunXNAOnce.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            button1.Location = new System.Drawing.Point(99, 332);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(244, 27);
            button1.TabIndex = 6;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = true;
            // 
            // IncompatibleGPUMessageForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(442, 373);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(btnRunXNAOnce);
            Controls.Add(label1);
            Controls.Add(lblXNALink);
            Controls.Add(lblXNADescription);
            Controls.Add(btnRunDX);
            Controls.Add(lblDescription);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "IncompatibleGPUMessageForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Graphics Card Incompatibility Detected";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnRunDX;
        private System.Windows.Forms.Label lblDescription;
        internal System.Windows.Forms.LinkLabel lblXNALink;
        private System.Windows.Forms.Label lblXNADescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunXNAOnce;
        private System.Windows.Forms.Button button1;
    }
}