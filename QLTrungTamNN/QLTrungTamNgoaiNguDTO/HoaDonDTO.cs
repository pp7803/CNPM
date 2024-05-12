using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDTO
{
    internal class HoaDonDTO
    {
        private string maHoaDon;
        private string maLopHoc;
        private string maHocVien;
        private DateTime ngayDangKi;
        private int hocPhi;
        private int tinhtrang;

        public HoaDonDTO()
        {
        }

        public HoaDonDTO(string maHoaDon, string maLopHoc, string maHocVien, DateTime ngayDangKi, int hocPhi, int tinhtrang)
        {
            this.maHoaDon = maHoaDon;
            this.maLopHoc = maLopHoc;
            this.maHocVien = maHocVien;
            this.ngayDangKi = ngayDangKi;
            this.hocPhi = hocPhi;
            this.tinhtrang = tinhtrang;
        }

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaLopHoc { get => maLopHoc; set => maLopHoc = value; }
        public string MaHocVien { get => maHocVien; set => maHocVien = value; }
        public DateTime NgayDangKi { get => ngayDangKi; set => ngayDangKi = value; }
        public int HocPhi { get => hocPhi; set => hocPhi = value; }
        public int Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
    }
}
