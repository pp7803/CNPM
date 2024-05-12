using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDTO
{
    internal class NhanVienDTO
    {
        private string maNhanVien;
        private string ho;
        private string ten;
        private DateTime ngaySinh;
        private int gioiTinh;
        private string diaChi;
        private string sdt;
        private string email;
        private string maLoaiNhanVien;
        private int tinhtrang;

        public NhanVienDTO()
        {
        }

        public NhanVienDTO(string maNhanVien, string ho, string ten, DateTime ngaySinh, int gioiTinh, string diaChi, string sdt, string email, string maLoaiNhanVien, int tinhtrang)
        {
            this.maNhanVien = maNhanVien;
            this.ho = ho;
            this.ten = ten;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.email = email;
            this.maLoaiNhanVien = maLoaiNhanVien;
            this.tinhtrang = tinhtrang;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string Ho { get => ho; set => ho = value; }
        public string Ten { get => ten; set => ten = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string MaLoaiNhanVien { get => maLoaiNhanVien; set => maLoaiNhanVien = value; }
        public int Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
    }
}
