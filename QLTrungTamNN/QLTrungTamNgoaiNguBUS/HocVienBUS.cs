using QLTrungTamNN.QLTrungTamNgoaiNguDAO;
using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguBUS
{
    internal class HocVienBUS
    {
        public List<HocVienDTO> LayDSHV()
        {
            HocVienDAO hvDAO = new HocVienDAO();
            return hvDAO.LayDanhSachHocVien();
        }
        public int themHocVien(HocVienDTO hv)
        {
            HocVienDAO hvADD = new HocVienDAO();
            return hvADD.themHV(hv);
        }
        public int suaHocVien(HocVienDTO hvHienTai)
        {
            return (new HocVienDAO()).suaHocVien(hvHienTai);
        }

        public string maHVMax()
        {
            HocVienDAO hvDAO = new HocVienDAO();
            return hvDAO.layMaHVMax();
        }

        public List<HocVienBangDiemDTO> layDSHVCuaMotLop(string p)
        {
            return (new HocVienDAO()).layDSHVCuaMotLop(p);
        }
        public List<HocVienDTO> DanhSachHVTheoMa(string m)
        {
            return (new HocVienDAO()).LayDanhSachHocVienTheoMa(m);
        }

        public List<HocVienDTO> DanhSachHVTheoTen(string t)
        {
            return (new HocVienDAO()).LayDanhSachHocVienTheoTen(t);
        }

        public List<HocVienDTO> LayDSHVTheoThang(int thang, int nam)
        {
            return (new HocVienDAO()).LayDSHVTheoThang(thang, nam);
        }

        public int SuaDiem(List<HocVienBangDiemDTO> lsHocVienDiem, string maLH)
        {
            return (new HocVienDAO()).suaDiem(lsHocVienDiem, maLH);
        }
    }
}
