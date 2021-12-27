using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_patika_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            int input = Introduction();

            while (true)
            {
                switch (input)
                {
                    case 1:
                        board.KartEkle();
                        input = Introduction();
                        break;
                    case 2:
                        board.KartSil();
                        input = Introduction();
                        break;
                    case 3:
                        board.KartTasi();
                        input = Introduction();
                        break;
                    case 4:
                        board.BoardListele();
                        input = Introduction();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        // // //
        public static int Introduction()
        {
            Console.WriteLine("\nLutfen yapmak istediginiz islemi secin");
            Console.WriteLine("************************************");
            Console.WriteLine("(1) Kart Ekle");
            Console.WriteLine("(2) Kart Sil");
            Console.WriteLine("(3) Kart Taşı");
            Console.WriteLine("(4) Board Listele");
            Console.WriteLine("(5) Çıkış");
            return int.Parse(Console.ReadLine());
        }
    }
}