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
                        MessageBox.Show("Vui lòng kiểm tra lại tài khoản");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thành công");
                        frmMain f = new frmMain();
                        f.MdiParent = this.MdiParent; // Đặt frmMain là con của MdiParent của frmDangNhap
                        f.Show();
                        if (tenTK.Equals("abc123") && mk.Equals("abc123"))
                        {
                            f.setDangNhapThanhCong("LNV001");
                        }
                        else
                        {
                            NhanVienBUS nvBUS = new NhanVienBUS();
                            nvDangNhap = nvBUS.thongTinNhanVien(tkDangNhap);
                            f.setDangNhapThanhCong(nvDangNhap.MaLoaiNhanVien);
                        }
                        this.Close();
                    }
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