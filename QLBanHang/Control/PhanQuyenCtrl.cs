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

        public DataTable GetDataPQ()
        {
            return pqMod.GetData();
        }

        public bool AddDataPQ(PhanQuyenObj pqObj)
        {
            return pqMod.AddDataPQ(pqObj);
        }

        public bool UpdDataPQ(PhanQuyenObj pqObj)
        {
            return pqMod.UpdDataPQ(pqObj);
        }

        public string CheckName(string taikhoan)
        {
            return pqMod.Checkname(taikhoan);
        }
    }
}
