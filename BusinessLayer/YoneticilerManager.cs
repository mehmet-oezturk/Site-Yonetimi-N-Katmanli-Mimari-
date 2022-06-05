using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Facadee;

namespace BusinessLayer
{
    public class YoneticilerManager
    {
        public static List<Yoneticiler> Listele()
        {
            return FYonetici.Listele();
        }
        public static int Ekleme(Yoneticiler veri)
        {
            if (veri.AdSoyad != null && veri.AdSoyad.Trim().Length > 0)
            {
                return FYonetici.Ekleme(veri);
            }
            return -1;
        }
        public static int Guncelle(Yoneticiler veri)
        {
            if (veri.AdSoyad != null && veri.AdSoyad.Trim().Length > 0)
            {
                return FYonetici.Guncelle(veri);
            }
            return -1;
        }



       

    }
}
