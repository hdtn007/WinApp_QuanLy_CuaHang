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
    class HoaDonCtrl
    {

        HoaDonMod hdMod = new HoaDonMod();

        public DataTable getDataHD()
        {
            return hdMod.GetDataHD();
        }

        public bool addDataHD(HoaDonObj hdObj)
        {
            return hdMod.AddDataHD(hdObj);
        }

        public bool updDateHD(HoaDonObj hdObj)
        {
            return hdMod.UpdDataHD(hdObj);
        }

        public bool delDateHD(string ma)
        {
            return hdMod.DelDataHD(ma);
        }

        public DataTable getTongTien(string mahd)
        {
            return hdMod.GetTongTien(mahd);
        }
        /*
        public bool UpdTongTienHD(HoaDonObj hdObj)
        {
            return hdMod.UpdTongTienHD(hdObj);
        }
        */
        public DataTable UpdTongTienHD(string mahd)
        {
            return hdMod.UpdTongTienHD(mahd);
        }
    }
}
