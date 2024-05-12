using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDAO
{
    internal class HoaDonDAO
    {
        public List<HoaDonDTO> layDSHD()
        {
            List<HoaDonDTO> lsRes = new List<HoaDonDTO>();

            string strTruyVan = "Select * From HOADON";
            SqlConnection conn = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, conn);
            conn.Open();
            while (sdr.Read())
            {
                HoaDonDTO hd = new HoaDonDTO();
                hd.MaHoaDon = sdr["MaHoaDon"].ToString();
                hd.MaLopHoc = sdr["MaLopHoc"].ToString();
                hd.MaHocVien = sdr["MaHocVien"].ToString();
                hd.NgayDangKi = DateTime.Parse(sdr["NgayDangKi"].ToString());
                hd.HocPhi = int.Parse(sdr["HocPhi"].ToString());
                lsRes.Add(hd);
            }
            sdr.Close();
            conn.Close();

            return lsRes;
        }
    }
}
