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
    public class FBlok
    {
        public static List<Bloks> Listele()
        {
            List<Bloks> itemlist = null;
            SqlCommand con = new SqlCommand("BListele", Baglanti.con);
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
                    itemlist = new List<Bloks>();
                    while (rdr.Read())
                    {
                        Bloks item = new Bloks();
                        item.ID = Convert.ToInt32(rdr["ID"]);
                        item.Kat = Convert.ToInt32(rdr["Kat"]);
                        
                        item.Ad = rdr["Ad"].ToString();
                        item.YoneticiID= Convert.ToInt32(rdr["YoneticiID"]);
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
        public static int Ekleme(Bloks veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("BEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
               
                komut.Parameters.AddWithValue("@Kat", veri.Kat);
                komut.Parameters.AddWithValue("@Ad", veri.Ad);
                komut.Parameters.AddWithValue("@YoneticiID", veri.YoneticiID);
                islem = komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;
        }
        public static int Guncelle(Bloks up)

        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("BYenile", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("@ID", up.ID);
                komut.Parameters.AddWithValue("@Kat", up.Kat);
                komut.Parameters.AddWithValue("@Ad", up.Ad);
                komut.Parameters.AddWithValue("@YoneticiID", up.YoneticiID);
                islem = komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;
        }
        public static bool Sil(Bloks islem)
        {
            SqlCommand komut = new SqlCommand("BSil", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@ID", islem.ID);
            return Baglanti.ExecuteNonQuery(komut);
        }
    }
}
