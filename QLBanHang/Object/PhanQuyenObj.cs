using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class PhanQuyenObj
    {
        string id, taikhoan, matkhau, manv,ghichu;
        int phanquyen;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string maNhanVien
        {
            get { return manv; }
            set { manv = value; }
        }
        public string GhiChu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
        public int Quyen
        {
            get { return phanquyen; }
            set { phanquyen = value; }
        }
        public string Taikhoan
        {
            get { return taikhoan; }
            set { taikhoan = value; }
        }

        public string MatKhau
        {
            get { return matkhau; }
            set { matkhau = value; }
        }

        public PhanQuyenObj() { }
        public PhanQuyenObj(string taikhoan, string matkhau, string id, int phanquyen, string manv, string ghichu)
        {
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.id = id;
            this.phanquyen = phanquyen;
            this.manv = manv;
            this.ghichu = ghichu;

        }
    }
}
