using QLBanHang.Control;
using QLBanHang.Model;
using QLBanHang.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class Form1 : Form
    {
        QuanLyCtrl qlcrt = new QuanLyCtrl();
        QuanLyMod qlmod = new QuanLyMod();
        QuanLyObj qlObj = new QuanLyObj();
        public Form1()
        {
            InitializeComponent();
        }
     
        private void label1_Click(object sender, EventArgs e)
        {

        }
      
        private void linkLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "https://www.facebook.com/HoDoanThanhNgoan";
            proc.Start();
        }
     
        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        void ganDulieuQL(QuanLyObj nvObj)
        {
            nvObj.Taikhoan = txtTaiKhoan.Text.Trim();
            nvObj.MatKhau = txtMatKhau.Text.Trim();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "") { txtThongBaoDangnhap.Text = "✘ Vui lòng nhập tài khoản ✘"; }
            else if (txtMatKhau.Text == "") { txtThongBaoDangnhap.Text = "✘ Vui lòng nhập mật khẩu ✘"; }
            else
            {
                ganDulieuQL(qlObj);
                if(qlcrt.check(qlObj))
                {
                    Form2 f = new Form2();

                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                    txtTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                    txtThongBaoDangnhap.Text = "";
                }
                else txtThongBaoDangnhap.Text = "✘ Sai tài khoản/ mật khẩu ✘";  
            }



        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            txtThongBaoDangnhap.Text = "";
            LoadShowEyeF1(true);
           // txtMatKhau.PasswordChar = '*';



            // txtMatKhau.UseSystemPasswordChar = false;
        }

        void LoadShowEyeF1(bool e) // e = hiện  ; !e = ẩn
        {
            AnMatKhau.Visible = e;
            hienMatKhau.Visible = !e;
            txtMatKhau.UseSystemPasswordChar = !e;
            


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi ứng dụng ?", "Chú ý !", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // txtDoiMatKhau
            
        }

        private void txtDoiMatKhau_Click(object sender, EventArgs e)
        {
            
        }

        private void hidepasscu_Click(object sender, EventArgs e)
        {
            
        }

        private void showmkdn_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadShowEyeF1(false);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadShowEyeF1(true);
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
