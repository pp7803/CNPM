using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDTO
{
    internal class BangDiemDTO
    {
        private string maHocVien;
        private string maLopHoc;
        private float diem;
        private int tinhtrang;

        public BangDiemDTO()
        {
        }

        public BangDiemDTO(string maHocVien, string maLopHoc, float diem, int tinhtrang     )
        {
            this.maHocVien = maHocVien;
            this.maLopHoc = maLopHoc;
            this.diem = diem;
            this.tinhtrang = tinhtrang;
        }

        public string MaHocVien { get => maHocVien; set => maHocVien = value; }
        public string MaLopHoc { get => maLopHoc; set => maLopHoc = value; }
        public float Diem { get => diem; set => diem = value; }
        public int Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
    }
}
