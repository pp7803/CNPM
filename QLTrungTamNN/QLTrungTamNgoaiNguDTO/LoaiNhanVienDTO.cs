using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDTO
{
    internal class LoaiNhanVienDTO
    {
        private string maLoaiNhanVien;
        private string tenLoai;
        private int trangthai;

        public LoaiNhanVienDTO()
        {
        }

        public LoaiNhanVienDTO(string maLoaiNhanVien, string tenLoai, int trangthai)
        {
            this.maLoaiNhanVien = maLoaiNhanVien;
            this.tenLoai = tenLoai;
            this.trangthai = trangthai;
        }

        public string MaLoaiNhanVien { get => maLoaiNhanVien; set => maLoaiNhanVien = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
    }
}
