using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class KhuyenMaiObj
    {
        string makm, tenkm, noidung;
        int giamgia;

        public int Giam
        {
            get { return giamgia; }
            set { giamgia = value; }
        }

        public string MaKhuyenmai
        {
            get { return makm; }
            set { makm = value; }

        }

        public string TenKhuyenMai
        {
            get { return tenkm; }
            set { tenkm = value; }
        }

        public string NoiDung
        {
            get { return noidung; }
            set { noidung = value; }
        }


        public KhuyenMaiObj() { }
        public KhuyenMaiObj (int giamgia, string makm, string tenkm, string noidung)
        {
            this.makm = makm;
            this.tenkm = tenkm;
            this.noidung = noidung;
            this.giamgia = giamgia;


        }
    }
}
