using QLTrungTamNN.QLTrungTamNgoaiNguDAO;
using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguBUS
{
    internal class NhanVienBUS
    {
        public List<NhanVienDTO> LayDSNhanVien()
        {
            NhanVienDAO nvDAO = new NhanVienDAO();
            return nvDAO.LayDanhSachNhanVien();

        }
        public int themmoiNV(NhanVienDTO nvDTO)
        {
            NhanVienDAO nvDAO = new NhanVienDAO();
            return nvDAO.themNV(nvDTO);
        }

        public string maNVMax()
        {
            NhanVienDAO nvDAO = new NhanVienDAO();
            return nvDAO.layMaNVMax();
        }
        public NhanVienDTO thongTinNhanVien(TaiKhoanDTO tk)
        {
            NhanVienDAO nvDAO = new NhanVienDAO();
            return nvDAO.layThongTinNhanVien(tk);
        }
        public List<string> dsMaNVChuaCoTK()
        {
            NhanVienDAO nvDAO = new NhanVienDAO();
            return nvDAO.layMaNVChuaCoTK();
        }

        public List<NhanVienDTO> DanhSachGiangVien()
        {
            NhanVienDAO nv = new NhanVienDAO();
            return nv.LayDanhSachGiangVien();
        }
        public List<NhanVienDTO> timKiemKhoaHocTheoMa(string m)
        {
            return (new NhanVienDAO()).LayDanhNVTheoMa(m);
        }

        public List<NhanVienDTO> timKiemKhoaHocTheoLoai(string l)
        {
            return (new NhanVienDAO()).LayDanhNVTheoLoai(l);
        }

        public string maNVMax(string p)
        {
            return (new NhanVienDAO()).layMaNVMax(p);
        }

        public int suaNhanVien(NhanVienDTO nvHienTai)
        {
            return (new NhanVienDAO()).suaNhanVien(nvHienTai);
        }
    }
}
