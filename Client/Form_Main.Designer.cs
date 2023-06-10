namespace Client
{
    partial class Form_Main
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
            System.Windows.Forms.Button button_tran;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.panel_left = new System.Windows.Forms.Panel();
            this.button_Note = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_top = new System.Windows.Forms.Panel();
            this.button_Thoat = new System.Windows.Forms.Button();
            this.panel_body = new System.Windows.Forms.Panel();
            this.button_Sendmail = new System.Windows.Forms.Button();
            button_tran = new System.Windows.Forms.Button();
            this.panel_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_tran
            // 
            button_tran.Dock = System.Windows.Forms.DockStyle.Top;
            button_tran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_tran.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button_tran.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            button_tran.Location = new System.Drawing.Point(0, 123);
            button_tran.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button_tran.Name = "button_tran";
            button_tran.Size = new System.Drawing.Size(267, 113);
            button_tran.TabIndex = 1;
            button_tran.Text = "Dịch";
            button_tran.UseVisualStyleBackColor = true;
            button_tran.Click += new System.EventHandler(this.button_tran_Click);
            // 
            // panel_left
            // 
            this.panel_left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(170)))), ((int)(((byte)(152)))));
            this.panel_left.Controls.Add(this.button_Sendmail);
            this.panel_left.Controls.Add(this.button_Note);
            this.panel_left.Controls.Add(button_tran);
            this.panel_left.Controls.Add(this.pictureBox1);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(267, 554);
            this.panel_left.TabIndex = 0;
            // 
            // button_Note
            // 
            this.button_Note.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_Note.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Note.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Note.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.button_Note.Location = new System.Drawing.Point(0, 236);
            this.button_Note.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Note.Name = "button_Note";
            this.button_Note.Size = new System.Drawing.Size(267, 113);
            this.button_Note.TabIndex = 2;
            this.button_Note.Text = "Ghi chú";
            this.button_Note.UseVisualStyleBackColor = true;
            this.button_Note.Click += new System.EventHandler(this.button_Note_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(170)))), ((int)(((byte)(152)))));
            this.panel_top.Controls.Add(this.button_Thoat);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(267, 0);
            this.panel_top.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(800, 123);
            this.panel_top.TabIndex = 1;
            // 
            // button_Thoat
            // 
            this.button_Thoat.Location = new System.Drawing.Point(656, 33);
            this.button_Thoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Thoat.Name = "button_Thoat";
            this.button_Thoat.Size = new System.Drawing.Size(128, 54);
            this.button_Thoat.TabIndex = 0;
            this.button_Thoat.Text = "Thoát";
            this.button_Thoat.UseVisualStyleBackColor = true;
            this.button_Thoat.Click += new System.EventHandler(this.button_Thoat_Click);
            // 
            // panel_body
            // 
            this.panel_body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(185)))));
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(267, 123);
            this.panel_body.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(800, 431);
            this.panel_body.TabIndex = 2;
            // 
            // button_Sendmail
            // 
            this.button_Sendmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_Sendmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Sendmail.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Sendmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.button_Sendmail.Location = new System.Drawing.Point(0, 349);
            this.button_Sendmail.Margin = new System.Windows.Forms.Padding(4);
            this.button_Sendmail.Name = "button_Sendmail";
            this.button_Sendmail.Size = new System.Drawing.Size(267, 113);
            this.button_Sendmail.TabIndex = 3;
            this.button_Sendmail.Text = "Gửi mail";
            this.button_Sendmail.UseVisualStyleBackColor = true;
            this.button_Sendmail.Click += new System.EventHandler(this.button_Sendmail_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel_body);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.panel_left);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.panel_left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_body;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Note;
        private System.Windows.Forms.Button button_Thoat;
        private System.Windows.Forms.Button button_Sendmail;
    }
}