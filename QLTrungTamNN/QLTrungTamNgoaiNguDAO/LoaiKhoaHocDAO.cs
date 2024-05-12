using QLTrungTamNN.QLTrungTamNgoaiNguDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDAO
{
    internal class LoaiKhoaHocDAO
    {
        public List<LoaiKhoaHocDTO> LayDanhSachLoaiKhoaHoc()
        {
            List<LoaiKhoaHocDTO> lsLoaiKhoaHoc = new List<LoaiKhoaHocDTO>();
            string strTruyVan = "SELECT * FROM LOAIKHOAHOC";
            SqlConnection sql = Connection.GetConnection();
            SqlDataReader sdr = Connection.truyVanDuLieu(strTruyVan, sql);
            while (sdr.Read())
            {
                LoaiKhoaHocDTO lkh = new LoaiKhoaHocDTO();
                lkh.MaLoaiKhoaHoc = sdr["MaLoaiKhoaHoc"].ToString();
                lkh.TenKhoaHoc = sdr["TenKhoaHoc"].ToString();
                lkh.Trangthai = int.Parse(sdr["Trangthai"].ToString());
                lsLoaiKhoaHoc.Add(lkh);
            }
            sdr.Close();
            sql.Close();
            return lsLoaiKhoaHoc;
        }
    }
}
