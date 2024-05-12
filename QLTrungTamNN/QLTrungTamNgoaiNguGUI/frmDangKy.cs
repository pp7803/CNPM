using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using QLTrungTamNN.QLTrungTamNgoaiNguDAO;

namespace QLTrungTamNN.QLTrungTamNgoaiNguGUI
{
    
    public partial class frmDangKy : Form
    {
        NhanVienDTO nvDangNhap;
        TaiKhoanDAO tkDAO;
        public frmDangKy()
        {
            InitializeComponent();
            tkDAO = new TaiKhoanDAO();
        }


        private void frmDangKy_Load(object sender, EventArgs e)
        {

        }

        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            string tk = textBoxTenTK.Text;
            string mk = textBoxMatKhau.Text;
            string xnmk = textBoxXNMK.Text;
            string em = textBoxEmail.Text;

            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk) || string.IsNullOrEmpty(xnmk) || string.IsNullOrEmpty(em))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (mk != xnmk)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!KiemTraMatKhau(mk))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 kí tự gồm chữ và số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                tkDAO.themTK(tk, mk, em);
                MessageBox.Show("Đăng ký tài khoản thành công");
            }

        }
        private bool KiemTraMatKhau(string matKhau)
        {
            string pattern = @"^(?=.*[a-zA-Z])(?=.*\d).{6}$"; // Mật khẩu phải có ít nhất một chữ cái và một số, và có tổng cộng 6 kí tự
            return Regex.IsMatch(matKhau, pattern);
        }
    }
}
