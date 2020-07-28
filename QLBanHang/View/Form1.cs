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
using System.Security.Cryptography;

namespace QLBanHang
{
    public partial class Form1 : Form
    {
        
        QuanLyCtrl qlcrt = new QuanLyCtrl();
        QuanLyMod qlmod = new QuanLyMod();
        QuanLyObj qlObj = new QuanLyObj();

        PhanQuyenMod pqmod = new PhanQuyenMod();
        PhanQuyenCtrl pqctr = new PhanQuyenCtrl();
        PhanQuyenObj pqObj = new PhanQuyenObj();

        AutoIDmod idmod = new AutoIDmod();
        AutoIDctrl iDctrl = new AutoIDctrl();
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

        void ganDulieuQL(QuanLyObj qlObj)
        {
            qlObj.Taikhoan = txtTaiKhoan.Text.Trim();
            qlObj.MatKhau = toMD5(txtMatKhau.Text);// txtMatKhau.Text.Trim();
        }

        void ganDulieuPQ(PhanQuyenObj pqObj)
        {
            pqObj.Taikhoan = txtTaiKhoan.Text.Trim();
            pqObj.MatKhau = toMD5(txtMatKhau.Text);// txtMatKhau.Text.Trim();
        }

        void gandulieuthemmoiadmin()
        {
            qlObj.ID = "admin";
            qlObj.Taikhoan = "admin";
            qlObj.MatKhau = toMD5("123");
            qlObj.Ten = "admin";

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            int phanquyen;
            string nametaikhoan = "";
            txtThongBaoDangnhap.Text = "";
            string LastID = iDctrl.GetLastID("QUANLY", "id");

            if (LastID == ""||LastID == null) {

                gandulieuthemmoiadmin();

                    qlcrt.addDataQL(qlObj);
                    MessageBox.Show("Đã tạo cửa hàng thành công vui lòng đăng nhập lại !.\nTài khoản mặc định của bạn là : admin | mật khẩu : 123 \nBạn có thể thay đổi mật khẩu trong bảng điều khiển !.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1_Load(sender, e);
               
            }
            else
            {
                if (rbntAdmin.Checked == true) // TK_USER = 1 thì đăng nhập kiểm tra bảng dữ liệu admin (QUANLY)
                {
                    phanquyen = 1;  // biến phần quyền 1 | quyền admin
                    TK_USER(phanquyen);
                    // ---------------------
                    if (txtTaiKhoan.Text == "") { txtThongBaoDangnhap.Text = "✘ Vui lòng nhập tài khoản ✘"; }
                    else if (txtMatKhau.Text == "") { txtThongBaoDangnhap.Text = "✘ Vui lòng nhập mật khẩu ✘"; }
                    else
                    {
                        ganDulieuQL(qlObj);
                        if (qlcrt.check(qlObj))
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
                else if (rbntNhanVien.Checked == true)
                {
                    // kiểm tra từ bản PHANQUYEN |


                    // ----------------------------------

                    if (txtTaiKhoan.Text == "") { txtThongBaoDangnhap.Text = "✘ Vui lòng nhập tài khoản ✘"; }
                    else if (txtMatKhau.Text == "") { txtThongBaoDangnhap.Text = "✘ Vui lòng nhập mật khẩu ✘"; }
                    else
                    {
                        ganDulieuPQ(pqObj);


                        phanquyen = pqctr.checkPQ(txtTaiKhoan.Text.Trim());  // kiểm tra quyền ở dòng code kiểm tra với nhập tài khoản |  2 hoặc 3
                        TK_USER(phanquyen);
                        nametaikhoan = pqctr.CheckName(txtTaiKhoan.Text.Trim());  // tên đăng nhập khi bán hàng
                        TK_Name(nametaikhoan);

                        if (pqctr.checkNV(pqObj))
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
                else if ((rbntAdmin.Checked == false) & (rbntNhanVien.Checked == false))
                {
                    txtThongBaoDangnhap.Text = "✘ Bạn chưa chọn loại tài khoản ! ✘";
                }
            }
            
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            // kiểm tra tài khoản trong csdl có tài khoản chưa;
            string LastID = iDctrl.GetLastID("QUANLY", "id");
            if(LastID==null||LastID=="")
            {
                txtThongBaoDangnhap.Text = "Chưa có tài khoản admin. Vui lòng ấn đăng nhập !.";
            }
            else
            {
                rbntNhanVien.Checked = true;
                txtThongBaoDangnhap.Text = "";
                LoadShowEyeF1(true);
            }


            // txtMatKhau.UseSystemPasswordChar = false;
        }

        
        public void TK_USER(int phanquyen) // tham số phân quyền getdata từ table phân quyền
        {
                PhanQuyenMod.QUYEN_USER = phanquyen;  // luôn luôn = 1
        }
        public void TK_Name(string name) // tham số phân quyền getdata từ table phân quyền
        {
            PhanQuyenMod.Name_USER = name;  // luôn luôn = 1
        }
        public void TK_USERid(string id) // tham số phân quyền getdata từ table phân quyền
        {
            PhanQuyenMod.ID_USER = id;  // luôn luôn = 1
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

        public string toMD5(string input)
        {
            string output = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(input);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                output += b.ToString("X2");
            }

            return output;
        }
    }
}
