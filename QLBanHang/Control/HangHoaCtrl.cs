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
    class HangHoaCtrl
    {

        HangHoaMod hhMod = new HangHoaMod();

        public DataTable getDataHH()
        {
            return hhMod.GetDataHH();
        }

        public bool addDataHH(HangHoaObj hhObj)
        {
            return hhMod.AddDataHH(hhObj);
        }

        public bool updDateHH(HangHoaObj hhObj)
        {
            return hhMod.UpdDataHH(hhObj);
        }

        public bool UpdDaBan(HangHoaObj hhObj)
        {
            return hhMod.UpdDaBan(hhObj);
        }

        public bool delDateHH(string ma)
        {
            return hhMod.DelDataHH(ma);
        }

    }
}
