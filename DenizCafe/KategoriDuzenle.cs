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
    public partial class KategoriDuzenle : Form
    {
        public KategoriDuzenle()
        {
            InitializeComponent();
        }
        public KategoriDuzenle(int categoryId)
        {
            
            InitializeComponent();
            label4.Text = categoryId.ToString();
        }
        public static int GetCategory(int categoryName)
        {
            return categoryName;
        }
       
        private void KategoriDuzenle_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();
            this.Hide();
            yoneticiPaneli.Show();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (txtEditCategory.Text!="")
            {
                string categoryName = txtEditCategory.Text;
                DenizCafeEntities db = new DenizCafeEntities();
                var category = db.Categories.FirstOrDefault(x => x.CategoryId.ToString() == label4.Text.ToString());
                if (!db.Categories.Any(x=>x.CategoryName.ToLower()==categoryName.ToLower()))
                {
                    category.CategoryName = categoryName;
                    category.CategoryIsActive = chkCategoryIsActive.Checked;
                    db.SaveChanges();
                    MessageBox.Show("Değişiklikler Kaydedildi ", "İşlem Başarılı");

                }
                else
                {
                    MessageBox.Show("Bu isimde bir kategori zaten var ! ", "Hata");

                }

            }
        }
    }
}
