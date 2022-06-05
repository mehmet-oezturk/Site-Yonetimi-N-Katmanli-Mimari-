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
    public class FDestek
    {
        public static List<DestekTalep> Listele()
        {
            List<DestekTalep> itemlist = null;
            SqlCommand con = new SqlCommand("DTListele", Baglanti.con);
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
                    itemlist = new List<DestekTalep>();
                    while (rdr.Read())
                    {   
                        DestekTalep item = new DestekTalep();
                        item.ID = Convert.ToInt32(rdr["ID"]);
                        item.DaireID = Convert.ToInt32(rdr["DaireID"]);

                        item.DTAciklama = rdr["DTAciklama"].ToString();
                       
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
        public static int Ekleme(DestekTalep veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("DTEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }

                komut.Parameters.AddWithValue("@DTAciklama", veri.DTAciklama);
                komut.Parameters.AddWithValue("@DaireID ", veri.DaireID);
                
                islem = komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;
        }

        

        public static bool Sil(DestekTalep islem)
        {
            SqlCommand komut = new SqlCommand("DTSil", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@ID", islem.ID);
            return Baglanti.ExecuteNonQuery(komut);
        }
    }
}
