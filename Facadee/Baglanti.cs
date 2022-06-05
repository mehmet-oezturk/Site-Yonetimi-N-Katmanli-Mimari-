
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Facadee
{
    public class Baglanti
    {
        public static readonly SqlConnection con = new SqlConnection
            ("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Site;Integrated Security=True");//bu alana kendi baglantı adresinizi yazacaksınız

        public static object KullaniciGiris { get; set; }

        public static bool ExecuteNonQuery(SqlCommand komut)
        {
            try
            {
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                return komut.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (komut.Connection.State != ConnectionState.Closed)
                    komut.Connection.Close();

            }


        }
    }
}
