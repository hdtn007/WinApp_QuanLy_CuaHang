﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanHang.Control;
using QLBanHang.Object;
using QLBanHang.Model;
using System.Net.Mail;
using System.Security.Cryptography;


namespace QLBanHang
{

    public partial class Form2 : Form
    {
        NhanVienCtrl nvctr = new NhanVienCtrl();  // Xử lý sự kiện thêm, xóa , sửa vào CSDL
        NhanVienObj nvObj = new NhanVienObj(); // Biến lưu tạm dữ liệu truyền vào từ các textbox, Sau đó chuyển vào CSDL khi ấn Lưu
        // ----------------------------------------------

        KhachHangCtrl khctr = new KhachHangCtrl();
        KhachHangObj khObj = new KhachHangObj();
        // -----------------------------------------------

        LoaiHangHoaCtrl lhhctr = new LoaiHangHoaCtrl();
        LoaiHangHoaObj lhhObj = new LoaiHangHoaObj();
        // -----------------------------------------------

        NhaCungCapCtrl nccctr = new NhaCungCapCtrl();
        NhaCungCapObj nccObj = new NhaCungCapObj();
        // -----------------------------------------------

        KhuyenMaiCtrl kmctr = new KhuyenMaiCtrl();
        KhuyenMaiObj kmObj = new KhuyenMaiObj();
        // -----------------------------------------------

        HangHoaCtrl hhctr = new HangHoaCtrl();
        HangHoaObj hhObj = new HangHoaObj();
        //   DataTable dtDSCT = new System.Data.DataTable();
        // int vitriclick = 0;
        // -----------------------------------------------

        HoaDonCtrl hdctr = new HoaDonCtrl();
        HoaDonObj hdObj = new HoaDonObj();

        CTHDCtrl cthdctr = new CTHDCtrl();
        ChiTietHoaDonObj cthdObj = new ChiTietHoaDonObj();

        // -----------------------------------------------

        ThongKeCtrl tkctr = new ThongKeCtrl();
        ThongKeObj tkObj = new ThongKeObj();

        // -----------------------------------------------

        QuanLyCtrl qlctr = new QuanLyCtrl();
        QuanLyObj qlObj = new QuanLyObj();

        SendMailMob mailMob = new SendMailMob();


        // -----------------------------------------------

          PhanQuyenMod pqmod = new PhanQuyenMod();

          PhanQuyenCtrl pqctr = new PhanQuyenCtrl();
          PhanQuyenObj pqObj = new PhanQuyenObj();


        // -----------------------------------------------

        AutoIDmod Idmod = new AutoIDmod();

        AutoIDctrl Idctr = new AutoIDctrl();


        // -----------------------------------------------

        // phân biệt giữa add và update
        int flag = 0; // trường hợp khi ấn các nút thêm sửa xóa, để set nút lưu là thêm mới hay sửa dử liệu củ...
        int flagKH = 0;
        int flagLHH = 0;
        int flagNCC = 0;
        int flagKM = 0;
        int flagHH = 0;
        int flagHD = 0;
        int flagCTHD = 0;
        int flagAdmin = 0;
        int flagPQ = 0;
        int checkmail = 0;
        // -----------------------------------------------
        public Form2()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lvDanhsachban_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //**************************************************************************************************************************************************************
        // Load CSDL vào form và các tab
        private void Form2_Load(object sender, EventArgs e)
        {
            phanquyen();

            //**************************************************************

            dtDanhSachNhanVien.DataBindings.Clear();
            DataTable dtNhanVien = new DataTable();
            dtNhanVien = nvctr.getData();
            dtDanhSachNhanVien.DataSource = dtNhanVien; // dtDanhSachNhanVien la datagidview 


            dtDanhSachKhachHang.DataBindings.Clear();
            DataTable dtKhachHang = new DataTable();
            dtKhachHang = khctr.getDataKH();
            dtDanhSachKhachHang.DataSource = dtKhachHang;


            dtDanhSachLoaiSanPham.DataBindings.Clear();
            DataTable dtLoaiHH = new DataTable();
            dtLoaiHH = lhhctr.getDataLHH();
            dtDanhSachLoaiSanPham.DataSource = dtLoaiHH;


            dtDanhSachNhaCungCap.DataBindings.Clear();
            DataTable dtNCC = new DataTable();
            dtNCC = nccctr.getDataNCC();
            dtDanhSachNhaCungCap.DataSource = dtNCC;


            dtDanhSachKhuyenmai.DataBindings.Clear();
            DataTable dtkhuyenmai = new DataTable();
            dtkhuyenmai = kmctr.getDataKm();
            dtDanhSachKhuyenmai.DataSource = dtkhuyenmai;

            dtDanhSachHangHoa.DataBindings.Clear();
            DataTable dtHangHoa = new DataTable();
            dtHangHoa = hhctr.getDataHH();
            dtDanhSachHangHoa.DataSource = dtHangHoa;


            // DataTable dtHoaDon = new DataTable();
            //  dtHoaDon = hdctr.getDataHD();
            //  dtdanhsachcthd.DataSource = dtHoaDon;
            dtdanhsachcthd.DataBindings.Clear();
            DataTable dtHoaDon = new DataTable();
            dtHoaDon = hdctr.getDataHD();
            dtdanhsachcthd.DataSource = dtHoaDon;



            txtNgayBanHD.Value = DateTime.Now.Date;


            // ***************************************************************


            bingdingNV();  // lấy dữ liệu từ DataSource truyền vào textbox
            bingdingKH();
            bingdingLHH();
            bingdingNCC();
            bingdingKm();
            bingdingHH();
            bingdingHD();
            bingdingPhanQuyen();


            loadcontrolHD();
            loadTKTraCuu();
            btnXoaTKSP.Enabled = false; // xóa thống kê sản phẩm

            // load quanly
            loadQuanLy();
            LoadShowEye(true);

            // load tài khoản nhân viên + admin
            dis_enLoadUSer(true);
            loadUser();

            //clear thong bao loi
            LoadLoi();


            // bingdingKHClear();
            // bingdingNVClear();
            dis_enKH(false);  // trạng thái đống mở các textbox
            dis_enNV(false);
            dis_enLHH(false);
            dis_enNCC(false);
            dis_enKm(false);
            dis_enHH(false);
            dis_enHD(false);
            dis_enTKTraCuu(false);

            HanCheQuyen();

        }
        //**************************************************************//*****************************************************************************************************************************************************************


         void LoadLoi() // 
        {

            thongbaoloinhanvien.Text = "";
            thongbaoloikhachhang.Text = "";
            thongbaoloiloaisanpham.Text = "";
            thongbaoloikm.Text = "";
            thongbaoloincc.Text = "";
            thongbaoloisanpham.Text = "";
           // thongbaoloiadmin.Text = "";
        }




        //**************************************************************//*****************************************************************************************************************************************************************

        // PHÂN QUYỀN
        private void phanquyen()
        {
            if(PhanQuyenMod.QUYEN_USER == 2)
            {
                //  this.tabControl1.Visible=false;
                tabControl1.TabPages.Remove(tabAdmin);
                

            }
            else if (PhanQuyenMod.QUYEN_USER == 3)
            {
                
                tabControl1.TabPages.Remove(tabAdmin);
                tabControl1.TabPages.Remove(tabQuanLy);
                

            }
            else if (PhanQuyenMod.QUYEN_USER == 1)
            {
                this.tabControl1.Visible = true;
                this.tabControl2.Visible = true;
                this.tabControl3.Visible = true;
                tabControl1.TabPages.Remove(tabBanHang);
            }
        }

        private void HanCheQuyen()
        {
            if(PhanQuyenMod.QUYEN_USER == 2)
            {
                mnXoaNv.Enabled = false;
                mnXoaNcc.Enabled = false;
                mnXoaKm.Enabled = false;
                mnXoaLoai.Enabled = false;
                mnXoaSp.Enabled = false;
                mnXoaKh.Enabled = false;
            }
            else
            {
                mnXoaNv.Enabled = true;
                mnXoaNcc.Enabled = true;
                mnXoaKm.Enabled = true;
                mnXoaLoai.Enabled = true;
                mnXoaSp.Enabled = true;
                mnXoaKh.Enabled = true;
            }
        }



        /* ********************************************************************************************************** */
        /* ********************************************************************************************************** */
        /* ********************* 1.0 SETUP HÀM XỬ LÝ TRUYỀN DỮ LIỆU VÀO CHO DANH SÁCH VÀ LIÊN KẾT TEXTBOX NHẬP DỮ LIỆU VỚI DANH SÁCH ********************************************** */
        /* ********************************************************************************************************** */
        /* ********************************************************************************************************** */

        // START  KHU VỰC DÀNH CHO TAB NHÂN VIÊN ********************************************************* //


        void bingdingNV()
        {
            txtMaNv.DataBindings.Clear();
            txtMaNv.DataBindings.Add("Text", dtDanhSachNhanVien.DataSource, "manv");

            txtTenNv.DataBindings.Clear();
            txtTenNv.DataBindings.Add("Text", dtDanhSachNhanVien.DataSource, "tennv");

            txtGioiTinhNv.DataBindings.Clear();
            txtGioiTinhNv.DataBindings.Add("Text", dtDanhSachNhanVien.DataSource, "gioitinh");

            dtNgaySinhNv.DataBindings.Clear();
            dtNgaySinhNv.DataBindings.Add("Text", dtDanhSachNhanVien.DataSource, "ngaysinh");

            txtDiaChiNv.DataBindings.Clear();
            txtDiaChiNv.DataBindings.Add("Text", dtDanhSachNhanVien.DataSource, "diachi");

            txtSdtNv.DataBindings.Clear();
            txtSdtNv.DataBindings.Add("Text", dtDanhSachNhanVien.DataSource, "sdt");

            txtCmndNv.DataBindings.Clear();
            txtCmndNv.DataBindings.Add("Text", dtDanhSachNhanVien.DataSource, "cmnd");

            txtEmailNv.DataBindings.Clear();
            txtEmailNv.DataBindings.Add("Text", dtDanhSachNhanVien.DataSource, "email");

            txtGhiChuNv.DataBindings.Clear();
            txtGhiChuNv.DataBindings.Add("Text", dtDanhSachNhanVien.DataSource, "ghichu");
        }

       

        // END  KHU VỰC DÀNH CHO TAB NHÂN VIÊN ********************************************************* //

        /* ********************************************************************************************************** */

        // START  KHU VỰC DÀNH CHO TAB KHÁCH HÀNG ********************************************************* //

        void bingdingKH()
        {
            txtMaKhachHang.DataBindings.Clear();
            txtMaKhachHang.DataBindings.Add("Text", dtDanhSachKhachHang.DataSource, "makh");

            txtTenKhachHang.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Add("Text", dtDanhSachKhachHang.DataSource, "tenkh");

            txtGioiTinhKhachHang.DataBindings.Clear();
            txtGioiTinhKhachHang.DataBindings.Add("Text", dtDanhSachKhachHang.DataSource, "gioitinh");                    

            txtDiaChiKhachHang.DataBindings.Clear();
            txtDiaChiKhachHang.DataBindings.Add("Text", dtDanhSachKhachHang.DataSource, "diachi");

            txtSDTKhachHang.DataBindings.Clear();
            txtSDTKhachHang.DataBindings.Add("Text", dtDanhSachKhachHang.DataSource, "sdt");

            txtGhiChuKhachHang.DataBindings.Clear();
            txtGhiChuKhachHang.DataBindings.Add("Text", dtDanhSachKhachHang.DataSource, "ghichu");
        }
      

        // END  KHU VỰC DÀNH CHO TAB KHÁCH HÀNG ********************************************************* //

        /* ********************************************************************************************************** */

        // START  KHU VỰC DÀNH CHO TAB LOẠI SẢN PHẨM ********************************************************* //



        void bingdingLHH()
        {
            txtMaLoaiSanPham.DataBindings.Clear();
            txtMaLoaiSanPham.DataBindings.Add("Text", dtDanhSachLoaiSanPham.DataSource, "maloai");

            txtTenLoaiSanPham.DataBindings.Clear();
            txtTenLoaiSanPham.DataBindings.Add("Text", dtDanhSachLoaiSanPham.DataSource, "tenloai");
        }



        // END  KHU VỰC DÀNH CHO TAB LOẠI SẢN PHẨM ********************************************************* //

        /* ********************************************************************************************************** */

        // START  KHU VỰC DÀNH CHO TAB NHÀ CUNG CẤP ********************************************************* //

        void bingdingNCC()
        {
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", dtDanhSachNhaCungCap.DataSource, "mancc");

            txtTenNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Add("Text", dtDanhSachNhaCungCap.DataSource, "tenncc");

            txtDiaChiNCC.DataBindings.Clear();
            txtDiaChiNCC.DataBindings.Add("Text", dtDanhSachNhaCungCap.DataSource, "diachi");

            txtSoDtNCC.DataBindings.Clear();
            txtSoDtNCC.DataBindings.Add("Text", dtDanhSachNhaCungCap.DataSource, "sdt");

            txtGhiChuNCC.DataBindings.Clear();
            txtGhiChuNCC.DataBindings.Add("Text", dtDanhSachNhaCungCap.DataSource, "ghichu");
        }

        // END  KHU VỰC DÀNH CHO TAB NHÀ CUNG CẤP ********************************************************* //

        /* ********************************************************************************************************** */

        // START  KHU VỰC DÀNH CHO TAB KHUYẾN MÃI ********************************************************* //

        void bingdingKm()
        {
            txtMaKm.DataBindings.Clear();
            txtMaKm.DataBindings.Add("Text", dtDanhSachKhuyenmai.DataSource, "mask");

            txtTenKm.DataBindings.Clear();
            txtTenKm.DataBindings.Add("Text", dtDanhSachKhuyenmai.DataSource, "tensk");

            txtNoiDungKm.DataBindings.Clear();
            txtNoiDungKm.DataBindings.Add("Text", dtDanhSachKhuyenmai.DataSource, "noidung");

            txtGiamKm.DataBindings.Clear();
            txtGiamKm.DataBindings.Add("Text", dtDanhSachKhuyenmai.DataSource, "giam");
            
            
        }

        // END  KHU VỰC DÀNH CHO TAB KHUYẾN MÃI ********************************************************* //

        /* ********************************************************************************************************** */

        // START  KHU VỰC DÀNH CHO TAB SẢN PHẨM ********************************************************* //

