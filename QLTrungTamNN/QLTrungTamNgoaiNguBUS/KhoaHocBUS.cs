using QLTrungTamNN.QLTrungTamNgoaiNguDAO;
using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguBUS
{
    internal class KhoaHocBUS
    {
        public List<KhoaHocDTO> DanhSachKhoaHoc()
        {
            KhoaHocDAO kh = new KhoaHocDAO();
            return kh.LayDanhSachKhoaHoc();
        }

        public int themKH(KhoaHocDTO kh)
        {
            KhoaHocDAO khDAO = new KhoaHocDAO();
            return khDAO.themKH(kh);
        }

        public string maKHMax()
        {
            KhoaHocDAO khDAO = new KhoaHocDAO();
            return khDAO.layMaKHMax();
        }

        public List<KhoaHocDTO> dsKHChuaDuLop()
        {
            KhoaHocDAO khDAO = new KhoaHocDAO();
            return khDAO.layDSKHChuaDuLop();
        }

        public List<KhoaHocDTO> timKiemKhoaHocTheoMa(string p)
        {
            return (new KhoaHocDAO()).timKiemKhoaHocTheoMa(p);
        }

        public List<KhoaHocDTO> timKiemKhoaHocTheoLoai(string p)
        {
            return (new KhoaHocDAO()).timKiemKhoaHocTheoLoai(p);
        }

        public int suaThongTinKH(KhoaHocDTO khHienTai)
        {
            return (new KhoaHocDAO()).suaThongTinKH(khHienTai);
        }

        public List<KhoaHocDTO> DanhSachKHTheoThang(int thang, int nam)
        {
            return (new KhoaHocDAO()).layDSKHTheoThang(thang, nam);
        }
    }
}
