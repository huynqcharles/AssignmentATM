using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentATM
{
    internal class TaiKhoan
    {
        public int SoThe { get; set; }
        public int PIN { get; set; }
        public string TenChuTaiKhoan { get; set; }
        public double SoDu { get; set; }

        public TaiKhoan()
        {
            
        }

        public TaiKhoan(int soThe, int pIN, string tenChuTaiKhoan, double soDu)
        {
            SoThe = soThe;
            PIN = pIN;
            TenChuTaiKhoan = tenChuTaiKhoan;
            SoDu = soDu;
        }

        public void XemSoDu()
        {
            Console.WriteLine($"So du hien tai: {this.SoDu} VND");
        }

        public void RutTien()
        {
            Console.Write("Nhap so tien muon rut: ");
            int tienRut = int.Parse(Console.ReadLine());

            if (tienRut > this.SoDu)
            {
                Console.WriteLine("So du khong du.");
            }
            else
            {
                this.SoDu -= tienRut;
                Console.WriteLine("Rut tien thanh cong.");
                XemSoDu();
            }
        }

        public void NapTien()
        {
            Console.Write("Nhap so tien muon nap: ");
            int tienNap = int.Parse(Console.ReadLine());

            this.SoDu += tienNap;
            Console.WriteLine("Nap tien thanh cong.");
            XemSoDu();
        }

        public void ChuyenTienToiSoThe(TaiKhoan taiKhoanDen)
        {
            Console.Write("Nhap so tien muon chuyen: ");
            int tienChuyen = int.Parse(Console.ReadLine());

            if (tienChuyen > this.SoDu)
            {
                Console.WriteLine("So du khong du.");
            }
            else
            {
                this.SoDu -= tienChuyen;
                taiKhoanDen.SoDu += tienChuyen;
                Console.WriteLine("Chuyen tien thanh cong.");
                XemSoDu();
            }
        }

        public void GuiTietKiem(double tienGui)
        {
            this.SoDu -= tienGui;
            Console.WriteLine("Gui tien thanh cong.");
            XemSoDu();
        }
    }
}