        void bingdingHH()
        {
            txtMaHH.DataBindings.Clear();
            txtMaHH.DataBindings.Add("Text", dtDanhSachHangHoa.DataSource, "mahh");

            txtTenHH.DataBindings.Clear();
            txtTenHH.DataBindings.Add("Text", dtDanhSachHangHoa.DataSource, "tenhh");

            txtGiaNhapSp.DataBindings.Clear();
            txtGiaNhapSp.DataBindings.Add("Text", dtDanhSachHangHoa.DataSource, "gianhap");

            txtDonGiaHH.DataBindings.Clear();
            txtDonGiaHH.DataBindings.Add("Text", dtDanhSachHangHoa.DataSource, "dongia");

            txtTonKhoHH.DataBindings.Clear();
            txtTonKhoHH.DataBindings.Add("Text", dtDanhSachHangHoa.DataSource, "tonkho");

            txtDonViHH.DataBindings.Clear();
            txtDonViHH.DataBindings.Add("Text", dtDanhSachHangHoa.DataSource, "donvi");

            txtDaBanHH.DataBindings.Clear();
            txtDaBanHH.DataBindings.Add("Text", dtDanhSachHangHoa.DataSource, "daban");

            txtNhaCungCapHH.DataBindings.Clear();
            txtNhaCungCapHH.DataBindings.Add("Text", dtDanhSachHangHoa.DataSource, "tenncc");

            txtLoaiHangHH.DataBindings.Clear();
            txtLoaiHangHH.DataBindings.Add("Text", dtDanhSachHangHoa.DataSource, "tenloai");

            txtKhuyenMaiHH.DataBindings.Clear();
            txtKhuyenMaiHH.DataBindings.Add("Text", dtDanhSachHangHoa.DataSource, "tensk");

            txtGhiChuHH.DataBindings.Clear();
            txtGhiChuHH.DataBindings.Add("Text", dtDanhSachHangHoa.DataSource, "ghichu"); 
            
        }

        // END  KHU VỰC DÀNH CHO TAB SẢN PHẨM ********************************************************* //

        /* ********************************************************************************************************** */

        // START  KHU VỰC DÀNH CHO TAB HÓA ĐƠN + CTHD ********************************************************* //

       
        void bingdingHD()
        {

            gbDanhSachCTHD.Text = "Danh Sách Hóa Đơn";

            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("Text", dtdanhsachcthd.DataSource, "mahd");

            txtTongTienHD.DataBindings.Clear();
            txtTongTienHD.DataBindings.Add("Text", dtdanhsachcthd.DataSource, "tongtien");

            


        }


        void bingdingCTHD(string macthd)
        {
              // macthd = txtMaHD.Text;

               gbDanhSachCTHD.Text = "Giỏ Hàng Của Hóa Đơn "+ macthd;

            //  try
            //  {
                DataTable dt = new System.Data.DataTable();
                dt = cthdctr.getDataCTHD(macthd);
                dtdanhsachcthd.DataSource = dt;

            //   }
            //   catch
            //   {
            //       dtdanhsachcthd.DataSource = null;
            //   }
            
            

            txtMaSpCTHD.DataBindings.Clear();
            txtMaSpCTHD.DataBindings.Add("Text", dtdanhsachcthd.DataSource, "mahh");

            btnKhuyenMaiHD.DataBindings.Clear();
            btnKhuyenMaiHD.DataBindings.Add("Text",dtdanhsachcthd.DataSource,"giam");

            txtTongTienHD.DataBindings.Clear();
            txtTongTienHD.DataBindings.Add("Text", dtdanhsachcthd.DataSource, "tongtien");


            txtsoluongspdamua.DataBindings.Clear();
            txtsoluongspdamua.DataBindings.Add("Text", dtdanhsachcthd.DataSource, "soluong");


        }




        // END  KHU VỰC DÀNH CHO TAB HÓA ĐƠN + CTHD ********************************************************* //

        /* ********************************************************************************************************** */
        // START  KHU VỰC DÀNH CHO TAB THỐNG KÊ ********************************************************* //
            
            void bingdingThongKe()
            {
                HangHoaCtrl hh = new HangHoaCtrl();
                txtChonSanPhamThongKe.DataSource = hh.getDataHH();
                txtChonSanPhamThongKe.DisplayMember = "tenhh";
                txtChonSanPhamThongKe.ValueMember = "mahh";

                txtTenSpPhuChu.DataBindings.Clear();
                txtTenSpPhuChu.DataBindings.Add("Text", txtChonSanPhamThongKe.DataSource, "tenhh");

                txtTonKhoPhuChu.DataBindings.Clear();
                txtTonKhoPhuChu.DataBindings.Add("Text", txtChonSanPhamThongKe.DataSource, "tonkho");

                txtGiaBanSpPhuChu.DataBindings.Clear();
                txtGiaBanSpPhuChu.DataBindings.Add("Text", txtChonSanPhamThongKe.DataSource, "dongia");

                txtGiaNhapSpPhuChu.DataBindings.Clear();
                txtGiaNhapSpPhuChu.DataBindings.Add("Text", txtChonSanPhamThongKe.DataSource, "gianhap");

                txtDonViPhuChu.DataBindings.Clear();
                txtDonViPhuChu.DataBindings.Add("Text", txtChonSanPhamThongKe.DataSource, "donvi");

                txtdonvitinhtongTK.DataBindings.Clear();
                txtdonvitinhtongTK.DataBindings.Add("Text", txtChonSanPhamThongKe.DataSource, "donvi");
             }

        // END  KHU VỰC DÀNH CHO TAB THỐNG KÊ ********************************************************* //

        /* ********************************************************************************************************** */
        // START  KHU VỰC DÀNH CHO TAB QUẢN LÝ ADMIN ********************************************************* //

        void bingdingPhanQuyen()
        {
            dtdanhsachuser.DataBindings.Clear(); 

            DataTable dt = new System.Data.DataTable();
            dt = pqctr.GetDataPQ();
            dtdanhsachuser.DataSource = dt;

            

            txtAddTaiKhoan.DataBindings.Clear();
            txtAddTaiKhoan.DataBindings.Add("Text", dtdanhsachuser.DataSource, "taikhoan");

            emailsaoluunhanvienmoi.DataBindings.Clear();
            emailsaoluunhanvienmoi.DataBindings.Add("Text", dtdanhsachuser.DataSource, "email");

            txtNewPass.DataBindings.Clear();
            txtNewPass.DataBindings.Add("Text", dtdanhsachuser.DataSource, "matkhau");

            txtReNewPass.DataBindings.Clear();
            txtReNewPass.DataBindings.Add("Text", dtdanhsachuser.DataSource, "matkhau");

            txtNameUser.DataBindings.Clear();
            txtNameUser.DataBindings.Add("Text", dtdanhsachuser.DataSource, "tennv");

            txtAddPhanQuyen.DataBindings.Clear();
            txtAddPhanQuyen.DataBindings.Add("Text", dtdanhsachuser.DataSource, "phanquyen");
        }

        void bingdingAdmin()
        {
            DataTable dt = new System.Data.DataTable();
            dt = qlctr.getData();
            dtdanhsachuser.DataSource = dt;

            txtNameUser.DataBindings.Clear();
            txtNameUser.DataBindings.Add("Text", dtdanhsachuser.DataSource, "ten");
        }
        // END  KHU VỰC DÀNH CHO TAB QUẢN LÝ ADMIN ********************************************************* //

        /* ********************************************************************************************************** */

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát giao diện quản lý ?", "Chú ý", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        /* ********************************************************************************************************** */
        /* ********************************************************************************************************** */
        /* ********************************************************************************************************** */
        /* ********************************************************************************************************** */

        private void mnThemnv_Click(object sender, EventArgs e)
        {
           
        }

