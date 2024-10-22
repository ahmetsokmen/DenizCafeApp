using DenizCafe.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenizCafe
{
    public partial class Giris : Form
    {
        DenizCafeEntities db = new DenizCafeEntities();

        public Giris()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text !="" && txtPassword.Text!="")
            {
            }
            string userName = txtUserName.Text;
                string password = txtPassword.Text;

                foreach (var item in db.Administrators)
                {
                }
                YoneticiPaneli yoneticiPaneli= new YoneticiPaneli();
                        this.Hide();
                        yoneticiPaneli.Show();
                    //if (item.AdminUserName == userName && item.AdminPassword == password)
                    //{
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Hata");


                    //}
               
           
            //else
            //{
            //    MessageBox.Show("Kullanıcı Adı ve Şifre Boş Olamaz", "Hata");
            //}
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            this.Hide();
            anasayfa.Show();
        }
    }
}
