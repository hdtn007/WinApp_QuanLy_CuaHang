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

           // DataTable dt = new DataTable();
            // cmd.CommandText = "SELECT TOP 1 '" + nameSelectColumn + "' FROM '" + nameTable + "' ORDER BY '" + nameSelectColumn + "' DESC";
            cmd.CommandText = "select MAX('"+ nameSelectColumn + "')'"+ nameSelectColumn + "' from '"+ nameTable + "' ";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                var dt = new DataSet();
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                // con.CloseConn();
                return dt.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
               /* string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn(); */
            }
            finally
            {
                if (con != null)
                {
                    con.CloseConn();
                }
            }
        }



    }
}
