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
    class NhaCungCapCtrl
    {
        NhaCungCapMod nccMod = new NhaCungCapMod();

        public DataTable getDataNCC()
        {
            return nccMod.GetDataNCC();
        }

        public bool addDataNCC(NhaCungCapObj nccObj)
        {
            return nccMod.AddDataNCC(nccObj);
        }

        public bool updDateNCC(NhaCungCapObj nccObj)
        {
            return nccMod.UpdDataNCC(nccObj);
        }

        public bool delDateNCC(string ma)
        {
            return nccMod.DelDataNCC(ma);
        }

    }
}
