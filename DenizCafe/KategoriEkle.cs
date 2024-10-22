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
    public partial class KategoriEkle : Form
    {
        public KategoriEkle()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            DenizCafeEntities db = new DenizCafeEntities();
            if (txtAddCategory.Text!="")
            {
                string categoryName = txtAddCategory.Text;
                if (!db.Categories.Any(x=>x.CategoryName.ToLower()==categoryName.ToLower()))
                {
                    bool categoryIsActive = chkCategoryIsActive.Checked;
                    db.Categories.Add(new Categories()
                    {
                        CategoryIsActive = categoryIsActive,
                        CategoryName = categoryName
                    });
                    db.SaveChanges();
                    MessageBox.Show("Kategori Eklendi ", "İşlem Başarılı");
                }
                else
                {
                    MessageBox.Show("Bu isimde bir Kategori Zaten Var !", "Hata");

                }

               
            }
            else
            {
                MessageBox.Show("Kategori Adı Boş Olamaz !", "Hata");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();
            this.Hide();
            yoneticiPaneli.Show();
        }
    }
}
