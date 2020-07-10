using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLBanHang.Object;

namespace QLBanHang.Model
{
    class HoaDonMod
    {

        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        
        public DataTable GetDataHD()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = @"select hd.mahd, hd.makh, nv.tennv, hd.ngayban, hd.tongtien from  HOADON hd, NHANVIEN nv where hd.manv = nv.manv";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.CloseConn();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }

            return dt;
        }

        public bool AddDataHD(HoaDonObj hdObj)
        {

            cmd.CommandText = "Insert into HOADON values ('" + hdObj.MaHoaDon + "',N'" + hdObj.NguoiLap + "',N'" + hdObj.KhachHang + "',CONVERT(DATE,'" + hdObj.NgayLap + "',103), '" + hdObj.TongTien + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseConn();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }


            return false;
        }

        public bool UpdDataHD(HoaDonObj hdObj)
        {

            cmd.CommandText = "Update HOADON set manv =  N'" + hdObj.NguoiLap  + "', makh = N'" + hdObj.KhachHang + "', ngayban = CONVERT(DATE,'" + hdObj.NgayLap + "',103), tongtien = '" + hdObj.TongTien + "' Where mahd = '" + hdObj.MaHoaDon + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }

        public bool DelDataHD(string ma)
        {
            //cmd.CommandText = "Delete HOADON Where mahd = '" + ma + "'";
            cmd.CommandText = "Delete CTHD where mahd = '" + ma + "' ; Delete HOADON where mahd = '" + ma + "'    ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }


        public DataTable GetTongTien(string mahd)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = @" select sum(thanhtien) as thanhtien from CTHD where mahd = '" + mahd + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.CloseConn();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }

            return dt;
        }
        /*
        public bool UpdTongTienHD(HoaDonObj hdObj)
        {

            cmd.CommandText = "Update HOADON set tongtien = (select sum(thanhtien) from CTHD where mahd = '" + hdObj.MaHoaDon + "'  ) where mahd = '" + hdObj.MaHoaDon + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        } */

        public DataTable UpdTongTienHD(string mahd)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = @" Update HOADON set tongtien = (select sum(thanhtien) from CTHD where mahd = '" + mahd + "'  ) where mahd = '" + mahd + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.CloseConn();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }

            return dt;
        }



    }
}
