
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Facadee;

namespace BusinessLayer
{
    public class BolumManager
    {
        public static List<Bolumler> Listele()
        {
            return FBolumler.Listele();
        }
        public static int Ekleme(Bolumler veri)
        {
            if (veri.Ad != null && veri.Ad.Trim().Length > 0)
            {
                return FBolumler.Ekleme(veri);
            }
            return -1;
        }
        public static void Guncelle(Bolumler up)
        {
            if (up.Ad != null && up.Ad.Trim().Length > 0)
            {
                FBolumler.Guncelle(up);
            }
            
        }

       
    }
}
