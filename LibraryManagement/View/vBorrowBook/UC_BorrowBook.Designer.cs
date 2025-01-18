namespace LibraryManagement.View.vBorrowBook
{
    partial class UC_BorrowBook
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbBook = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dueDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbMember = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Submit = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.containerTableCategory = new Guna.UI2.WinForms.Guna2Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridViewBorrowBook = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.deleteBorrowBook = new Guna.UI2.WinForms.Guna2Button();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.containerTableCategory.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBorrowBook)).BeginInit();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(16, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 100);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(294, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 100);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraryManagement.Properties.Resources.borrow_dark;
            this.pictureBox1.Location = new System.Drawing.Point(28, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Plus Jakarta Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.label1.Location = new System.Drawing.Point(90, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Borrow Book";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 8;
            this.guna2Panel1.Controls.Add(this.panel3);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(16, 116);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Padding = new System.Windows.Forms.Padding(16);
            this.guna2Panel1.ShadowDecoration.BorderRadius = 8;
            this.guna2Panel1.ShadowDecoration.Depth = 2;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Size = new System.Drawing.Size(634, 264);
            this.guna2Panel1.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbBook);
            this.panel3.Controls.Add(this.dueDate);
            this.panel3.Controls.Add(this.cbMember);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.Submit);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(16, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(602, 232);
            this.panel3.TabIndex = 5;
            // 
            // cbBook
            // 
            this.cbBook.BackColor = System.Drawing.Color.Transparent;
            this.cbBook.BorderRadius = 8;
            this.cbBook.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBook.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbBook.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbBook.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.cbBook.ItemHeight = 30;
            this.cbBook.Location = new System.Drawing.Point(136, 70);
            this.cbBook.Name = "cbBook";
            this.cbBook.Size = new System.Drawing.Size(462, 36);
            this.cbBook.TabIndex = 2;
            // 
            // dueDate
            // 
            this.dueDate.BorderRadius = 8;
            this.dueDate.Checked = true;
            this.dueDate.FillColor = System.Drawing.Color.White;
            this.dueDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dueDate.Location = new System.Drawing.Point(137, 129);
            this.dueDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dueDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dueDate.Name = "dueDate";
            this.dueDate.Size = new System.Drawing.Size(139, 36);
            this.dueDate.TabIndex = 3;
            this.dueDate.Value = new System.DateTime(2024, 12, 26, 7, 18, 47, 929);
            // 
            // cbMember
            // 
            this.cbMember.BackColor = System.Drawing.Color.Transparent;
            this.cbMember.BorderRadius = 8;
            this.cbMember.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMember.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMember.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMember.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.cbMember.ItemHeight = 30;
            this.cbMember.Location = new System.Drawing.Point(136, 13);
            this.cbMember.Name = "cbMember";
            this.cbMember.Size = new System.Drawing.Size(462, 36);
            this.cbMember.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Due Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Book";
            // 
            // Submit
            // 
            this.Submit.BorderRadius = 8;
            this.Submit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Submit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Submit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Submit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Submit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(149)))), ((int)(((byte)(13)))));
            this.Submit.Font = new System.Drawing.Font("Plus Jakarta Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit.ForeColor = System.Drawing.Color.White;
            this.Submit.Location = new System.Drawing.Point(136, 189);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(140, 40);
            this.Submit.TabIndex = 4;
            this.Submit.Text = "Borrow";
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Member";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(16, 380);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(634, 32);
            this.panel4.TabIndex = 9;
            // 
            // containerTableCategory
            // 
            this.containerTableCategory.BackColor = System.Drawing.Color.Transparent;
            this.containerTableCategory.BorderRadius = 8;
            this.containerTableCategory.Controls.Add(this.panel5);
            this.containerTableCategory.Controls.Add(this.guna2Panel4);
            this.containerTableCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.containerTableCategory.FillColor = System.Drawing.Color.White;
            this.containerTableCategory.Location = new System.Drawing.Point(16, 412);
            this.containerTableCategory.Name = "containerTableCategory";
            this.containerTableCategory.Padding = new System.Windows.Forms.Padding(16);
            this.containerTableCategory.ShadowDecoration.BorderRadius = 8;
            this.containerTableCategory.ShadowDecoration.Depth = 2;
            this.containerTableCategory.ShadowDecoration.Enabled = true;
            this.containerTableCategory.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.containerTableCategory.Size = new System.Drawing.Size(634, 431);
            this.containerTableCategory.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridViewBorrowBook);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(16, 64);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(16);
            this.panel5.Size = new System.Drawing.Size(602, 351);
            this.panel5.TabIndex = 5;
            // 
            // dataGridViewBorrowBook
            // 
            this.dataGridViewBorrowBook.AllowUserToAddRows = false;
            this.dataGridViewBorrowBook.AllowUserToDeleteRows = false;
            this.dataGridViewBorrowBook.AllowUserToResizeColumns = false;
            this.dataGridViewBorrowBook.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewBorrowBook.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Plus Jakarta Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBorrowBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBorrowBook.ColumnHeadersHeight = 40;
            this.dataGridViewBorrowBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBorrowBook.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBorrowBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBorrowBook.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dataGridViewBorrowBook.Location = new System.Drawing.Point(16, 16);
            this.dataGridViewBorrowBook.Name = "dataGridViewBorrowBook";
            this.dataGridViewBorrowBook.RowHeadersVisible = false;
            this.dataGridViewBorrowBook.RowTemplate.Height = 40;
            this.dataGridViewBorrowBook.Size = new System.Drawing.Size(570, 319);
            this.dataGridViewBorrowBook.TabIndex = 6;
            this.dataGridViewBorrowBook.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewBorrowBook.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewBorrowBook.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewBorrowBook.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewBorrowBook.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewBorrowBook.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewBorrowBook.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dataGridViewBorrowBook.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewBorrowBook.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBorrowBook.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewBorrowBook.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewBorrowBook.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridViewBorrowBook.ThemeStyle.HeaderStyle.Height = 40;
            this.dataGridViewBorrowBook.ThemeStyle.ReadOnly = false;
            this.dataGridViewBorrowBook.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewBorrowBook.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewBorrowBook.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewBorrowBook.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewBorrowBook.ThemeStyle.RowsStyle.Height = 40;
            this.dataGridViewBorrowBook.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewBorrowBook.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewBorrowBook.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewBorrowBook_DataBindingComplete);
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.deleteBorrowBook);
            this.guna2Panel4.Controls.Add(this.label11);
            this.guna2Panel4.Controls.Add(this.pictureBox3);
            this.guna2Panel4.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.guna2Panel4.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel4.Location = new System.Drawing.Point(16, 16);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Padding = new System.Windows.Forms.Padding(0, 4, 0, 12);
            this.guna2Panel4.Size = new System.Drawing.Size(602, 48);
            this.guna2Panel4.TabIndex = 1;
            // 
            // deleteBorrowBook
            // 
            this.deleteBorrowBook.BorderRadius = 8;
            this.deleteBorrowBook.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteBorrowBook.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deleteBorrowBook.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deleteBorrowBook.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deleteBorrowBook.Dock = System.Windows.Forms.DockStyle.Right;
            this.deleteBorrowBook.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(149)))), ((int)(((byte)(13)))));
            this.deleteBorrowBook.Font = new System.Drawing.Font("Plus Jakarta Sans", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBorrowBook.ForeColor = System.Drawing.Color.White;
            this.deleteBorrowBook.Location = new System.Drawing.Point(517, 4);
            this.deleteBorrowBook.Name = "deleteBorrowBook";
            this.deleteBorrowBook.Size = new System.Drawing.Size(85, 32);
            this.deleteBorrowBook.TabIndex = 5;
            this.deleteBorrowBook.Text = "Delete";
            this.deleteBorrowBook.Click += new System.EventHandler(this.deleteBorrowBook_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Plus Jakarta Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.label11.Location = new System.Drawing.Point(35, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 32);
            this.label11.TabIndex = 0;
            this.label11.Text = "List of Book Loan";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::LibraryManagement.Properties.Resources.list;
            this.pictureBox3.Location = new System.Drawing.Point(9, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(16, 843);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(634, 32);
            this.panel6.TabIndex = 11;
            // 
            // UC_BorrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.containerTableCategory);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(683, 400);
            this.Name = "UC_BorrowBook";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.Size = new System.Drawing.Size(666, 400);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.containerTableCategory.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBorrowBook)).EndInit();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2DateTimePicker dueDate;
        private Guna.UI2.WinForms.Guna2ComboBox cbMember;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button Submit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2Panel containerTableCategory;
        private System.Windows.Forms.Panel panel5;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewBorrowBook;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel6;
        private Guna.UI2.WinForms.Guna2ComboBox cbBook;
        private Guna.UI2.WinForms.Guna2Button deleteBorrowBook;
    }
}
