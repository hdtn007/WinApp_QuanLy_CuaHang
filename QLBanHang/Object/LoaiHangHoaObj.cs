using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class LoaiHangHoaObj
    {
        string maloai, tenloai;

        public string MaLoaiHH
        {
            get { return maloai; }
            set { maloai = value; }

        }

        public string TenLoaiHH
        {
            get { return tenloai; }
            set { tenloai = value; }
        }

        public LoaiHangHoaObj() { }
        public LoaiHangHoaObj(string maloai, string tenloai)
        {
            this.maloai = maloai;
            this.tenloai = tenloai;

        }
    }
}
