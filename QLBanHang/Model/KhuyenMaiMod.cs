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
    class KhuyenMaiMod
    {

        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetDataKm()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select mask, tensk, noidung, giam from SUKIEN";
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

        public bool AddDataKm(KhuyenMaiObj kmObj)
        {

            cmd.CommandText = "Insert into SUKIEN values ('" + kmObj.MaKhuyenmai + "',N'" + kmObj.TenKhuyenMai + "',N'" + kmObj.NoiDung + "','" + kmObj.Giam + "')";
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


        public bool UpdGiam(KhuyenMaiObj kmObj)
        {
            cmd.CommandText = "Update SUKIEN set giam ='" + kmObj.Giam + "' Where mask = '" + kmObj.MaKhuyenmai + "'";
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

        public bool UpdDataKm(KhuyenMaiObj kmObj)
        {

            cmd.CommandText = "Update SUKIEN set tensk =  N'" + kmObj.TenKhuyenMai + "', noidung = N'" + kmObj.NoiDung + "', giam =N'" + kmObj.Giam + "' Where mask = '" + kmObj.MaKhuyenmai + "'";
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

        public bool DelDataKm(string ma)
        {
            cmd.CommandText = "Delete SUKIEN Where mask = '" + ma + "'";
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
