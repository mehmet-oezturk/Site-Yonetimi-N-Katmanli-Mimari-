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
   public class FBolumler
    {
        public static List<Bolumler> Listele()
        {
            List<Bolumler> itemlist = null;
            SqlCommand con = new SqlCommand("BLListele", Baglanti.con);
            try
            {

                con.CommandType = CommandType.StoredProcedure;
                if (con.Connection.State != ConnectionState.Open)
                {
                    con.Connection.Open();
                }
                SqlDataReader rdr = con.ExecuteReader();
                //DataTablereader ve sqldatareader nesnelerinin HasRows
                //propertesinin data olması durumunda true bir değer data yoksa false
                // değeri döndürmesidir.

                //işlem yaparken if ile dönen değeri kontrol ettiririz.
                //True ise veriyi tabloya basabiliriz. False ise veri olmadığı için tabloya data yollamayız.

                if (rdr.HasRows)
                {
                    itemlist = new List<Bolumler>();
                    while (rdr.Read())
                    {
                        Bolumler item = new Bolumler();
                        item.ID = Convert.ToInt32(rdr["ID"]);
                        

                        item.Ad = rdr["Ad"].ToString();
                        
                        itemlist.Add(item);
                    }
                }
            }
            catch
            {
                itemlist = null;
            }
            finally
            {
                con.Connection.Close();
            }
            return itemlist;
        }

      

        public static int Ekleme(Bolumler veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("BLEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

               
                komut.Parameters.AddWithValue("Ad", veri.Ad);
                
                islem = komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;
        }

        //public static void Sil(global::siteyönetimi.Bolumler k)
        //{
        //    throw new NotImplementedException();
        //}

        public static int Guncelle(Bolumler up)

        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("BLYenile", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("@ID", up.ID);

                komut.Parameters.AddWithValue("@Ad", up.Ad);
               
                islem = komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;
        }
        public static bool Sil(Bolumler islem)
        {
            SqlCommand komut = new SqlCommand("BLSil", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@ID", islem.ID);
            return Baglanti.ExecuteNonQuery(komut);
        }

    }
}
