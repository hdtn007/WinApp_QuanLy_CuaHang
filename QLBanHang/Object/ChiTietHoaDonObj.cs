using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class ChiTietHoaDonObj
    {
        string mahd, mahh;
        int soluong, dongia, khuyenmai, thanhtien;

        public string MaHoaDon
        {
            get { return mahd; }
            set { mahd = value; }
        }

        public string MaHangHoa
        {
            get { return mahh; }
            set { mahh = value; }
        }

        public int DonGia
        {
            get { return dongia; }
            set { dongia = value; }

        }

        public int SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        public int ThanhTien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }

        public int KhuyenMai
        {
            get { return khuyenmai; }
            set { khuyenmai = value; }
        }

        public ChiTietHoaDonObj() { }
        public ChiTietHoaDonObj(string mahd, string mahh, int soluong, int dongia, int khuyenmai, int thanhtien)
        {
            this.mahd = mahd;
            this.mahh = mahh;
            this.soluong = soluong;
            this.dongia = dongia;
            this.khuyenmai = khuyenmai;
            this.thanhtien = thanhtien;

        }
    }
}
