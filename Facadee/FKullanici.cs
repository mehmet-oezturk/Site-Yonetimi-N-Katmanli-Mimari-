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
   public class FKullanici
    {
        public static int KGiris(KullaniciGiris veri) 
        {   
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("KGiris", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("@KullaniciAdi", veri.KullaniciAdi);
                komut.Parameters.AddWithValue("@Sifre", veri.Sifre);

                


                komut.ExecuteNonQuery();
            }
            catch
            {
                islem = -1;
            }
            return islem;
        }
        public static int DGiris(Daireler veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("DGiris", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("@ID", veri.ID);
                komut.Parameters.AddWithValue("@AdSoyad", veri.AdSoyad);

                komut.ExecuteNonQuery();
            }
            catch
            {
                islem = -1;
            }
            return islem;
        }
        public static int Ekleme(KullaniciGiris veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("KEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                komut.Parameters.AddWithValue("@KullaniciAdi", veri.KullaniciAdi);
                komut.Parameters.AddWithValue("@Sifre", veri.Sifre);
                
                islem = komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;
        }



    }
}
