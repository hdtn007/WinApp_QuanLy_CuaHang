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
    class NhaCungCapMod
    {

        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetMaNCC()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select MAX(mancc) from NCC";
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

        public DataTable GetDataNCC()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select mancc, tenncc, diachi, sdt, ghichu  from NCC";
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

        public bool AddDataNCC(NhaCungCapObj nccObj)
        {

            cmd.CommandText = "Insert into NCC values ('" + nccObj.MaNhaCungCap + "',N'" + nccObj.TenNhaCungCap + "',N'" + nccObj.DiaChi + "','" + nccObj.SoDienThoai + "',N'" + nccObj.GhiChu + "')";
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

        public bool UpdDataNCC(NhaCungCapObj nccObj)
        {

            cmd.CommandText = "Update NCC set tenncc =  N'" + nccObj.TenNhaCungCap + "', diachi = N'" + nccObj.DiaChi + "', sdt = '" + nccObj.SoDienThoai + "', ghichu =N'" + nccObj.GhiChu + "' Where mancc = '" + nccObj.MaNhaCungCap + "'";
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

        public bool DelDataNCC(string ma)
        {
            cmd.CommandText = "Delete THONGKE from HANGHOA hh, NCC nc Where  THONGKE.mahh= hh.mahh and hh.mancc=nc.mancc and nc.mancc = '" + ma + "'; Delete CTHD from HANGHOA hh, NCC nc Where nc.mancc=hh.mancc and hh.mahh = CTHD.mahh and nc.mancc = '" + ma + "';Delete HANGHOA Where mancc = '" + ma + "'; Delete NCC Where mancc = '" + ma + "' ";
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
