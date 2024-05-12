using QLTrungTamNN.QLTrungTamNgoaiNguDAO;
using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguBUS
{
    internal class LopHocBUS
    {
        public List<LopHocDTO> DanhSachLopHoc()
        {
            LopHocDAO lh = new LopHocDAO();
            return lh.LayDanhSachLopHoc();
        }

        public int themLH(LopHocDTO lh)
        {
            LopHocDAO lhDAO = new LopHocDAO();
            return lhDAO.themLH(lh);
        }

        public string maLHMax()
        {
            LopHocDAO lhDAO = new LopHocDAO();
            return lhDAO.layMaLHMax();
        }

        public List<LopHocDTO> DanhSachLopTheoMaKH(string p)
        {
            return (new LopHocDAO()).layDanhSachLopTheoMaKH(p);
        }

        public List<LopHocDTO> DanhSachLopTheoTenLH(string p)
        {
            return (new LopHocDAO()).layDanhSachLopTheoTenLH(p);
        }

        public int suaLopHoc(LopHocDTO lhHienTai)
        {
            return (new LopHocDAO()).suaLopHoc(lhHienTai);
        }

        public List<LopHocDTO> layLHChuaKhaiGiang()
        {
            return (new LopHocDAO()).layLHChuaKhaiGiang();
        }
        public int DangKyLop(string p1, string p2)
        {
            return (new LopHocDAO()).dangKyLop(p1, p2);
        }

        public bool ktMaHV(string p)
        {
            return (new LopHocDAO()).ktMaHV(p);
        }

        public bool ktSoHVDKVaSoHVToiDa(string p)
        {
            return (new LopHocDAO()).laySoHVDangKy(p) <= (new LopHocDAO()).laySoHVToiDa(p);
        }

        public List<LopHocDTO> layDSLopHocCuaGV(NhanVienDTO nhanVienDTO)
        {
            return (new LopHocDAO()).layDSLopCuaGV(nhanVienDTO);
        }

        public bool ktHVDaDK(string p1, string p2)
        {
            return (new LopHocDAO()).ktHVDaDK(p1, p2);
        }
    }
}
