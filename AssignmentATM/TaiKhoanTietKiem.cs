using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentATM
{
    internal class TaiKhoanTietKiem : TaiKhoan
    {
        public double LaiSuatHangThang { get; set; }
        public int ThoiHan { get; set; } // so thang tiet kiem

        public TaiKhoanTietKiem()
        {
            
        }

        public TaiKhoanTietKiem(int soThe, int pIN, string tenChuTaiKhoan, double soDu, double laiSuatHangThang, int thoiHan) : base(soThe, pIN, tenChuTaiKhoan, soDu)
        {
            LaiSuatHangThang = laiSuatHangThang;
            ThoiHan = thoiHan;
        }

        public void InBangLaiSuat()
        {
            Console.WriteLine("Thang\t\tTien Goc\t\tLai Suat");
            Console.WriteLine("-------------------------------------------------------------");

            for (int i = 1; i <= this.ThoiHan; i++)
            {
                double laiSuatThang = this.SoDu * (this.LaiSuatHangThang / 100);

                Console.WriteLine($"{i}\t\t{this.SoDu.ToString("0.00")}\t\t{laiSuatThang.ToString("0.00")}");

                this.SoDu += laiSuatThang;
            }
        }
    }
}
