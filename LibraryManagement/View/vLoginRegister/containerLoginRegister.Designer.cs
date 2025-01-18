namespace LibraryManagement.View.vLoginRegister
{
    partial class containerLoginRegister
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contentLoginRegister = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoLoginRegister = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoLoginRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // contentLoginRegister
            // 
            this.contentLoginRegister.BackColor = System.Drawing.Color.Transparent;
            this.contentLoginRegister.Dock = System.Windows.Forms.DockStyle.Right;
            this.contentLoginRegister.Location = new System.Drawing.Point(500, 0);
            this.contentLoginRegister.Name = "contentLoginRegister";
            this.contentLoginRegister.Size = new System.Drawing.Size(500, 653);
            this.contentLoginRegister.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.logoLoginRegister);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 653);
            this.panel2.TabIndex = 1;
            // 
            // logoLoginRegister
            // 
            this.logoLoginRegister.Image = global::LibraryManagement.Properties.Resources.rack_white;
            this.logoLoginRegister.Location = new System.Drawing.Point(151, 278);
            this.logoLoginRegister.Name = "logoLoginRegister";
            this.logoLoginRegister.Size = new System.Drawing.Size(206, 88);
            this.logoLoginRegister.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoLoginRegister.TabIndex = 0;
            this.logoLoginRegister.TabStop = false;
            // 
            // containerLoginRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.contentLoginRegister);
            this.Name = "containerLoginRegister";
            this.Size = new System.Drawing.Size(1000, 653);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoLoginRegister)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel contentLoginRegister;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox logoLoginRegister;
    }
}
