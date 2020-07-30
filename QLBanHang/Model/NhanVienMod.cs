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
    class NhanVienMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetMANV()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select MAX(manv)manv from NHANVIEN ";
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

        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select manv, tennv, gioitinh, ngaysinh, diachi, sdt, cmnd, email, ghichu  from NHANVIEN";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.CloseConn();
            }
            catch(Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }

            return dt;
        }

        public bool AddData(NhanVienObj nvObj)
        {

            cmd.CommandText = "Insert into NHANVIEN values ('" + nvObj.MaNhanVien + "',N'" + nvObj.TenNhanVien + "',N'" + nvObj.GioiTinh + "',CONVERT(DATE,'" + nvObj.NgaySinh + "',103),N'" + nvObj.DiaChi + "','" + nvObj.SDT + "','" + nvObj.CMND + "','" + nvObj.Email + "',N'" + nvObj.GhiChu + "')";
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

        public bool UpdData(NhanVienObj nvObj)
        {

            cmd.CommandText = "Update NHANVIEN set tennv =  N'" + nvObj.TenNhanVien + "', gioitinh = N'" + nvObj.GioiTinh + "', ngaysinh = CONVERT(DATE,'" + nvObj.NgaySinh + "',103), diachi = N'" + nvObj.DiaChi + "',sdt = '" + nvObj.SDT + "',cmnd = '" + nvObj.CMND + "', email = '" + nvObj.Email + "', ghichu =N'" + nvObj.GhiChu + "' Where manv = '" + nvObj.MaNhanVien + "'";
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
            cmd.CommandText = "Delete PHANQUYEN Where manv='" + ma + "'; Delete NHANVIEN Where manv = '" + ma + "' "; // xóa bản nhiều trước
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
