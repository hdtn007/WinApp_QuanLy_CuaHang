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
    class LoaiHangHoaMod
    {

        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetMaLHH()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select MAX(maloai)maloai from LOAIHH";
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

        public DataTable GetDataLHH()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select maloai, tenloai  from LOAIHH";
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

        public bool AddDataLHH(LoaiHangHoaObj lhhObj)
        {

            cmd.CommandText = "Insert into LOAIHH values ('" + lhhObj.MaLoaiHH + "',N'" + lhhObj.TenLoaiHH + "')";
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

        public bool UpdDataLHH(LoaiHangHoaObj lhhObj)
        {

            cmd.CommandText = "Update LOAIHH set tenloai =  N'" + lhhObj.TenLoaiHH + "' Where maloai = '" + lhhObj.MaLoaiHH + "'";
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

        public bool DelDataLHH(string ma)
        {
            cmd.CommandText = "Delete THONGKE from HANGHOA hh, LOAIHH l Where  THONGKE.mahh= hh.mahh and hh.maloai=l.maloai and l.maloai = '" + ma + "'; Delete CTHD from HANGHOA hh, LOAIHH l Where l.maloai=hh.maloai and hh.mahh = CTHD.mahh and l.maloai = '" + ma + "';Delete HANGHOA Where maloai = '" + ma + "'; Delete LOAIHH Where maloai = '" + ma + "'";
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

    }
}
