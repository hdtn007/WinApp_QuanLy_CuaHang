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
using QLBanHang.Control;
using QLBanHang.Object;
using QLBanHang.Model;

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
            //**************************************************************
            DataTable dtNhanVien = new DataTable();
            dtNhanVien = nvctr.getData();
            dtDanhSachNhanVien.DataSource = dtNhanVien; // dtDanhSachNhanVien la datagidview 



            DataTable dtKhachHang = new DataTable();
            dtKhachHang = khctr.getDataKH();
            dtDanhSachKhachHang.DataSource = dtKhachHang;



            DataTable dtLoaiHH = new DataTable();
            dtLoaiHH = lhhctr.getDataLHH();
            dtDanhSachLoaiSanPham.DataSource = dtLoaiHH;



            DataTable dtNCC = new DataTable();
            dtNCC = nccctr.getDataNCC();
            dtDanhSachNhaCungCap.DataSource = dtNCC;



            DataTable dtkhuyenmai = new DataTable();
            dtkhuyenmai = kmctr.getDataKm();
            dtDanhSachKhuyenmai.DataSource = dtkhuyenmai;


            DataTable dtHangHoa = new DataTable();
            dtHangHoa = hhctr.getDataHH();
            dtDanhSachHangHoa.DataSource = dtHangHoa;


            // DataTable dtHoaDon = new DataTable();
            //  dtHoaDon = hdctr.getDataHD();
            //  dtdanhsachcthd.DataSource = dtHoaDon;

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
            // bingdingThongKe();
            loadTKTraCuu();
            btnXoaTKSP.Enabled = false;

            // load quanly
            loadQuanLy();
            LoadShowEye(true);


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

        }
        //**************************************************************//*****************************************************************************************************************************************************************


            int LoiNhap ( int e) // e= 0 (không lỗi) ; e = ! 0 (lỗi)
        {

            return e;
        }




        //**************************************************************//*****************************************************************************************************************************************************************




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

          //  txtKhachHangHD.DataBindings.Clear();
          //  txtKhachHangHD.DataBindings.Add("Text", dtdanhsachcthd.DataSource, "mahd");

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

        /* ********************************************************************************************************** */
        /* ********************************************************************************************************** */
        /* ********************* 2.0 SETUP CÁC HÀM XỬ LÝ DÀNH CHO CÁC NÚT THÊM, SỬA , XÓA, LƯU, HỦY ********************************************** */
        /* ********************************************************************************************************** */
        /* ********************************************************************************************************** */

        // START  KHU VỰC DÀNH CHO TAB NHÂN VIÊN ********************************************************* //

        // setup các nút đóng và mở 
        void dis_enNV(bool e)  // e = true (đóng) ; !e = mở
        {
            txtMaNv.Enabled = e;
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

        }

        void loadcontrolNV() // truyền dữ kiện ban đầu vào cho textbox gioi tinh
        {
            txtGioiTinhNv.Items.Clear();
            txtGioiTinhNv.Items.Add("Khác");
            txtGioiTinhNv.Items.Add("Nam");
            txtGioiTinhNv.Items.Add("Nữ");

           // txtGioiTinhNv.SelectedItem = 0;
        }

        void clearDataNV()
        {
            txtMaNv.Text = "";
            txtTenNv.Text = "";
        //    txtGioiTinhNv.Text = "";
            dtNgaySinhNv.Value = DateTime.Now.Date;
            txtDiaChiNv.Text = "";
            txtSdtNv.Text = "";
            txtCmndNv.Text = "";
            txtEmailNv.Text = "";
            txtGhiChuNv.Text = "";

            loadcontrolNV(); // thay cho dữ liệu giới tính đã set ở hàm trước
        
            

        }

        void ganDuLieuNV(NhanVienObj nvObj) // gán dữ liệu từ textbox vào cho biến tạm nvObj
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
           // nvObj.MatKhau = "";
           // truyền null cho những dữ liệu không có textbox truyền vào

        }

        //  END KHU VỰC DÀNH CHO TAB NHÂN VIÊN ********************************************************* //

        /* ********************************************************************************************************** */


        //  START  KHU VỰC DÀNH CHO TAB KHÁCH HÀNG ********************************************************* //

            
        // setup các nút đóng và mở 
        void dis_enKH(bool e)  // e = true (đóng) ; !e = mở
        {
            txtMaKhachHang.Enabled = e;
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

        }
      
        void loadcontrolKH() // truyền dữ kiện ban đầu vào cho textbox gioi tinh
        {
            txtGioiTinhKhachHang.Items.Clear();
            txtGioiTinhKhachHang.Items.Add("Khác");
            txtGioiTinhKhachHang.Items.Add("Nam");
            txtGioiTinhKhachHang.Items.Add("Nữ");
            
          //  txtGioiTinhKhachHang.SelectedItem = 0;
        }

        void clearDataKH()
        {
            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtDiaChiKhachHang.Text = "";
            txtSDTKhachHang.Text = "";
            txtGhiChuKhachHang.Text = "";

            loadcontrolKH(); // thay cho dữ liệu giới tính đã set ở hàm trước



        }

        void ganDuLieuKH(KhachHangObj khObj) // gán dữ liệu từ textbox vào cho biến tạm nvObj
        {
            khObj.MaKhachHang = txtMaKhachHang.Text.Trim();
            khObj.TenKhachHang = txtTenKhachHang.Text.Trim();
            khObj.GioiTinh = txtGioiTinhKhachHang.Text.Trim();
            khObj.DiaChi = txtDiaChiKhachHang.Text.Trim();
            khObj.SoDienThoai = txtSDTKhachHang.Text.Trim();
            khObj.GhiChu = txtGhiChuKhachHang.Text.Trim();
            // truyền null cho những dữ liệu không có textbox truyền vào

        }

        //  END  KHU VỰC DÀNH CHO TAB KHÁCH HÀNG ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB LOẠI SẢN PHẨM ********************************************************* //

        void dis_enLHH(bool e)  // e = true (đóng) ; !e = mở
        {
            txtMaLoaiSanPham.Enabled = e;
            txtTenLoaiSanPham.Enabled = e;

            mnHuyLoai.Enabled = e;
            mnLuuLoai.Enabled = e;
            mnThemLoai.Enabled = !e;
            mnSuaLoai.Enabled = !e;
            mnXoaLoai.Enabled = !e;

        }
        
        void clearDataLHH()
        {
            txtMaLoaiSanPham.Text = "";
            txtTenLoaiSanPham.Text = "";
            
        }

        void ganDuLieuLHH(LoaiHangHoaObj lhhObj) // gán dữ liệu từ textbox vào cho biến tạm nvObj
        {
            lhhObj.MaLoaiHH = txtMaLoaiSanPham.Text.Trim();
            lhhObj.TenLoaiHH = txtTenLoaiSanPham.Text.Trim();
            // truyền null cho những dữ liệu không có textbox truyền vào

        }

        //  END  KHU VỰC DÀNH CHO TAB LOẠI SẢN PHẨM ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB NHÀ CUNG CẤP ********************************************************* //

        void dis_enNCC(bool e)  // e = true (đóng) ; !e = mở
        {
            txtMaNCC.Enabled = e;
            txtTenNCC.Enabled = e;
            txtDiaChiNCC.Enabled = e;
            txtSoDtNCC.Enabled = e;
            txtGhiChuNCC.Enabled = e;

            mnHuyNcc.Enabled = e;
            mnLuuNcc.Enabled = e;
            mnThemNcc.Enabled = !e;
            mnSuaNcc.Enabled = !e;
            mnXoaNcc.Enabled = !e;

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
            // truyền null cho những dữ liệu không có textbox truyền vào

        }

        //  END  KHU VỰC DÀNH CHO TAB NHÀ CUNG CẤP ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB KHUYẾN MÃI ********************************************************* //

        void dis_enKm(bool e)  // e = true (đóng) ; !e = mở
        {
            txtMaKm.Enabled = e;
            txtTenKm.Enabled = e;
            txtNoiDungKm.Enabled = e;
            txtGiamKm.Enabled = e;

            mnHuyKm.Enabled = e;
            mnLuuKm.Enabled = e;
            mnThemKm.Enabled = !e;
            mnSuaKm.Enabled = !e;
            mnXoaKm.Enabled = !e;

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
            // truyền null cho những dữ liệu không có textbox truyền vào

        }

        //  END  KHU VỰC DÀNH CHO TAB KHUYẾN MÃI ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB SẢN PHẨM ********************************************************* //

        void dis_enHH(bool e)  // e = true (đóng) ; !e = mở
        {
            txtMaHH.Enabled = e;
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

        }

        void loadcontrolHH() // truyền dữ kiện ban đầu vào cho textbox gioi tinh
        {
            txtDonViHH.Items.Clear();
            txtDonViHH.Items.Add("Khác");
            txtDonViHH.Items.Add("Kg");
            txtDonViHH.Items.Add("Tấn");
            txtDonViHH.Items.Add("Hộp");
            txtDonViHH.Items.Add("Thùng");
            txtDonViHH.Items.Add("Lốc");
            txtDonViHH.Items.Add("Chai");
            txtDonViHH.Items.Add("Lít");
            txtDonViHH.Items.Add("Cái");

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
            // truyền null cho những dữ liệu không có textbox truyền vào

        }

        //  END  KHU VỰC DÀNH CHO TAB SẢN PHẨM ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB HÓA ĐƠN + CTHD ********************************************************* //


        void dis_enHD(bool e)  // e = true (đóng) ; !e = mở
        {
            txtSanPhamHD.Enabled = e;
            txtSoLuongCTHD.Enabled = e;

            txtKhachHangHD.Enabled = !e;


            btnThemCTHD.Enabled = e;
            btnHuyCHTD.Enabled = e;
            btnXoaSpCTHD.Enabled = e;
          //  btnCheckKM.Enabled = e;

            btnInHoaDon.Enabled = !e;
            btnThemHD.Enabled = !e;
            btnXoaHD.Enabled = !e;
            btnGioHangHD.Enabled = !e;
            
            //  clearDataHD();
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

            

            clearDataHD();
        }

        void clearDataHD()
        {
            
            txtSanPhamHD.Text = "";
            txtSoLuongCTHD.Text = "0";
          //  txtTongTienHD.Text = "0.00";
            btnKhuyenMaiHD.Text = "0";
           // txtThanhTienAdd.Text = "";


        }


        void ganDulieuHDsub()
        {

            txtSanPhamHD.DisplayMember = "mahh";
            txtSanPhamHD.ValueMember = "tenhh";


         //   txtKhachHangHD.DisplayMember = "makh";
        //    txtKhachHangHD.ValueMember = "tenkh";
        }

        int autoHD = 1;
       // string macthd;

        void ganDuLieuHD(HoaDonObj hdObj) // gán dữ liệu từ textbox vào cho biến tạm nvObj
        {


            hdObj.MaHoaDon = "" + autoHD; // cài đặt mã tự tăng
            hdObj.NguoiLap = "NV001"; // cài đặt mặt định NV001
            hdObj.KhachHang = txtKhachHangHD.Text.Trim();
            hdObj.NgayLap = txtNgayBanHD.Text.Trim();
           // hdObj.TongTien = float.Parse(txtTongTienHD.Text.Trim());



            // truyền null cho những dữ liệu không có textbox truyền vào

        }


        void dis_enCTHD(bool e)  // e = true (đóng) ; !e = mở
        {
            txtSanPhamHD.Enabled = !e;
            txtSoLuongCTHD.Enabled = !e;

            txtKhachHangHD.Enabled = e;


            btnThemCTHD.Enabled = !e;
            btnHuyCHTD.Enabled = !e;
            btnXoaSpCTHD.Enabled = !e;
           // btnCheckKM.Enabled = !e;

            btnInHoaDon.Enabled = !e;
            btnThemHD.Enabled = e;
            btnXoaHD.Enabled = e;
            btnGioHangHD.Enabled = e;
            

            //  clearDataHD();
            loadcontrolCTHD();

        }

        void loadcontrolCTHD() // truyền dữ kiện ban đầu vào cho textbox 
        {
            
            //  chú ý !!!!!!!
            
            HangHoaCtrl hh = new HangHoaCtrl();
            txtSanPhamHD.DataSource = hh.getDataHH();
            txtSanPhamHD.DisplayMember = "tenhh";
            txtSanPhamHD.ValueMember = "mahh";

           // DataTable dt = new System.Data.DataTable();
           // dt = cthdctr.GetDonVi(macthd);
           // txtSanPhamHD.DataSource = dt;

            txtDonViSp.DataBindings.Clear();
            txtDonViSp.DataBindings.Add("Text", txtSanPhamHD.DataSource, "donvi");

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
          //  btnKhuyenMaiHD.Text = "0";

           
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
            
           // hdObj.TongTien = int.Parse( );


            // truyền null cho những dữ liệu không có textbox truyền vào

        }

        void ganTongTienHD(string mahd)
        {

            hdctr.UpdTongTienHD(mahd);

        }


        //  END  KHU VỰC DÀNH CHO TAB HÓA ĐƠN + CTHD ********************************************************* //

        /* ********************************************************************************************************** */
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
         //   tkObj.SoLuongDaBan = int.Parse(txtSoLuongCTHD.Text.Trim());
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

        /* ********************************************************************************************************** */
        // START  KHU VỰC DÀNH CHO TAB QUẢN LÝ ADMIN ********************************************************* //

        void ganDulieuQL(QuanLyObj nvObj)
        {
            nvObj.MatKhau = txtMatKhauMoi.Text.Trim();
        }

        void loadQuanLy()
        {
            txtMatKhauCu.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLaiMatKhau.Text = "";
            txtThongBaoDoiMK.Text = "";

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



        /* ********************************************************************************************************** */
        /* ********************************************************************************************************** */
        /* ********************* 3.0 SETUP CÁC NÚT THÊM, SỬA, XÓA, LƯU HỦY ********************************************** */
        /* ********************************************************************************************************** */
        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB NHÂN VIÊN ********************************************************* //

        private void mnThemNv_Click_1(object sender, EventArgs e)
        {
            flag = 0;
            dis_enNV(true);
            loadcontrolNV();

            dtNgaySinhNv.Text = DateTime.Now.Date.ToShortDateString();

            clearDataNV();

        }

        private void mnSuaNv_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_enNV(true);
            loadcontrolNV();
        }

        private void mnXoaNv_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn XÓA thông tin nhân viên này ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Xóa
                if (nvctr.delDate(txtMaNv.Text.Trim()))
                    MessageBox.Show("Bạn đã XÓA thông tin nhân viên thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("XÓA THẤT BẠI : LỖI HỆ THỐNG !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                return;

            Form2_Load(sender, e);

        }

        private void mnLuuNv_Click(object sender, EventArgs e)
        {
            ganDuLieuNV(nvObj);
            if(flag==0)
            {
                // TH Thêm nv mới
                if (nvctr.addData(nvObj))
                {
                    MessageBox.Show("Bạn đã THÊM một nhân viên mới thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                else
                    MessageBox.Show("CẬP NHẬT THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            

        }

        private void mnHuyNv_Click(object sender, EventArgs e)
        {
            Form2_Load(sender, e);
            dis_enNV(false);
        }


        //  END  KHU VỰC DÀNH CHO TAB NHÂN VIÊN ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB KHÁCH HÀNG ********************************************************* //

        private void mnThemKh_Click(object sender, EventArgs e)
        {
            flagKH = 0;
            dis_enKH(true);
            loadcontrolKH();

            clearDataKH();
            

        }

        private void mnSuaKh_Click(object sender, EventArgs e)
        {
            flagKH = 1;
            dis_enKH(true);
            loadcontrolKH();

        }

        private void mnXoaKh_Click(object sender, EventArgs e)
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
            else
                return;

            Form2_Load(sender, e);

        }

        private void mnLuuKh_Click(object sender, EventArgs e)
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

        private void mnHuyKh_Click(object sender, EventArgs e)
        {
            Form2_Load(sender, e);
            dis_enKH(false);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //  END  KHU VỰC DÀNH CHO TAB KHÁCH HÀNG ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB LOẠI HÀNG HÓA ********************************************************* //

        private void mnThemLoai_Click(object sender, EventArgs e)
        {

            flagLHH = 0;
            dis_enLHH(true);
            clearDataLHH();
        }

        private void mnSuaLoai_Click(object sender, EventArgs e)
        {
            flagLHH = 1;
            dis_enLHH(true);           
        }

        private void mnXoaLoai_Click(object sender, EventArgs e)
        {
            DialogResult dr3 = MessageBox.Show("Bạn có chắc muốn XÓA thông tin Loại Sản Phẩm này ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr3 == DialogResult.Yes)
            {
                // Xóa
                if (lhhctr.delDateLHH(txtMaLoaiSanPham.Text.Trim()))
                    MessageBox.Show("Bạn đã XÓA thông tin Loại Sản Phẩm thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("XÓA THẤT BẠI : LỖI HỆ THỐNG !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                return;

            Form2_Load(sender, e);
        }

        private void mnLuuLoai_Click(object sender, EventArgs e)
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

        private void mnHuyLoai_Click(object sender, EventArgs e)
        {
            Form2_Load(sender, e);
            dis_enLHH(false);
        }


        //  END  KHU VỰC DÀNH CHO TAB LOẠI HÀNG HÓA ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB NHÀ CUNG CẤP ********************************************************* //

        private void mnThemNcc_Click(object sender, EventArgs e)
        {
            flagNCC = 0;
            dis_enNCC(true);
            clearDataNCC();
        }

        private void mnSuaNcc_Click(object sender, EventArgs e)
        {
            flagNCC = 1;
            dis_enNCC(true);
        }

        private void mnXoaNcc_Click(object sender, EventArgs e)
        {
            DialogResult dr4 = MessageBox.Show("Bạn có chắc muốn XÓA thông tin NCC này ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void mnLuuNcc_Click(object sender, EventArgs e)
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

        private void mnHuyNcc_Click(object sender, EventArgs e)
        {
            Form2_Load(sender, e);
            dis_enNCC(false);
        }

        //  END  KHU VỰC DÀNH CHO TAB NHÀ CUNG CẤP ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB SỰ KIỆN ********************************************************* //

        private void mnThemKm_Click(object sender, EventArgs e)
        {
            flagKM = 0;
            dis_enKm(true);
            clearDataKm();
        }

        private void mnSuaKm_Click(object sender, EventArgs e)
        {
            flagKM = 1;
            dis_enKm(true);
        }

        private void mnXoaKm_Click(object sender, EventArgs e)
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

        private void mnLuuKm_Click(object sender, EventArgs e)
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

        private void mnHuyKm_Click(object sender, EventArgs e)
        {
            Form2_Load(sender, e);
            dis_enKm(false);
        }

        //  END  KHU VỰC DÀNH CHO TAB SỰ KIỆN ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB HÀNG HÓA ********************************************************* //

        private void mnThemSp_Click(object sender, EventArgs e)
        {
            flagHH = 0;
            dis_enHH(true);
            loadcontrolHH();

            clearDataHH();
        }

        private void mnXoaSp_Click(object sender, EventArgs e)
        {
            DialogResult dr6 = MessageBox.Show("Bạn có chắc muốn XÓA thông tin sản phẩm này ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void mnSuaSp_Click(object sender, EventArgs e)
        {
            flagHH = 1;
            dis_enHH(true);
            loadcontrolHH();
        }

        private void mnLuuSp_Click(object sender, EventArgs e)
        {
            ganDulieuHHsub();
            ganDuLieuHH(hhObj);
            
            if (flagHH == 0)
            {
                // TH Thêm nv mới
                if (hhctr.addDataHH(hhObj))
                {
                    MessageBox.Show("Bạn đã THÊM một sản phẩm mới thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form2_Load(sender, e);
                    dis_enHH(false);
                }
                else
                    MessageBox.Show("THÊM THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // TH Sửa tt nhân viên
                if (hhctr.updDateHH(hhObj))
                {
                    MessageBox.Show("Bạn đã CẬP NHẬT thông tin sản phẩm thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form2_Load(sender, e);
                    dis_enHH(false);
                }
                else
                    MessageBox.Show("CẬP NHẬT THẤT BẠI : NHẬP SAI THÔNG TIN !", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnHuySp_Click(object sender, EventArgs e)
        {
            Form2_Load(sender, e);
            dis_enHH(false);
        }

        //  END  KHU VỰC DÀNH CHO TAB HÀNG HÓA ********************************************************* //

        /* ********************************************************************************************************** */

        //  START  KHU VỰC DÀNH CHO TAB HÓA ĐƠN ********************************************************* //

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            /*
             * Lưu mới một hóa đơn với mã tự sinh
             */
            autoHD++;

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
                    TonKho_DaBan(mahh,soluong);
                    //

                    ganTongTienHD(mahd);
                    bingdingCTHD(mahd);
                    dis_enCTHD(false);
                    
                }
                else
                {
                    
                    MessageBox.Show("THÊM THẤT BẠI ", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ganTongTienHD(mahd);
                    bingdingCTHD(mahd);
                    dis_enCTHD(false);
                }

            }

          //  bingdingHH();
           // dis_enHH(false);

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

        private void btnLuuMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text == "") { txtThongBaoDoiMK.Text = "✘ Vui lòng nhập mật khẩu cũ ✘"; }
            else if (txtMatKhauMoi.Text == "") { txtThongBaoDoiMK.Text = "✘ Vui lòng nhập mật khẩu mới ✘"; }
            else if (txtNhapLaiMatKhau.Text != txtMatKhauMoi.Text) { txtThongBaoDoiMK.Text = "✘ Mật khẩu mới không trùng nhau ✘"; }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source= HO-DOAN-THANH-N\SQLEXPRESS; ;Initial Catalog = QL_CUAHANG;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From QUANLY where taikhoan='admin'and matkhau='" + txtMatKhauCu.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    QuanLyObj thdObj = new QuanLyObj();
                    QuanLyCtrl thdcrt = new QuanLyCtrl();
                    ganDulieuQL(thdObj);
                    if (thdcrt.updDate(thdObj))
                    {
                        //  gửi mật khẩu mới vào mail
                        SendMailMob mailMob = new SendMailMob();
                        if (mailMob.SendMail(txtNhapLaiMatKhau.Text) == true)
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


        // END  KHU VỰC DÀNH CHO TAB THỐNG KÊ ********************************************************* //

        /* ********************************************************************************************************** */
        // START  KHU VỰC DÀNH CHO TAB QUẢN LÝ ADMIN ********************************************************* //
        // END  KHU VỰC DÀNH CHO TAB QUẢN LÝ ADMIN ********************************************************* //

        /* ********************************************************************************************************** */
    }
}
