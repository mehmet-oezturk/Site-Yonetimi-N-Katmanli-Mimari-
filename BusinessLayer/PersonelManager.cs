using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Facadee;

namespace BusinessLayer
{
   public class PersonelManager
    {
        public static int Ekleme(Personeller veri)
        {
            if (veri.AdSoyad != null && veri.AdSoyad.Trim().Length > 0)
            {
                return FPersonel.Ekleme(veri);
            }
            return -1;
        }
        public static int Guncelleme(Personeller veri)
        {
            if (veri.AdSoyad != null && veri.AdSoyad.Trim().Length > 0)
            {
                return FPersonel.Guncelle(veri);
            }
            return -1;
        }
    }
}
