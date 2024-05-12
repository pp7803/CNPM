using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDTO
{
    internal class HocVienDTO
    {
        private string maHocVien;
        private string ho;
        private string ten;
        private DateTime ngaySinh;
        private int gioiTinh;
        private string diaChi;
        private string email;
        private DateTime ngayGiaNhap;
        private int trangthai;

        public HocVienDTO()
        {
        }

        public HocVienDTO(string maHocVien, string ho, string ten, DateTime ngaySinh, int gioiTinh, string diaChi, string email, DateTime ngayGiaNhap, int trangthai)
        {
            this.maHocVien = maHocVien;
            this.ho = ho;
            this.ten = ten;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.email = email;
            this.ngayGiaNhap = ngayGiaNhap;
            this.trangthai = trangthai;
        }

        public string MaHocVien { get => maHocVien; set => maHocVien = value; }
        public string Ho { get => ho; set => ho = value; }
        public string Ten { get => ten; set => ten = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public DateTime NgayGiaNhap { get => ngayGiaNhap; set => ngayGiaNhap = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
    }
}