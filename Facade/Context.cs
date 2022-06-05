using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Context: DbContext
    {
        public DbSet<Bloks> Bloks { get; set; }
        public DbSet<Bolumler> Bolumlers { get; set; }
        public DbSet<Daireler> Dairelers { get; set; }
        public DbSet<DestekTalep> DestekTaleps { get; set; }
        public DbSet<KullaniciGiris>KullaniciGirises { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Yoneticiler> Yoneticilers { get; set; }

    }
}
