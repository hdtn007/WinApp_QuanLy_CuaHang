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
    class AutoIDmod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public string GetLastID(string nameTable, string nameSelectColumn)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select*from "+ nameTable.ToString() + " ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            string lastID = "";

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

            if (dt.Rows.Count <= 0)
            {
                return lastID;
            }
            else
            {
                lastID = dt.Rows[dt.Rows.Count - 1][nameSelectColumn.ToString()].ToString().Substring(0,5); // Substring(0,5) bắt đầu lấy từ vitri 1 lấy 5 ký tự

                return lastID;
            }
            
        }



    }
}
