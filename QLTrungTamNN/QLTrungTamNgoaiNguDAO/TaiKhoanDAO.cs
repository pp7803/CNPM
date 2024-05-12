using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDAO
{
    internal class TaiKhoanDAO
    {
        public TaiKhoanDTO dangNhap(string strTK, string strMK)
        {
            TaiKhoanDTO taiKhoanKQ = null;

            string strTruyVanTK = "Select * From TAIKHOAN Where TAI_KHOAN = @TaiKhoan And MAT_KHAU = @MatKhau And TINH_TRANG = 1";
            SqlParameter[] paramTK = new SqlParameter[2];
            paramTK[0] = new SqlParameter("@TaiKhoan", strTK);
            paramTK[1] = new SqlParameter("@MatKhau", strMK);
            SqlConnection conn = Connection.GetConnection();
            conn.Open();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVanTK, paramTK, conn);
            
            if (sdr.Read())
            {
                taiKhoanKQ = new TaiKhoanDTO();
                taiKhoanKQ.TaiKhoan = sdr["TAI_KHOAN"].ToString();
            }
            sdr.Close();
            conn.Close();

            return taiKhoanKQ;
        }

        public List<TaiKhoanDTO> layDSTaiKhoan()
        {
            List<TaiKhoanDTO> dsTaiKhoan = new List<TaiKhoanDTO>();

            string strTruyVan = "Select * From TAIKHOAN where TINH_TRANG = 1";
            SqlConnection conn = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
            while (sdr.Read())
            {
                TaiKhoanDTO tk = new TaiKhoanDTO();
                tk.TaiKhoan = sdr["TaiKhoan"].ToString();
                tk.MatKhau = sdr["MatKhau"].ToString();
                tk.Email = sdr["Email"].ToString();
                tk.TinhTrang = int.Parse(sdr["TrangThai"].ToString());
                dsTaiKhoan.Add(tk);
            }
            sdr.Close();
            conn.Close();

            return dsTaiKhoan;
        }

        public int doiMatKhau(string tk, string mk, string em)
        {
            string strTruyVan = "Update TAIKHOAN Set MATKHAU = @matkhau where EMAIL = @email";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@matkhau", mk);
            param[1] = new SqlParameter("@email", em);
            int kq = Connection.thayDoiDuLieu(strTruyVan, param, conn);
            conn.Close();

            return kq;
        }

        public int themTK(string tk, string mk, string em)
        {
            string strTruyVan = "Insert Into TAIKHOAN Values (@taikhoan, @matkhau, @email, 1)";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@taikhoan", tk);
            param[1] = new SqlParameter("@matkhau", mk);
            param[2] = new SqlParameter("@email", em);
            int kq = Connection.thayDoiDuLieu(strTruyVan, param, conn);
            conn.Close();

            return kq;
        }


    }
}
