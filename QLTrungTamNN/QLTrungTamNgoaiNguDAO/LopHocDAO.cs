using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDAO
{
    internal class LopHocDAO
    {
        public List<LopHocDTO> LayDanhSachLopHoc()
        {
            List<LopHocDTO> lsLopHoc = new List<LopHocDTO>();
            string strTruyVan = "SELECT * FROM LOPHOC";
            SqlConnection sql = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, sql);
            while (sdr.Read())
            {
                LopHocDTO lh = new LopHocDTO();
                lh.MaLopHoc = sdr["MaLopHoc"].ToString();
                lh.TenLopHoc = sdr["TenLopHoc"].ToString();
                lh.MaKhoaHoc = sdr["MaKhoaHoc"].ToString();
                lh.MaNhanVien = sdr["MaNhanVien"].ToString();
                lh.NgayHoc = DateTime.Parse(sdr["NgayHoc"].ToString());
                lh.GioBatDau = sdr["GioBatDau"].ToString();
                lh.GioKetThuc = sdr["GioKetThuc"].ToString();
                lh.SoHocVienToiDa = int.Parse(sdr["SoHocVienToiDa"].ToString());
                lh.SoHocVienDaDK = int.Parse(sdr["SoHocVienDaDK"].ToString());
                lh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsLopHoc.Add(lh);
            }
            sdr.Close();
            sql.Close();
            return lsLopHoc;
        }

        public int themLH(LopHocDTO lh)
        {
            string strTruyVan = "Insert Into LOPHOC Values (@MA_LOP_HOC, @TEN_LOP_HOC, @MA_KHOA_HOC, @MA_NHAN_VIEN, @NGAY_HOC, @GIO_BAT_DAU, @SO_HOC_VIEN_TOI_DA, @SoHVToiDa, @SO_HOC_VIEN_DANG_KY, 1)";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@MA_LOP_HOC", lh.MaLopHoc);
            param[1] = new SqlParameter("@TEN_LOP_HOC", lh.TenLopHoc);
            param[2] = new SqlParameter("@MA_KHOA_HOC", lh.MaKhoaHoc);
            param[3] = new SqlParameter("@MA_NHAN_VIEN", lh.MaNhanVien);
            param[4] = new SqlParameter("@NGAY_HOC", lh.NgayHoc);
            param[5] = new SqlParameter("@GIO_BAT_DAU", lh.GioBatDau);
            param[6] = new SqlParameter("@GIO_KET_THUC", lh.GioKetThuc);
            param[7] = new SqlParameter("@SO_HOC_VIEN_TOI_DA", lh.SoHocVienToiDa);
            param[8] = new SqlParameter("@SO_HOC_VIEN_DANG_KY", lh.SoHocVienDaDK);
            int kq = Connection.thayDoiDuLieu(strTruyVan, param, conn);
            conn.Close();

            return kq;
        }

        public string layMaLHMax()
        {
            string strTruyVan = "SELECT MAX(MA_LOP_HOC) FROM LOPHOC";
            SqlConnection conn = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
            string ma = null;
            if (sdr.Read())
            {
                ma = sdr[0].ToString();
            }
            if (string.IsNullOrEmpty(ma))
            {
                return "LH000001";
            }
            int chuyenSo = int.Parse(ma.Replace("LH", ""));
            string maRes = "LH" + (chuyenSo + 1).ToString("000000");
            return maRes;
        }


        public List<LopHocDTO> layDanhSachLopTheoMaKH(string p)
        {
            List<LopHocDTO> lsLopHoc = new List<LopHocDTO>();
            string strTruyVan = "SELECT * FROM LOPHOC WHERE MA_KHOA_HOC = @MaKH";
            SqlConnection sql = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MaKH", p);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, sql);
            while (sdr.Read())
            {
                LopHocDTO lh = new LopHocDTO();
                lh.MaLopHoc = sdr["MaLopHoc"].ToString();
                lh.TenLopHoc = sdr["TenLopHoc"].ToString();
                lh.MaKhoaHoc = sdr["MaKhoaHoc"].ToString();
                lh.MaNhanVien = sdr["MaNhanVien"].ToString();
                lh.NgayHoc = DateTime.Parse(sdr["NgayHoc"].ToString());
                lh.GioBatDau = sdr["GioBatDau"].ToString();
                lh.GioKetThuc = sdr["GioKetThuc"].ToString();
                lh.SoHocVienToiDa = int.Parse(sdr["SoHocVienToiDa"].ToString());
                lh.SoHocVienDaDK = int.Parse(sdr["SoHocVienDaDK"].ToString());
                lh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsLopHoc.Add(lh);
            }
            sdr.Close();
            sql.Close();
            return lsLopHoc;
        }


        public List<LopHocDTO> layDanhSachLopTheoTenLH(string p)
        {
            List<LopHocDTO> lsLopHoc = new List<LopHocDTO>();
            string strTruyVan = "select * from LOPHOC where TEN_LOP_HOC = @TenLH";
            SqlConnection sql = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TenLH", p);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, sql);
            while (sdr.Read())
            {
                LopHocDTO lh = new LopHocDTO();
                lh.MaLopHoc = sdr["MaLopHoc"].ToString();
                lh.TenLopHoc = sdr["TenLopHoc"].ToString();
                lh.MaKhoaHoc = sdr["MaKhoaHoc"].ToString();
                lh.MaNhanVien = sdr["MaNhanVien"].ToString();
                lh.NgayHoc = DateTime.Parse(sdr["NgayHoc"].ToString());
                lh.GioBatDau = sdr["GioBatDau"].ToString();
                lh.GioKetThuc = sdr["GioKetThuc"].ToString();
                lh.SoHocVienToiDa = int.Parse(sdr["SoHocVienToiDa"].ToString());
                lh.SoHocVienDaDK = int.Parse(sdr["SoHocVienDaDK"].ToString());
                lh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsLopHoc.Add(lh);

            }
            sdr.Close();
            sql.Close();
            return lsLopHoc;
        }

        public int suaLopHoc(LopHocDTO lhHienTai)
        {
            string strTruyVan = "Update LOPHOC Set MA_NHAN_VIEN = @MA_NHAN_VIEN, NGAY_HOC = @NGAY_HOC, GIO_BAT_DAU = @GIO_BAT_DAU, GIO_KET_THUC = @GIO_KET_THUC, SO_HOC_VIEN_TOI_DA = @SO_HOC_VIEN_TOI_DA where MA_LOP_HOC = @MA_LOP_HOC";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@MA_NHAN_VIEN", lhHienTai.MaNhanVien);
            param[1] = new SqlParameter("@NGAY_HOC", lhHienTai.NgayHoc);
            param[2] = new SqlParameter("@GIO_BAT_DAU", lhHienTai.GioBatDau);
            param[3] = new SqlParameter("@GIO_KET_THUC", lhHienTai.GioKetThuc);
            param[4] = new SqlParameter("@SO_HOC_VIEN_TOI_DA", lhHienTai.SoHocVienToiDa);
            param[5] = new SqlParameter("@MA_LOP_HOC", lhHienTai.MaLopHoc);
            int kq = Connection.thayDoiDuLieu(strTruyVan, param, conn);
            conn.Close();

            return kq;
        }

        public List<LopHocDTO> layLHChuaKhaiGiang()
        {
            List<LopHocDTO> lsLopHoc = new List<LopHocDTO>();
            string strTruyVan = "select * from LOPHOC inner join KHOAHOC on LOPHOC.MA_KHOA_HOC = KHOAHOC.MA_KHOA_HOC where KHOAHOC.NGAY_KHAI_GIANG > GETDATE() and SO_HOC_VIEN_DANG_KY < SO_HOC_VIEN_TOI_DA";
            SqlConnection sql = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, sql);
            while (sdr.Read())
            {
                LopHocDTO lh = new LopHocDTO();
                lh.MaLopHoc = sdr["MaLopHoc"].ToString();
                lh.TenLopHoc = sdr["TenLopHoc"].ToString();
                lh.MaKhoaHoc = sdr["MaKhoaHoc"].ToString();
                lh.MaNhanVien = sdr["MaNhanVien"].ToString();
                lh.NgayHoc = DateTime.Parse(sdr["NgayHoc"].ToString());
                lh.GioBatDau = sdr["GioBatDau"].ToString();
                lh.GioKetThuc = sdr["GioKetThuc"].ToString();
                lh.SoHocVienToiDa = int.Parse(sdr["SoHocVienToiDa"].ToString());
                lh.SoHocVienDaDK = int.Parse(sdr["SoHocVienDaDK"].ToString());
                lh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsLopHoc.Add(lh);

            }
            sdr.Close();
            sql.Close();
            return lsLopHoc;
        }

        public int dangKyLop(string p1, string p2)
        {
            string maHD = layMaHDMax();

            string strTruyVan = "Insert Into HOADON Values (@MA_HOA_DON, @MA_LOP_HOC, @MA_HOC_VIEN, @NGAY_DANG_KY, @HOC_PHI, 1)";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@MA_HOA_DON", maHD);
            param[1] = new SqlParameter("@MA_LOP_HOC", p2);
            param[2] = new SqlParameter("@MA_HOC_VIEN", p1);
            param[3] = new SqlParameter("@NGAY_DANG_KY", DateTime.Now.ToShortDateString());
            param[4] = new SqlParameter("@HOC_PHI", layHocPhiLopHoc(p2));
            int kq = Connection.thayDoiDuLieu(strTruyVan, param, conn);
            conn.Close();

            int SoHVDK = laySoHVDangKy(p2);

            conn = Connection.GetConnection();
            strTruyVan = "Update LOPHOC Set SO_HOC_VIEN_DANG_KY = @SoHVDangKy";
            SqlParameter[] param1 = new SqlParameter[1];
            param1[0] = new SqlParameter("@SoHVDangKy", ++SoHVDK);
            kq += Connection.thayDoiDuLieu(strTruyVan, param1, conn);
            conn.Close();

            return kq;
        }

        public int laySoHVDangKy(string p2)
        {
            string strTruyVan = "Select SO_HOC_VIEN_DANG_KY from LOPHOC where MA_LOPC_HOC = @MaLH";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MaLH", p2);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, conn);
            int SoHVDK = 0;
            if (sdr.Read())
            {
                SoHVDK = int.Parse(sdr[0].ToString());
            }
            return SoHVDK;
        }

        private int layHocPhiLopHoc(string p2)
        {
            string strTruyVan = "Select HOC_PHI from KHOAHOC where MA_KHOA_HOC = (select MA_KHOA_HOC from LOPHOC where MA_LOP_HOC = @MaLH)";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MaLH", p2);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, conn);
            int hocphi = 0;
            if (sdr.Read())
            {
                hocphi = int.Parse(sdr[0].ToString());
            }
            return hocphi;
        }

        private string layMaHDMax()
        {
            string strTruyVan = "Select Max(MA_HOA_DON) from HOADON";
            SqlConnection conn = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
            string ma = null;
            if (sdr.Read())
            {
                ma = sdr[0].ToString();
            }
            if (string.IsNullOrEmpty(ma))
            {
                return "HD000001";
            }
            int chuyenSo = int.Parse(ma.Replace("HD", ""));
            string maRes = "HD" + (chuyenSo + 1).ToString("000000");
            return maRes;
        }

        public bool ktMaHV(string p)
        {
            string strTruyVan = "Select MA_HOC_VIEN from HOCVIEN where MA_HOC_VIEN = @MaHV";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MaHV", p);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, conn);
            string maHV = null;
            if (sdr.Read())
            {
                maHV = sdr[0].ToString();
            }
            return !string.IsNullOrEmpty(maHV);
        }
        public int laySoHVToiDa(string p)
        {
            string strTruyVan = "Select SO_HOC_VIEN_TOI_DA from LOPHOC where MA_LOP_HOC = @MaLH";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MaLH", p);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, conn);
            int SoHVTD = 0;
            if (sdr.Read())
            {
                SoHVTD = int.Parse(sdr[0].ToString());
            }
            return SoHVTD;
        }

        public List<LopHocDTO> layDSLopCuaGV(NhanVienDTO nhanVienDTO)
        {
            List<LopHocDTO> lsLopHoc = new List<LopHocDTO>();
            string strTruyVan = "select * from LOPHOC where MA_NHAN_VIEN = @MaNV";
            SqlConnection sql = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MaNV", nhanVienDTO.MaNhanVien);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, sql);
            while (sdr.Read())
            {
                LopHocDTO lh = new LopHocDTO();
                lh.MaLopHoc = sdr["MaLopHoc"].ToString();
                lh.TenLopHoc = sdr["TenLopHoc"].ToString();
                lh.MaKhoaHoc = sdr["MaKhoaHoc"].ToString();
                lh.MaNhanVien = sdr["MaNhanVien"].ToString();
                lh.NgayHoc = DateTime.Parse(sdr["NgayHoc"].ToString());
                lh.GioBatDau = sdr["GioBatDau"].ToString();
                lh.GioKetThuc = sdr["GioKetThuc"].ToString();
                lh.SoHocVienToiDa = int.Parse(sdr["SoHocVienToiDa"].ToString());
                lh.SoHocVienDaDK = int.Parse(sdr["SoHocVienDaDK"].ToString());
                lh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsLopHoc.Add(lh);

            }
            sdr.Close();
            sql.Close();
            return lsLopHoc;
        }

        public bool ktHVDaDK(string p1, string p2)
        {
            string strTruyVan = "Select MA_HOC_VIEN from HOADON where MA_HOC_VIEN = @MaHV and MA_LOP_HOC = @MaLH";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@MaHV", p1);
            param[1] = new SqlParameter("@MaLH", p2);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, conn);
            string maHV = null;
            if (sdr.Read())
            {
                maHV = sdr[0].ToString();
            }
            return string.IsNullOrEmpty(maHV);
        }
    }
}
