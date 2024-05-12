using QLTrungTamNN.QLTrungTamNgoaiNguDAO;
using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguBUS
{
    internal class TaiKhoanBUS
    {
        public TaiKhoanDTO ktDangNhap(string strTaiKhoan, string strMatKhau)
        {
            TaiKhoanDAO tkDAO = new TaiKhoanDAO();
            return tkDAO.dangNhap(strTaiKhoan, strMatKhau);
        }

        public List<TaiKhoanDTO> dsTaiKhoan()
        {
            TaiKhoanDAO tkDAO = new TaiKhoanDAO();
            return tkDAO.layDSTaiKhoan();
        }

        public int doiMatKhau(string tk, string mk, string em)
        {
            TaiKhoanDAO tkDAO = new TaiKhoanDAO();
            return tkDAO.doiMatKhau(tk, mk, em);
        }

        public int themTK(string tk, string mk, string em)
        {
            TaiKhoanDAO tkDAO = new TaiKhoanDAO();
            return tkDAO.themTK(tk, mk , em);
        }


    }
}
