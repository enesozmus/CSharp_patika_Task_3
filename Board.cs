using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_patika_Task_3
{
    public class Board
    {
        Dictionary<int, string> people = new Dictionary<int, string>();

        List<Kart> TODO = new List<Kart>();
        List<Kart> INPROGRESS = new List<Kart>();
        List<Kart> DONE = new List<Kart>();

        public Board()  // istemler arasında    → hazır kartlar
        {
            // ID, isim1
            people.Add(0, "Ali Yılmaz");            // integer değeri   →   0       string değeri   →   Ali Yılmaz   
            people.Add(1, "Ahmet Ozmus");
            people.Add(2, "Zuhal Ceylin");
            people.Add(3, "Ebrar Kuzik");
            people.Add(4, "Betül Yenilmez");
            people.Add(5, "Yavuz Selim");

            TODO.Add(new Kart("Gezi", "Kuzey Işıkları'nı izle!", "Ali Yılmaz", Kart.Buyukluk.L));
            INPROGRESS.Add(new Kart("Gezi", "Nevşehir'de Balona Bin!", "Zuhal Ceylin", Kart.Buyukluk.S));
            DONE.Add(new Kart("Macera", "Yunuslarla yüz!", "Betül Yenilmez", Kart.Buyukluk.XL));
            DONE.Add(new Kart("Gezi", "Büyük Kanyon'a Git!", "Ebrar Kuzik", Kart.Buyukluk.M));
            TODO.Add(new Kart("Sosyal", "Kan Bağışla!", "Yavuz Selim", Kart.Buyukluk.XL));
            INPROGRESS.Add(new Kart("Macera", "Şelale Altında Yıkan!", "Ahmet Ozmus", Kart.Buyukluk.XS));
        }
        //  Kart Ekle       
        public void KartEkle()
        {
            string baslik;
            string icerik;
            int buyukluk;
            int kisi;

            Console.WriteLine("Kartınız için lütfen bir başlık giriniz          : ");
            baslik = Console.ReadLine();
            Console.WriteLine("Kartınız için lütfen bir içerik giriniz          : ");
            icerik = Console.ReadLine();
            Console.WriteLine("Kartınız için bir büyüklük seçiniz -> XS(1),S(2),M(3),L(4),XL(5)   :");
            buyukluk = int.Parse(Console.ReadLine());
            Console.WriteLine("Kişi ID'sini giriniz                             : ");
            kisi = int.Parse(Console.ReadLine());

            if (people.ContainsKey(kisi) && buyukluk > 0 && buyukluk <= 5)
            {
                TODO.Add(new Kart(baslik, icerik, people[kisi], (Kart.Buyukluk)buyukluk));
                Console.WriteLine("Ekleme işlemi gerçekleşti!");
            }
            else
                Console.WriteLine("Hatalı bir işlem yaptınız!");
        }
        //  Kart Sil
        public void KartSil()
        {
            string baslik;
            string icerik;


            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen silmek istediğiniz kartın başlığını yazınız   :    ");
            baslik = Console.ReadLine();
            Console.WriteLine("Lütfen silmek istediğiniz kartın içeriğini yazınız   :    ");
            icerik = Console.ReadLine();

            //
            bool bulundu = false;

            foreach (var kart in TODO.ToArray())
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    TODO.Remove(kart);
                    Console.WriteLine("Kart silindi.");
                    bulundu = true;
                }
            }

            //
            foreach (var kart in INPROGRESS.ToArray())
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    INPROGRESS.Remove(kart);
                    Console.WriteLine("Kart silindi.");
                    bulundu = true;
                }
            }

            //
            foreach (var kart in DONE.ToArray())
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    DONE.Remove(kart);
                    Console.WriteLine("Kart silindi.");
                    bulundu = true;
                }
            }

            if (!bulundu)
            {
                int choice;
                Console.WriteLine("Aradiginiz kriterlere uygun kart bulunamadi.");
                Console.WriteLine("* Silmeyi sonlandirmak icin (1)");
                Console.WriteLine("* Yeniden denemek icin (2)");
                choice = int.Parse(Console.ReadLine());
                if (choice == 2)
                    KartSil();
                else
                    Console.WriteLine("Kart silme işlemi sonlandırıldı!");
            }
        }


        //  //  //
        private void KartEkle(Kart kart, ref List<Kart> addList, ref List<Kart> deleteList)
        {
            addList.Add(kart);
            deleteList.Remove(kart);
            Console.WriteLine("Taşıma işlemi gerçekleştirildi!");
        }


        //  //  //
        private void KartAra(string baslik, string icerik, ref List<Kart> kartListesi, ref bool bulundu, string listName)
        {
            foreach (var kart in kartListesi.ToArray())
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    bulundu = true;

                    Console.WriteLine("Bulunan Kart Bilgileri:");
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("Başlık       :   {0}", kart.Baslik);
                    Console.WriteLine("İçerik       :   {0}", kart.Icerik);
                    Console.WriteLine("Atanan Kişi  :   {0}", kart.AtananKisi);
                    Console.WriteLine("Büyüklük     :   {0}", kart.Boyut);
                    Console.WriteLine("Line         :   {0}", listName);
                    Console.WriteLine();
                    Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçin:");
                    Console.WriteLine("(1) TODO");
                    Console.WriteLine("(2) IN PROGRESS");
                    Console.WriteLine("(3) DONE");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            KartEkle(kart, ref TODO, ref kartListesi);
                            break;
                        case 2:
                            KartEkle(kart, ref INPROGRESS, ref kartListesi);
                            break;
                        case 3:
                            KartEkle(kart, ref DONE, ref kartListesi);
                            break;
                        default:
                            Console.WriteLine("Hatalı bir işlem yaptınız!");
                            break;
                    }
                }
            }
        }
        //  Kart Taşı
        public void KartTasi()
        {
            string baslik;
            string icerik;
            bool bulundu = false;

            Console.WriteLine("Lütfen taşımak istediğiniz kartın başlığını yazınız   :    ");
            baslik = Console.ReadLine();
            Console.WriteLine("Lütfen silmek istediğiniz kartın içeriğini yazınız   :    ");
            icerik = Console.ReadLine();

            KartAra(baslik, icerik, ref TODO, ref bulundu, "TODO");
            KartAra(baslik, icerik, ref INPROGRESS, ref bulundu, "INPROGRESS");
            KartAra(baslik, icerik, ref DONE, ref bulundu, "DONE");

            if (!bulundu)
            {
                int choice;
                Console.WriteLine("Aradığınız kart bulunamadı!");
                Console.WriteLine("* Taşıma işlemini sonlandırmak için (1)");
                Console.WriteLine("* Yeniden denemek için (2)");
                choice = int.Parse(Console.ReadLine());
                if (choice == 2)
                    KartTasi();
                else
                    Console.WriteLine("Kart silme işlemi sonlandırıldı!");
            }
        }
        //  Board Listele
        public void BoardListele()
        {
            Console.WriteLine("\nTODO Line");
            Console.WriteLine("*****************************");

            foreach (var kart in TODO)
            {
                Console.WriteLine("Başlık       : {0}", kart.Baslik);
                Console.WriteLine("İçerik       : {0}", kart.Icerik);
                Console.WriteLine("Atanan Kişi  : {0}", kart.AtananKisi);
                Console.WriteLine("Büyüklük     : {0}", kart.Boyut);
                Console.WriteLine("-");
            }
            Console.WriteLine("\nIN PROGRESS Line");
            Console.WriteLine("*****************************");

            foreach (var kart in INPROGRESS)
            {
                Console.WriteLine("Başlık       : {0}", kart.Baslik);
                Console.WriteLine("İçerik       : {0}", kart.Icerik);
                Console.WriteLine("Atanan Kişi  : {0}", kart.AtananKisi);
                Console.WriteLine("Büyüklük     : {0}", kart.Boyut);
                Console.WriteLine("-");
            }
            Console.WriteLine("\nDONE Line");
            Console.WriteLine("*****************************");

            foreach (var kart in DONE)
            {
                Console.WriteLine("Başlık       : {0}", kart.Baslik);
                Console.WriteLine("İçerik       : {0}", kart.Icerik);
                Console.WriteLine("Atanan Kişi  : {0}", kart.AtananKisi);
                Console.WriteLine("Büyüklük     : {0}", kart.Boyut);
                Console.WriteLine("-");
            }
        }
    }
}