        private void btnThemNv_Click(object sender, EventArgs e)
        {
            

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

/* ******************************************************************************************************************************** */
/* ******************************************************************************************************************************** */
/* ********************* 2.0 SETUP CÁC HÀM XỬ LÝ DÀNH CHO CÁC NÚT THÊM, SỬA , XÓA, LƯU, HỦY *************************************** */
/* ******************************************************************************************************************************** */
/* ******************************************************************************************************************************** */


        // START  KHU VỰC DÀNH CHO TAB NHÂN VIÊN ********************************************************* //
        void dis_enNV(bool e)  // e = true (đóng) ; !e = mở
        {
            //txtMaNv.Enabled = e; -- Đóng khi tăng mã tự động
            txtTenNv.Enabled = e;
            txtGioiTinhNv.Enabled = e;
            dtNgaySinhNv.Enabled = e;
            txtDiaChiNv.Enabled = e;
            txtSdtNv.Enabled = e;
            txtCmndNv.Enabled = e;
            txtEmailNv.Enabled = e;
            txtGhiChuNv.Enabled = e;

            mnHuyNv.Enabled = e;
            mnLuuNv.Enabled = e;
            mnThemNv.Enabled = !e;
            mnSuaNv.Enabled = !e;
            mnXoaNv.Enabled = !e;

            dtDanhSachNhanVien.Enabled = !e;
        }

        void loadcontrolNV() // truyền dữ kiện ban đầu vào cho textbox gioi tinh
        {
            txtGioiTinhNv.Items.Clear();
            txtGioiTinhNv.Items.Add("Khác");
            txtGioiTinhNv.Items.Add("Nam");
            txtGioiTinhNv.Items.Add("Nữ");
        }

        void clearDataNV()
        {
            txtMaNv.Text = "";         
            txtTenNv.Text = "";
            dtNgaySinhNv.Value = DateTime.Now.Date;
            txtDiaChiNv.Text = "";
            txtSdtNv.Text = "";
            txtCmndNv.Text = "";
            txtEmailNv.Text = "";
            txtGhiChuNv.Text = "";
            //txtGioiTinhNv.Text = "";

            loadcontrolNV(); // load gioi tinh
        }

        void ganDuLieuNV(NhanVienObj nvObj) // gán dữ liệu từ textbox vào CSDL
        { 
            nvObj.MaNhanVien = txtMaNv.Text.Trim(); 
            nvObj.TenNhanVien = txtTenNv.Text.Trim();
            nvObj.GioiTinh = txtGioiTinhNv.Text.Trim();
            nvObj.NgaySinh = dtNgaySinhNv.Text.Trim();
            nvObj.DiaChi = txtDiaChiNv.Text.Trim();
            nvObj.SDT = txtSdtNv.Text.Trim();
            nvObj.CMND = txtCmndNv.Text.Trim();
            nvObj.Email = txtEmailNv.Text.Trim();
            nvObj.GhiChu = txtGhiChuNv.Text.Trim();
        }
        //  END KHU VỰC DÀNH CHO TAB NHÂN VIÊN ********************************************************* //



/* ******************************************************************************************************************************** */


        //  START  KHU VỰC DÀNH CHO TAB KHÁCH HÀNG ********************************************************* //
        void dis_enKH(bool e)  // e = true (đóng) ; !e = mở
        {
           // txtMaKhachHang.Enabled = e; -- Đống khi tăng mã tự động
            txtTenKhachHang.Enabled = e;
            txtGioiTinhKhachHang.Enabled = e;
            txtDiaChiKhachHang.Enabled = e;
            txtSDTKhachHang.Enabled = e;
            txtGhiChuKhachHang.Enabled = e;

            mnHuyKh.Enabled = e;
            mnLuuKh.Enabled = e;
            mnThemKh.Enabled = !e;
            mnSuaKh.Enabled = !e;
            mnXoaKh.Enabled = !e;

            dtDanhSachKhachHang.Enabled = !e;
        }
      
        void loadcontrolKH() // truyền dữ kiện ban đầu vào cho textbox gioi tinh
        {
            txtGioiTinhKhachHang.Items.Clear();
            txtGioiTinhKhachHang.Items.Add("Khác");
            txtGioiTinhKhachHang.Items.Add("Nam");
            txtGioiTinhKhachHang.Items.Add("Nữ");
        }

        void clearDataKH()
        {
            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtDiaChiKhachHang.Text = "";
            txtSDTKhachHang.Text = "";
            txtGhiChuKhachHang.Text = "";
            //txtGioiTinhKhachHang.Text = "";

            loadcontrolKH(); //load gioi tinh
        }

        void ganDuLieuKH(KhachHangObj khObj) // gán dữ liệu từ textbox vào CSDL
        {
            khObj.MaKhachHang = txtMaKhachHang.Text.Trim();
            khObj.TenKhachHang = txtTenKhachHang.Text.Trim();
            khObj.GioiTinh = txtGioiTinhKhachHang.Text.Trim();
            khObj.DiaChi = txtDiaChiKhachHang.Text.Trim();
            khObj.SoDienThoai = txtSDTKhachHang.Text.Trim();
            khObj.GhiChu = txtGhiChuKhachHang.Text.Trim();
        }
        //  END  KHU VỰC DÀNH CHO TAB KHÁCH HÀNG ********************************************************* //

/* ******************************************************************************************************************************* */

        //  START  KHU VỰC DÀNH CHO TAB LOẠI SẢN PHẨM ********************************************************* //
        void dis_enLHH(bool e)  // e = true (đóng) ; !e = mở
        {
            //txtMaLoaiSanPham.Enabled = e;
            txtTenLoaiSanPham.Enabled = e;

            mnHuyLoai.Enabled = e;
            mnLuuLoai.Enabled = e;
            mnThemLoai.Enabled = !e;
            mnSuaLoai.Enabled = !e;
            mnXoaLoai.Enabled = !e;
            dtDanhSachLoaiSanPham.Enabled = !e;
        }
        
        void clearDataLHH()
        {
            txtMaLoaiSanPham.Text = "";
            txtTenLoaiSanPham.Text = "";            
        }

        void ganDuLieuLHH(LoaiHangHoaObj lhhObj) // gán dữ liệu từ textbox vào CSDL
        {
            lhhObj.MaLoaiHH = txtMaLoaiSanPham.Text.Trim();
            lhhObj.TenLoaiHH = txtTenLoaiSanPham.Text.Trim();
        }

        //  END  KHU VỰC DÀNH CHO TAB LOẠI SẢN PHẨM ********************************************************* //

/* ******************************************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB NHÀ CUNG CẤP ********************************************************* //

        void dis_enNCC(bool e)  // e = true (đóng) ; !e = mở
        {
            //txtMaNCC.Enabled = e;
            txtTenNCC.Enabled = e;
            txtDiaChiNCC.Enabled = e;
            txtSoDtNCC.Enabled = e;
            txtGhiChuNCC.Enabled = e;

            mnHuyNcc.Enabled = e;
            mnLuuNcc.Enabled = e;
            mnThemNcc.Enabled = !e;
            mnSuaNcc.Enabled = !e;
            mnXoaNcc.Enabled = !e;
            dtDanhSachNhaCungCap.Enabled = !e;
        }
        
        void clearDataNCC()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChiNCC.Text = "";
            txtSoDtNCC.Text = "";
            txtGhiChuNCC.Text = "";
        }

        void ganDuLieuNCC(NhaCungCapObj nccObj) // gán dữ liệu từ textbox vào cho biến tạm 
        {
            nccObj.MaNhaCungCap = txtMaNCC.Text.Trim();
            nccObj.TenNhaCungCap = txtTenNCC.Text.Trim();
            nccObj.DiaChi = txtDiaChiNCC.Text.Trim();
            nccObj.SoDienThoai = txtSoDtNCC.Text.Trim();
            nccObj.GhiChu = txtGhiChuNCC.Text.Trim();
        }

        //  END  KHU VỰC DÀNH CHO TAB NHÀ CUNG CẤP ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB KHUYẾN MÃI ********************************************************* //

        void dis_enKm(bool e)  // e = true (đóng) ; !e = mở
        {
            //txtMaKm.Enabled = e;
            txtTenKm.Enabled = e;
            txtNoiDungKm.Enabled = e;
            txtGiamKm.Enabled = e;

            mnHuyKm.Enabled = e;
            mnLuuKm.Enabled = e;
            mnThemKm.Enabled = !e;
            mnSuaKm.Enabled = !e;
            mnXoaKm.Enabled = !e;

            dtDanhSachKhuyenmai.Enabled = !e;

        }

        void clearDataKm()
        {
            txtMaKm.Text = "";
            txtTenKm.Text = "";
            txtNoiDungKm.Text = "";
            txtGiamKm.Text = "0";
        }

        void ganDuLieuKm(KhuyenMaiObj kmObj) // gán dữ liệu từ textbox vào cho biến tạm 
        {
            kmObj.MaKhuyenmai = txtMaKm.Text.Trim();
            kmObj.TenKhuyenMai = txtTenKm.Text.Trim();
            kmObj.NoiDung = txtNoiDungKm.Text.Trim();
            kmObj.Giam = int.Parse(txtGiamKm.Text.Trim());
        }

        //  END  KHU VỰC DÀNH CHO TAB KHUYẾN MÃI ********************************************************* //

/* ******************************************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB SẢN PHẨM ********************************************************* //

        void dis_enHH(bool e)  // e = true (đóng) ; !e = mở
        {
            //txtMaHH.Enabled = e; -- Tăng mã tự động
            txtTenHH.Enabled = e;
            txtGiaNhapSp.Enabled = e;
            txtDonGiaHH.Enabled = e;
            txtTonKhoHH.Enabled = e;
            txtDonViHH.Enabled = e;
            txtDaBanHH.Enabled = e;
            txtNhaCungCapHH.Enabled = e;
            txtLoaiHangHH.Enabled = e;
            txtKhuyenMaiHH.Enabled = e;
            txtGhiChuHH.Enabled = e;

            mnHuySp.Enabled = e;
            mnLuuSp.Enabled = e;
            mnThemSp.Enabled = !e;
            mnSuaSp.Enabled = !e;
            mnXoaSp.Enabled = !e;

            dtDanhSachHangHoa.Enabled = !e;
        }

        void loadcontrolHH() // truyền dữ kiện ban đầu vào cho textbox gioi tinh
        {
            txtDonViHH.Items.Clear();
            txtDonViHH.Items.Add("Khác");

            txtDonViHH.SelectedItem = 0;

            //  chú ý !!!!!!!

            NhaCungCapCtrl ncc = new NhaCungCapCtrl();
            txtNhaCungCapHH.DataSource = ncc.getDataNCC();
            txtNhaCungCapHH.DisplayMember = "tenncc";
            txtNhaCungCapHH.ValueMember = "mancc";
            
            LoaiHangHoaCtrl loai = new LoaiHangHoaCtrl();
            txtLoaiHangHH.DataSource = loai.getDataLHH();
            txtLoaiHangHH.DisplayMember = "tenloai";
            txtLoaiHangHH.ValueMember = "maloai";
            
            KhuyenMaiCtrl km = new KhuyenMaiCtrl();
            txtKhuyenMaiHH.DataSource = km.getDataKm();
            txtKhuyenMaiHH.DisplayMember = "tensk";
            txtKhuyenMaiHH.ValueMember = "mask";   
        }

        void clearDataHH()
        {
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtGiaNhapSp.Text = "";
            txtDonGiaHH.Text = "";
            txtTonKhoHH.Text = "0";
            txtDonViHH.Text = "";
            txtDaBanHH.Text = "0";
    //        txtNhaCungCapHH.Text = "";
    //        txtLoaiHangHH.Text = "";
      //      txtKhuyenMaiHH.Text = "";
            txtGhiChuHH.Text = "";

            loadcontrolHH(); // thay cho dữ liệu giới tính đã set ở hàm trước
        }

        void ganDulieuHHsub()
        {
            txtNhaCungCapHH.DisplayMember = "mancc";
            txtNhaCungCapHH.ValueMember = "tenncc";
            
            txtLoaiHangHH.DisplayMember = "maloai";
            txtLoaiHangHH.ValueMember = "tenloai"; 

            txtKhuyenMaiHH.DisplayMember = "mask";
            txtKhuyenMaiHH.ValueMember = "tensk";
        }

        void ganDuLieuHH(HangHoaObj hhObj) // gán dữ liệu từ textbox vào cho biến tạm nvObj
        {
            hhObj.MaHangHoa = txtMaHH.Text.Trim();
            hhObj.TenHangHoa = txtTenHH.Text.Trim();
            hhObj.GiaNhap = int.Parse(txtGiaNhapSp.Text.Trim());
            hhObj.DonGia = int.Parse(txtDonGiaHH.Text.Trim());
            hhObj.TonKho = int.Parse(txtTonKhoHH.Text.Trim());
            hhObj.DonVi = txtDonViHH.Text.Trim();
            hhObj.DaBan = int.Parse(txtDaBanHH.Text.Trim());
            hhObj.NhaCungCap = txtNhaCungCapHH.Text.Trim();
            hhObj.LoaiHangHoa = txtLoaiHangHH.Text.Trim();
            hhObj.KhuyenMai = txtKhuyenMaiHH.Text.Trim();
            

            hhObj.GhiChu = txtGhiChuHH.Text.Trim();
        }

        //  END  KHU VỰC DÀNH CHO TAB SẢN PHẨM ********************************************************* //

/* ******************************************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB HÓA ĐƠN + CTHD ********************************************************* //


        void dis_enHD(bool e)  // e = true (đóng) ; !e = mở
        {
            txtSanPhamHD.Enabled = e;
            txtSoLuongCTHD.Enabled = e;

            txtKhachHangHD.Enabled = !e;


            btnThemCTHD.Enabled = e;
            btnHuyCHTD.Enabled = e;
            btnXoaSpCTHD.Enabled = e;

            btnInHoaDon.Enabled = !e;
            btnThemHD.Enabled = !e;
            btnXoaHD.Enabled = !e;
            btnGioHangHD.Enabled = !e;
            

            loadcontrolHD();
        }

        void loadcontrolHD() // truyền dữ kiện ban đầu vào cho textbox 
        {
            //  chú ý !!!!!!!

            HangHoaCtrl hh = new HangHoaCtrl();
            txtSanPhamHD.DataSource = hh.getDataHH();
            txtSanPhamHD.DisplayMember = "tenhh";
            txtSanPhamHD.ValueMember = "mahh";
          
            KhachHangCtrl kh = new KhachHangCtrl();
            txtKhachHangHD.DataSource = kh.getDataKH();
            txtKhachHangHD.DisplayMember = "tenkh";
            txtKhachHangHD.ValueMember = "makh";

            txtMaSpCTHD.Text = "";
            txtMaSpAdd.Text = "";
            txtDonGiaCTHD.Text = "";
            txtGiamAdd.Text = "";
            lbloiBH.Text = "";
            txtKhachHangHD.Text = "";
            txtDonViSp.Text = "";
            txttonkho.Text = "";
            txttonkhosub.Text = "";

            clearDataHD();
        }

        void clearDataHD()
        {            
            txtSanPhamHD.Text = "";
            txtSoLuongCTHD.Text = "0";
            btnKhuyenMaiHD.Text = "0";
        }


        void ganDulieuHDsub()
        {

            txtSanPhamHD.DisplayMember = "mahh";
            txtSanPhamHD.ValueMember = "tenhh";
        }

        void ganDuLieuHD(HoaDonObj hdObj) // gán dữ liệu từ textbox vào cho biến tạm nvObj
        {
            /* Tăng mã tự động*/

            hdObj.MaHoaDon = txtMaHD.Text.Trim(); // cài đặt mã tự tăng
            hdObj.NguoiLap = PhanQuyenMod.Name_USER.ToString(); // cài đặt mặt định dựa trên tên của tài khoản đăng nhập
            hdObj.KhachHang = txtKhachHangHD.Text.Trim();
            hdObj.NgayLap = txtNgayBanHD.Text.Trim();
        }

        void dis_enCTHD(bool e)  // e = true (đóng) ; !e = mở
        {
            txtSanPhamHD.Enabled = !e;
            txtSoLuongCTHD.Enabled = !e;

            txtKhachHangHD.Enabled = e;

            btnThemCTHD.Enabled = !e;
            btnHuyCHTD.Enabled = !e;
            btnXoaSpCTHD.Enabled = !e;

            btnInHoaDon.Enabled = !e;
            btnThemHD.Enabled = e;
            btnXoaHD.Enabled = e;
            btnGioHangHD.Enabled = e;           
            
            loadcontrolCTHD();
        }

        void loadcontrolCTHD() // truyền dữ kiện ban đầu vào cho textbox 
        {            
            //  chú ý !!!!!!!
            
            HangHoaCtrl hh = new HangHoaCtrl();
            txtSanPhamHD.DataSource = hh.getDataHH();
            txtSanPhamHD.DisplayMember = "tenhh";
            txtSanPhamHD.ValueMember = "mahh";

            txtDonViSp.DataBindings.Clear();
            txtDonViSp.DataBindings.Add("Text", txtSanPhamHD.DataSource, "donvi");

            txttonkho.DataBindings.Clear();
            txttonkho.DataBindings.Add("Text",txtSanPhamHD.DataSource,"tonkho");

            txtMaSpAdd.DataBindings.Clear();
            txtMaSpAdd.DataBindings.Add("Text", txtSanPhamHD.DataSource, "mahh");

            txtDonGiaCTHD.DataBindings.Clear();
            txtDonGiaCTHD.DataBindings.Add("Text", txtSanPhamHD.DataSource, "dongia");

            txtGiamAdd.DataBindings.Clear();
            txtGiamAdd.DataBindings.Add("Text", txtSanPhamHD.DataSource, "giam");

            txtgianhapspadd.DataBindings.Clear();
            txtgianhapspadd.DataBindings.Add("Text", txtSanPhamHD.DataSource, "gianhap");

            clearDataCTHD();
        }

        void clearDataCTHD()
        {            
            txtSoLuongCTHD.Text = "1";
        }
        
        void ganDulieuCTHDsub()
        {
            txtSanPhamHD.DisplayMember = "mahh";
            txtSanPhamHD.ValueMember = "tenhh";            
        }
        void ganDuLieuCTHD(ChiTietHoaDonObj cthdObj) // gán dữ liệu từ textbox vào cho biến tạm nvObj
        {
            string mahh = txtSanPhamHD.Text;

            cthdObj.MaHoaDon =txtMaHD.Text.Trim(); // Lấy từ hóa đơn đã tạo trước đó
            cthdObj.MaHangHoa = txtSanPhamHD.Text.Trim(); // cài đặt tự động
            cthdObj.SoLuong = int.Parse(txtSoLuongCTHD.Text.Trim());

            cthdObj.DonGia = int.Parse(txtDonGiaCTHD.Text.Trim());

            cthdObj.KhuyenMai = int.Parse(txtGiamAdd.Text.Trim());

            int sl = int.Parse(txtSoLuongCTHD.Text.Trim());
            int dg = int.Parse(txtDonGiaCTHD.Text.Trim());
            int km = int.Parse(txtGiamAdd.Text.Trim());
          
            cthdObj.ThanhTien = (sl*dg)-(sl*dg*km/100);
        }

        void ganTongTienHD(string mahd)
        {
            hdctr.UpdTongTienHD(mahd);
        }


        //  END  KHU VỰC DÀNH CHO TAB HÓA ĐƠN + CTHD ********************************************************* //

/* ******************************************************************************************************************************* */
        // START  KHU VỰC DÀNH CHO TAB THỐNG KÊ ********************************************************* //
  
            void TonKho_DaBan(string mahh, int soluong)
             {
            
               tkctr.updDaBan(mahh,soluong);

              }

            void gandulieuThongKe(ThongKeObj tkObj)
        {
            tkObj.MaHangHoa = txtSanPhamHD.Text.Trim();
            tkObj.NgayBan = txtNgayBanHD.Text.Trim();
            tkObj.GiaBan = int.Parse(txtDonGiaCTHD.Text.Trim());
            tkObj.GiaNhap = int.Parse(txtgianhapspadd.Text.Trim());
            tkObj.TongDoanhThu = 0;
            tkObj.LoiNhuan = 0;

        }

        void ReloadThongKe(ThongKeObj tkObj)
        {
            tkctr.updDate(tkObj);

        }

        void dis_enTKTraCuu(bool e)
        {
            txtChonSanPhamThongKe.Enabled = e;
            txtNgayThongKe.Enabled = e;
            btnThongKeTheoNgay.Enabled = e;
            btnThongKeTheoThang.Enabled = e;
            btnThongKeTheoNam.Enabled = e;
            btnAllSpNgay.Enabled = e;
            btnAllSpThang.Enabled = e;
            btnAllSpNam.Enabled = e;
           // btnXoaTKSP.Enabled = e;



            //loadTKTraCuu();
        }

        void loadTKTraCuu()
        {
            txtDateBangSoLieu.Text = "";
            txtSlTongThu.Text = "0";
            txtSlLoiNhuan.Text = "0";
            txtSlDaban.Text = "0";
            txtSlSoSanPhamBanRa.Text = "";
           // txtdonvitinhtongTK.Text = "Đơn Vị";
            txtTrongNgayBSL.Text = "";

            tabledulieuthongke.DataBindings.Clear(); // ẩn. ở bên dưới
            
        }


        void loadTraCuu()
        {
           // HangHoaCtrl hh = new HangHoaCtrl();
          //  txtChonSanPhamThongKe.DataSource = hh.getDataHH();
            txtChonSanPhamThongKe.DisplayMember = "mahh";
            txtChonSanPhamThongKe.ValueMember = "tenhh";

            btnXoaTKSP.Enabled = true;
        }

