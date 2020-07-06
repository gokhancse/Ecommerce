using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;

namespace DataLayer
{
    public class SiteDil
    {
        public Hashtable KelimeleriGetir(string dil = "TR")
        {
            Hashtable kelime = new Hashtable();
            if (HttpContext.Current.Session["Kelimeler"] != null)
            {
                kelime = HttpContext.Current.Session["Kelimeler"] as Hashtable;
                return kelime;
            }

            SqlConnection connection = new SqlConnection(@"Data Source=HAKAN-PC\SQLEXRESS;Initial Catalog=ECOM_DBase;Integrated Security=True");

            connection.Open();
            SqlCommand command = new SqlCommand("select SatirNo," + dil + " from Kelimeler", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                kelime.Add(reader["SatirNo"].ToString(), reader[dil].ToString());
            }
            reader.Close();
            connection.Close();
            HttpContext.Current.Session["Kelimeler"] = kelime;
            return kelime;
        }
        public string DileGoreGetir(string tr, string eng)
        {
            return HttpContext.Current.Session["Dil"] == null || HttpContext.Current.Session["Dil"] == "TR" ? tr : eng;
        }

    }
}