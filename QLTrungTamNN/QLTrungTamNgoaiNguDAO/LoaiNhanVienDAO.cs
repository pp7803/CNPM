using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTrungTamNN.QLTrungTamNgoaiNguDTO;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDAO
{
    internal class LoaiNhanVienDAO
    {
        public List<LoaiNhanVienDTO> LayDanhSachLoaiNV()
        {
            List<LoaiNhanVienDTO> lsLoaiNV = new List<LoaiNhanVienDTO>();
            string strTruyVan = "SELECT * FROM LOAINHANVIEN";
            SqlConnection sql = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, sql);
            while (sdr.Read())
            {
                LoaiNhanVienDTO lnv = new LoaiNhanVienDTO();
                lnv.MaLoaiNhanVien = sdr["MaLoaiNhanVien"].ToString();
                lnv.TenLoai = sdr["TenLoai"].ToString();
                lnv.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsLoaiNV.Add(lnv);
            }
            sdr.Close();
            sql.Close();
            return lsLoaiNV;
        }
    }
}
