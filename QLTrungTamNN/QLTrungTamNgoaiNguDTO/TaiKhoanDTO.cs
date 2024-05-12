using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDTO
{
    internal class TaiKhoanDTO
    {
        private string taiKhoan;
        private string matKhau;
        private string email;
        private int tinhTrang;

        public TaiKhoanDTO()
        {
        }

        public TaiKhoanDTO(string taiKhoan, string matKhau, string email, int tinhTrang)
        {
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
            this.email = email;
            this.tinhTrang = tinhTrang;
        }

        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string Email { get => email; set => email = value; }
        public int TinhTrang { get => tinhTrang; set => tinhTrang = value; }
    }
}
