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
    class NhanVienCtrl
    {

        NhanVienMod nvMod = new NhanVienMod();

        public DataTable getData()
        {
            return nvMod.GetData();
        }

        public DataTable getMANV()
        {
            return nvMod.GetMANV();
        }

        public bool addData(NhanVienObj nvObj)
        {
            return nvMod.AddData(nvObj);
        }

        public bool updDate(NhanVienObj nvObj)
        {
            return nvMod.UpdData(nvObj);
        }

        public bool delDate(string ma)
        {
            return nvMod.DelData(ma);
        }
    }
}
  