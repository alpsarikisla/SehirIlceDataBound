using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        public List<Sehir> SehirleriGetir()
        {
            List<Sehir> Sehirler = new List<Sehir>();
            try
            {
                cmd.CommandText = "SELECT ID, Isim FROM Sehirler";
                cmd.Parameters.Clear();

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Sehir s = new Sehir()
                    {
                        ID = reader.GetInt32(0),
                        Isim = reader.GetString(1)
                    };
                    Sehirler.Add(s);
                }
                return Sehirler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }


        /// <summary>
        /// Veritabanından tüm ilçeleri getirir
        /// </summary>
        /// <returns>Jenerik koleksiyon olarak Ilce koleksiyonu döndürür</returns>
        public List<Ilce> IlceleriGetir()
        {
            List<Ilce> ilceler = new List<Ilce>();
            try
            {
                cmd.CommandText = "SELECT ID, SehirID, Isim FROM Ilceler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ilce i = new Ilce()
                    {
                        ID = reader.GetInt32(0),
                        SehirID = reader.GetInt32(1),
                        Isim = reader.GetString(2)
                    };
                    ilceler.Add(i);
                }
                return ilceler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Gönderilen şehirID ye göre tanımlı ilçeleri getirir
        /// </summary>
        /// <param name="SehirID">int türünde Şehir bilgisi</param>
        /// <returns>Jenerik koleksiyon olarak Ilce koleksiyonu döndürür</returns>
        public List<Ilce> IlceleriGetir(int SehirID)
        {
            List<Ilce> ilceler = new List<Ilce>();
            try
            {
                cmd.CommandText = "SELECT ID, SehirID, Isim FROM Ilceler WHERE SehirID=@sid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sid", SehirID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ilce i = new Ilce()
                    {
                        ID = reader.GetInt32(0),
                        SehirID = reader.GetInt32(1),
                        Isim = reader.GetString(2)
                    };
                    ilceler.Add(i);
                }
                return ilceler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
