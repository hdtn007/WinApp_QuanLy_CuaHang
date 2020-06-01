using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class NhaCungCapObj
    {
        string mancc, tenncc, diachi, sdt, ghichu;

        public string MaNhaCungCap
        {
            get { return mancc; }
            set { mancc = value; }
        }

        public string TenNhaCungCap
        {
            get { return tenncc; }
            set { tenncc = value; }
        }

        public string SoDienThoai
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public string GhiChu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }


        public NhaCungCapObj() { }
        public NhaCungCapObj(string mancc, string tenncc, string sdt, string diachi, string ghichu)
        {

            this.mancc = mancc;
            this.tenncc = tenncc;
            this.sdt = sdt;
            this.diachi = diachi;
            this.ghichu = ghichu;

        }
    }
}
