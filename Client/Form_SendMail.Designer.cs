namespace Client
{
    partial class Form_SendMail
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
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button_DangNhap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbRecent = new System.Windows.Forms.Label();
            this.button_PhanHoi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_email
            // 
            this.textBox_email.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.textBox_email.Location = new System.Drawing.Point(20, 44);
            this.textBox_email.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_email.Multiline = true;
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(158, 27);
            this.textBox_email.TabIndex = 0;
            this.textBox_email.Text = "21522122@gm.uit.edu.vn";
            this.textBox_email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.textBox_password.Location = new System.Drawing.Point(208, 43);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_password.Multiline = true;
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(138, 27);
            this.textBox_password.TabIndex = 1;
            this.textBox_password.Text = "bvemzszycqeyaxtf";
            this.textBox_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_DangNhap
            // 
            this.button_DangNhap.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.button_DangNhap.Location = new System.Drawing.Point(404, 37);
            this.button_DangNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_DangNhap.Name = "button_DangNhap";
            this.button_DangNhap.Size = new System.Drawing.Size(74, 32);
            this.button_DangNhap.TabIndex = 2;
            this.button_DangNhap.Text = "Đăng nhập";
            this.button_DangNhap.UseVisualStyleBackColor = true;
            this.button_DangNhap.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.label1.Location = new System.Drawing.Point(64, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Địa chỉ email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.label2.Location = new System.Drawing.Point(254, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật khẩu";
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(20, 74);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(556, 217);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.lbTotal.Location = new System.Drawing.Point(107, 294);
            this.lbTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(32, 14);
            this.lbTotal.TabIndex = 6;
            this.lbTotal.Text = "Total";
            // 
            // lbRecent
            // 
            this.lbRecent.AutoSize = true;
            this.lbRecent.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.lbRecent.Location = new System.Drawing.Point(415, 294);
            this.lbRecent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRecent.Name = "lbRecent";
            this.lbRecent.Size = new System.Drawing.Size(38, 14);
            this.lbRecent.TabIndex = 7;
            this.lbRecent.Text = "Resent";
            // 
            // button_PhanHoi
            // 
            this.button_PhanHoi.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_PhanHoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.button_PhanHoi.Location = new System.Drawing.Point(495, 36);
            this.button_PhanHoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_PhanHoi.Name = "button_PhanHoi";
            this.button_PhanHoi.Size = new System.Drawing.Size(74, 32);
            this.button_PhanHoi.TabIndex = 8;
            this.button_PhanHoi.Text = "Phản hồi";
            this.button_PhanHoi.UseVisualStyleBackColor = true;
            this.button_PhanHoi.Click += new System.EventHandler(this.button_PhanHoi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.label3.Location = new System.Drawing.Point(57, 294);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tổng số: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.label4.Location = new System.Drawing.Point(356, 294);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gần đây:";
            // 
            // button_refresh
            // 
            this.button_refresh.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(62)))), ((int)(((byte)(53)))));
            this.button_refresh.Location = new System.Drawing.Point(495, 5);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(74, 26);
            this.button_refresh.TabIndex = 11;
            this.button_refresh.Text = "Tải lại";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // Form_SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(584, 314);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_PhanHoi);
            this.Controls.Add(this.lbRecent);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_DangNhap);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_email);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_SendMail";
            this.Text = "Form_SendMail";
            this.Load += new System.EventHandler(this.Form_SendMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button_DangNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbRecent;
        private System.Windows.Forms.Button button_PhanHoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_refresh;
    }
}