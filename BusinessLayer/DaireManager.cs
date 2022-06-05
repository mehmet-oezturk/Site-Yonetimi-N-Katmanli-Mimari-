using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Facadee;

namespace BusinessLayer
{
    public class DaireManager
    {
        public static List<Daireler> Listele()
        {
            return FDaireler.Listele();
        }
        public static int Ekleme(Daireler veri)
        {
            if (veri.AdSoyad != null && veri.AdSoyad.Trim().Length > 0)
            {
                return FDaireler.Ekleme(veri);
            }
            return -1;
        }
        public static int Guncelle(Daireler veri)
        {
            if (veri.AdSoyad != null && veri.AdSoyad.Trim().Length > 0)
            {
                return FDaireler.Guncelle(veri);
            }
            return -1;
        }



       
    }
}
