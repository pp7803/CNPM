using QLTrungTamNN.QLTrungTamNgoaiNguDAO;
using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguBUS
{
    internal class HoaDonBUS
    {
        public List<HoaDonDTO> DanhSachHoaDon()
        {
            return (new HoaDonDAO()).layDSHD();
        }
    }
}
