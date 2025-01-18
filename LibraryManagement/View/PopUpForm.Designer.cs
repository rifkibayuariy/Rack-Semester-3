namespace LibraryManagement.View
{
    partial class PopUpForm
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
            this.components = new System.ComponentModel.Container();
            this.FormPopUp = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.header = new Guna.UI2.WinForms.Guna2Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.title = new System.Windows.Forms.Label();
            this.logoHeader = new Guna.UI2.WinForms.Guna2PictureBox();
            this.PopUpFormContainer = new System.Windows.Forms.Panel();
            this.mdPopUp = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.header.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPopUp
            // 
            this.FormPopUp.ContainerControl = this;
            this.FormPopUp.DockIndicatorTransparencyValue = 0.6D;
            this.FormPopUp.TransparentWhileDrag = true;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.Transparent;
            this.header.Controls.Add(this.panel1);
            this.header.Controls.Add(this.title);
            this.header.Controls.Add(this.logoHeader);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.FillColor = System.Drawing.Color.White;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Margin = new System.Windows.Forms.Padding(0);
            this.header.Name = "header";
            this.header.Padding = new System.Windows.Forms.Padding(24, 4, 8, 4);
            this.header.ShadowDecoration.BorderRadius = 0;
            this.header.ShadowDecoration.Depth = 2;
            this.header.ShadowDecoration.Enabled = true;
            this.header.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.header.Size = new System.Drawing.Size(600, 30);
            this.header.TabIndex = 3;
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(551, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(41, 22);
            this.panel1.TabIndex = 3;
            // 
            // cbClose
            // 
            this.cbClose.BorderRadius = 2;
            this.cbClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbClose.FillColor = System.Drawing.Color.OrangeRed;
            this.cbClose.IconColor = System.Drawing.Color.White;
            this.cbClose.Location = new System.Drawing.Point(3, 2);
            this.cbClose.Name = "cbClose";
            this.cbClose.Size = new System.Drawing.Size(36, 18);
            this.cbClose.TabIndex = 2;
            // 
            // title
            // 
            this.title.Dock = System.Windows.Forms.DockStyle.Left;
            this.title.Font = new System.Drawing.Font("Plus Jakarta Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.title.Location = new System.Drawing.Point(82, 4);
            this.title.Margin = new System.Windows.Forms.Padding(0);
            this.title.Name = "title";
            this.title.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.title.Size = new System.Drawing.Size(466, 22);
            this.title.TabIndex = 1;
            this.title.Text = "Pop Up Form";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // logoHeader
            // 
            this.logoHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.logoHeader.Image = global::LibraryManagement.Properties.Resources.ALGORITMADANPEMROGRAMAN_CROPPED;
            this.logoHeader.ImageRotate = 0F;
            this.logoHeader.Location = new System.Drawing.Point(24, 4);
            this.logoHeader.Margin = new System.Windows.Forms.Padding(0);
            this.logoHeader.Name = "logoHeader";
            this.logoHeader.Size = new System.Drawing.Size(58, 22);
            this.logoHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoHeader.TabIndex = 0;
            this.logoHeader.TabStop = false;
            this.logoHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // PopUpFormContainer
            // 
            this.PopUpFormContainer.AutoScroll = true;
            this.PopUpFormContainer.BackColor = System.Drawing.Color.Transparent;
            this.PopUpFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PopUpFormContainer.Location = new System.Drawing.Point(0, 30);
            this.PopUpFormContainer.Name = "PopUpFormContainer";
            this.PopUpFormContainer.Size = new System.Drawing.Size(600, 470);
            this.PopUpFormContainer.TabIndex = 4;
            // 
            // mdPopUp
            // 
            this.mdPopUp.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.mdPopUp.Caption = "";
            this.mdPopUp.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.mdPopUp.Parent = this;
            this.mdPopUp.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.mdPopUp.Text = "";
            // 
            // PopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.PopUpFormContainer);
            this.Controls.Add(this.header);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "PopUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PopUpForm";
            this.header.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm FormPopUp;
        private Guna.UI2.WinForms.Guna2Panel header;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2ControlBox cbClose;
        private System.Windows.Forms.Label title;
        private Guna.UI2.WinForms.Guna2PictureBox logoHeader;
        private System.Windows.Forms.Panel PopUpFormContainer;
        private Guna.UI2.WinForms.Guna2MessageDialog mdPopUp;
    }
}