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
    class ThongKeCtrl
    {

        ThongKeMob tkMod = new ThongKeMob();

        public DataTable getData()
        {
            return tkMod.GetData();
        }

        public bool addData(ThongKeObj tkObj)
        {
            return tkMod.AddData(tkObj);
        }
        
        public bool updDate(ThongKeObj tkObj)
        {
            return tkMod.UpdData(tkObj);
        }
        
        public bool delDate(string ma)
        {
            return tkMod.DelData(ma);
        }

        public DataTable updDaBan(string mahh, int soluong)
        {
            return tkMod.UpdDaBan(mahh,soluong);
        }

        // Only sp
        public DataTable SelectOnlyDD(string mahh, string ngayban)
        {
            return tkMod.SelectOnlyDD(mahh, ngayban);
        }
        public DataTable SelectOnlyMM(string mahh, string ngayban)
        {
            return tkMod.SelectOnlyMM(mahh, ngayban);
        }
        public DataTable SelectOnlyYYYY(string mahh, string ngayban)
        {
            return tkMod.SelectOnlyYYYY(mahh, ngayban);
        }

        // All sp
        public DataTable SelectAllDD(string mahh, string ngayban)
        {
            return tkMod.SelectAllDD(mahh, ngayban);
        }
        public DataTable SelectAllMM(string mahh, string ngayban)
        {
            return tkMod.SelectAllMM(mahh, ngayban);
        }
        public DataTable SelectAllYYYY(string mahh, string ngayban)
        {
            return tkMod.SelectAllYYYY(mahh, ngayban);
        }
    }
}
