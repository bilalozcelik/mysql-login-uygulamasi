using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace login_uygulaması
{
    public partial class Login : Form
    {
        Metot mtt = new Metot();
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textParola.Focus();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string conStr = "SERVER=localhost;DATABASE=testdb;UID=root;PWD=tbist.2022";
            using (var baglan = new MySqlConnection(conStr))
            {
                using (var komut = new MySqlCommand("select k_adi from kullanicilar order by k_adi",baglan))
                {
                    try
                    {
                        komut.Connection.Open();
                        MySqlDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            comboUyeler.Items.Add(dr["k_adi"].ToString());

                        }
                        comboUyeler.SelectedIndex = 0;

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("bağlantı hatası");
                    }
                }

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (mtt.kullaniciKontrol(comboUyeler.SelectedItem.ToString(), textParola.Text) == 1)
            { //MessageBox.Show("giriş başarılı");
                anaForm af = new anaForm();
                af.lblKullanici.Text = this.comboUyeler.SelectedItem.ToString();
                af.Text="Merhaba "+ this.comboUyeler.SelectedItem.ToString();
                this.Hide();
                af.Show();
            }
            else { MessageBox.Show("giriş yapılamadı"); }
        }
    }
}
