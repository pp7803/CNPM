using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using QLTrungTamNN.QLTrungTamNgoaiNguBUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTrungTamNN.QLTrungTamNgoaiNguGUI
{
    public partial class frmDangNhap : Form
    {
        NhanVienDTO nvDangNhap;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void linkLabelQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuenMatKhau quenMatKhau = new frmQuenMatKhau();
            quenMatKhau.ShowDialog();
        }


        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = textBoxTenTK.Text;
            string mk = textBoxMatKhau.Text;
            if (tenTK.Trim() == "")
            {
                MessageBox.Show("Chưa nhập thông tin tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (mk.Trim() == "")
            {
                MessageBox.Show("Chưa nhập thông tin mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TaiKhoanBUS tkBUS = new TaiKhoanBUS();
                TaiKhoanDTO tkDangNhap = tkBUS.ktDangNhap(tenTK,mk);
                NhanVienBUS nvBUS = new NhanVienBUS();
                nvDangNhap = nvBUS.thongTinNhanVien(tkDangNhap);
                if (nvDangNhap != null)
                {
                    MessageBox.Show("Đăng nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    frmMain f = new frmMain();
                    f.setDangNhapThanhCong(nvDangNhap);
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}