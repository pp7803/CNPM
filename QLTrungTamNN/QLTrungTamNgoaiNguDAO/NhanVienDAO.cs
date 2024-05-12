using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDAO
{
    internal class NhanVienDAO
    {
        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            List<NhanVienDTO> lsresult = new List<NhanVienDTO>();
            string StrTruyVan = "select * from NHANVIEN";
            SqlConnection conn = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(StrTruyVan, conn);
            while (sdr.Read())
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNhanVien = sdr["MaNhanVien"].ToString();
                nv.Ho = sdr["Ho"].ToString();
                nv.Ten = sdr["Ten"].ToString();
                nv.NgaySinh = DateTime.Parse(sdr["NgaySinh"].ToString());
                nv.GioiTinh = int.Parse(sdr["GioiTInh"].ToString());
                nv.DiaChi = sdr["DiaChi"].ToString();
                nv.Sdt = sdr["Sdt"].ToString();
                nv.Email = sdr["Email"].ToString();
                nv.MaLoaiNhanVien = sdr["MaLoaiNhanVien"].ToString();
                nv.Tinhtrang = int.Parse(sdr["Tinhtrang"].ToString());
                lsresult.Add(nv);
            }
            sdr.Close();
            conn.Close();
            return lsresult;
        }
        public NhanVienDTO layThongTinNhanVien(TaiKhoanDTO tk)
        {
            NhanVienDTO nhanVienKQ = null;

            if (tk != null)
            {
                string strTruyVanNV = "Select * From NHANVIEN Where MA_NHAN_VIEN = @MaNV And TINH_TRANG = 1";
                SqlParameter[] paramNV = new SqlParameter[1];
                paramNV[0] = new SqlParameter("@MaNV", tk.TaiKhoan);
                SqlConnection conn = Connection.GetConnection();
                conn.Open();
                SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVanNV, paramNV, conn);
                
                if (sdr.Read())
                {
                    nhanVienKQ = new NhanVienDTO();
                    nhanVienKQ.MaNhanVien = sdr["MaNhanVien"].ToString();
                    nhanVienKQ.Ho = sdr["Ho"].ToString();
                    nhanVienKQ.Ten = sdr["Ten"].ToString();
                    nhanVienKQ.NgaySinh = DateTime.Parse(sdr["NgaySinh"].ToString());
                    nhanVienKQ.GioiTinh = int.Parse(sdr["GioiTinh"].ToString());
                    nhanVienKQ.DiaChi = sdr["DiaChi"].ToString();
                    nhanVienKQ.Sdt = sdr["SDT"].ToString();
                    nhanVienKQ.Email = sdr["Email"].ToString();
                    nhanVienKQ.MaLoaiNhanVien = sdr["MaLoaiNhanVien"].ToString();
                    nhanVienKQ.Tinhtrang = int.Parse(sdr["Tinhtrang"].ToString());
                }
                sdr.Close();
                conn.Close();
            }

            return nhanVienKQ;
        }

        public List<string> layMaNVChuaCoTK()
        {
            List<string> dsMaNV = new List<string>();

            string strTruyVan = "Select MA_NHAN_VIEN From NHANVIEN Where MA_NHAN_VIEN NOT IN (Select TAI_KHOAN From TAIKHOAN where TRNAG_THAI = 1) And TinhTrang = 1";
            SqlConnection conn = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
            while (sdr.Read())
            {
                string maNV = sdr["MaNV"].ToString();
                dsMaNV.Add(maNV);
            }

            return dsMaNV;
        }

        public int themNV(NhanVienDTO nv)
        {
            string strTruyVan = "Insert Into NHANVIEN Values (@MaNV, @Ho, @Ten, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @Email, @LoaiNV, 1)";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@MaNV", nv.MaNhanVien);
            param[1] = new SqlParameter("@Ho", nv.Ho);
            param[2] = new SqlParameter("@Ten", nv.Ten);
            param[3] = new SqlParameter("@NgaySinh", nv.NgaySinh);
            param[4] = new SqlParameter("@GioiTinh", nv.GioiTinh);
            param[5] = new SqlParameter("@DiaChi", nv.DiaChi);
            param[6] = new SqlParameter("@SDT", nv.Sdt);
            param[7] = new SqlParameter("@SDT", nv.Email);
            param[8] = new SqlParameter("@LoaiNV", nv.MaLoaiNhanVien);
            int kq = Connection.thayDoiDuLieu(strTruyVan, param, conn);
            conn.Close();

            return kq;
        }
        public string layMaNVMax()
        {
            string strTruyVan = "Select Max(MA_NHAN_VIEN) from nhanvien";
            SqlConnection conn = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
            string ma = null;
            if (sdr.Read())
            {
                ma = sdr[0].ToString();
            }
            if (string.IsNullOrEmpty(ma))
            {
                return "GV001";
            }
            int chuyenSo = int.Parse(ma.Replace("NV", ""));
            string maRes = "NV" + (chuyenSo + 1).ToString("000000");
            return maRes;
        }


        public List<NhanVienDTO> LayDanhSachGiangVien()
        {
            List<NhanVienDTO> lsNhanVien = new List<NhanVienDTO>();
            string strTruyVan = "select * from nhanvien where LOAI_NHAN_VIEN = LNV000003";
            SqlConnection sql = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, sql);
            while (sdr.Read())
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNhanVien = sdr["MaNhanVien"].ToString();
                nv.Ho = sdr["Ho"].ToString();
                nv.Ten = sdr["Ten"].ToString();
                nv.NgaySinh = DateTime.Parse(sdr["NgaySinh"].ToString());
                nv.GioiTinh = int.Parse(sdr["GioiTInh"].ToString());
                nv.DiaChi = sdr["DiaChi"].ToString();
                nv.Sdt = sdr["Sdt"].ToString();
                nv.Email = sdr["Email"].ToString();
                nv.MaLoaiNhanVien = sdr["MaLoaiNhanVien"].ToString();
                nv.Tinhtrang = int.Parse(sdr["Tinhtrang"].ToString());
                lsNhanVien.Add(nv);

            }
            sdr.Close();
            sql.Close();
            return lsNhanVien;
        }

        public List<NhanVienDTO> LayDanhNVTheoMa(string m)
        {
            List<NhanVienDTO> lsNhanVien = new List<NhanVienDTO>();
            string struyvan = "select * from nhanvien where MA_NHA_VIEN like @MaNV";
            SqlConnection sql = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MaNV", "%" + m + "%");
            SqlDataReader sdr = Connection.truyVanDuLieu(struyvan, param, sql);
            while (sdr.Read())
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNhanVien = sdr["MaNhanVien"].ToString();
                nv.Ho = sdr["Ho"].ToString();
                nv.Ten = sdr["Ten"].ToString();
                nv.NgaySinh = DateTime.Parse(sdr["NgaySinh"].ToString());
                nv.GioiTinh = int.Parse(sdr["GioiTInh"].ToString());
                nv.DiaChi = sdr["DiaChi"].ToString();
                nv.Sdt = sdr["Sdt"].ToString();
                nv.Email = sdr["Email"].ToString();
                nv.MaLoaiNhanVien = sdr["MaLoaiNhanVien"].ToString();
                nv.Tinhtrang = int.Parse(sdr["Tinhtrang"].ToString());
                lsNhanVien.Add(nv);

            }
            sdr.Close();
            sql.Close();
            return lsNhanVien;
        }
        public List<NhanVienDTO> LayDanhNVTheoLoai(string l)
        {
            List<NhanVienDTO> lsNhanVien = new List<NhanVienDTO>();
            string strTruyVan = "select * from nhanvien where MA_LOAI_NHAN_VIEN = (Select MA_LOAI_NHAN_VIEN from loainhanvien where TEN_LOAI = @TenLoai)";
            SqlConnection sql = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TenLoai", l);
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, param, sql);
            while (sdr.Read())
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNhanVien = sdr["MaNhanVien"].ToString();
                nv.Ho = sdr["Ho"].ToString();
                nv.Ten = sdr["Ten"].ToString();
                nv.NgaySinh = DateTime.Parse(sdr["NgaySinh"].ToString());
                nv.GioiTinh = int.Parse(sdr["GioiTInh"].ToString());
                nv.DiaChi = sdr["DiaChi"].ToString();
                nv.Sdt = sdr["Sdt"].ToString();
                nv.Email = sdr["Email"].ToString();
                nv.MaLoaiNhanVien = sdr["MaLoaiNhanVien"].ToString();
                nv.Tinhtrang = int.Parse(sdr["Tinhtrang"].ToString());
                lsNhanVien.Add(nv);

            }
            sdr.Close();
            sql.Close();
            return lsNhanVien;
        }


        public string layMaNVMax(string p)
        {
            string maRes = "";
            switch (int.Parse(p))
            {
                case 1:
                    {
                        string strTruyVan = "Select Max(MA_NHAN_VIEN) from nhanvien where LOAI_NHAN_VIEN = LNV000001";
                        SqlConnection conn = Connection.GetConnection();
                        SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
                        string ma = null;
                        if (sdr.Read())
                        {
                            ma = sdr[0].ToString();
                        }
                        if (string.IsNullOrEmpty(ma))
                        {
                            return "QL000001";
                        }
                        int chuyenSo = int.Parse(ma.Replace("QL", ""));
                        maRes = "QL" + (chuyenSo + 1).ToString("000000");
                    }
                    break;
                case 2:
                    {
                        string strTruyVan = "Select Max(MA_NHAN_VIEN) from nhanvien where LOAI_NHAN_VIEN = LNV000002";
                        SqlConnection conn = Connection.GetConnection();
                        SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
                        string ma = null;
                        if (sdr.Read())
                        {
                            ma = sdr[0].ToString();
                        }
                        if (string.IsNullOrEmpty(ma))
                        {
                            return "GVU000001";
                        }
                        int chuyenSo = int.Parse(ma.Replace("GVU", ""));
                        maRes = "GVU" + (chuyenSo + 1).ToString("000000");
                    }
                    break;
                case 3:
                    {
                        string strTruyVan = "Select Max(MA_NHAN_VIEN) from nhanvien where LOAI_NHAN_VIEN = LNV000003";
                        SqlConnection conn = Connection.GetConnection();
                        SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
                        string ma = null;
                        if (sdr.Read())
                        {
                            ma = sdr[0].ToString();
                        }
                        if (string.IsNullOrEmpty(ma))
                        {
                            return "GV000001";
                        }
                        int chuyenSo = int.Parse(ma.Replace("GV", ""));
                        maRes = "GV" + (chuyenSo + 1).ToString("000000");
                    }
                    break;
                case 4:
                    {
                        string strTruyVan = "Select Max(MA_NHAN_VIEN) from nhanvien where LOAI_NHAN_VIEN = LNV000004";
                        SqlConnection conn = Connection.GetConnection();
                        SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
                        string ma = null;
                        if (sdr.Read())
                        {
                            ma = sdr[0].ToString();
                        }
                        if (string.IsNullOrEmpty(ma))
                        {
                            return "QT000001";
                        }
                        int chuyenSo = int.Parse(ma.Replace("QT", ""));
                        maRes = "QT" + (chuyenSo + 1).ToString("000000");
                    }
                    break;
            }
            return maRes;
        }

        public int suaNhanVien(NhanVienDTO nvHienTai)
        {
            string strTruyVan = "Update nhanvien Set  HO = @Ho, TEN = @Ten, NGAY_SINH = @NgaySinh, GIOI_TINH = @GioiTinh, DIA_CHI = @DiaChi, SDT = @SDT, EMAIL = @Email, TINH_TRANG = @TinhTrang where MA_NHAN_VIEN = @MaNV";
            SqlConnection conn = Connection.GetConnection();
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Ho", nvHienTai.Ho);
            param[1] = new SqlParameter("@Ten", nvHienTai.Ten);
            param[2] = new SqlParameter("@NgaySinh", nvHienTai.NgaySinh);
            param[3] = new SqlParameter("@GioiTinh", nvHienTai.GioiTinh);
            param[4] = new SqlParameter("@DiaChi", nvHienTai.DiaChi);
            param[5] = new SqlParameter("@SDT", nvHienTai.Sdt);
            param[6] = new SqlParameter("@Email", nvHienTai.Email);
            param[7] = new SqlParameter("@LoaiNV", nvHienTai.MaLoaiNhanVien);
            param[8] = new SqlParameter("@TinhTrang", nvHienTai.Tinhtrang);
            param[9] = new SqlParameter("@MaNV", nvHienTai.MaNhanVien);

            int kq = Connection.thayDoiDuLieu(strTruyVan, param, conn);

            conn.Close();
            return kq;
        }
    }
}
