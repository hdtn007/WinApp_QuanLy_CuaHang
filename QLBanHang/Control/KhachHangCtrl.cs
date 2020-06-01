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
    class KhachHangCtrl
    {
        KhachHangMod khMod = new KhachHangMod();

        public DataTable getDataKH()
        {
            return khMod.GetDataKH();
        }

        public bool addDataKH(KhachHangObj khObj)
        {
            return khMod.AddDataKH(khObj);
        }

        public bool updDateKH(KhachHangObj khObj)
        {
            return khMod.UpdDataKH(khObj);
        }

        public bool delDateKH(string ma)
        {
            return khMod.DelDataKH(ma);
        }
    }
}
