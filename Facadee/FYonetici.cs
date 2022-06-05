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
    public class FYonetici
    { 
    public static List<Yoneticiler> Listele()
    {
        List<Yoneticiler> itemlist = null;
        SqlCommand con = new SqlCommand("YListele", Baglanti.con);
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
                itemlist = new List<Yoneticiler>();
                while (rdr.Read())
                {
                    Yoneticiler item = new Yoneticiler();
                    item.ID = Convert.ToInt32(rdr["ID"]);
                    

                    item.AdSoyad = rdr["AdSoyad"].ToString();
                    item.Tel = rdr["Tel"].ToString();
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
    public static int Ekleme(Yoneticiler veri)
    {
        int islem = 0;
        try
        {
            SqlCommand komut = new SqlCommand("YEkle", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("@AdSoyad", veri.AdSoyad);
            komut.Parameters.AddWithValue("@Tel", veri.Tel);
            
            islem = komut.ExecuteNonQuery();

        }
        catch
        {
            islem = -1;
        }
        return islem;
    }
    public static int Guncelle(Yoneticiler up)

    {
        int islem = 0;
        try
        {
            SqlCommand komut = new SqlCommand("YYenile", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@ID", up.ID);
            komut.Parameters.AddWithValue("@AdSoyad", up.AdSoyad);
            komut.Parameters.AddWithValue("@Tel", up.Tel);
            
            islem = komut.ExecuteNonQuery();

        }
        catch
        {
            islem = -1;
        }
        return islem;
    }
    public static bool Sil(Yoneticiler islem)
    {
        SqlCommand komut = new SqlCommand("YSil", Baglanti.con);
        komut.CommandType = CommandType.StoredProcedure;
        komut.Parameters.AddWithValue("@ID", islem.ID);
        return Baglanti.ExecuteNonQuery(komut);
    }
}
}

