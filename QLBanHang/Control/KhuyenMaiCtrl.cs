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
    class KhuyenMaiCtrl
    {
        KhuyenMaiMod kmMod = new KhuyenMaiMod();

        public DataTable getDataKm()
        {
            return kmMod.GetDataKm();
        }

        public DataTable getMaKm()
        {
            return kmMod.GetMaKm();
        }

        public bool addDataKm(KhuyenMaiObj kmObj)
        {
            return kmMod.AddDataKm(kmObj);
        }

        public bool updDateKm(KhuyenMaiObj kmObj)
        {
            return kmMod.UpdDataKm(kmObj);
        }

        public bool UpdDataGiam(KhuyenMaiObj kmObj)
        {
            return kmMod.UpdGiam(kmObj);
        }

        public bool delDateKm(string ma)
        {
            return kmMod.DelDataKm(ma);
        }
    }
}
