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
    class PhanQuyenMod
    {

        public static int QUYEN_USER; // kiểm tra quyền truy cập để ẩn tab
        public static string ID_USER; // chứa id của user đăng nhập
        public static string Name_USER;

        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select taikhoan,matkhau,manv from PHANQUYEN";
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

        public bool CheckNV(PhanQuyenObj pqObj)  // kiểm tra mk tk khi đăng nhập là nhân viên
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "Select Count(*) From PHANQUYEN where taikhoan='"+pqObj.Taikhoan+"'and matkhau='" + pqObj.MatKhau + "'";
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


        public int CheckPQ(string taikhoan)  // lấy quyền đăng nhập
        {
            DataTable dt = new DataTable();
            int pq=3;

            cmd.CommandText = "Select * From PHANQUYEN where taikhoan='" + taikhoan + "' ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        pq = int.Parse(dr["phanquyen"].ToString());
                    }
                }
                
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            finally
            {
                con.CloseConn();
            }

            return pq;
        }


    }
}
