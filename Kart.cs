using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_patika_Task_3
{
    public class Kart
    {
        public Kart(string baslik, string icerik, string atananKisi, Buyukluk boyut)
        {
            Baslik = baslik;
            Icerik = icerik;
            AtananKisi = atananKisi;
            Boyut = boyut;
        }

        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string AtananKisi { get; set; }
        public Buyukluk Boyut { get; set; }

        public enum Buyukluk
        {
            XS,
            S,
            M,
            L,
            XL
        }
        enum Kolon
        {
            TODO,
            INPROGRESS,
            DONE
        }
    }
}