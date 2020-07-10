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
    class LoaiHangHoaCtrl
    {

        LoaiHangHoaMod lhhMod = new LoaiHangHoaMod();
        public DataTable getmaLHH()
        {
            return lhhMod.GetMaLHH();
        }

        public DataTable getDataLHH()
        {
            return lhhMod.GetDataLHH();
        }

        public bool addDataLHH(LoaiHangHoaObj lhhObj)
        {
            return lhhMod.AddDataLHH(lhhObj);
        }

        public bool updDateLHH(LoaiHangHoaObj lhhObj)
        {
            return lhhMod.UpdDataLHH(lhhObj);
        }

        public bool delDateLHH(string ma)
        {
            return lhhMod.DelDataLHH(ma);
        }

    }
}
