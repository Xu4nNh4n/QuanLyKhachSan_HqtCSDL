using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS
{
    public class Account
    {
        public int MaNV { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }
        public static Account Current { get; set; }
        public Account() { }
        public Account(int maNV, string tenDN, string matKhau, string vaiTro, DateTime ngayTao, string trangThai)
        {
            this.MaNV = maNV;
            this.TenDN = tenDN;
            this.MatKhau = matKhau;
            this.VaiTro = vaiTro;
            this.NgayTao = ngayTao;
            this.TrangThai = trangThai;
        }
    }
}
