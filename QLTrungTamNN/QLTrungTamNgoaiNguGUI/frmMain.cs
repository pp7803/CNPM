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

namespace QLTrungTamNN.QLTrungTamNgoaiNguGUI
{
    public partial class frmMain : Form
    {
        bool sidebarExpand;
        bool isDangNhap = false;
        NhanVienDTO nvDangNhap;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }
         
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
        
        internal void setDangNhapThanhCong(NhanVienDTO nv)
        {
            isDangNhap = true;
            nvDangNhap = nv;
            labelperson.Text = "Hi, " + nvDangNhap.Ten;
            if (nvDangNhap.MaLoaiNhanVien == "LNV01") //quản lý
            {
                buttonHome.Enabled = true;
                buttonKhoaHoc.Enabled = true;
                buttonLopHoc.Enabled = true;
                buttonGiaoVien.Enabled = true;
                buttonDiem.Enabled = true;
                buttonHoaDon.Enabled = true;
                buttontquanly.Enabled = true;
                buttonDangXuat.Enabled = true;
                buttonthongtin.Enabled = true;
                buttonhocvien.Enabled = true;
            }
            else if (nvDangNhap.MaLoaiNhanVien == "LNV02") //giảng viên
            {
                buttonHome.Enabled = true;
                buttonKhoaHoc.Enabled = false;
                buttonLopHoc.Enabled = true;
                buttonGiaoVien.Enabled = true;
                buttonDiem.Enabled = true;
                buttonHoaDon.Enabled = false;
                buttontquanly.Enabled = false;
                buttonDangXuat.Enabled = true;
                buttonthongtin.Enabled=true;
                buttonhocvien.Enabled=true;
            }
            else //Nhân viên
            {
                buttonHome.Enabled = true;
                buttonKhoaHoc.Enabled = false;
                buttonLopHoc.Enabled = true;
                buttonGiaoVien.Enabled = false;
                buttonDiem.Enabled = false;
                buttonHoaDon.Enabled = true;
                buttontquanly.Enabled = false;
                buttonDangXuat.Enabled = true;
                buttonthongtin.Enabled=true;
                buttonhocvien.Enabled=true;
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {

        }

        private void buttonhocvien_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHocVien frmHocVien = new frmHocVien();
            frmHocVien.ShowDialog();

            this.Close();
        }
    }
}
