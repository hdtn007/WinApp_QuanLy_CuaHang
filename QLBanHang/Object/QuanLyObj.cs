using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class QuanLyObj
    {
        string taikhoan, matkhau;

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

        public QuanLyObj() { }
        public QuanLyObj(string taikhoan, string matkhau)
        {
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;

        }
    }
}
