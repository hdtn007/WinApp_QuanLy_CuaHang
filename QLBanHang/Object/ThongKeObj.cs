using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Object
{
    class ThongKeObj
    {
        string mahh, ngayban;
        int soluongban, tongthu, loinhuan, giaban, gianhap;

        public string MaHangHoa
        {
            get { return mahh; }
            set { mahh = value; }
        }

        public int GiaBan
        {
            get { return giaban; }
            set { giaban = value; }
        }

        public int GiaNhap
        {
            get { return gianhap; }
            set { gianhap = value; }
        }

        public string NgayBan
        {
            get { return ngayban; }
            set { ngayban = value; }
        }

        public int SoLuongDaBan
        {
            get { return soluongban; }
            set { soluongban = value; }
        }

        public int TongDoanhThu
        {
            get { return tongthu; }
            set { tongthu = value; }
        }

        public int LoiNhuan
        {
            get { return loinhuan; }
            set { loinhuan = value; }
        }
        public ThongKeObj() { }
        public ThongKeObj(string mahh, string ngayban, int soluongban, int tongthu, int loinhuan, int giaban, int gianhap)
        {
            this.mahh = mahh;
            this.ngayban = ngayban;
            this.soluongban = soluongban;
            this.tongthu = tongthu;
            this.loinhuan = loinhuan;
            this.giaban = giaban;
            this.gianhap = gianhap;


        }
    }
}
