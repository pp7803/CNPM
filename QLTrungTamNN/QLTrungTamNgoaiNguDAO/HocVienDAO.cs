using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDAO
{
    internal class HocVienDAO
    {
        public List<HocVienDTO> LayDanhSachHocVien()
        {
            List<HocVienDTO> lsResult = new List<HocVienDTO>();
            string strTruyvan = "SELECT * FROM HOCVIEN";
            SqlConnection conn = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyvan, conn);
            while (sdr.Read())
            {
                HocVienDTO hv = new HocVienDTO();
                hv.MaHocVien = sdr["MaHocVien"].ToString();
                hv.Ho = sdr["Ho"].ToString();
                hv.Ten = sdr["Ten"].ToString();
                hv.NgaySinh = DateTime.Parse(sdr["NgaySinh"].ToString());
                hv.GioiTinh = int.Parse(sdr["GioiTinh"].ToString());
                hv.DiaChi = sdr["DiaChi"].ToString();
                hv.Email = sdr["Email"].ToString();
                hv.NgayGiaNhap = DateTime.Parse(sdr["NgayGiaNhap"].ToString());
                hv.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsResult.Add(hv);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }
        public int themHV(HocVienDTO hv)
        {
            string strTruyVan = "INSERT INTO HOCVIEN VALUES (@MA_HOC_VIEN, @HO, @TEN, @NGAY_SINH, @GIOI_TINH, @DIA_CHI, @EMAIL, @NGAY_GIA_NHAP, 1)";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@MA_HOC_VIEN", hv.MaHocVien);
            param[1] = new SqlParameter("@HO", hv.Ho);
            param[2] = new SqlParameter("@TEN", hv.Ten);
            param[3] = new SqlParameter("@NGAY_SINH", hv.NgaySinh);
            param[4] = new SqlParameter("@GIOI_TINH", hv.GioiTinh);
            param[5] = new SqlParameter("@DIA_CHI", hv.DiaChi);
            param[6] = new SqlParameter("@EMAIL", hv.Email);
            param[7] = new SqlParameter("@NGAY_GIA_NHAP", hv.NgayGiaNhap);

            int kq = Connection.thayDoiDuLieu(strTruyVan, param, conn);
            conn.Close();

            return kq;
        }

        public string layMaHVMax()
        {
            string strTruyVan = "SELECT Max(MA_HOC_VIEN) FROM HOCVIEN";
            SqlConnection conn = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
            string ma = null;
            if (sdr.Read())
            {
                ma = sdr[0].ToString();
            }
            if (string.IsNullOrEmpty(ma))
            {
                return "HV000001";
            }
            int chuyenSo = int.Parse(ma.Replace("HV", ""));
            string maRes = "HV" + (chuyenSo + 1).ToString("000000");
            return maRes;
        }

        public List<HocVienDTO> themHV()
        {
            throw new NotImplementedException();
        }

        public List<HocVienBangDiemDTO> layDSHVCuaMotLop(string p)
        {
            List<HocVienBangDiemDTO> lsResult = new List<HocVienBangDiemDTO>();
            string strTruyvan = "select HOCVIEN.*, DIEM from HOCVIEN inner join BANGDIEM on HOCVIEN.MA_HOC_VIEN = BANGDIEM.MA_HOC_VIEN where HOCVIEN.MA_HOC_VIEN in (select MA_HOC_VIEN from BANGDIEM where MA_LOP_HOC = @MA_LOP_HOC) and MA_LOP_HOC = @MA_LOP_HOC";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MA_LOP_HOC", p);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyvan, param, conn);
            while (sdr.Read())
            {
                HocVienBangDiemDTO hv = new HocVienBangDiemDTO();
                hv.MaHocVien = sdr["MaHocVien"].ToString();
                hv.Ho = sdr["Ho"].ToString();
                hv.Ten = sdr["Ten"].ToString();
                hv.NgaySinh = DateTime.Parse(sdr["NgaySinh"].ToString());
                hv.GioiTinh = int.Parse(sdr["GioiTinh"].ToString());
                hv.DiaChi = sdr["DiaChi"].ToString();
                hv.Email = sdr["Email"].ToString();
                hv.NgayGiaNhap = DateTime.Parse(sdr["NgayGiaNhap"].ToString());
                hv.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                hv.Diem = float.Parse(sdr["Diem"].ToString());
                lsResult.Add(hv);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }

        public List<HocVienDTO> LayDSHVTheoThang(int thang, int nam)
        {
            List<HocVienDTO> lsResult = new List<HocVienDTO>();
            string strTruyvan = "select* from HOCVIEN where MONTH(NGAY_GIA_NHAP) = @thang and YEAR(NGAY_GIA_NHAP) = @nam";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@thang", thang);
            param[1] = new SqlParameter("@nam", nam);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyvan, param, conn);
            while (sdr.Read())
            {
                HocVienDTO hv = new HocVienDTO();
                hv.MaHocVien = sdr["MaHocVien"].ToString();
                hv.Ho = sdr["Ho"].ToString();
                hv.Ten = sdr["Ten"].ToString();
                hv.NgaySinh = DateTime.Parse(sdr["NgaySinh"].ToString());
                hv.GioiTinh = int.Parse(sdr["GioiTinh"].ToString());
                hv.DiaChi = sdr["DiaChi"].ToString();
                hv.Email = sdr["Email"].ToString();
                hv.NgayGiaNhap = DateTime.Parse(sdr["NgayGiaNhap"].ToString());
                hv.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsResult.Add(hv);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }

        public List<HocVienDTO> LayDanhSachHocVienTheoMa(string m)
        {
            List<HocVienDTO> lsHocVien = new List<HocVienDTO>();
            string struyvan = "select * from HOCVIEN where MA_HOC_VIEN like @MA_HOC_VIEN";
            SqlConnection sql = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MA_HOC_VIEN", "%" + m + "%");
            SqlDataReader sdr = Connection.truyVanDuLieu(struyvan, param, sql);
            while (sdr.Read())
            {
                HocVienDTO hv = new HocVienDTO();
                hv.MaHocVien = sdr["MaHocVien"].ToString();
                hv.Ho = sdr["Ho"].ToString();
                hv.Ten = sdr["Ten"].ToString();
                hv.NgaySinh = DateTime.Parse(sdr["NgaySinh"].ToString());
                hv.GioiTinh = int.Parse(sdr["GioiTinh"].ToString());
                hv.DiaChi = sdr["DiaChi"].ToString();
                hv.Email = sdr["Email"].ToString();
                hv.NgayGiaNhap = DateTime.Parse(sdr["NgayGiaNhap"].ToString());
                hv.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsHocVien.Add(hv);

            }
            sdr.Close();
            sql.Close();
            return lsHocVien;
        }

        public List<HocVienDTO> LayDanhSachHocVienTheoTen(string t)
        {
            List<HocVienDTO> lsHocVien = new List<HocVienDTO>();
            string struyvan = "select * from HOCVIEN where TEN like @TenHV";
            SqlConnection sql = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TenHV", "%" + t + "%");
            SqlDataReader sdr = Connection.truyVanDuLieu(struyvan, param, sql);
            while (sdr.Read())
            {
                HocVienDTO hv = new HocVienDTO();
                hv.MaHocVien = sdr["MaHocVien"].ToString();
                hv.Ho = sdr["Ho"].ToString();
                hv.Ten = sdr["Ten"].ToString();
                hv.NgaySinh = DateTime.Parse(sdr["NgaySinh"].ToString());
                hv.GioiTinh = int.Parse(sdr["GioiTinh"].ToString());
                hv.DiaChi = sdr["DiaChi"].ToString();
                hv.Email = sdr["Email"].ToString();
                hv.NgayGiaNhap = DateTime.Parse(sdr["NgayGiaNhap"].ToString());
                hv.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsHocVien.Add(hv);

            }
            sdr.Close();
            sql.Close();
            return lsHocVien;
        }

        public int suaHocVien(HocVienDTO hv)
        {
            string strTruyVan = "UPDATE HOCVIEN SET HO = @HO, TEN = @TEN, NGAY_SINH = @NGAY_SINH, GIOI_TINH = @GIOI_TINH, DIA_CHI = @DIA_CHI, EMAIL = @EMAIL, NGAY_GIA_NHAP = @NGAY_GIA_NHAP, TRANGTHAI = @TRANGTHAI WHERE MA_HOC_VIEN = @MA_HOC_VIEN";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@HO", hv.Ho);
            param[1] = new SqlParameter("@TEN", hv.Ten);
            param[2] = new SqlParameter("@NGAY_SINH", hv.NgaySinh);
            param[3] = new SqlParameter("@GIOI_TINH", hv.GioiTinh);
            param[4] = new SqlParameter("@DIA_CHI", hv.DiaChi);
            param[5] = new SqlParameter("@EMAIL", hv.Email);
            param[6] = new SqlParameter("@NGAY_GIA_NHAP", hv.NgayGiaNhap);
            param[7] = new SqlParameter("@TRANGTHAI", hv.Trangthai);
            param[8] = new SqlParameter("@MA_HOC_VIEN", hv.MaHocVien);
            int kq = Connection.thayDoiDuLieu(strTruyVan, param, conn);
            conn.Close();
            return kq;
        }

        public int suaDiem(List<HocVienBangDiemDTO> lsHocVienDiem, string maLH)
        {
            string strTruyVan = "UPDATE BANGDIEM SET DIEM = @DIEM WHERE MA_HOC_VIEN = @MA_HOC_VIEN AND MA_LOP_HOC = @MA_LOP_HOC";
            int kq = 0;
            foreach (HocVienBangDiemDTO hv in lsHocVienDiem)
            {
                SqlConnection conn = Connection.GetConnection();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@DIEM", hv.Diem);
                param[1] = new SqlParameter("@MA_HOC_VIEN", hv.MaHocVien);
                param[2] = new SqlParameter("@MA_LOP_HOC", maLH);
                kq += Connection.thayDoiDuLieu(strTruyVan, param, conn);
                conn.Close();
            }
            return kq;
        }
    }
}
