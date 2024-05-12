using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDAO
{
    internal class KhoaHocDAO
    {
        public List<KhoaHocDTO> LayDanhSachKhoaHoc()
        {
            List<KhoaHocDTO> lsKhoaHoc = new List<KhoaHocDTO>();
            string strTruyVan = "select * from KHOAHOC";
            SqlConnection sql = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, sql);
            while (sdr.Read())
            {
                KhoaHocDTO kh = new KhoaHocDTO();
                kh.MaKhoaHoc = sdr["MaKhoaHoc"].ToString();
                kh.MaLoaiKhoaHoc = sdr["MaLoaiKhoaHoc"].ToString();
                kh.TenKhoaHoc = sdr["TenKhoaHoc"].ToString();
                kh.NgayKhaiGiang = DateTime.Parse(sdr["NgayKhaiGiang"].ToString());
                kh.NgayKetThuc = DateTime.Parse(sdr["NgayKetThuc"].ToString());
                kh.SoLop = int.Parse(sdr["SoLop"].ToString());
                kh.HocPhi = int.Parse(sdr["HocPhi"].ToString());
                kh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsKhoaHoc.Add(kh);

            }
            sdr.Close();
            sql.Close();
            return lsKhoaHoc;
        }

        public int themKH(KhoaHocDTO kh)
        {
            string strTruyVan = "Insert Into KHOAHOC Values (@MA_KHOA_HOC, @LOAI_KHOA_HOC,@TEN_KHOA_HOC, @NGAY_KHAI_GIANG, @NGAY_KET_THUC, @SO_LOP, @HOC_PHI, 1)";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@MA_KHOA_HOC", kh.MaKhoaHoc);
            param[1] = new SqlParameter("@MA_LOAI_KHOA_HOC", kh.MaLoaiKhoaHoc);
            param[2] = new SqlParameter("@TEN_KHOA_HOC", kh.TenKhoaHoc);
            param[3] = new SqlParameter("@NgayKhaiGiang", kh.NgayKhaiGiang);
            param[4] = new SqlParameter("@NgayKetThuc", kh.NgayKetThuc);
            param[5] = new SqlParameter("@SoLop", kh.SoLop);
            param[6] = new SqlParameter("@HocPhi", kh.HocPhi);
            int kq = Connection.thayDoiDuLieu(strTruyVan, param, conn);
            conn.Close();

            return kq;
        }

        public string layMaKHMax()
        {
            string strTruyVan = "Select Max(MA_KHOA_HOC) from KHOAHOC";
            SqlConnection conn = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
            string ma = null;
            if (sdr.Read())
            {
                ma = sdr[0].ToString();
            }
            if (string.IsNullOrEmpty(ma))
            {
                return "KH000001";
            }
            int chuyenSo = int.Parse(ma.Replace("KH0", ""));
            string maRes = "KH0" + (chuyenSo + 1).ToString("00000");
            return maRes;
        }

        public List<KhoaHocDTO> layDSKHChuaDuLop()
        {
            List<KhoaHocDTO> lsRes = new List<KhoaHocDTO>();
            string strTruyVan = "select * from KHOAHOC where MA_KHOA_HOC not in (select MA_KHOA_HOC from LOPHOC group by MA_KHOA_HOC)";
            SqlConnection conn = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
            while (sdr.Read())
            {
                KhoaHocDTO kh = new KhoaHocDTO();
                kh.MaKhoaHoc = sdr["MaKhoaHoc"].ToString();
                kh.MaLoaiKhoaHoc = sdr["MaLoaiKhoaHoc"].ToString();
                kh.TenKhoaHoc = sdr["TenKhoaHoc"].ToString();
                kh.NgayKhaiGiang = DateTime.Parse(sdr["NgayKhaiGiang"].ToString());
                kh.NgayKetThuc = DateTime.Parse(sdr["NgayKetThuc"].ToString());
                kh.SoLop = int.Parse(sdr["SoLop"].ToString());
                kh.HocPhi = int.Parse(sdr["HocPhi"].ToString());
                kh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsRes.Add(kh);
            }
            sdr.Close();
            conn.Close();

            strTruyVan = "select * from KHOAHOC where MA_KHOA_HOC in (select LOPHOC.MA_KHOA_HOC from LOPHOC inner join KHOAHOC on LOPHOC.MA_KHOA_HOC = KHOAHOC.MA_KHOA_HOC group by LOPHOC.MA_KHOA_HOC, KHOAHOC.SO_LOP having count(*) < KHOAHOC.SO_LOP)";
            conn = Connection.GetConnection();
            sdr = Connection.truyVanDuLieu(strTruyVan, conn);
            while (sdr.Read())
            {
                KhoaHocDTO kh = new KhoaHocDTO();
                kh.MaKhoaHoc = sdr["MaKhoaHoc"].ToString();
                kh.MaLoaiKhoaHoc = sdr["MaLoaiKhoaHoc"].ToString();
                kh.TenKhoaHoc = sdr["TenKhoaHoc"].ToString();
                kh.NgayKhaiGiang = DateTime.Parse(sdr["NgayKhaiGiang"].ToString());
                kh.NgayKetThuc = DateTime.Parse(sdr["NgayKetThuc"].ToString());
                kh.SoLop = int.Parse(sdr["SoLop"].ToString());
                kh.HocPhi = int.Parse(sdr["HocPhi"].ToString());
                kh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsRes.Add(kh);
            }
            sdr.Close();
            conn.Close();

            return lsRes;
        }

        public string layLoaiKHTheoMa(string p)
        {
            string tenLoai = null;
            string strTruyVan = "SELECT TEN_KHOA_HOC FROM LOAI_KHOA_HOC INNER JOIN KHOAHOC ON LOAI_KHOA_HOC.MA_LOAI_KHOA_HOC = KHOAHOC.MA_LOAI_KHOA_HOC WHERE KHOAHOC.MA_KHOA_HOC = @MA_KHOA_HOC";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MA_KHOA_HOC", p);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, conn);
            if (sdr.Read())
            {
                tenLoai = sdr[0].ToString();
            }

            return tenLoai;
        }


        public List<KhoaHocDTO> timKiemKhoaHocTheoMa(string p)
        {
            List<KhoaHocDTO> lsKhoaHoc = new List<KhoaHocDTO>();
            string strTruyVan = "SELECT * FROM KHOAHOC WHERE MA_KHOA_HOC LIKE @MaKH";
            SqlConnection sql = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MaKH", "%" + p + "%");
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, sql);
            while (sdr.Read())
            {
                KhoaHocDTO kh = new KhoaHocDTO();
                kh.MaKhoaHoc = sdr["MaKhoaHoc"].ToString();
                kh.MaLoaiKhoaHoc = sdr["MaLoaiKhoaHoc"].ToString();
                kh.TenKhoaHoc = sdr["TenKhoaHoc"].ToString();
                kh.NgayKhaiGiang = DateTime.Parse(sdr["NgayKhaiGiang"].ToString());
                kh.NgayKetThuc = DateTime.Parse(sdr["NgayKetThuc"].ToString());
                kh.SoLop = int.Parse(sdr["SoLop"].ToString());
                kh.HocPhi = int.Parse(sdr["HocPhi"].ToString());
                kh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsKhoaHoc.Add(kh);
            }
            sdr.Close();
            sql.Close();
            return lsKhoaHoc;
        }


        public List<KhoaHocDTO> timKiemKhoaHocTheoLoai(string p)
        {
            List<KhoaHocDTO> lsKhoaHoc = new List<KhoaHocDTO>();
            string strTruyVan = "SELECT * FROM KHOAHOC WHERE MA_LOAI_KHOA_HOC = (SELECT MA_LOAI_KHOA_HOC FROM LOAI_KHOA_HOC WHERE TEN_KHOA_HOC = @TenKh)";
            SqlConnection sql = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TenKh", p);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, sql);
            while (sdr.Read())
            {
                KhoaHocDTO kh = new KhoaHocDTO();
                kh.MaKhoaHoc = sdr["MaKhoaHoc"].ToString();
                kh.MaLoaiKhoaHoc = sdr["MaLoaiKhoaHoc"].ToString();
                kh.TenKhoaHoc = sdr["TenKhoaHoc"].ToString();
                kh.NgayKhaiGiang = DateTime.Parse(sdr["NgayKhaiGiang"].ToString());
                kh.NgayKetThuc = DateTime.Parse(sdr["NgayKetThuc"].ToString());
                kh.SoLop = int.Parse(sdr["SoLop"].ToString());
                kh.HocPhi = int.Parse(sdr["HocPhi"].ToString());
                kh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsKhoaHoc.Add(kh);
            }
            sdr.Close();
            sql.Close();
            return lsKhoaHoc;
        }


        public int suaThongTinKH(KhoaHocDTO khHienTai)
        {
            string strTruyVan = "Update KHOAHOC Set NGAY_KHAI_GIANG = @NGAY_KHAI_GIANG, NGAY_KET_THUC = @NGAY_KET_THUC, SO_LOP = @SO_LOP, HOC_PHI = @HOC_PHI Where MA_KHOA_HOC = @MA_KHOA_HOC";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@NGAY_KHAI_GIANG", khHienTai.NgayKhaiGiang);
            param[1] = new SqlParameter("@NGAY_KET_THUC", khHienTai.NgayKetThuc);
            param[2] = new SqlParameter("@SO_LOP", khHienTai.SoLop);
            param[3] = new SqlParameter("@HOC_PHI", khHienTai.HocPhi);
            param[4] = new SqlParameter("@MA_KHOA_HOC", khHienTai.MaKhoaHoc);
            int kq = Connection.thayDoiDuLieu(strTruyVan, param, conn);
            conn.Close();

            return kq;
        }

        public List<KhoaHocDTO> layDSKHTheoThang(int thang, int nam)
        {
            List<KhoaHocDTO> lsKhoaHoc = new List<KhoaHocDTO>();
            string strTruyVan = "SELECT * FROM KHOAHOC WHERE MONTH(NGAY_KHAI_GIANG) = @thang AND YEAR(NGAY_KHAI_GIANG) = @nam";
            SqlConnection sql = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@thang", thang);
            param[1] = new SqlParameter("@nam", nam);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, sql);
            while (sdr.Read())
            {
                KhoaHocDTO kh = new KhoaHocDTO();
                kh.MaKhoaHoc = sdr["MaKhoaHoc"].ToString();
                kh.MaLoaiKhoaHoc = sdr["MaLoaiKhoaHoc"].ToString();
                kh.TenKhoaHoc = sdr["TenKhoaHoc"].ToString();
                kh.NgayKhaiGiang = DateTime.Parse(sdr["NgayKhaiGiang"].ToString());
                kh.NgayKetThuc = DateTime.Parse(sdr["NgayKetThuc"].ToString());
                kh.SoLop = int.Parse(sdr["SoLop"].ToString());
                kh.HocPhi = int.Parse(sdr["HocPhi"].ToString());
                kh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsKhoaHoc.Add(kh);
            }
            sdr.Close();
            sql.Close();
            return lsKhoaHoc;
        }

    }
}
