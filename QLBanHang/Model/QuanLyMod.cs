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
    class QuanLyMod
    {
        

        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select taikhoan,matkhau,ten from QUANLY";
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
        
        public bool AddDataQL(QuanLyObj qlObj)
        {

            cmd.CommandText = "Insert into QUANLY values ('" + qlObj.ID + "','" + qlObj.Taikhoan + "','" + qlObj.MatKhau + "',N'" + qlObj.Ten + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseConn();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }


            return false;
        }
        

        public bool UpdData(QuanLyObj qlObj)
        {

            cmd.CommandText = "Update QUANLY set matkhau = '" + qlObj.MatKhau + "', ten = N'"+qlObj.Ten+"' Where taikhoan = 'admin'";
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

        public bool UpdDataTenAdmin(QuanLyObj qlObj)
        {

            cmd.CommandText = "Update QUANLY set ten = N'" + qlObj.Ten + "' Where taikhoan = 'admin'";
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

        public bool Check(QuanLyObj qlObj)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "Select Count(*) From QUANLY where taikhoan='" + qlObj.Taikhoan + "'and matkhau='" + qlObj.MatKhau + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }

        public bool Check1(QuanLyObj qlObj)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "Select Count(*) From QUANLY where taikhoan='admin'and matkhau='" + qlObj.MatKhau + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
        /*
        public bool DelData(string tk)
        {
            cmd.CommandText = "Delete QUANLY Where taikhoan = '" + tk + "'";
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
        */

    }
}
