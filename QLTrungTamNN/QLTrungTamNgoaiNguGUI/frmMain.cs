﻿using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
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
            this.IsMdiContainer = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            f.MdiParent = this;
            f.Dock = DockStyle.Top;
            f.Show();
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

        internal void setDangNhapThanhCong(string nv)
        {
            isDangNhap = true;
            if (nv.Equals("LNV001"))
            {
                buttonHome.Enabled = true;
                buttonKhoaHoc.Enabled = true;
                buttonLopHoc.Enabled = true;
                buttonGiaoVien.Enabled = true;
                buttonDiem.Enabled = true;
                buttonHoaDon.Enabled = true;
                buttonthongTin.Enabled = true;
                buttonDangXuat.Enabled = true;
            }
            else if (nv.Equals("LNV002"))
            {
                buttonHome.Enabled = true;
                buttonKhoaHoc.Enabled = true;
                buttonLopHoc.Enabled = true;
                buttonGiaoVien.Enabled = true;
                buttonDiem.Enabled = true;
                buttonHoaDon.Enabled = false;
                buttonthongTin.Enabled = true;
                buttonDangXuat.Enabled = true;
            }
            else if (nv.Equals("LNV003"))
            {
                buttonHome.Enabled = true;
                buttonKhoaHoc.Enabled = true;
                buttonLopHoc.Enabled = true;
                buttonGiaoVien.Enabled = true;
                buttonDiem.Enabled = true;
                buttonHoaDon.Enabled = false;
                buttonthongTin.Enabled = true;
                buttonDangXuat.Enabled = true;
            }
            else
            {
                buttonHome.Enabled = true;
                buttonKhoaHoc.Enabled = true;
                buttonLopHoc.Enabled = true;
                buttonGiaoVien.Enabled = true;
                buttonDiem.Enabled = true;
                buttonHoaDon.Enabled = true;
                buttonthongTin.Enabled = true;
                buttonDangXuat.Enabled = true;
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {

        }
    }
}
