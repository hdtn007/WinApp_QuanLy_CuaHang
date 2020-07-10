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
    class HangHoaMod
    {

        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetMaHH()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = @"select MAX(mahh)mahh from HANGHOA";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                // con.CloseConn();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }

            return dt;
        }

        public DataTable GetDataHH()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = @"select hh.mahh, hh.tenhh, hh.gianhap, hh.dongia, hh.tonkho, hh.donvi, hh.daban, ncc.tenncc, loai.tenloai, sk.tensk, sk.giam, hh.ghichu  from HANGHOA hh, NCC ncc, SUKIEN sk, LOAIHH loai where hh.mancc=ncc.mancc and hh.maloai=loai.maloai and hh.mask=sk.mask";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
               // con.CloseConn();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }

            return dt;
        }

        public bool AddDataHH(HangHoaObj hhObj)
        {

            cmd.CommandText = "Insert into HANGHOA values ('" + hhObj.MaHangHoa + "',N'" + hhObj.TenHangHoa + "','" + hhObj.GiaNhap + "','" + hhObj.DonGia + "','" + hhObj.TonKho + "',N'" + hhObj.DonVi + "','" + hhObj.DaBan + "',N'" + hhObj.NhaCungCap + "',N'" + hhObj.LoaiHangHoa + "',N'" + hhObj.KhuyenMai + "',N'" + hhObj.GhiChu + "')";
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

        public bool UpdDataHH(HangHoaObj hhObj)
        {

            cmd.CommandText = "Update HANGHOA set tenhh =  N'" + hhObj.TenHangHoa + "', gianhap = '" + hhObj.GiaNhap + "', dongia = '" + hhObj.DonGia + "', tonkho = N'" + hhObj.TonKho + "',donvi = N'" + hhObj.DonVi + "',daban = '" + hhObj.DaBan + "', mancc = '" + hhObj.NhaCungCap + "', maloai = '" + hhObj.LoaiHangHoa + "', mask = '" + hhObj.KhuyenMai + "', ghichu =N'" + hhObj.GhiChu + "' Where mahh = '" + hhObj.MaHangHoa + "'";
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


        public bool UpdDaBan(HangHoaObj hhObj)
        {
            cmd.CommandText = "Update HANGHOA set Diem ='" + hhObj.DaBan + "' Where mahh = '" + hhObj.MaHangHoa + "'";
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




        public bool DelDataHH(string ma)
        {
            cmd.CommandText = "Delete HANGHOA Where mahh = '" + ma + "'";
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
