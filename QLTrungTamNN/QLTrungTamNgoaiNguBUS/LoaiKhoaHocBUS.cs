using QLTrungTamNN.QLTrungTamNgoaiNguDAO;
using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguBUS
{
    internal class LoaiKhoaHocBUS
    {
        public List<LoaiKhoaHocDTO> DanhSachLoaiKhoaHoc()
        {
            LoaiKhoaHocDAO lkh = new LoaiKhoaHocDAO();
            return lkh.LayDanhSachLoaiKhoaHoc();
        }

        public string LoaiKHTheoMaKH(string p)
        {
            KhoaHocDAO khDAO = new KhoaHocDAO();
            return khDAO.layLoaiKHTheoMa(p);
        }
    }
}
