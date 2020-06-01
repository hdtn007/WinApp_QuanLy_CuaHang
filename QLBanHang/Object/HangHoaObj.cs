using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class HangHoaObj
    {
        string mahh, tenhh,donvi,ghichu, ncc,loaihh,khuyenmai;
        int tonkho, daban;
        int dongia,gianhap;

        public int DonGia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        public int GiaNhap
        {
            get { return gianhap; }
            set { gianhap = value; }
        }

        public int TonKho
        {
            get { return tonkho; }
            set { tonkho = value;  }

        }

        public int DaBan
        {
            get { return daban; }
            set { daban = value; }

        }

        public string MaHangHoa
        {
            get { return mahh; }
            set { mahh = value; }

        }

        public string TenHangHoa
        {
            get { return tenhh; }
            set { tenhh = value; }

        }

        public string DonVi
        {
            get { return donvi; }
            set { donvi = value; }

        }

        public string GhiChu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        public string NhaCungCap
        {
            get { return ncc; }
            set { ncc = value; }
        }

        public string LoaiHangHoa
        {
            get { return loaihh; }
            set { loaihh = value; }
        }

        public string KhuyenMai
        {
            get { return khuyenmai; }
            set { khuyenmai = value; }
        }

        public HangHoaObj() { }
        public HangHoaObj(string mahh, string tenhh, string donvi,string loaihh, string ncc, string khuyenmai, string ghichu, int dongia, int gianhap, int tonkho, int daban)
        {
            this.mahh = mahh;
            this.tenhh = tenhh;
            this.ghichu = ghichu;
            this.donvi = donvi;
            this.dongia = dongia;
            this.gianhap = gianhap;
            this.tonkho = tonkho;
            this.daban = daban;
            this.ncc = ncc;
            this.loaihh = loaihh;
            this.khuyenmai = khuyenmai;
        }
    }
}
