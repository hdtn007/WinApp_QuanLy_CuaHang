using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class QuanLyObj
    {
        string id,taikhoan, matkhau,ten;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
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

        public QuanLyObj() { }
        public QuanLyObj(string taikhoan, string matkhau, string id, string ten)
        {
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.id = id;
            this.ten = ten;

        }
    }
}