        // END  KHU VỰC DÀNH CHO TAB THỐNG KÊ ********************************************************* //

/* ****************************************************************************************************************************** */
      
       // START  KHU VỰC DÀNH CHO TAB QUẢN LÝ ADMIN ********************************************************* //

        void ganDulieuQL(QuanLyObj nvObj)
        {
            nvObj.MatKhau = toMD5(txtMatKhauMoi.Text);//txtMatKhauMoi.Text.Trim();
        }

        void loadQuanLy()
        {
            txtMatKhauCu.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLaiMatKhau.Text = "";
            txtThongBaoDoiMK.Text = "";
            txtmailsaoluu.Text = "";

            txtNoteInternet.Text = "";
            if (InternetConnection.IsConnectedToInternet())
            {
                txtNoteInternet.ForeColor = System.Drawing.Color.Green;
                txtNoteInternet.Text = " Đã kết nối internet, bạn có thể đổi mật khẩu !.";
            }
            else
            {
                txtNoteInternet.ForeColor = System.Drawing.Color.Red;
                txtNoteInternet.Text = " Đã mất kết nối internet, bạn không thể đổi mật khẩu !.";
            }

        }

        void LoadShowEye(bool e) // e = hiện  ; !e = ẩn
        {
            hidepasscu.Visible = e;
            showpasscu.Visible = !e;
            hidepassmoi1.Visible = e;
            showpassmoi1.Visible = !e;
            hidepassmoi2.Visible = e;
            showpassmoi2.Visible = !e;
        }

        // END  KHU VỰC DÀNH CHO TAB QUẢN LÝ ADMIN ********************************************************* //

        /* ********************************************************************************************************** */

        // START  KHU VỰC DÀNH CHO TAB QUẢN LÝ TÀI KHOẢN ********************************************************* //



        // END  KHU VỰC DÀNH CHO TAB QUẢN LÝ TÀI KHOẢN ********************************************************* //
        /* ********************************************************************************************************** */

        void dis_enLoadUSer(bool e) // e = mở ; !e = đóng
        {
            rbntTKNhanVien.Checked = e;
        }
        void loadUser()
        {
            thongbaoloiadmin.ForeColor = System.Drawing.Color.Red;
            thongbaoloiadmin.Text = "";
            txtAddTaiKhoan.Text = "";
            txtNewPass.Text = "";
            txtReNewPass.Text = "";
            //emailsaoluunhanvienmoi.Text = "";

            emailsaoluunhanvienmoi.DataBindings.Clear();

            gbDanhSachUser.Text = "Danh sách tài khoản User";
            mnphanquyen.Text = "Phân quyền nhân viên";

            NhanVienCtrl nv = new NhanVienCtrl();
            txtNameUser.DataSource = nv.getData();
            txtNameUser.DisplayMember = "tennv";
            txtNameUser.ValueMember = "manv";

            txtAddPhanQuyen.Items.Clear();
            txtAddPhanQuyen.Items.Add("2");
            txtAddPhanQuyen.Items.Add("3");


        }

        void loadAdmin()
        {

            txtAddTaiKhoan.Text = "admin";
            txtNewPass.Text = "";
            txtReNewPass.Text = "";
            emailsaoluunhanvienmoi.Text = "";
            txtNameUser.Text = "";

            emailsaoluunhanvienmoi.DataBindings.Clear();

            gbDanhSachUser.Text = "Danh sách tài khoản Admin";
            mnphanquyen.Text = "Đổi tên admin";

            //txtAddPhanQuyen.Items.Clear();
            txtAddPhanQuyen.Items.Clear();
            txtAddPhanQuyen.Items.Add("1");
            txtAddPhanQuyen.SelectedItem = 1;

            NhanVienCtrl nv = new NhanVienCtrl();
            txtNameUser.DataSource = nv.getData();
            txtNameUser.DisplayMember = "tennv";
            txtNameUser.ValueMember = "manv";

            dtdanhsachuser.DataBindings.Clear();
            bingdingAdmin(); // load bảng dữ liệu 
        }

        void dis_enNhanVien(bool e) // e = mở ; !e = đóng
        {
            mndangkymoi.Enabled = e;
            mndoimatkhau.Enabled = e;
            mnphanquyen.Enabled = e;
            LuuTKmoi.Enabled = !e;
            HuyTKmoi.Enabled = !e;

            txtAddTaiKhoan.Enabled = !e;
            txtNewPass.Enabled = !e;
            txtReNewPass.Enabled = !e;
            emailsaoluunhanvienmoi.Enabled = !e;
            checksaoluu.Enabled = !e;
            txtNameUser.Enabled = !e;
            txtAddPhanQuyen.Enabled = !e;

            dtdanhsachuser.Enabled = e;
        }

        void dis_enAdmin(bool e) // e = mở ; !e = đóng
        {
            mndangkymoi.Enabled = !e;
            mndoimatkhau.Enabled = !e;
            mnphanquyen.Enabled = e;
            LuuTKmoi.Enabled = !e;
            HuyTKmoi.Enabled = !e;

            txtAddTaiKhoan.Enabled = !e;
            txtNewPass.Enabled = !e;
            txtReNewPass.Enabled = !e;
            emailsaoluunhanvienmoi.Enabled = !e;
            checksaoluu.Enabled = !e;
            txtNameUser.Enabled = !e;
            txtAddPhanQuyen.Enabled = !e;

        }

        void dkmoinhanvien(bool e)
        {
            mndangkymoi.Enabled = !e;
            mndoimatkhau.Enabled = !e;
            mnphanquyen.Enabled = !e;
            LuuTKmoi.Enabled = e;
            HuyTKmoi.Enabled = e;

            grLoaiTaiKhoan.Enabled = !e;
            txtAddTaiKhoan.Enabled = e;
            txtNewPass.Enabled = e;
            txtReNewPass.Enabled = e;
            emailsaoluunhanvienmoi.Enabled = e;
            checksaoluu.Enabled = e;
            txtNameUser.Enabled = e;
            txtAddPhanQuyen.Enabled = e;

            txtAddTaiKhoan.Text = "";
            txtNewPass.Text = "";
            txtReNewPass.Text = "";
            //  emailsaoluunhanvienmoi.Text = "";

            NhanVienCtrl nv = new NhanVienCtrl();
            txtNameUser.DataSource = nv.getData();
            txtNameUser.DisplayMember = "tennv";
            txtNameUser.ValueMember = "manv";

            emailsaoluunhanvienmoi.DataBindings.Clear();
            emailsaoluunhanvienmoi.DataBindings.Add("Text", txtNameUser.DataSource, "email");

        }

        void gandulieuthemmoiuser()
        {
            /* Tăng mã tự động*/
            string LastID = Idctr.GetLastID("PHANQUYEN", "id"); // bảng, cột được lấy mã cuối
            string maid = TangMaTuDong(LastID, "US");  // Tiền tố US + mã tự động tăng


            txtNameUser.DisplayMember = "manv";
            txtNameUser.ValueMember = "tennv";


            pqObj.ID = maid.Trim();
            pqObj.Taikhoan = txtAddTaiKhoan.Text.Trim();
            pqObj.MatKhau = toMD5(txtReNewPass.Text); //txtReNewPass.Text.Trim();
            pqObj.Quyen = int.Parse(txtAddPhanQuyen.Text.Trim());
            int quyen = int.Parse(txtAddPhanQuyen.Text.Trim());
            pqObj.maNhanVien = txtNameUser.Text.Trim();

            if (quyen == 2)
            {
                pqObj.GhiChu = "2. Quyền Quản Lý ( tab Bán Hàng và tab Quản Lý)";
            }
            else if (quyen == 3)
            {
                pqObj.GhiChu = "3. Quyền Nhân Viên ( tab Bán Hàng )";
            }
            else
            {
                thongbaoloiadmin.Text = "Vui lòng chọn phân quyền là : 2 hoặc 3 !";
            }

        }

        void gandulieuthemmoiadmin()
        {
            qlObj.ID = "admin";
            qlObj.Taikhoan = "admin";
            qlObj.MatKhau = toMD5(txtReNewPass.Text);// txtReNewPass.Text.Trim();
            qlObj.Ten = txtNameUser.Text.Trim();

        }
        void dkmoiAdmin(bool e)
        {
            mndangkymoi.Enabled = !e;
            mndoimatkhau.Enabled = !e;
            mnphanquyen.Enabled = !e;
            LuuTKmoi.Enabled = e;
            HuyTKmoi.Enabled = e;

            grLoaiTaiKhoan.Enabled = !e;
            txtAddTaiKhoan.Enabled = !e;
            txtNewPass.Enabled = e;
            txtReNewPass.Enabled = e;
            emailsaoluunhanvienmoi.Enabled = e;
            checksaoluu.Enabled = e;
            txtNameUser.Enabled = e;
            txtAddPhanQuyen.Enabled = e;

            NhanVienCtrl nv = new NhanVienCtrl();
            txtNameUser.DataSource = nv.getData();
            txtNameUser.DisplayMember = "tennv";
            txtNameUser.ValueMember = "manv";

            emailsaoluunhanvienmoi.DataBindings.Clear();
            emailsaoluunhanvienmoi.DataBindings.Add("Text", txtNameUser.DataSource, "email");
        }
        void doimknhanvien(bool e)
        {
            mndangkymoi.Enabled = !e;
            mndoimatkhau.Enabled = !e;
            mnphanquyen.Enabled = !e;
            LuuTKmoi.Enabled = e;
            HuyTKmoi.Enabled = e;

            grLoaiTaiKhoan.Enabled = !e;
            txtAddTaiKhoan.Enabled = !e;
            txtNewPass.Enabled = e;
            txtReNewPass.Enabled = e;
            emailsaoluunhanvienmoi.Enabled = e;
            checksaoluu.Enabled = e;
            txtNameUser.Enabled = !e;
            txtAddPhanQuyen.Enabled = !e;

        }

        void phanquyennhanvien(bool e)
        {
            mndangkymoi.Enabled = !e;
            mndoimatkhau.Enabled = !e;
            mnphanquyen.Enabled = !e;
            LuuTKmoi.Enabled = e;
            HuyTKmoi.Enabled = e;

            grLoaiTaiKhoan.Enabled = !e;
            txtAddTaiKhoan.Enabled = !e;
            txtNewPass.Enabled = !e;
            txtReNewPass.Enabled = !e;
            emailsaoluunhanvienmoi.Enabled = !e;
            checksaoluu.Enabled = !e;
            txtNameUser.Enabled = !e;
            txtAddPhanQuyen.Enabled = e;

        }
        void phanquyenadmin(bool e)
        {
            mndangkymoi.Enabled = !e;
            mndoimatkhau.Enabled = !e;
            mnphanquyen.Enabled = !e;
            LuuTKmoi.Enabled = e;
            HuyTKmoi.Enabled = e;

            grLoaiTaiKhoan.Enabled = !e;
            txtAddTaiKhoan.Enabled = !e;
            txtNewPass.Enabled = !e;
            txtReNewPass.Enabled = !e;
            emailsaoluunhanvienmoi.Enabled = !e;
            checksaoluu.Enabled = !e;
            txtNameUser.Enabled = e;
            txtAddPhanQuyen.Enabled = !e;

        }

        /* ********************************************************************************************************** */
        /* ********************************************************************************************************** */
        /* ********************* 3.0 SETUP CÁC NÚT THÊM, SỬA, XÓA, LƯU HỦY ********************************************** */
        /* ********************************************************************************************************** */
        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB NHÂN VIÊN ********************************************************* //

        private void mnThemNv_Click_1(object sender, EventArgs e)
        {
            thongbaoloinhanvien.Text = "";

            flag = 0;
            dis_enNV(true);
            clearDataNV();

            /* Tăng mã tự động */
            string LastID = Idctr.GetLastID("NHANVIEN", "manv"); // bảng, cột được lấy mã cuối
            txtMaNv.Text = TangMaTuDong(LastID, "NV"); // Tiền tố chữ trước mã số 
        }

        private void mnSuaNv_Click(object sender, EventArgs e)
        {
            thongbaoloinhanvien.Text = "";
            if (txtMaNv.Text == "" || txtMaNv.Text == null)
            {
                thongbaoloinhanvien.Text = "Chưa chọn nhân viên. ";
            }
            else
            { 
                flag = 1;
                bingdingNV();
                dis_enNV(true);
            }
        }

