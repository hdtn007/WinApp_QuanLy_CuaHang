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
    class AutoIDctrl
    {
        AutoIDmod autoIdMod = new AutoIDmod();

        public string GetLastID(string TenBang, string TenCot)
        {
            return autoIdMod.GetLastID(TenBang, TenCot);
        }
    }
}
