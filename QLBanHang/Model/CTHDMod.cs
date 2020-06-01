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
    class CTHDMod
    {


        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetDataCTHD(string ma)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = @" select ct.mahd, hh.mahh , hh.tenhh, hh.dongia , ct.soluong, hh.donvi, sk.giam, (hh.dongia*ct.soluong)-(hh.dongia*ct.soluong*sk.giam)/100 as thanhtien, hd.tongtien from  CTHD ct, HANGHOA hh, SUKIEN sk, HOADON hd where ct.mahh = hh.mahh and hh.mask = sk.mask  and hd.mahd = ct.mahd and ct.mahd = '" + ma + "'  ";
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

        public bool AddDataCTHD(ChiTietHoaDonObj cthdObj)
        {

            cmd.CommandText = "Insert into CTHD values ('" + cthdObj.MaHoaDon + "',N'" + cthdObj.MaHangHoa + "', '" + cthdObj.SoLuong + "', '" + cthdObj.KhuyenMai + "', '" + cthdObj.DonGia + "', '" + cthdObj.ThanhTien + "')";
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

        public bool UpdDataCTHD(ChiTietHoaDonObj cthdObj)
        {

            cmd.CommandText = "Update CTHD set soluong = '" + cthdObj.SoLuong + "',thanhtien = '" + cthdObj.ThanhTien + "', Where mahh = '" + cthdObj.MaHangHoa + "' ";
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



        public bool DelDataCTHD(string mahh)
        {
            cmd.CommandText = "Delete CTHD Where mahh = '" + mahh + "'";
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
        /*
        public DataTable GetDonVi(string mahh)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = @"select hh.donvi from HANGHOA hh, SUKIEN sk where hh.mask = sk.mask and mahh = '" + mahh + "'";
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
        } */
        /*
        public DataTable GetDonGia(string mahh)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = @"select dongia from HANGHOA where mahh = '" + mahh + "'";
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
        */

        public DataTable GetDonGiaKhuyenmai(string mahh)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = @" select hh.dongia,sk.giam from  CTHD ct, HANGHOA hh, SUKIEN sk where ct.mahh = hh.mahh and hh.mask = sk.mask and mahd = '" + mahh + "'";
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
        


        public DataTable GetTongTien(string mahh)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = @"select sum((hh.dongia*ct.soluong)-(hh.dongia*ct.soluong*sk.giam)/100) as tongtien from  CTHD ct, HANGHOA hh, SUKIEN sk where ct.mahh = hh.mahh and hh.mask = sk.mask and mahd ='" + mahh+"' ";
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