        private void mnXoaNv_Click(object sender, EventArgs e)
        {
            thongbaoloinhanvien.Text = "";
            if (txtMaNv.Text == "" || txtMaNv.Text == null)
            {
                thongbaoloinhanvien.Text = "Chưa chọn nhân viên. ";
            }
            else
            {
                DialogResult dr = MessageBox.Show("Xóa NHÂN VIÊN này. Bạn sẽ đồng thời xóa bỏ TÀI KHOẢN ĐĂNG NHẬP của nhân viên này.\n \nBẠN CÓ CHẮC KHÔNG ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    // Xóa
                    if (nvctr.delDate(txtMaNv.Text.Trim()))
                        MessageBox.Show(" 𝐗𝐨á thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("𝐗𝐨á thất bại !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else return;

                Form2_Load(sender, e);
            }
        }

        private void mnLuuNv_Click(object sender, EventArgs e)
        {
            if(fixNhanVien())
            {
                ganDuLieuNV(nvObj);
                if (flag == 0)
                {
                    // TH Thêm nv mới
                    if (nvctr.addData(nvObj))
                    {
                        MessageBox.Show("Bạn đã thêm một nhân viên mới thành công !" + " Bạn cần phải tạo một tài khoản đăng nhập mới cho nhân viên này !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        Form2_Load(sender, e);
                        dis_enNV(false);
                    }
                    else
                        MessageBox.Show("THÊM THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // TH Sửa tt nhân viên
                    if (nvctr.updDate(nvObj))
                    {
                        MessageBox.Show("Bạn đã CẬP NHẬT thông tin Nhân Viên thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2_Load(sender, e);
                        dis_enNV(false);
                    } 
                }
            }
            HanCheQuyen();
        }

        private void mnHuyNv_Click(object sender, EventArgs e)
        {
            clearDataNV();
            dtdanhsachuser.DataBindings.Clear();
            Form2_Load(sender, e);
            dis_enNV(false);
            HanCheQuyen();
        }
        //  END  KHU VỰC DÀNH CHO TAB NHÂN VIÊN ********************************************************* //


/* ******************************************************************************************************************************** */


        //  START  KHU VỰC DÀNH CHO TAB KHÁCH HÀNG ********************************************************* //
        private void mnThemKh_Click(object sender, EventArgs e)
        {
            thongbaoloikhachhang.Text = "";

            flagKH = 0;
            dis_enKH(true);
            loadcontrolKH();
            clearDataKH();

            /* Tăng mã tự động*/
            string LastID = Idctr.GetLastID("KHACHHANG", "makh"); // bảng, cột được lấy mã cuối
            txtMaKhachHang.Text = TangMaTuDong(LastID, "KH");  // Tiền tố chữ trước mã số 
        }

        private void mnSuaKh_Click(object sender, EventArgs e)
        {
            thongbaoloikhachhang.Text = "";
            if (txtMaKhachHang.Text == "" || txtMaKhachHang.Text == null)
            {
                thongbaoloikhachhang.Text = "Chưa chọn khách hàng cần sửa. ";
            }
            else
            {
                flagKH = 1;
                bingdingKH();
                //loadcontrolKH();
                dis_enKH(true);
            }
        }

        private void mnXoaKh_Click(object sender, EventArgs e)
        {
            thongbaoloikhachhang.Text = "";
            if (txtMaKhachHang.Text == "" || txtMaKhachHang.Text == null)
            {
                thongbaoloikhachhang.Text = "Chưa chọn khách hàng cần xóa. ";
            }
            else
            {
                DialogResult dr2 = MessageBox.Show("Bạn có chắc muốn XÓA thông tin khách hàng này ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr2 == DialogResult.Yes)
                {
                    // Xóa
                    if (khctr.delDateKH(txtMaKhachHang.Text.Trim()))
                        MessageBox.Show("Bạn đã XÓA thông tin khách hàng thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("XÓA THẤT BẠI : LỖI HỆ THỐNG !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else return;

                Form2_Load(sender, e);
            }
        }

        private void mnLuuKh_Click(object sender, EventArgs e)
        {
            if(fixKhachHang())
            {
                ganDuLieuKH(khObj);
                if (flagKH == 0)
                {
                    // TH Thêm mới
                    if (khctr.addDataKH(khObj))
                    {
                        MessageBox.Show("Bạn đã THÊM một khách hàng mới thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2_Load(sender, e);
                        dis_enKH(false);
                    }
                    else
                        MessageBox.Show("THÊM THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // TH Sửa tt 
                    if (khctr.updDateKH(khObj))
                    {
                        MessageBox.Show("Bạn đã CẬP NHẬT thông tin khách hàng thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2_Load(sender, e);
                        dis_enKH(false);
                    }
                    else
                        MessageBox.Show("CẬP NHẬT THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            HanCheQuyen();
        }

        private void mnHuyKh_Click(object sender, EventArgs e)
        {
            clearDataKH();
            Form2_Load(sender, e);
            dis_enKH(false);
            HanCheQuyen();
        }

        //  END  KHU VỰC DÀNH CHO TAB KHÁCH HÀNG ********************************************************* //

/* ******************************************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB LOẠI HÀNG HÓA ********************************************************* //

        private void mnThemLoai_Click(object sender, EventArgs e)
        {
            thongbaoloiloaisanpham.Text = "";

            flagLHH = 0;
            dis_enLHH(true);
            clearDataLHH();

            /* Tăng mã tự động*/
            string LastID = Idctr.GetLastID("LOAIHH", "maloai"); // bảng, cột được lấy mã cuối
            txtMaLoaiSanPham.Text = TangMaTuDong(LastID, "L");  // Tiền tố chữ trước mã số 
        }

        private void mnSuaLoai_Click(object sender, EventArgs e)
        {
            thongbaoloiloaisanpham.Text = "";
            if (txtMaLoaiSanPham.Text == "" || txtMaLoaiSanPham.Text == null)
            {
                thongbaoloiloaisanpham.Text = "Chưa chọn loại sản phẩm cần sửa. ";
            }
            else
            {
                flagLHH = 1;
                bingdingLHH();
                dis_enLHH(true);
            }
        }

        private void mnXoaLoai_Click(object sender, EventArgs e)
        {
            thongbaoloiloaisanpham.Text = "";
            if (txtMaLoaiSanPham.Text == "" || txtMaLoaiSanPham.Text == null)
            {
                thongbaoloiloaisanpham.Text = "Chưa chọn loại sản phẩm cần xóa. ";
            }
            else
            {
                DialogResult dr3 = MessageBox.Show("Xóa loại sản phẩm này. Đồng nghĩa với việc xóa tất cả thông tin sản phẩm thuộc loại này.\nBạn có chắc sẽ ngừng kinh doanh loại sản phẩm này? ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr3 == DialogResult.Yes)
                {
                    // Xóa
                    if (lhhctr.delDateLHH(txtMaLoaiSanPham.Text.Trim()))
                        MessageBox.Show("Bạn đã XÓA thông tin Loại Sản Phẩm thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("XÓA THẤT BẠI : LỖI HỆ THỐNG !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else return;

                Form2_Load(sender, e);
            }
        }

        private void mnLuuLoai_Click(object sender, EventArgs e)
        {
            if(fixLoaiSP())
            {
                ganDuLieuLHH(lhhObj);
                if (flagLHH == 0)
                {
                    // TH Thêm mới
                    if (lhhctr.addDataLHH(lhhObj))
                    {
                        MessageBox.Show("Bạn đã THÊM một Loại Sản Phẩm mới thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2_Load(sender, e);
                        dis_enLHH(false);
                    }
                    else
                        MessageBox.Show("THÊM THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // TH Sửa tt
                    if (lhhctr.updDateLHH(lhhObj))
                    {
                        MessageBox.Show("Bạn đã CẬP NHẬT thông tin Loại Sản Phẩm thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2_Load(sender, e);
                        dis_enLHH(false);
                    }
                    else
                        MessageBox.Show("CẬP NHẬT THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            HanCheQuyen();
        }

        private void mnHuyLoai_Click(object sender, EventArgs e)
        {
            clearDataLHH();
            Form2_Load(sender, e);
            dis_enLHH(false);
            HanCheQuyen();
        }


        //  END  KHU VỰC DÀNH CHO TAB LOẠI HÀNG HÓA ********************************************************* //

/* ******************************************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB NHÀ CUNG CẤP ********************************************************* //

        private void mnThemNcc_Click(object sender, EventArgs e)
        {
            thongbaoloincc.Text = "";

            flagNCC = 0;
            dis_enNCC(true);
            clearDataNCC();

            /* Tăng mã tự động*/
            string LastID = Idctr.GetLastID("NCC", "mancc"); // bảng, cột được lấy mã cuối
            txtMaNCC.Text = TangMaTuDong(LastID, "NC");  // Tiền tố chữ trước mã số
        }

        private void mnSuaNcc_Click(object sender, EventArgs e)
        {
            thongbaoloincc.Text = "";
            if (txtMaNCC.Text == "" || txtMaNCC.Text == null)
            {
                thongbaoloincc.Text = "Chưa chọn nhà cung cấp cần sửa. ";
            }
            else
            {
                flagNCC = 1;
                bingdingNCC();
                dis_enNCC(true);
            }
        }

        private void mnXoaNcc_Click(object sender, EventArgs e)
        {
            thongbaoloincc.Text = "";
            if (txtMaNCC.Text == "" || txtMaNCC.Text == null)
            {
                thongbaoloincc.Text = "Chưa chọn nhà cung cấp cần xóa. ";
            }
            else
            {
                DialogResult dr4 = MessageBox.Show("Xóa nhà cung cấp này. Tất cả các thông tin sản phẩm từ Nhà cung cấp này sẻ bị mất vĩnh viễn.\nBạn có chắn chắn không ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr4 == DialogResult.Yes)
                {
                    // Xóa
                    if (nccctr.delDateNCC(txtMaNCC.Text.Trim()))
                        MessageBox.Show("Bạn đã XÓA thông tin NCC thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("XÓA THẤT BẠI : LỖI HỆ THỐNG !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    return;

                Form2_Load(sender, e);
            }
        }

        private void mnLuuNcc_Click(object sender, EventArgs e)
        {
            if(fixNCC())
            {
                ganDuLieuNCC(nccObj);
                if (flagNCC == 0)
                {
                    // TH Thêm mới
                    if (nccctr.addDataNCC(nccObj))
                    {
                        MessageBox.Show("Bạn đã THÊM một NCC mới thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2_Load(sender, e);
                        dis_enNCC(false);
                    }
                    else
                        MessageBox.Show("THÊM THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (nccctr.updDateNCC(nccObj))
                    {
                        MessageBox.Show("Bạn đã CẬP NHẬT thông tin NCC thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2_Load(sender, e);
                        dis_enNCC(false);
                    }
                    else
                        MessageBox.Show("CẬP NHẬT THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            HanCheQuyen();

        }

        private void mnHuyNcc_Click(object sender, EventArgs e)
        {
            clearDataNCC();
            Form2_Load(sender, e);
            dis_enNCC(false);
            HanCheQuyen();
        }

        //  END  KHU VỰC DÀNH CHO TAB NHÀ CUNG CẤP ********************************************************* //

/* ******************************************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB SỰ KIỆN ********************************************************* //

        private void mnThemKm_Click(object sender, EventArgs e)
        {
            thongbaoloikm.Text = "";

            flagKM = 0;
            dis_enKm(true);
            clearDataKm();

            /* Tăng mã tự động*/
            string LastID = Idctr.GetLastID("SUKIEN", "mask"); // bảng, cột được lấy mã cuối
            txtMaKm.Text = TangMaTuDong(LastID, "KM");  // Tiền tố chữ trước mã số
        }

        private void mnSuaKm_Click(object sender, EventArgs e)
        {
            thongbaoloikm.Text = "";
            if (txtMaKm.Text == "" || txtMaKm.Text == null)
            {
                thongbaoloikm.Text = "Chưa chọn khuyến mãi cần sửa. ";
            }
            else
            {
                flagKM = 1;
                bingdingKm();
                dis_enKm(true);
            }
        }

        private void mnXoaKm_Click(object sender, EventArgs e)
        {
            thongbaoloikm.Text = "";
            if (txtMaKm.Text == "" || txtMaKm.Text == null)
            {
                thongbaoloikm.Text = "Chưa chọn khuyến mãi cần xóa. ";
            }
            else
            {
                DialogResult dr5 = MessageBox.Show("Bạn có chắc muốn XÓA thông tin khuyến mãi này ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr5 == DialogResult.Yes)
                {
                    // Xóa
                    if (kmctr.delDateKm(txtMaKm.Text.Trim()))
                        MessageBox.Show("Bạn đã XÓA thông tin khuyến mãi thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("XÓA THẤT BẠI : LỖI HỆ THỐNG !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    return;

                Form2_Load(sender, e);
            }
        }

        private void mnLuuKm_Click(object sender, EventArgs e)
        {
            if(fixKM())
            {
                ganDuLieuKm(kmObj);
                if (flagKM == 0)
                {
                    // TH Thêm mới
                    if (kmctr.addDataKm(kmObj))
                    {
                        MessageBox.Show("Bạn đã THÊM một khuyến mãi mới thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2_Load(sender, e);
                        dis_enKm(false);
                    }
                    else
                        MessageBox.Show("THÊM THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (kmctr.updDateKm(kmObj))
                    {
                        MessageBox.Show("Bạn đã CẬP NHẬT thông tin khuyến mãi thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2_Load(sender, e);
                        dis_enKm(false);
                    }
                    else
                        MessageBox.Show("CẬP NHẬT THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            HanCheQuyen();

        }

        private void mnHuyKm_Click(object sender, EventArgs e)
        {
            clearDataKm();
            Form2_Load(sender, e);
            dis_enKm(false);

            HanCheQuyen();
        }

        //  END  KHU VỰC DÀNH CHO TAB SỰ KIỆN ********************************************************* //

/* ******************************************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB HÀNG HÓA ********************************************************* //

        private void mnThemSp_Click(object sender, EventArgs e)
        {
            thongbaoloisanpham.Text = "";

            flagHH = 0;
            dis_enHH(true);
            loadcontrolHH();
            clearDataHH();

            /* Tăng mã tự động*/
            string LastID = Idctr.GetLastID("HANGHOA", "mahh"); // bảng, cột được lấy mã cuối
            txtMaHH.Text = TangMaTuDong(LastID, "SP");  // Tiền tố chữ trước mã số
        }

        private void mnXoaSp_Click(object sender, EventArgs e)
        {
            thongbaoloisanpham.Text = "";
            if (txtMaHH.Text == "" || txtMaHH.Text == null)
            {
                thongbaoloisanpham.Text = "Chưa chọn sản phẩm cần xóa. ";
            }
            else
            {
                DialogResult dr6 = MessageBox.Show("Xóa SẢN PHẨM này. Thông tin THỐNG KÊ DOANH THU  của sản phẩm này trong toàn bộ thời gian qua sẽ bị mất vĩnh viễn !.\nBạn có chắc chắn muốn xóa không ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr6 == DialogResult.Yes)
                {
                    // Xóa
                    if (hhctr.delDateHH(txtMaHH.Text.Trim()))
                        MessageBox.Show("Bạn đã XÓA thông tin sản phẩm thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("XÓA THẤT BẠI : LỖI HỆ THỐNG !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    return;

                Form2_Load(sender, e);
            }
        }

        private void mnSuaSp_Click(object sender, EventArgs e)
        {
            thongbaoloisanpham.Text = "";
            if (txtMaHH.Text == "" || txtMaHH.Text == null)
            {
                thongbaoloisanpham.Text = "Chưa chọn sản phẩm cần sửa. ";
            }
            else
            {
                flagHH = 1;
                loadcontrolHH();
                bingdingHH();
                dis_enHH(true);
            }
            
        }

        private void mnLuuSp_Click(object sender, EventArgs e)
        {
            if(fixSanPham())
            {
                ganDulieuHHsub();
                ganDuLieuHH(hhObj);

                if (flagHH == 0)
                {
                    // TH Thêm nv mới
                    if (hhctr.addDataHH(hhObj))
                    {
                        loadcontrolHH();
                        MessageBox.Show("Bạn đã THÊM một sản phẩm mới thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2_Load(sender, e);
                        dis_enHH(false);
                    }
                    else
                    {
                        loadcontrolHH();
                        MessageBox.Show("THÊM THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // TH Sửa tt nhân viên
                    if (hhctr.updDateHH(hhObj))
                    {
                        loadcontrolHH();
                        MessageBox.Show("Bạn đã CẬP NHẬT thông tin sản phẩm thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2_Load(sender, e);
                        dis_enHH(false);
                    }
                    else
                    {
                        loadcontrolHH();
                        MessageBox.Show("CẬP NHẬT THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            HanCheQuyen();
        }
            

        private void mnHuySp_Click(object sender, EventArgs e)
        {
            clearDataHH();
            Form2_Load(sender, e);
            dis_enHH(false);

            HanCheQuyen();
        }

        //  END  KHU VỰC DÀNH CHO TAB HÀNG HÓA ********************************************************* //

/* ******************************************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB HÓA ĐƠN ********************************************************* //

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            /*
             * Lưu mới một hóa đơn với mã tự sinh
             */

            /* Tăng mã tự động*/
            string LastID = Idctr.GetLastID("HOADON", "mahd"); // bảng, cột được lấy mã cuối
            txtMaHD.Text = TangMaTuDong(LastID, "HD");  // Tiền tố chữ trước mã số

            ganDulieuHDsub(); //không cần đổi mã thành text - text thành mã khi k có liên kết csdl
            ganDuLieuHD(hdObj);

            if (flagHD == 0)
            {
                // TH Thêm 
                if (hdctr.addDataHD(hdObj))
                {
                    MessageBox.Show("Đã tạo HÓA ĐƠN mới hãy bấm vào GIỎ HÀNG !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //    dtdanhsachcthd.DataBindings.Clear();

                    // txtMaHD.Text = macthd;

                    Form2_Load(sender, e);
                   // bingdingHD();
                    dis_enHD(false);

                }
                else
                {
                    MessageBox.Show("Tạo hóa đơn mới THẤT BẠI !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Form2_Load(sender, e);
                   // bingdingHD();
                    dis_enHD(false);
                }
               
            }


        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            /*
             * Xóa hóa đơn + đồng thời xóa cthd
            */
                DialogResult dr6 = MessageBox.Show("Hóa đơn này sẽ bị xóa ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr6 == DialogResult.Yes)
                {
                    // Xóa
                    if (hdctr.delDateHD(txtMaHD.Text.Trim()))
                        MessageBox.Show("Bạn đã XÓA thông tin hóa đơn thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("XÓA THẤT BẠI : LỖI HỆ THỐNG !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    return;

                Form2_Load(sender, e);            
        }

        private void btnHuyCHTD_Click(object sender, EventArgs e)
        {
            /*
             * Hủy mọi trạng thái của chỉnh sửa CTHD và trở về màn hình hiển thị danh sách hóa đơn
             */
            dtdanhsachcthd.DataBindings.Clear();
            Form2_Load(sender, e);
            dis_enHD(false);
        }

        private void btnXoaSpCTHD_Click(object sender, EventArgs e)
        {
            /*
             * Xóa sản phẩm đã thêm vào chi tiết hóa đơn
             */
            string mahd = txtMaHD.Text;

            int soluong = - int.Parse(txtsoluongspdamua.Text.Trim());
            string mahh = txtMaSpCTHD.Text;




            DialogResult dr7 = MessageBox.Show("Xóa SẢN PHẨM ra khỏi GIỎ HÀNG ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr7 == DialogResult.Yes)
            {
                // Xóa
                if (cthdctr.delDateCTHD(txtMaSpCTHD.Text.Trim()))
                    MessageBox.Show("Bạn đã XÓA thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("XÓA THẤT BẠI !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // cập nhật đã bán
                TonKho_DaBan(mahh, soluong);
                //
                ganTongTienHD(mahd);
            }
            else
                return;

            // Form2_Load(sender, e);
            bingdingCTHD(txtMaHD.Text);
            dis_enCTHD(false);


        }

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            if (fixXuLyHoaDon() == true)
            {
                /*
             *  tạo mới và Lưu sản phẩm đã chọn vào danh sách CTHD với mỗi sản phẩm cùng một mã hóa đơn đã tạo trước đó
             *  mỗi lần thêm phải load lại tổng tiền
             */


                ganDulieuCTHDsub();
                ganDuLieuCTHD(cthdObj);
                gandulieuThongKe(tkObj);


                string mahd = txtMaHD.Text;
                int soluong = int.Parse(txtSoLuongCTHD.Value.ToString());
                string mahh = txtMaSpAdd.Text;


                // insert thống kê
                tkctr.addData(tkObj);



                if (flagCTHD == 0)
                {
                    // TH Thêm sp mới
                    if (cthdctr.addDataCTHD(cthdObj))
                    {
                        MessageBox.Show("Bạn đã THÊM một sản phẩm mới thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        // cập nhật đã bán
                        TonKho_DaBan(mahh, soluong);
                        //

                        ganTongTienHD(mahd);
                        bingdingCTHD(mahd);
                        dis_enCTHD(false);

                    }
                    else
                    {

                        MessageBox.Show("Thêm thất bại, sản phẩm có thể đã tồn tại trong giỏ hàng ", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ganTongTienHD(mahd);
                        bingdingCTHD(mahd);
                        dis_enCTHD(false);
                    }

                }

                //  bingdingHH();
                // dis_enHH(false)
            }
            else
                MessageBox.Show("Kiểm tra lại số lượng mua hoặc mặt hàng đã tồn tại", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtMaHD_Click(object sender, EventArgs e)
        {

        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
           
            //bingding1();
        }

        private void txtTTKhuyenMai_Click(object sender, EventArgs e)
        {

        }

        private void btnGioHangHD_Click(object sender, EventArgs e)
        {
            // hiển thị cthd
            txttonkhosub.Text = "/            Sản phẩm (                )";
            string mahd = txtMaHD.Text;
            dtdanhsachcthd.DataBindings.Clear();

            bingdingCTHD(mahd);
            dis_enCTHD(false);
        }

        private void btnDonateHD_Click(object sender, EventArgs e)
        {

        }

        // END  KHU VỰC DÀNH CHO TAB HÓA ĐƠN ********************************************************* //

        /* ********************************************************************************************************** */

        /* ********************************************************************************************************** */

        // START  KHU VỰC DÀNH CHO TAB THỐNG KÊ ********************************************************* //

        private void button1_Click(object sender, EventArgs e)
        {
           // Form2_Load(sender, e);
            ReloadThongKe(tkObj);
            bingdingThongKe();
            dis_enTKTraCuu(true);
            loadTKTraCuu();

            btnXoaTKSP.Enabled = false;
        }

        private void btnThongKeTheoNgay_Click(object sender, EventArgs e)
        {
            loadTraCuu(); // load sản phẩm thành mã sp
           
            /* hiển thị ngày tháng năm  */
            txtTrongNgayBSL.Text = "Trong ngày : --- ";
            DateTime ngay = new DateTime();
            ngay = DateTime.Parse(txtNgayThongKe.Text.Trim());
            txtDateBangSoLieu.Text = ngay.Day.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Year.ToString() + " ( cho sản phẩm " + txtTenSpPhuChu.Text +" )" ;


            // truyền tham số mhh và soluong
            string mahh = txtChonSanPhamThongKe.Text.Trim();
            string ngayban = txtNgayThongKe.Text.Trim();

            // đổ dữ liệu ra datagridview ( được ẩn đi) databinding vào các txt
            DataTable dt = new DataTable();
            dt = tkctr.SelectOnlyDD(mahh,ngayban);
            tabledulieuthongke.DataSource = dt;

            txtSlTongThu.DataBindings.Clear();
            txtSlTongThu.DataBindings.Add("Text", tabledulieuthongke.DataSource, "tongthu");
            txtSlLoiNhuan.DataBindings.Clear();
            txtSlLoiNhuan.DataBindings.Add("Text", tabledulieuthongke.DataSource, "loinhuan");
            txtSlDaban.DataBindings.Clear();
            txtSlDaban.DataBindings.Add("Text", tabledulieuthongke.DataSource, "soluongban");

            dis_enTKTraCuu(false);

            if(txtSlTongThu.Text.ToString() == "" || txtSlTongThu.Text.ToString() == "0")
            { txtSlSoSanPhamBanRa.Text = "✘ Trong ngày " + ngay.Day + "/" + ngay.Month + "/" + ngay.Year + " sản phẩm này không được bán ra ! ✘"; }

            
        }

        private void btnThongKeTheoThang_Click(object sender, EventArgs e)
        {
            loadTraCuu(); // load sản phẩm thành mã sp
            
            /* hiển thị ngày tháng năm  */
            txtTrongNgayBSL.Text = "Trong tháng : --- ";
            DateTime ngay = new DateTime();
            ngay = DateTime.Parse(txtNgayThongKe.Text.Trim());
            txtDateBangSoLieu.Text = ngay.Month.ToString() + "/" + ngay.Year.ToString() + " ( cho sản phẩm " + txtTenSpPhuChu.Text + " )";


            // truyền tham số mhh và soluong
            string mahh = txtChonSanPhamThongKe.Text.Trim();
            string ngayban = txtNgayThongKe.Text.Trim();

            // đổ dữ liệu ra datagridview ( được ẩn đi) databinding vào các txt
            DataTable dt = new DataTable();
            dt = tkctr.SelectOnlyMM(mahh, ngayban);
            tabledulieuthongke.DataSource = dt;

            txtSlTongThu.DataBindings.Clear();
            txtSlTongThu.DataBindings.Add("Text", tabledulieuthongke.DataSource, "tongthu");
            txtSlLoiNhuan.DataBindings.Clear();
            txtSlLoiNhuan.DataBindings.Add("Text", tabledulieuthongke.DataSource, "loinhuan");
            txtSlDaban.DataBindings.Clear();
            txtSlDaban.DataBindings.Add("Text", tabledulieuthongke.DataSource, "soluongban");

            dis_enTKTraCuu(false);

            if (txtSlTongThu.Text.ToString() == "" || txtSlTongThu.Text.ToString() == "0")
            { txtSlSoSanPhamBanRa.Text = "✘ Trong tháng " + ngay.Month +"/"+ngay.Year+ " sản phẩm này không được bán ra ! ✘"; }

        }

        private void btnThongKeTheoNam_Click(object sender, EventArgs e)
        {
            loadTraCuu(); // load sản phẩm thành mã sp

            /* hiển thị ngày tháng năm  */
            txtTrongNgayBSL.Text = "Trong năm : --- ";
            DateTime ngay = new DateTime();
            ngay = DateTime.Parse(txtNgayThongKe.Text.Trim());
            txtDateBangSoLieu.Text = ngay.Year.ToString() + " ( cho sản phẩm " + txtTenSpPhuChu.Text + " )";


            // truyền tham số mhh và soluong
            string mahh = txtChonSanPhamThongKe.Text.Trim();
            string ngayban = txtNgayThongKe.Text.Trim();

            // đổ dữ liệu ra datagridview ( được ẩn đi) databinding vào các txt
            DataTable dt = new DataTable();
            dt = tkctr.SelectOnlyYYYY(mahh, ngayban);
            tabledulieuthongke.DataSource = dt;

            txtSlTongThu.DataBindings.Clear();
            txtSlTongThu.DataBindings.Add("Text", tabledulieuthongke.DataSource, "tongthu");
            txtSlLoiNhuan.DataBindings.Clear();
            txtSlLoiNhuan.DataBindings.Add("Text", tabledulieuthongke.DataSource, "loinhuan");
            txtSlDaban.DataBindings.Clear();
            txtSlDaban.DataBindings.Add("Text", tabledulieuthongke.DataSource, "soluongban");

            dis_enTKTraCuu(false);

            if (txtSlTongThu.Text.ToString() == "" || txtSlTongThu.Text.ToString() == "0")
            { txtSlSoSanPhamBanRa.Text = "✘ Trong năm " + ngay.Year + " sản phẩm này không được bán ra ! ✘"; }

        }

        private void btnAllSpNgay_Click(object sender, EventArgs e)
        {
            loadTraCuu(); // load sản phẩm thành mã sp

            /* hiển thị ngày tháng năm  */
            txtTrongNgayBSL.Text = "Trong ngày : --- ";
            DateTime ngay = new DateTime();
            ngay = DateTime.Parse(txtNgayThongKe.Text.Trim());
            txtDateBangSoLieu.Text = ngay.Day.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Year.ToString() + " ( cho tất cả các sản phẩm )";


            // truyền tham số mhh và soluong
            string mahh = txtChonSanPhamThongKe.Text.Trim();
            string ngayban = txtNgayThongKe.Text.Trim();

            // đổ dữ liệu ra datagridview ( được ẩn đi) databinding vào các txt
            DataTable dt = new DataTable();
            dt = tkctr.SelectAllDD(mahh, ngayban);
            tabledulieuthongke.DataSource = dt;

            txtSlTongThu.DataBindings.Clear();
            txtSlTongThu.DataBindings.Add("Text", tabledulieuthongke.DataSource, "tongthu");
            txtSlLoiNhuan.DataBindings.Clear();
            txtSlLoiNhuan.DataBindings.Add("Text", tabledulieuthongke.DataSource, "loinhuan");
            txtSlDaban.DataBindings.Clear();
            txtSlDaban.DataBindings.Add("Text", tabledulieuthongke.DataSource, "soluongban");

            dis_enTKTraCuu(false);

            if (txtSlTongThu.Text.ToString() == "" || txtSlTongThu.Text.ToString() == "0")
            { txtSlSoSanPhamBanRa.Text = "✘ Trong ngày " + ngay.Day +"/"+ngay.Month+"/" + ngay.Year + " không có sản phẩm nào được bán ra ! ✘"; }

        }

        private void btnAllSpThang_Click(object sender, EventArgs e)
        {
            loadTraCuu(); // load sản phẩm thành mã sp

            /* hiển thị ngày tháng năm  */
            txtTrongNgayBSL.Text = "Trong tháng : --- ";
            DateTime ngay = new DateTime();
            ngay = DateTime.Parse(txtNgayThongKe.Text.Trim());
            txtDateBangSoLieu.Text = ngay.Month.ToString() + "/" + ngay.Year.ToString() + " ( cho tất cả các sản phẩm )";


            // truyền tham số mhh và soluong
            string mahh = txtChonSanPhamThongKe.Text.Trim();
            string ngayban = txtNgayThongKe.Text.Trim();

            // đổ dữ liệu ra datagridview ( được ẩn đi) databinding vào các txt
            DataTable dt = new DataTable();
            dt = tkctr.SelectAllMM(mahh, ngayban);
            tabledulieuthongke.DataSource = dt;

            txtSlTongThu.DataBindings.Clear();
            txtSlTongThu.DataBindings.Add("Text", tabledulieuthongke.DataSource, "tongthu");
            txtSlLoiNhuan.DataBindings.Clear();
            txtSlLoiNhuan.DataBindings.Add("Text", tabledulieuthongke.DataSource, "loinhuan");
            txtSlDaban.DataBindings.Clear();
            txtSlDaban.DataBindings.Add("Text", tabledulieuthongke.DataSource, "soluongban");

            dis_enTKTraCuu(false);

            if (txtSlTongThu.Text.ToString() == "" || txtSlTongThu.Text.ToString() == "0")
            { txtSlSoSanPhamBanRa.Text = "✘ Trong tháng " + ngay.Month + "/" + ngay.Year + " không có sản phẩm nào được bán ra ! ✘"; }

        }

        private void btnAllSpNam_Click(object sender, EventArgs e)
        {
            loadTraCuu(); // load sản phẩm thành mã sp

            /* hiển thị ngày tháng năm  */
            txtTrongNgayBSL.Text = "Trong năm : --- ";
            DateTime ngay = new DateTime();
            ngay = DateTime.Parse(txtNgayThongKe.Text.Trim());
            txtDateBangSoLieu.Text = ngay.Year.ToString() + " ( cho tất cả các sản phẩm )";


            // truyền tham số mhh và soluong
            string mahh = txtChonSanPhamThongKe.Text.Trim();
            string ngayban = txtNgayThongKe.Text.Trim();

            // đổ dữ liệu ra datagridview ( được ẩn đi) databinding vào các txt
            DataTable dt = new DataTable();
            dt = tkctr.SelectAllYYYY(mahh, ngayban);
            tabledulieuthongke.DataSource = dt;

            txtSlTongThu.DataBindings.Clear();
            txtSlTongThu.DataBindings.Add("Text", tabledulieuthongke.DataSource, "tongthu");
            txtSlLoiNhuan.DataBindings.Clear();
            txtSlLoiNhuan.DataBindings.Add("Text", tabledulieuthongke.DataSource, "loinhuan");
            txtSlDaban.DataBindings.Clear();
            txtSlDaban.DataBindings.Add("Text", tabledulieuthongke.DataSource, "soluongban");

            dis_enTKTraCuu(false);

            if (txtSlTongThu.Text.ToString() == "" || txtSlTongThu.Text.ToString() == "0")
            { txtSlSoSanPhamBanRa.Text = "✘ Trong năm " + ngay.Year + " không có sản phẩm nào được bán ra ! ✘"; }

        }

        private void btnXoaTKSP_Click(object sender, EventArgs e)
        {
            loadTraCuu();

            DialogResult dr = MessageBox.Show("Xóa tất cả các thống kê về sản phẩm ", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Xóa
                if (tkctr.delDate(txtChonSanPhamThongKe.Text.Trim()))
                    MessageBox.Show("Xóa thành công ! ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("XÓA THẤT BẠI ", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                return;

            Form2_Load(sender, e);
            dis_enTKTraCuu(false);
        }

        // END  KHU VỰC DÀNH CHO TAB THỐNG KÊ ********************************************************* //

        /* ********************************************************************************************************** */
        // START  KHU VỰC DÀNH CHO TAB ĐỔI mk ADMIN ********************************************************* //

        QuanLyObj thdObj = new QuanLyObj();
        QuanLyCtrl thdcrt = new QuanLyCtrl();
        void ganDulieuQL1(QuanLyObj nvObj)
        {
            nvObj.MatKhau = toMD5(txtMatKhauCu.Text);// txtMatKhauCu.Text.Trim();
        }

        private void btnLuuMatKhau_Click(object sender, EventArgs e)
        {
            txtThongBaoDoiMK.Text = "";

            // kiểm tra kết nối internet
            txtNoteInternet.Text = "";
            if (InternetConnection.IsConnectedToInternet())
            {
                txtNoteInternet.ForeColor = System.Drawing.Color.Green;
                txtNoteInternet.Text = " Đã kết nối internet, bạn có thể đổi mật khẩu !.";
            }
            else
            {
                txtNoteInternet.ForeColor = System.Drawing.Color.Red;
                txtNoteInternet.Text = " Đã mất kết nối internet, bạn không thể đổi mật khẩu !.";
            }
            // end kiểm tra kết nối internet

            if (txtMatKhauCu.Text == "") { txtThongBaoDoiMK.Text = "✘ Vui lòng nhập mật khẩu cũ ✘"; }
            else if (txtMatKhauMoi.Text == "") { txtThongBaoDoiMK.Text = "✘ Vui lòng nhập mật khẩu mới ✘"; }
            else if (txtmailsaoluu.Text == ""){ txtThongBaoDoiMK.Text = "✘ Vui lòng nhập Email ✘"; }
            else if (txtNhapLaiMatKhau.Text != txtMatKhauMoi.Text) { txtThongBaoDoiMK.Text = "✘ Mật khẩu mới không trùng nhau ✘"; }
            else
            {
                ganDulieuQL1(qlObj); // mat khau củ
                if (thdcrt.check1(qlObj))
                {
                    ganDulieuQL(thdObj);
                    if (thdcrt.updDate(thdObj))
                    {
                        //  gửi mật khẩu mới vào mail
                        txtThongBaoDoiMK.Text = "Đang kiểm tra mail !.";
                        SendMailMob mailMob = new SendMailMob();
                        if (mailMob.SendMail(txtNhapLaiMatKhau.Text, txtmailsaoluu.Text) == true)
                        {
                            txtThongBaoDoiMK.Text = "";
                            DialogResult m = MessageBox.Show("✓ Đã cập nhật mật khẩu mới thành công! ✓", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (m == DialogResult.Yes)
                            {
                                this.Close();
                            }
                            else Form2_Load(sender, e);
                        }
                        else txtThongBaoDoiMK.Text = "✘ Không có mạng internet✘";

                    }
                    else txtThongBaoDoiMK.Text = "✘Cập nhật mật khẩu thất bại! Vui lòng kiểm tra lại✘";
                }
                else
                {
                    txtThongBaoDoiMK.Text = "✘Bạn đã nhập mật khẩu cũ sai! ✘";
                }

            }
        }

        private void btnHuyMatKhau_Click(object sender, EventArgs e)
        {
            Form2_Load(sender, e);
        }

        

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            hidepassmoi1.Visible = false;
            showpassmoi1.Visible = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            hidepasscu.Visible = false;
            showpasscu.Visible = true;
            txtMatKhauCu.UseSystemPasswordChar = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            hidepassmoi2.Visible = false;
            showpassmoi2.Visible = true;
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
        }

        private void showpasscu_Click(object sender, EventArgs e)
        {
            hidepasscu.Visible = true;
            showpasscu.Visible = false;
            txtMatKhauCu.UseSystemPasswordChar = false;
        }

        private void showpassmoi1_Click(object sender, EventArgs e)
        {
            hidepassmoi1.Visible = true;
            showpassmoi1.Visible = false;
            txtMatKhauMoi.UseSystemPasswordChar = false;
        }

        private void showpassmoi2_Click(object sender, EventArgs e)
        {
            hidepassmoi2.Visible = true;
            showpassmoi2.Visible = false;
            txtNhapLaiMatKhau.UseSystemPasswordChar = false;
        }

        // END  KHU VỰC DÀNH CHO TAB ĐỔI mk ADMIN ********************************************************* //

        /* ********************************************************************************************************** */
        // START  KHU VỰC DÀNH CHO TAB QUẢN LÝ USER ********************************************************* //

        private void mndangkymoi_Click(object sender, EventArgs e)
        {
           // thongbaoloiadmin.Text = "";

            flagPQ = 0;
            flagAdmin = 0;
            dtdanhsachuser.Enabled = false;
   


            if (rbntTKNhanVien.Checked)
            {
                loadUser();
                dkmoinhanvien(true);
                
            }
            else if (rbntTKAdmin.Checked)
            {
                loadAdmin();
                dkmoiAdmin(true);
                
            }

            // kiểm tra kết nối internet
            if (InternetConnection.IsConnectedToInternet())
            {
                    thongbaoloiadmin.ForeColor = System.Drawing.Color.Green;
                    thongbaoloiadmin.Text = " Đã kết nối internet, có thể sao lưu mật khẩu !.";
                
            }
            else
            {
                    thongbaoloiadmin.ForeColor = System.Drawing.Color.Red;
                    thongbaoloiadmin.Text = " Đã mất kết nối internet, không thể sao lưu mật khẩu !.";
            }
        }

        private void mndoimatkhau_Click(object sender, EventArgs e)
        {
            txtNewPass.Text = "";
            txtReNewPass.Text = "";
            
            if (txtAddTaiKhoan.Text == "" || txtAddTaiKhoan.Text == null)
            {
                thongbaoloiadmin.Text = "Chưa chọn tài khoản cần đổi mật khẩu. ";
            }
            else
            {
                flagPQ = 1;
                flagAdmin = 1;
                doimknhanvien(true);
                dtdanhsachuser.Enabled = false;

                // kiểm tra kết nối internet
                if (InternetConnection.IsConnectedToInternet())
                {
                    thongbaoloiadmin.ForeColor = System.Drawing.Color.Green;
                    thongbaoloiadmin.Text = " Đã kết nối internet, có thể sao lưu mật khẩu !.";
                }
                else
                {
                    thongbaoloiadmin.ForeColor = System.Drawing.Color.Red;
                    thongbaoloiadmin.Text = " Chưa kết nối internet, không thể sao lưu mật khẩu !.";
                }
            }


        }

        private void mnphanquyen_Click(object sender, EventArgs e)
        {
            thongbaoloiadmin.Text = "";
            if (txtAddTaiKhoan.Text == "" || txtAddTaiKhoan.Text == null)
            {
                thongbaoloiadmin.ForeColor = System.Drawing.Color.Red;
                thongbaoloiadmin.Text = "Chưa chọn tài khoản cần phân quyền lại. ";
            }
            else
            {
                flagPQ = 1;
                flagAdmin = 1;

                dtdanhsachuser.Enabled = false;

                if (rbntTKNhanVien.Checked)
                {
                    phanquyennhanvien(true);
                }
                else if (rbntTKAdmin.Checked)
                {
                    phanquyenadmin(true);
                }
            }
        }

        private void LuuTKmoi_Click(object sender, EventArgs e)
        {
                       

            if (rbntTKNhanVien.Checked) // nhân viên
            {
                if (fixphanquyentk())
                {
                    
                    // lưu tài khoản nhân viên
                    gandulieuthemmoiuser();

                    if (flagPQ == 0) //  Thêm mới tk
                    {

                        if (pqctr.AddDataPQ(pqObj))
                        {

                            mailsaoluumatkhau(txtReNewPass.Text, emailsaoluunhanvienmoi.Text, txtAddTaiKhoan.Text, thongbaoloiadmin.Text);
                            
                            DialogResult m = MessageBox.Show("Bạn đã tạo tài khoản thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (m == DialogResult.OK)
                            {
                                thongbaoloiadmin.Text = "";
                                dis_enNhanVien(true);
                                loadUser();
                                dtdanhsachuser.DataBindings.Clear();
                                bingdingPhanQuyen(); // load bảng dữ liệu
                                grLoaiTaiKhoan.Enabled = true;
                            }
                            else Form2_Load(sender, e);

                        }
                        else
                        {
                            MessageBox.Show("Tạo tài khoản thất bại !. \nCó thể tài khoản này đã tồn tại hoặc nhân viên này đã có tài khoản rồi !.\n Vui lòng kiểm tra lại!.", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNameUser.DisplayMember = "tennv";
                            txtNameUser.ValueMember = "manv";
                            thongbaoloiadmin.Text = "";
                        }

                        
                    }
                    else // sửa tài khoản
                    {
                        // Sửa tài khoản nhân viên
                        if (pqctr.UpdDataPQ(pqObj))
                        {
                            //  gửi mật khẩu mới vào mail
                            mailsaoluumatkhau(txtReNewPass.Text, emailsaoluunhanvienmoi.Text, txtAddTaiKhoan.Text, thongbaoloiadmin.Text);

                            
                            DialogResult m = MessageBox.Show("Bạn đã thay đổi thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (m == DialogResult.OK)
                            {
                                thongbaoloiadmin.Text = "";
                                dis_enNhanVien(true);
                                loadUser();
                                dtdanhsachuser.DataBindings.Clear();
                                bingdingPhanQuyen(); // load bảng dữ liệu
                                grLoaiTaiKhoan.Enabled = true;
                            }
                            else Form2_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("CẬP NHẬT THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNameUser.DisplayMember = "tennv";
                            txtNameUser.ValueMember = "manv";
                            thongbaoloiadmin.Text = "";
                        }
                    }
                }
            }
            else if (rbntTKAdmin.Checked)  // admin
            {
                thongbaoloiadmin.Text = "";
                // lưu tài khoản admin
                gandulieuthemmoiadmin();

                if (flagAdmin == 0)
                {
                    //  Thêm tài khoản admin
                    if (qlctr.addDataQL(qlObj))
                    {
                        MessageBox.Show("Bạn đã THÊM thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dis_enAdmin(true);
                        loadAdmin();
                        dtdanhsachuser.DataBindings.Clear();
                        bingdingAdmin(); // load bảng dữ liệu
                        grLoaiTaiKhoan.Enabled = true;

                    }
                    else
                        MessageBox.Show("CHỈ TỒN TẠI 1 TÀI KHOẢN ADMIN DUY NHẤT !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Sửa tài khoản admin
                    if (qlctr.updDateTenAdmin(qlObj))
                    {
                        MessageBox.Show("Bạn đã CẬP NHẬT thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dis_enAdmin(true);
                        loadAdmin();
                        dtdanhsachuser.DataBindings.Clear();
                        bingdingAdmin(); // load bảng dữ liệu
                        grLoaiTaiKhoan.Enabled = true;
                    }
                    else
                        MessageBox.Show("CẬP NHẬT THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
            dtdanhsachuser.Enabled = true;
        }

        private void HuyTKmoi_Click(object sender, EventArgs e)
        {
            thongbaoloiadmin.Text = "";

            Form2_Load(sender, e);
            if (rbntTKNhanVien.Checked)
            {
                dis_enNhanVien(true);
                loadUser();
                dtdanhsachuser.DataBindings.Clear();
                bingdingPhanQuyen(); // load bảng dữ liệu
            }
            else if (rbntTKAdmin.Checked)
            {
                dis_enAdmin(true);
                loadAdmin();
                dtdanhsachuser.DataBindings.Clear();
                bingdingAdmin(); // load bảng dữ liệu
            }

            dtdanhsachuser.Enabled = true;
            grLoaiTaiKhoan.Enabled = true;
        }

        private void rbntTKNhanVien_CheckedChanged(object sender, EventArgs e)
        {
                dis_enNhanVien(true);
                loadUser();
                dtdanhsachuser.DataBindings.Clear();
                bingdingPhanQuyen(); // load bảng dữ liệu 

        }

        private void rbntTKAdmin_CheckedChanged(object sender, EventArgs e)
        {
                dis_enAdmin(true);
                loadAdmin();
                dtdanhsachuser.DataBindings.Clear();
                bingdingAdmin(); // load bảng dữ liệu


        }

        // END  KHU VỰC DÀNH CHO TAB QUẢN LÝ USER ********************************************************* //

        /* ********************************************************************************************************** */
        // START  KHU VỰC DÀNH CHO TAB FIX LỖI ********************************************************* //

        private bool fixNhanVien()
        {
            thongbaoloinhanvien.Text = "";
            DateTime now = DateTime.Now;
            int s = dtNgaySinhNv.Value.Year;
            // fix lỗi đễ trống các trường bắt buộc txt
           if (txtTenNv.Text == "")
            {
                thongbaoloinhanvien.Text = "✘ Không được bỏ trống Tên nhân viên ✘"; return false;
            }
            else if (txtGioiTinhNv.Text == null)
            {
                thongbaoloinhanvien.Text = "✘ Chọn sai giới tính ✘"; return false;
            }
            else if ((now.Year - s) < 18)
            {
                thongbaoloinhanvien.Text = "✘ Người lao động phải trên 18 tuổi ✘"; return false;
            }
            else if(txtDiaChiNv.Text=="")
            {
                thongbaoloinhanvien.Text = "✘ Địa chỉ không được bỏ trống ✘"; return false;
            }
            else if (txtSdtNv.Text == "")
            {
                thongbaoloinhanvien.Text = "✘ Số điện thoại không được bỏ trống ✘"; return false;
            }

            else if (txtCmndNv.Text == "")
            {
                thongbaoloinhanvien.Text = "✘ Không được bỏ trống CMND ✘"; return false;
            }
            
            
            else
            {
                try
                {
                    String mail = txtEmailNv.Text;
                    var test = new MailAddress(mail);
                    thongbaoloinhanvien.Text = "";
                    return true;
                }
                catch (FormatException)
                {
                    thongbaoloinhanvien.Text = "✘ Vui lòng kiểm tra lại Email ✘";
                    return false;
                }
                catch (ArgumentException)
                {
                    thongbaoloinhanvien.Text = "✘ Vui lòng kiểm tra lại Email✘";
                    return false;
                }
            }
            // fix lỗi sai cấu trúc email
            // fix lỗi ngày tháng năm bắt buộc +18 trở lên
        }

        private bool fixSanPham()
        {
            thongbaoloiloaisanpham.Text = "";

            if (txtTenHH.Text == "")
            {
                thongbaoloisanpham.Text = "✘ Không bỏ trống tên sản phẩm ✘"; return false;
            }
            else if (txtDonGiaHH.Text == "")
            {
                thongbaoloisanpham.Text = "✘ Không bỏ trống trống đơn giá ✘"; return false;
            }

            else if (txtTonKhoHH.Text == "")
            {
                thongbaoloisanpham.Text = "✘Không được bỏ trống Ton Kho ✘";

                return false;
            }
            else if (txtDonViHH.Text == "")
            {
                thongbaoloisanpham.Text = "✘ Không bỏ trống đơn vị tính sản phẩm ✘"; return false;
            }
            else if (txtLoaiHangHH.SelectedItem == null)
            {
                thongbaoloisanpham.Text = "✘Không được bỏ trống loại hàng hóa ✘"; return false;
            }
            else if (txtNhaCungCapHH.SelectedItem == null)
            {
                thongbaoloisanpham.Text = "✘Không được bỏ trống nhà cung cấp ✘"; return false;
            }
            
            
            else if (txtKhuyenMaiHH.SelectedItem == null)
            {
                thongbaoloisanpham.Text = "✘Không được bỏ trống khuyến mãi ✘"; return false;
            }
            
            
            else if (txtGiaNhapSp.Text == "")
            {
                thongbaoloisanpham.Text = "✘Không được bỏ trống giá nhập của sản phẩm ✘";

                return false;
            }
            else  return true;
        }

        private bool fixNCC()
        {
            thongbaoloincc.Text = "";
            if (txtMaNCC.Text == "")
            {
                thongbaoloincc.Text = "✘ Không được bỏ trống mã nhà cung cấp ✘ "; return false;
            }
            else if (txtTenNCC.Text == "")
            {
                thongbaoloincc.Text = "✘ Không được bỏ trống tên nhà cung cấp ✘ "; return false;
            }
            else if (txtDiaChiNCC.Text == "")
            {
                thongbaoloincc.Text = "✘ Không được bỏ trống địa chỉ nhà cung cấp ✘"; return false;
            }
            else if (txtSoDtNCC.Text == "")
            {
                thongbaoloincc.Text = "✘ Không được bỏ trống số điện thoại nhà cung cấp ✘"; return false;
            }
            
            
            else return true;
        }

        private bool fixKM()
        {
            thongbaoloikm.Text = "";
            if (txtMaKm.Text == "")
            {
                thongbaoloikm.Text = "✘Không được bỏ trống mã khuyến mãi ✘"; return false;
            }
            else if (txtTenKm.Text == "")
            {
                thongbaoloikm.Text = "✘Không được bỏ trống tên khuyến mãi ✘"; return false;
            }
            else if (txtGiamKm.Text == "")
            {
                thongbaoloikm.Text = "✘Không được bỏ trống % giảm ✘"; return false;
            }
            
            else if (txtNoiDungKm.Text == "")
            {
                thongbaoloikm.Text = "✘Không được bỏ trống nội dung khuyến mãi ✘"; return false;
            }
            else return true;
        }

        private bool fixKhachHang()
        {
            thongbaoloikhachhang.Text = "";
            if (txtMaKhachHang.Text == "")
            {
                thongbaoloikhachhang.Text = "✘ Không được bỏ trống mã khách hàng ✘"; return false;
            }
            else if (txtTenKhachHang.Text == "")
            {
                thongbaoloikhachhang.Text = "✘ Không được bỏ trống tên khách hàng ✘"; return false;
            }
            else if (txtGioiTinhKhachHang.Text == null)
            {
                thongbaoloikhachhang.Text = "✘ Không được bỏ trống giới tính ✘"; return false;
            }
            else if (txtDiaChiKhachHang.Text == "")
            {
                thongbaoloikhachhang.Text = "✘ Không được bỏ trống địa chỉ ✘"; return false;
            }
            
            else if (txtSDTKhachHang.Text == "")
            {
                thongbaoloikhachhang.Text = "✘ Không được bỏ trống số điện thoại ✘"; return false;
            }
            
            else return true;
        }

        private bool fixLoaiSP()
        {
            thongbaoloiloaisanpham.Text = "";
            if (txtMaLoaiSanPham.Text == "")
            {
                thongbaoloiloaisanpham.Text = "✘ Không được bỏ trống mã loại ✘"; return false;
            }
            else if (txtTenLoaiSanPham.Text == "")
            {
                thongbaoloiloaisanpham.Text = "✘ Không được bỏ trống tên loại ✘"; return false;
            }
            else return true;
        }

        private bool fixXuLyHoaDon() //  
        {

            lbloiBH.Text = "";

            String soluongmua = txtSoLuongCTHD.Value.ToString();
            String tonkho = txttonkho.Text.Trim();

            int sl = int.Parse(soluongmua);

            int result = 0;
            if (txtSanPhamHD.SelectedItem == null)
            {
                lbloiBH.Text = "Vui lòng chọn sản phẩm";
                return false;
            }
            else if (txtSoLuongCTHD.Value == null || txtSoLuongCTHD.Value==0)
            { lbloiBH.Text = "Số lượng không hợp lệ.";
                return false;
            }
            else if (int.TryParse(txttonkho.Text, out result))
            {
                if (result == 0)
                {
                    lbloiBH.Text = "Sản phẩm đã bán hết";
                    return false;
                }
                else if (sl > result)
                {
                    lbloiBH.Text = "Vượt quá số lượng còn lại";
                    return false;
                }
                else if (sl <= 0)
                {
                    lbloiBH.Text = "Số lượng không thể nhỏ hơn 1.";
                    return false;
                }
                else
                {
                    lbloiBH.Text = "";
                    return true;
                }
            }
            else
                return false;
            // kiểm tra nếu loại sản phẩm tồn kho nhỏ hơn số lượng bán ra thì thông báo lổi ra messagebox
            // thêm hiển thị số lượng còn lại
        }
        private bool fixphanquyentk()
        {
            thongbaoloiadmin.ForeColor = System.Drawing.Color.Red;

            if (txtAddTaiKhoan.Text == "")
            {
                thongbaoloiadmin.Text = "✘ Không được bỏ trống tên tài khoản ✘"; return false;
            }
            else if (txtNewPass.Text == "")
            {
                thongbaoloiadmin.Text = "✘ Bạn chưa nhập mật khẩu ✘"; return false;
            }
            else if (txtReNewPass.Text == "")
            {
                thongbaoloiadmin.Text = "✘ Vui lòng nhập lại mật khẩu ✘"; return false;
            }
            else if (txtNewPass.Text != txtReNewPass.Text)
            {
                thongbaoloiadmin.Text = "✘ Mật khẩu không trùng nhau✘"; return false;
            }
            else if (emailsaoluunhanvienmoi.Text == "")
            {
                thongbaoloiadmin.Text = "✘ Chưa nhập mail lưu mật khẩu✘"; return false;
            }
            else if (txtNameUser.SelectedItem == null)
            {
                thongbaoloiadmin.Text = "✘ Chưa nhập tên nhân viên ✘"; return false;
            }
            else if (txtAddPhanQuyen.SelectedItem == null)
            {
                thongbaoloiadmin.Text = "✘ Vui lòng chọn phân quyền ✘"; return false;
            }

            else
            {
                try
                {
                    String mail = emailsaoluunhanvienmoi.Text;
                    var test = new MailAddress(mail);
                    thongbaoloinhanvien.Text = "";
                    return true;
                }
                catch (FormatException)
                {
                    thongbaoloiadmin.Text = "✘ Vui lòng kiểm tra lại Email ✘";
                    return false;
                }
                catch (ArgumentException)
                {
                    thongbaoloiadmin.Text = "✘ Vui lòng kiểm tra lại Email✘";
                    return false;
                }
            }

        }

        private void groupBox19_Enter(object sender, EventArgs e)
        {

        }


        private void txtSoLuongCTHD_ValueChanged(object sender, EventArgs e)
        {
            lbloiBH.Text = "";

            String soluongmua = txtSoLuongCTHD.Value.ToString();
            String tonkho = txttonkho.Text.Trim();

            int sl = int.Parse(soluongmua);

            int result = 0;
            if (int.TryParse(txttonkho.Text, out result))
                if(result==0)
                {
                    lbloiBH.Text = "Sản phẩm đã bán hết";
                }
                else if (sl > result)
                {
                    lbloiBH.Text = "Vượt quá số lượng còn lại.";
 
                }
                else if (sl <= 0)
                {
                    lbloiBH.Text = "Số lượng không thể nhỏ hơn 1.";
                }
                else
                {
                    lbloiBH.Text = "";
   
                }
 
        }

        private void txtSanPhamHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbloiBH.Text = "";
        }


        // END  KHU VỰC DÀNH CHO TAB FIX LỖI ********************************************************* //

        /* ********************************************************************************************************** */


        // START  KHU VỰC DÀNH CHO TĂNG MÃ TỰ ĐỘNG ********************************************************* //

        public string TangMaTuDong(string lastID, string prefixID) // lastID (vd: NV002) , prefixID tiền tố (vd: "NV")
        {

            string zeroNumber = "";
            int nextID;


            if (lastID == "" || lastID == null)
                {
                    nextID = 1;  // nếu chưa có dữ liệu khởi tạo mã tiền tố + 001
                    int lengthNumerID = 6 - nextID.ToString().Length - prefixID.Length;// lastID.Length - prefixID.Length;                  
                    for (int i = 0; i <= lengthNumerID; i++)
                            {
                                if (nextID < Math.Pow(10, i))
                                {
                                    for (int j = 1; j <= lengthNumerID - i; i++)
                                    {
                                        zeroNumber += "0"; // thêm số 0 trước hậu tốs
                                    }
                                    return prefixID + zeroNumber + nextID.ToString();
                                }
                            }
                 }
            else
            {
                string sotam = lastID.Substring(prefixID.Length, 5 - prefixID.Length); // NV002 : remove(2,3) = 002
                nextID = int.Parse(sotam.ToString()) + 1;

                int lengthNumerID = 6 - nextID.ToString().Length - prefixID.Length;// lastID.Length - prefixID.Length;                  
                for (int i = 0; i <= lengthNumerID; i++)
                {
                    if (nextID < Math.Pow(10, i))
                    {
                        for (int j = 1; j <= lengthNumerID - i; i++)
                        {
                            zeroNumber += "0"; // thêm số 0 trước hậu tốs
                        }
                        return prefixID + zeroNumber + nextID.ToString();
                    }
                }
            }
            return prefixID + zeroNumber + nextID.ToString();
            
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            ReloadThongKe(tkObj);
        }


        // END  KHU VỰC DÀNH CHO TĂNG MÃ TỰ ĐỘNG ********************************************************* //

        /* ********************************************************************************************************** */

        // START  KHU VỰC DÀNH MÃ HÓA password ********************************************************* //

        public string toMD5(string input)
        {
            string output="";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(input);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                output += b.ToString("X2");
            }

            return output;
        }


        // Sao Lưu mật khẩu khi tạo mới hoặc đổi mật khẩu cho tài khoản nhân viên
        
        private void checksaoluu_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void mailsaoluumatkhau(string matkhau, string diachimail, string tentaikhoan, string thongbaoloi)
        {
            if (checksaoluu.Checked==true)
            {
                thongbaoloi = "Đang kiểm tra Eamil !.";
                SendMailMob mailMob = new SendMailMob();
                
                if (mailMob.SendMailTK(matkhau, diachimail, tentaikhoan) == true)
                {
                    thongbaoloi = "Đã gửi mật khẩu đến email : "+diachimail;
                }
                else thongbaoloi = "Mật khẩu chưa được gửi đến email !.";

            }
            else { thongbaoloi = "Mật khẩu không được gửi đến Email !."; }
            
        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        // END  KHU VỰC DÀNH MÃ HÓA password ********************************************************* //

        /* ********************************************************************************************************** */



    }
}
