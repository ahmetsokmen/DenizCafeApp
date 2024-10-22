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
    public partial class UrunEkle : Form
    {
        public UrunEkle()
        {
            InitializeComponent();
        }
        

        private void btnBack_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();
            this.Hide();
            yoneticiPaneli.Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            bool isFloat = false;
            for (int i = 0; i < txtAddProductPrice.Text.Length; i++)
            {
                if (txtAddProductPrice.Text[i] == '0' || txtAddProductPrice.Text[i] == '1' || txtAddProductPrice.Text[i] == '2' || txtAddProductPrice.Text[i] == '3' || txtAddProductPrice.Text[i] == '4' || txtAddProductPrice.Text[i] == '5' || txtAddProductPrice.Text[i] == '6' || txtAddProductPrice.Text[i] == '7' || txtAddProductPrice.Text[i] == '8' || txtAddProductPrice.Text[i] == '9' || txtAddProductPrice.Text[i] == '.'|| txtAddProductPrice.Text[i] == ',')
                {
                    txtAddProductPrice.Text = txtAddProductPrice.Text.Replace(".", ",");
                    isFloat = true;
                    continue;

                }
                else
                {
                    isFloat = false;
                    break;
                }
            }
            if (txtAddProductName.Text!=""&&isFloat==true&&cmbAddProductCategory.SelectedItem!=null)
            {
                
                DenizCafeEntities db = new DenizCafeEntities();
                string productName = txtAddProductName.Text;
                decimal productPrice = Convert.ToDecimal(txtAddProductPrice.Text);
                string categoryName = cmbAddProductCategory.Text;

                db.Products.Add(new Products
                {
                    ProductName = productName,
                    ProductPrice = productPrice,
                    CategoryId = db.Categories.FirstOrDefault(x => x.CategoryName == categoryName).CategoryId,
                    ProductInStock = chkAddProductStock.Checked
                });
                db.SaveChanges();
                    
                MessageBox.Show("Ürün Eklendi", "İşlem Başarılı");

            }
            else
            {
                MessageBox.Show("Lütfen Değerleri Kontrol Ediniz", "Hata");

            }
        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {
            DenizCafeEntities db = new DenizCafeEntities();
            cmbAddProductCategory.DataSource = db.Categories.Select(x => x.CategoryName).ToList();
           

        }

        private void txtAddProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsDigit(e.KeyChar)==false||)
            //{
            //    e.Handled = true;
            //}
        }
    }
}
