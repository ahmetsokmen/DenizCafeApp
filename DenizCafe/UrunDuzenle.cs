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
    public partial class UrunDuzenle : Form
    {
        public UrunDuzenle()
        {
            InitializeComponent();
        }
        public UrunDuzenle(int id)
        {
            InitializeComponent();
            label6.Text = id.ToString();
            DenizCafeEntities db = new DenizCafeEntities();
            cmbEditProductCategory.DataSource = db.Categories.Select(x => x.CategoryName).ToList();

            var categoryName = db.Categories.FirstOrDefault(x => x.CategoryId == db.Products.FirstOrDefault(y=>y.ProductId==id).CategoryId).CategoryName.ToString();

            cmbEditProductCategory.SelectedItem = categoryName;




        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();
            this.Hide();
            yoneticiPaneli.Show();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {

            bool isFloat = false;
            for (int i = 0; i < txtEditProductPrice.Text.Length; i++)
            {
                if (txtEditProductPrice.Text[i] == '0' || txtEditProductPrice.Text[i] == '1' || txtEditProductPrice.Text[i] == '2' || txtEditProductPrice.Text[i] == '3' || txtEditProductPrice.Text[i] == '4' || txtEditProductPrice.Text[i] == '5' || txtEditProductPrice.Text[i] == '6' || txtEditProductPrice.Text[i] == '7' || txtEditProductPrice.Text[i] == '8' || txtEditProductPrice.Text[i] == '9' || txtEditProductPrice.Text[i] == '.' || txtEditProductPrice.Text[i] == ',')
                {
                    txtEditProductPrice.Text = txtEditProductPrice.Text.Replace(".", ",");
                    isFloat = true;
                    continue;

                }
                else
                {
                    isFloat = false;
                    break;
                }
            }
            if (txtEditProductPrice.Text != "" && isFloat == true && txtEditProductPrice.ToString()!="" && cmbEditProductCategory.SelectedItem != null)
            {

                DenizCafeEntities db = new DenizCafeEntities();
                string productName = txtEditProductName.Text;
                decimal productPrice = Convert.ToDecimal(txtEditProductPrice.Text);
                string categoryName = cmbEditProductCategory.Text;

                 var product = db.Products.Find(Convert.ToInt32(label6.Text));
                product.ProductName = productName;
                product.ProductPrice = productPrice;
                product.CategoryId = db.Categories.FirstOrDefault(x => x.CategoryName == categoryName).CategoryId;
                product.ProductInStock = chkEditProductStock.Checked;

                db.SaveChanges();

                MessageBox.Show("Ürün Güncellendi", "İşlem Başarılı");

            }
            else
            {
                MessageBox.Show("Lütfen Değerleri Kontrol Ediniz", "Hata");

            }

        }
    }
   
}
