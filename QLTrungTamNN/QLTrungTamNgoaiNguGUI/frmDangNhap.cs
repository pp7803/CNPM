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

        private void linkLabelDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy dangKy = new frmDangKy();
            dangKy.ShowDialog();
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = textBoxTenTK.Text;
            string mk = textBoxMatKhau.Text;
            if (tenTK.Trim() == "" || mk.Trim() == "")
            {
                MessageBox.Show("Chưa nhập thông tin tài khoản");
            }
            else
            {
                try
                {
                    TaiKhoanBUS tkBUS = new TaiKhoanBUS();
                    TaiKhoanDTO tkDangNhap = tkBUS.ktDangNhap(tenTK, mk);
                    if (tkDangNhap == null)
                    {
                        MessageBox.Show("Không tìm thấy tài khoản");
                        return;
                    }

                    NhanVienBUS nvBUS = new NhanVienBUS();
                    nvDangNhap = nvBUS.thongTinNhanVien(tkDangNhap);
                    if (nvDangNhap == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin nhân viên tương ứng");
                        return;
                    }

                    MessageBox.Show("Đăng nhập thành công");
                    frmMain f = new frmMain();
                    f.ShowDialog();
                    f.setDangNhapThanhCong(nvDangNhap);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}