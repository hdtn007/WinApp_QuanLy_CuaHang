﻿namespace QLBanHang
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLienHe = new System.Windows.Forms.LinkLabel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txtThongBaoDangnhap = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.hienMatKhau = new System.Windows.Forms.PictureBox();
            this.AnMatKhau = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.hienMatKhau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnMatKhau)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(107, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG NHẬP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.AcceptsReturn = true;
            this.txtTaiKhoan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTaiKhoan.ForeColor = System.Drawing.Color.Black;
            this.txtTaiKhoan.Location = new System.Drawing.Point(121, 97);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(132, 19);
            this.txtTaiKhoan.TabIndex = 1;
            this.txtTaiKhoan.TextChanged += new System.EventHandler(this.txtTaiKhoan_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(43, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(43, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // linkLienHe
            // 
            this.linkLienHe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLienHe.AutoSize = true;
            this.linkLienHe.BackColor = System.Drawing.Color.White;
            this.linkLienHe.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLienHe.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.linkLienHe.Location = new System.Drawing.Point(149, 254);
            this.linkLienHe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLienHe.Name = "linkLienHe";
            this.linkLienHe.Size = new System.Drawing.Size(56, 17);
            this.linkLienHe.TabIndex = 4;
            this.linkLienHe.TabStop = true;
            this.linkLienHe.Text = "Liên Hệ";
            this.linkLienHe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLienHe_LinkClicked);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.AutoSize = true;
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.Black;
            this.btnDangNhap.Location = new System.Drawing.Point(125, 203);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(2);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(105, 34);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txtThongBaoDangnhap
            // 
            this.txtThongBaoDangnhap.AutoSize = true;
            this.txtThongBaoDangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtThongBaoDangnhap.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtThongBaoDangnhap.ForeColor = System.Drawing.Color.White;
            this.txtThongBaoDangnhap.Location = new System.Drawing.Point(77, 172);
            this.txtThongBaoDangnhap.Name = "txtThongBaoDangnhap";
            this.txtThongBaoDangnhap.Size = new System.Drawing.Size(63, 15);
            this.txtThongBaoDangnhap.TabIndex = 5;
            this.txtThongBaoDangnhap.Text = "Thông báo";
            this.txtThongBaoDangnhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMatKhau.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMatKhau.Location = new System.Drawing.Point(121, 131);
            this.txtMatKhau.Multiline = true;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Size = new System.Drawing.Size(130, 20);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            // 
            // hienMatKhau
            // 
            this.hienMatKhau.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hienMatKhau.BackgroundImage")));
            this.hienMatKhau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hienMatKhau.Location = new System.Drawing.Point(254, 133);
            this.hienMatKhau.Name = "hienMatKhau";
            this.hienMatKhau.Size = new System.Drawing.Size(25, 18);
            this.hienMatKhau.TabIndex = 10;
            this.hienMatKhau.TabStop = false;
            this.hienMatKhau.Visible = false;
            this.hienMatKhau.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // AnMatKhau
            // 
            this.AnMatKhau.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AnMatKhau.BackgroundImage")));
            this.AnMatKhau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AnMatKhau.Location = new System.Drawing.Point(255, 133);
            this.AnMatKhau.Name = "AnMatKhau";
            this.AnMatKhau.Size = new System.Drawing.Size(25, 18);
            this.AnMatKhau.TabIndex = 11;
            this.AnMatKhau.TabStop = false;
            this.AnMatKhau.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(354, 301);
            this.Controls.Add(this.AnMatKhau);
            this.Controls.Add(this.hienMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtThongBaoDangnhap);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.linkLienHe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 340);
            this.MinimumSize = new System.Drawing.Size(370, 340);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Quản Lý Cửa Hàng | V1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hienMatKhau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnMatKhau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLienHe;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Label txtThongBaoDangnhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.PictureBox hienMatKhau;
        private System.Windows.Forms.PictureBox AnMatKhau;
    }
}
