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
    class QuanLyCtrl
    {

        QuanLyMod qlMod = new QuanLyMod();
        SendMailMob mailMob = new SendMailMob();

        public DataTable getData()
        {
            return qlMod.GetData();
        }
        /*
        public bool addData(QuanLyObj qlObj)
        {
            return qlMod.AddData(qlObj);
        }
        */
        public bool updDate(QuanLyObj qlObj)
        {
            return qlMod.UpdData(qlObj);
        }

        public bool check(QuanLyObj qlObj)
        {
            return qlMod.Check(qlObj);
        }
        /*
        public void SendMailMob(string makhaumoi)
        {
            mailMob.SendMail();
        } */
        
    }
}
