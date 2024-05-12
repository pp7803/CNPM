using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDTO
{
    internal class LopHocDTO
    {
        private string maLopHoc;
        private string tenLopHoc;
        private string maKhoaHoc;
        private string maNhanVien;
        private DateTime ngayHoc;
        private string gioBatDau;
        private string gioKetThuc;
        private int soHocVienToiDa;
        private int soHocVienDaDK;
        private int trangthai;

        public LopHocDTO()
        {
        }

        public LopHocDTO(string maLopHoc, string tenLopHoc, string maKhoaHoc, string maNhanVien, DateTime ngayHoc, string gioBatDau, string gioKetThuc, int soHocVienToiDa, int soHocVienDaDK, int trangthai)
        {
            this.maLopHoc = maLopHoc;
            this.tenLopHoc = tenLopHoc;
            this.maKhoaHoc = maKhoaHoc;
            this.maNhanVien = maNhanVien;
            this.ngayHoc = ngayHoc;
            this.gioBatDau = gioBatDau;
            this.gioKetThuc = gioKetThuc;
            this.soHocVienToiDa = soHocVienToiDa;
            this.soHocVienDaDK = soHocVienDaDK;
            this.trangthai = trangthai;
        }

        public string MaLopHoc { get => maLopHoc; set => maLopHoc = value; }
        public string TenLopHoc { get => tenLopHoc; set => tenLopHoc = value; }
        public string MaKhoaHoc { get => maKhoaHoc; set => maKhoaHoc = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayHoc { get => ngayHoc; set => ngayHoc = value; }
        public string GioBatDau { get => gioBatDau; set => gioBatDau = value; }
        public string GioKetThuc { get => gioKetThuc; set => gioKetThuc = value; }
        public int SoHocVienToiDa { get => soHocVienToiDa; set => soHocVienToiDa = value; }
        public int SoHocVienDaDK { get => soHocVienDaDK; set => soHocVienDaDK = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
    }
}
