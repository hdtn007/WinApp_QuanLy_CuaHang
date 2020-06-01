using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class HoaDonObj
    {
        string mahd, ngaylap, nguoilap, khachhang;
        int tongtien;

        public string MaHoaDon
        {
            get { return mahd; }
            set { mahd = value; }

        }

        public string NgayLap
        {
            get { return ngaylap; }
            set { ngaylap = value; }

        }

        public string NguoiLap
        {
            get { return nguoilap; }
            set { nguoilap = value; }
        }

        public string KhachHang
        {
            get { return khachhang; }
            set { khachhang = value; }
        }

        public int TongTien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }


        public HoaDonObj() { }
        public HoaDonObj(string mahd, string khachhang, string ngaylap, string nguoilap, int tongtien)
        {
            this.mahd = mahd;
            this.ngaylap = ngaylap;
            this.nguoilap = nguoilap;
            this.khachhang = khachhang;
            this.tongtien = tongtien;

        }
    }
}
