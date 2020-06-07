using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLBanHang.Model;
using QLBanHang.Object;

namespace QLBanHang.Control
{
    class PhanQuyenCtrl
    {

        PhanQuyenMod pqMod = new PhanQuyenMod();
        public bool checkNV(PhanQuyenObj pqObj)
        {
            return pqMod.CheckNV(pqObj);
        }

        public int checkPQ(string taikhoan)
        {
            return pqMod.CheckPQ(taikhoan);
        }
    }
}
