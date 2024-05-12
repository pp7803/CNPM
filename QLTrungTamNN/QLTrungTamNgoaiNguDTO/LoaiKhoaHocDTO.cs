using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDTO
{
    internal class LoaiKhoaHocDTO
    {
        private string maLoaiKhoaHoc;
        private string tenKhoaHoc;
        private int trangthai;

        public LoaiKhoaHocDTO()
        {
        }

        public LoaiKhoaHocDTO(string maLoaiKhoaHoc, string tenKhoaHoc, int trangthai)
        {
            this.maLoaiKhoaHoc = maLoaiKhoaHoc;
            this.tenKhoaHoc = tenKhoaHoc;
            this.trangthai = trangthai;
        }

        public string MaLoaiKhoaHoc { get => maLoaiKhoaHoc; set => maLoaiKhoaHoc = value; }
        public string TenKhoaHoc { get => tenKhoaHoc; set => tenKhoaHoc = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
    }
}
