using DenizCafe.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenizCafe
{
    public partial class YoneticiPaneli : Form
    {

        public YoneticiPaneli()
        {
            InitializeComponent();
        }


        private void btnListCategories_Click(object sender, EventArgs e)
        {
            lstCategories.Items.Clear();
            DenizCafeEntities db = new DenizCafeEntities();
            foreach (var item in db.Categories)
            {
                lstCategories.Items.Add(item.CategoryName);
            }
        }
        public int GetCategoryFromListBox()
        {
            DenizCafeEntities db = new DenizCafeEntities();
            string selectedCategoryName = lstCategories.SelectedItem.ToString();
            int selectedCategoryId = db.Categories.FirstOrDefault(x => x.CategoryName == selectedCategoryName).CategoryId;
            dgvProducts.DataSource = db.Products.Where(x => x.CategoryId == selectedCategoryId).ToList();
            return selectedCategoryId;
        }
        public int GetProductIdtFromDataGridVİew()
        {
                int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells[0].Value);
                return productId; 
           
           
        }
        public void dgvReset()
        {
            GetCategoryFromListBox();
            this.dgvProducts.Columns["ProductId"].Visible = false;
            this.dgvProducts.Columns["CategoryId"].Visible = false;
            this.dgvProducts.Columns["Categories"].Visible = false;
            this.dgvProducts.Columns["OrderLines"].Visible = false;
            dgvProducts.Columns[1].HeaderText = "Ürün Adı";
            dgvProducts.Columns[2].HeaderText = "Fiyat ₺";
            dgvProducts.Columns[3].HeaderText = "Stok";

        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReset();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            KategoriEkle kategoriEkle = new KategoriEkle();
            this.Hide();
            kategoriEkle.Show();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {


            if (lstCategories.Items.Count != 0)
            {


                if (lstCategories.SelectedItem != null)
                {
                    DenizCafeEntities db = new DenizCafeEntities();
                    KategoriDuzenle kategoriDuzenle = new KategoriDuzenle(GetCategoryFromListBox());// edit: modifiers ile yazdırdık ama categoryyi ctor ile aldık.
                    kategoriDuzenle.txtEditCategory.Text = lstCategories.SelectedItem.ToString();//txteditcategorynin modifiers çzelliği public yapıldı. ikinci alternatif olarak ctor ile almak mümkün.
                    kategoriDuzenle.chkCategoryIsActive.Checked = db.Categories.Find(GetCategoryFromListBox()).CategoryIsActive;

                    this.Hide();
                    kategoriDuzenle.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen Kategori Seçiniz ", "Hata");
                }
            }

        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.Items.Count != 0)
            {


                if (lstCategories.SelectedItem != null)
                {
                    DenizCafeEntities db = new DenizCafeEntities();
                    var category = db.Categories.Find(GetCategoryFromListBox());
                    if (MessageBox.Show(category.CategoryName.ToString() + " isimli kategori silinecektir.\nOnaylıyor Musunuz ? ", "Kategori Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (var item in category.Products)
                        {
                            db.Products.Remove(item);
                        }
                        db.Categories.Remove(category);
                        db.SaveChanges();
                        MessageBox.Show("Kategori Silindi", "İşlem Başarılı");

                    }

                }
                else
                {
                    MessageBox.Show("Lütfen Kategori Seçiniz ", "Hata");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            this.Hide();
            anasayfa.Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            UrunEkle urunekle = new UrunEkle();
            this.Hide();
            urunekle.Show();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.Rows.Count != 0)
            {

                if (dgvProducts.SelectedRows.Count!=0)
                {
                    DenizCafeEntities db = new DenizCafeEntities();
                    UrunDuzenle urunDuzenle = new UrunDuzenle(GetProductIdtFromDataGridVİew());// edit: modifiers ile yazdırdık ama categoryyi ctor ile aldık.
                    var product = db.Products.Find(GetProductIdtFromDataGridVİew());
                    urunDuzenle.txtEditProductName.Text = product.ProductName;  //txteditcategorynin modifiers çzelliği public yapıldı. ikinci alternatif olarak ctor ile almak mümkün.
                    urunDuzenle.txtEditProductPrice.Text = product.ProductPrice.ToString();
                    //urunDuzenle.cmbEditProductCategory.SelectedItem= db.Products.Find(product.ProductId).ProductName.ToString();
                    urunDuzenle.chkEditProductStock.Checked = product.ProductInStock;

                    this.Hide();
                    urunDuzenle.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen Ürün Seçiniz ", "Hata");
                }
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.Rows.Count != 0)
            { 
                if (dgvProducts.SelectedRows.Count != 0)
                {
                    DenizCafeEntities db = new DenizCafeEntities();
                    var product = db.Products.Find(GetProductIdtFromDataGridVİew());
                    

                    if (MessageBox.Show(product.ProductName.ToString() + " isimli ürün silinecektir.\nOnaylıyor Musunuz ? ", "Ürün Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        db.Products.Remove(product);
                        db.SaveChanges();
                        MessageBox.Show("Ürün Silindi", "İşlem Başarılı");

                    }

                }
                else
                {
                    MessageBox.Show("Lütfen Ürün Seçiniz ", "Hata");
                }



            }


            }

        private void btnReports_Click(object sender, EventArgs e)
        {
            DenizCafeEntities db = new DenizCafeEntities();
            DateTime bugun = DateTime.Now;
            var todaysOrderLines = db.OrderLines.Where(a => a.OrderLineDate.Day == bugun.Day && a.OrderLineDate.Month == bugun.Month && a.OrderLineDate.Year == bugun.Year);
            decimal total = todaysOrderLines.Sum(x => x.OrderLineTotal);
            string dosya_yolu = @"C:\DenizCafeReports.txt";
            //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
            FileStream fs = new FileStream(dosya_yolu, FileMode.Append, FileAccess.Write);
            //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
            //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
            //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
            StreamWriter sw = new StreamWriter(fs);
            //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
            sw.Write(bugun);
            sw.Write("\n");
            sw.Write("\n");
            foreach (var item in todaysOrderLines)
            {
                var product = db.Products.Find(item.ProductId);
                sw.Write("Sipariş Id = " + item.OrderLineId + " Müşteri No " + item.OrderId + " Ürün Adı =  " + product.ProductName + " Adedi = " + item.OrderLineProductCount + " Toplam Tutar = " + item.OrderLineTotal + " ₺ " + " Tarih = " + item.OrderLineDate);
                sw.Write("\n");
            }
            sw.Write("\n"); sw.Write("\n");
            sw.Write("Toplam = "); sw.Write(total.ToString()); sw.Write(" ₺ ");
            sw.Write("\n"); sw.Write("\n");
            //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
            sw.Flush();
            //Veriyi tampon bölgeden dosyaya aktardık.
            sw.Close();
            fs.Close();
            //İşimiz bitince kullandığımız nesneleri iade ettik.

            MessageBox.Show("Bugünkü satışlara ait raporlar " + dosya_yolu + "dosyasına eklendi", "İşlem Başarılı");
        }
    }
    }

