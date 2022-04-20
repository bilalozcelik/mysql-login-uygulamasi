using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace login_uygulaması
{
    public class Metot
    {
        #region kullanıcı kontrol
        string conStr = "SERVER=localhost;DATABASE=testdb;UID=root;PWD=tbist.2022";
        public int kullaniciKontrol(string kAd, string kSifre)
        {
            int sonuc = 0;
            using (var con = new MySqlConnection(conStr))
            {
                using (var cmd = new MySqlCommand($"select k_adi,k_sifre from kullanicilar where k_adi='{kAd}' and k_sifre='{kSifre}'", con))
                {
                    try
                    {
                        cmd.Connection.Open();
                        MySqlDataReader dtr = cmd.ExecuteReader();
                        if (dtr.Read())
                        {
                            string d_k = dtr["k_adi"].ToString();
                            string d_s = dtr["k_sifre"].ToString();
                            if (d_k == kAd && d_s == kSifre)
                            {
                                sonuc = 1;
                            }
                            else
                            {
                                sonuc = 0;
                            }
                        }
                    }
                    catch
                    {
                        sonuc = 0;
                    }
                }
                return sonuc;
            }
        }
    }
    #endregion

}
