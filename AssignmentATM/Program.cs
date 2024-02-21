using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaiKhoan> danhSachTaiKhoan = new List<TaiKhoan>
            {
                new TaiKhoan { SoThe = 123456789, PIN = 1234, TenChuTaiKhoan = "Nguyen Van A", SoDu = 1000.0 },
                new TaiKhoan { SoThe = 987654321, PIN = 4321, TenChuTaiKhoan = "Tran Thi B", SoDu = 2000.0 },
                new TaiKhoan { SoThe = 456789123, PIN = 5678, TenChuTaiKhoan = "Le Van C", SoDu = 1500.0 },
                new TaiKhoan { SoThe = 321654987, PIN = 8765, TenChuTaiKhoan = "Hoang Thi D", SoDu = 2500.0 },
                new TaiKhoan { SoThe = 789123456, PIN = 3456, TenChuTaiKhoan = "Do Van E", SoDu = 1800.0 },
                new TaiKhoan { SoThe = 654987321, PIN = 6543, TenChuTaiKhoan = "Pham Thi F", SoDu = 2200.0 },
                new TaiKhoan { SoThe = 234567891, PIN = 7890, TenChuTaiKhoan = "Truong Van G", SoDu = 1900.0 },
                new TaiKhoan { SoThe = 987123456, PIN = 0987, TenChuTaiKhoan = "Nguyen Thi H", SoDu = 2700.0 },
                new TaiKhoan { SoThe = 543216789, PIN = 2109, TenChuTaiKhoan = "Ho Thi I", SoDu = 1600.0 },
                new TaiKhoan { SoThe = 876543219, PIN = 5432, TenChuTaiKhoan = "Le Van K", SoDu = 2300.0 }
            };

            List<TaiKhoanTietKiem> danhSachTaiKhoanTietKiem = new List<TaiKhoanTietKiem>();

            Menu(danhSachTaiKhoan);
            Console.ReadLine();
        }

        static void Menu(List<TaiKhoan> danhSachTaiKhoan)
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Dien so the: ");
                int soThe = int.Parse(Console.ReadLine());
                Console.Write("Dien ma PIN: ");
                int pin = int.Parse(Console.ReadLine());

                int luaChon = -1;

                if (KiemTraSoTheVaPIN(danhSachTaiKhoan, soThe, pin))
                {
                    do
                    {
                        Console.WriteLine();
                        TaiKhoan taiKhoan = GetTaiKhoan(danhSachTaiKhoan, soThe);

                        Console.WriteLine($"Xin chao {taiKhoan.TenChuTaiKhoan}, Happy New Year ATM");
                        Console.WriteLine("1. Xem so du");
                        Console.WriteLine("2. Rut tien");
                        Console.WriteLine("3. Nap tien");
                        Console.WriteLine("4. Chuyen tien toi so the");
                        Console.WriteLine("5. Gui tiet kiem");
                        Console.WriteLine("0. Thoat");

                        Console.Write("Xin moi lua chon: ");
                        luaChon = int.Parse(Console.ReadLine());

                        switch (luaChon)
                        {
                            case 1:
                                taiKhoan.XemSoDu();
                                break;
                            case 2:
                                taiKhoan.RutTien();
                                break;
                            case 3:
                                taiKhoan.NapTien();
                                break;
                            case 4:
                                Console.Write("Nhap so the muon chuyen: ");
                                int soTheDen = int.Parse(Console.ReadLine());

                                if (KiemTraSoThe(danhSachTaiKhoan, soTheDen))
                                {
                                    TaiKhoan taiKhoanDen = GetTaiKhoan(danhSachTaiKhoan, soTheDen);
                                    taiKhoan.ChuyenTienToiSoThe(taiKhoanDen);
                                }
                                break;
                            case 5:
                                Console.Write("Nhap so tien muon gui tiet kiem: ");
                                int tienTietKiem = int.Parse(Console.ReadLine());
                                Console.Write("Nhap lai suat gui hang thang: ");
                                double laiSuatHangThang = double.Parse(Console.ReadLine());
                                Console.Write("Nhap thoi han gui tiet kiem (thang): ");
                                int thoiHan = int.Parse(Console.ReadLine());

                                taiKhoan.GuiTietKiem(tienTietKiem);

                                TaiKhoanTietKiem taiKhoanTietKiem = new TaiKhoanTietKiem(taiKhoan.SoThe, taiKhoan.PIN, taiKhoan.TenChuTaiKhoan, tienTietKiem, laiSuatHangThang, thoiHan);
                                taiKhoanTietKiem.InBangLaiSuat();
                                break;
                            default:
                                Console.WriteLine("Vui long chon lai.");
                                break;
                        }
                    } while (luaChon != 0);

                    break;
                }
            }
        }

        static bool KiemTraSoTheVaPIN(List<TaiKhoan> danhSachTaiKhoan, int soThe, int pin)
        {
            foreach (var taiKhoan in danhSachTaiKhoan)
            {
                if (taiKhoan.SoThe == soThe && taiKhoan.PIN == pin)
                {
                    Console.WriteLine("So The va PIN hop le.");
                    return true;
                }
            }

            Console.WriteLine("So The hoac PIN khong dung.");
            return false;
        }

        static bool KiemTraSoThe(List<TaiKhoan> danhSachTaiKhoan, int soThe)
        {
            foreach (var taiKhoan in danhSachTaiKhoan)
            {
                if (taiKhoan.SoThe == soThe )
                {
                    Console.WriteLine("So The hop le.");
                    return true;
                }
            }

            Console.WriteLine("So The khong dung.");
            return false;
        }

        static TaiKhoan GetTaiKhoan(List<TaiKhoan> danhSachTaiKhoan, int soThe)
        {
            foreach (TaiKhoan taiKhoan in danhSachTaiKhoan)
            {
                if (taiKhoan.SoThe == soThe)
                {
                    return taiKhoan;
                }
            }
            return null;
        }
    }
}
