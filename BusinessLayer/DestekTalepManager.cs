using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Facadee;

namespace BusinessLayer
{
   public class DestekTalepManager
    {
        public static List<DestekTalep> Listele()
        {
            return FDestek.Listele();
        }
      
    }
}
