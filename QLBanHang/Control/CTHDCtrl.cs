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
    class CTHDCtrl
    {

        CTHDMod cthdMod = new CTHDMod();

        public DataTable getDataCTHD(string mahd)
        {
            return cthdMod.GetDataCTHD(mahd);
        }

        public bool addDataCTHD(ChiTietHoaDonObj cthdObj)
        {
            return cthdMod.AddDataCTHD(cthdObj);
        }

        public bool updDateCTHD(ChiTietHoaDonObj cthdObj)
        {
            return cthdMod.UpdDataCTHD(cthdObj);
        }


        public bool delDateCTHD(string mahh)
        {
            return cthdMod.DelDataCTHD(mahh);
        }


        /*
        public DataTable GetDonVi(string mahh)
        {
            return cthdMod.GetDonVi(mahh);
        }
        *//*
        public DataTable GetDonGia(string mahh)
        {
            return cthdMod.GetDonGia(mahh);
        }
        */
        
        public DataTable GetDonGiaKhuyenmai(string mahh)
        {
            return cthdMod.GetDonGiaKhuyenmai(mahh);
        }
        
        public DataTable GetTongTien(string mahh)
        {
            return cthdMod.GetTongTien(mahh);
        }
    }
}
