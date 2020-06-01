using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class NhanVienObj
    {
        string ma, ten, gioitinh, diachi, sdt, email, cmnd, ghichu;
        string ngaysinh;

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string NgaySinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        public string MaNhanVien
        {
            get { return ma; }
            set { ma = value; }
        }

        public string TenNhanVien
        {
            get { return ten; }
            set { ten = value; }
        }

        public string GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        public string CMND
        {
            get { return cmnd; }
            set { cmnd = value; }
        }

        public string GhiChu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public NhanVienObj() { }
        public NhanVienObj(string ma, string ten, string diachi, string gioitinh, string email, string ghichu, string cmnd, string sdt, string ngaysinh)
        {
            this.ma = ma;
            this.ten = ten;
            this.diachi = diachi;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.sdt = sdt;
            this.cmnd = cmnd;
            this.email = email;
            this.ghichu = ghichu;
            

        }




    }
}
