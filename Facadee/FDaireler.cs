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
    public class FDaireler
    {
        public static List<Daireler> Listele()
        {
            List<Daireler> itemlist = null;
            SqlCommand con = new SqlCommand("DListele", Baglanti.con);
            try
            {

                con.CommandType = CommandType.StoredProcedure;
                if (con.Connection.State != ConnectionState.Open)
                {
                    con.Connection.Open();
                }
                SqlDataReader rdr = con.ExecuteReader();
                
                if (rdr.HasRows)
                {
                    itemlist = new List<Daireler>();
                    while (rdr.Read())
                    {
                        Daireler item = new Daireler();
                        item.DaireNo = Convert.ToInt32(rdr["DaireNo"]);
                        item.BlokNo = Convert.ToInt32(rdr["BlokID"]);

                        item.AdSoyad = rdr["AdSoyad"].ToString();
                        item.Tel = rdr["Tel"].ToString();
                        item.Aidat = Convert.ToDecimal(rdr["Aidat"]);
                        item.Kira = Convert.ToDecimal(rdr["Kira"]);
                        item.Dolu= Convert.ToBoolean(rdr["Dolu"]);
                        item.ID=Convert.ToInt32(rdr["ID"]);
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

      

        public static int Ekleme(Daireler veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("DEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                komut.Parameters.AddWithValue("@DaireNo", veri.DaireNo);
                komut.Parameters.AddWithValue("@BlokNo", veri.BlokNo);
                komut.Parameters.AddWithValue("@AdSoyad", veri.AdSoyad);
                komut.Parameters.AddWithValue("@Tel", veri.Tel);
                komut.Parameters.AddWithValue("@Aidat", veri.Aidat);
                komut.Parameters.AddWithValue("@Kira", veri.Kira);
                komut.Parameters.AddWithValue("@Dolu", veri.Dolu);
                islem = komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;
        }
        public static int Guncelle(Daireler veri)

        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("DYenile", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("@ID", veri.ID);
                komut.Parameters.AddWithValue("@DaireNo", veri.DaireNo);
                komut.Parameters.AddWithValue("@BlokNo", veri.BlokNo);
                komut.Parameters.AddWithValue("@AdSoyad", veri.AdSoyad);
                komut.Parameters.AddWithValue("@Tel", veri.Tel);
                komut.Parameters.AddWithValue("@Aidat", veri.Aidat);
                komut.Parameters.AddWithValue("@Kira", veri.Kira);
                komut.Parameters.AddWithValue("@Dolu", veri.Dolu);
                islem = komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;
        }
        public static bool Sil(Daireler islem)
        {
            SqlCommand komut = new SqlCommand("DSil", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@ID", islem.ID);
            return Baglanti.ExecuteNonQuery(komut);
        }
        public static List<Daireler> BorcluListele()
        {
            List<Daireler> itemlist = null;
            SqlCommand con = new SqlCommand("DBorclu", Baglanti.con);
            try
            {

                con.CommandType = CommandType.StoredProcedure;
                if (con.Connection.State != ConnectionState.Open)
                {
                    con.Connection.Open();
                }
                SqlDataReader rdr = con.ExecuteReader();

                if (rdr.HasRows)
                {
                    itemlist = new List<Daireler>();
                    while (rdr.Read())
                    {
                        Daireler item = new Daireler();
                        item.DaireNo = Convert.ToInt32(rdr["DaireNo"]);
                        item.BlokNo = Convert.ToInt32(rdr["BlokID"]);

                        item.AdSoyad = rdr["AdSoyad"].ToString();
                        item.Tel = rdr["Tel"].ToString();
                        item.Aidat = Convert.ToDecimal(rdr["Aidat"]);
                        item.Kira = Convert.ToDecimal(rdr["Kira"]);
                        item.Dolu = Convert.ToBoolean(rdr["Dolu"]);
                        item.ID = Convert.ToInt32(rdr["ID"]);
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
        public static List<Daireler> BorcsuzListele()
        {
            List<Daireler> itemlist = null;
            SqlCommand con = new SqlCommand("DBorcsuz", Baglanti.con);
            try
            {

                con.CommandType = CommandType.StoredProcedure;
                if (con.Connection.State != ConnectionState.Open)
                {
                    con.Connection.Open();
                }
                SqlDataReader rdr = con.ExecuteReader();

                if (rdr.HasRows)
                {
                    itemlist = new List<Daireler>();
                    while (rdr.Read())
                    {
                        Daireler item = new Daireler();
                        item.DaireNo = Convert.ToInt32(rdr["DaireNo"]);
                        item.BlokNo = Convert.ToInt32(rdr["BlokID"]);

                        item.AdSoyad = rdr["AdSoyad"].ToString();
                        item.Tel = rdr["Tel"].ToString();
                        item.Aidat = Convert.ToDecimal(rdr["Aidat"]);
                        item.Kira = Convert.ToDecimal(rdr["Kira"]);
                        item.Dolu = Convert.ToBoolean(rdr["Dolu"]);
                        item.ID = Convert.ToInt32(rdr["ID"]);
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
    }
}
