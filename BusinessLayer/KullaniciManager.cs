using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Facadee;

namespace BusinessLayer
{
    public class KullaniciManager
    {
        public static int DGiris(Daireler veri)
        {

            if (veri.AdSoyad != null && veri.AdSoyad.Trim().Length > 0)
            {
                return FKullanici.DGiris(veri);
            }
            return -1;
        } 

        
       

    }
}
