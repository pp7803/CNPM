using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDTO
{
    internal class KhoaHocDTO
    {
        private string maKhoaHoc;
        private string maLoaiKhoaHoc;
        private string tenKhoaHoc;
        private DateTime ngayKhaiGiang;
        private DateTime ngayKetThuc;
        private int soLop;
        private int hocPhi;
        private int trangthai;

        public KhoaHocDTO()
        {
        }

        public KhoaHocDTO(string maKhoaHoc, string maLoaiKhoaHoc, string tenKhoaHoc, DateTime ngayKhaiGiang, DateTime ngayKetThuc, int soLop, int hocPhi, int trangthai)
        {
            this.maKhoaHoc = maKhoaHoc;
            this.maLoaiKhoaHoc = maLoaiKhoaHoc;
            this.tenKhoaHoc = tenKhoaHoc;
            this.ngayKhaiGiang = ngayKhaiGiang;
            this.ngayKetThuc = ngayKetThuc;
            this.soLop = soLop;
            this.hocPhi = hocPhi;
            this.trangthai = trangthai;
        }

        public string MaKhoaHoc { get => maKhoaHoc; set => maKhoaHoc = value; }
        public string MaLoaiKhoaHoc { get => maLoaiKhoaHoc; set => maLoaiKhoaHoc = value; }
        public string TenKhoaHoc { get => tenKhoaHoc; set => tenKhoaHoc = value; }
        public DateTime NgayKhaiGiang { get => ngayKhaiGiang; set => ngayKhaiGiang = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public int SoLop { get => soLop; set => soLop = value; }
        public int HocPhi { get => hocPhi; set => hocPhi = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
    }
}
