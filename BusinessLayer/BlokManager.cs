

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Facadee;

namespace BusinessLayer//CRUD işlemleri gerçekleşmeden önce süzgeç olarak kullanılan katman filtreleme yapılır listelemede filtrelemeye gerek yoktur
{
    public class BlokManager
    {
        public static List<Bloks> Listele()
        {
            return FBlok.Listele();
        }
        public static int Ekleme(Bloks veri)
        {
            if (veri.Ad != null && veri.Ad.Trim().Length > 0)
            { 
                return FBlok.Ekleme(veri);
            }
            return -1;
        }
        public static int Guncelle(Bloks veri)
        {
            if (veri.Ad != null && veri.Ad.Trim().Length > 0)
            {
                return FBlok.Guncelle(veri);
            }
            return -1;
        }

     

        public static int Guncelle(Bolumler add)
        {
            throw new NotImplementedException();
        }
    }
}
