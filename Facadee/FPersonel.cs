using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entity;

namespace Facadee
{
    public class FPersonel
    {
     
        
            public static int Ekleme(Personeller veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("PEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                komut.Parameters.AddWithValue("@AdSoyad", veri.AdSoyad);
                komut.Parameters.AddWithValue("@BolumNo", veri.BolumNo);
                komut.Parameters.AddWithValue("@Tel", veri.Tel);
                komut.Parameters.AddWithValue("@CalistigiBlokNo", veri.CalistigiBlokNo);

                islem = komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;
        }
        public static int Guncelle(Personeller veri)

        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("PYenile", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("@ID",veri.ID);
                komut.Parameters.AddWithValue("@AdSoyadt", veri.AdSoyad);
                komut.Parameters.AddWithValue("@BolumNo", veri.BolumNo);
                komut.Parameters.AddWithValue("@Tel", veri.Tel);
                komut.Parameters.AddWithValue("@CalistigiBlokNo", veri.CalistigiBlokNo);
                islem = komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;
        }
        public static bool Sil(Personeller islem)
        {
            SqlCommand komut = new SqlCommand("PSil", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@ID", islem.ID);
            return Baglanti.ExecuteNonQuery(komut);
        }
    }
}
