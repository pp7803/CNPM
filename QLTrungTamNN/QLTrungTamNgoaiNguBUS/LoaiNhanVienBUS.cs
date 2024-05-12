using QLTrungTamNN.QLTrungTamNgoaiNguDAO;
using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguBUS
{
    internal class LoaiNhanVienBUS
    {
        public List<LoaiNhanVienDTO> LayDSLoaiNV()
        {
            LoaiNhanVienDAO lnv = new LoaiNhanVienDAO();
            return lnv.LayDanhSachLoaiNV();

        }
    }
}
