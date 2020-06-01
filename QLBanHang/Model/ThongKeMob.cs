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
    class ThongKeMob
    {

        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select mahh, ngayban, giaban, gianhap, soluongban, tongthu, loinhuan from THONGKE";
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

        public bool AddData(ThongKeObj tkObj)
        {

            cmd.CommandText = "Insert into THONGKE values ('" + tkObj.MaHangHoa + "',CONVERT(DATE,'" + tkObj.NgayBan + "',103),'" + tkObj.GiaBan + "','" + tkObj.GiaNhap + "','" + tkObj.SoLuongDaBan + "','" + tkObj.TongDoanhThu + "','" + tkObj.LoiNhuan + "')";
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


        public bool UpdData(ThongKeObj tkObj)
        {

            cmd.CommandText = " Update THONGKE set tongthu = giaban*soluongban, loinhuan = giaban*soluongban - gianhap*soluongban ";
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



        public bool DelData(string ma)
        {
            cmd.CommandText = "Delete THONGKE Where mahh = '" + ma + "'";
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

        public DataTable UpdDaBan(string mahh, int soluong)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = @" Update HANGHOA set daban = daban + "+soluong+ ", tonkho = tonkho - " + soluong + " where mahh = '" + mahh+ "' ; Update THONGKE set soluongban = soluongban + "+soluong+" where mahh = '"+mahh+"' ";
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


        // thống kê từng sp dd/mm/yyyy

        public DataTable SelectOnlyDD(string mahh, string ngayban)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where mahh='" + mahh + "' and day(ngayban) = day(CONVERT(DATE,'" + ngayban + "',103)) and month(ngayban) = month(CONVERT(DATE,'" + ngayban + "',103)) and year(ngayban) = year(CONVERT(DATE,'" + ngayban + "',103))";
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

        public DataTable SelectOnlyMM(string mahh, string ngayban)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where mahh='" + mahh + "' and month(ngayban) = month(CONVERT(DATE,'" + ngayban + "',103)) and year(ngayban) = year(CONVERT(DATE,'" + ngayban + "',103))";
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

        public DataTable SelectOnlyYYYY(string mahh, string ngayban)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where mahh='" + mahh + "' and year(ngayban) = year(CONVERT(DATE,'" + ngayban + "',103))";
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

        // thống kê tất cả các sp dd/mm/yyyy

        public DataTable SelectAllDD(string mahh, string ngayban)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where day(ngayban) = day(CONVERT(DATE,'" + ngayban + "',103)) and month(ngayban) = month(CONVERT(DATE,'" + ngayban + "',103)) and year(ngayban) = year(CONVERT(DATE,'" + ngayban + "',103))";
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

        public DataTable SelectAllMM(string mahh, string ngayban)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where month(ngayban) = month(CONVERT(DATE,'" + ngayban + "',103)) and year(ngayban) = year(CONVERT(DATE,'" + ngayban + "',103))";
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

        public DataTable SelectAllYYYY(string mahh, string ngayban)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where year(ngayban) = year(CONVERT(DATE,'" + ngayban + "',103))";
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
