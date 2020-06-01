using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class KhachHangObj
    {
        string makh, tenkh, diachi, sdt, ghichu, gioitinh;

        public string MaKhachHang
        {
            get { return makh; }
            set { makh = value; }

        }

        public string TenKhachHang
        {
            get { return tenkh; }
            set { tenkh = value; }

        }

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }

        }

        public string SoDienThoai
        {
            get { return sdt; }
            set { sdt = value; }

        }

        public string GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }

        }

        public string GhiChu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        public KhachHangObj() { }
        public KhachHangObj(string makh,string tenkh,string sdt,string gioitinh,string diachi,string ghichu)
        {

            this.makh = makh;
            this.tenkh = tenkh;
            this.gioitinh = gioitinh;
            this.ghichu = ghichu;
            this.diachi = diachi;
            this.sdt = sdt;

        }
    }
}
