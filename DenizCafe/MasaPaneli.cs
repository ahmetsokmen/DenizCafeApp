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
    public partial class MasaPaneli : Form
    {

        public MasaPaneli()
        {
            InitializeComponent();
        }
        bool isTableFull;//ctordan önce çalışıyor.
        Orders order;
        //bool toggleLight;
        //Timer t = new Timer();
        public MasaPaneli(string id)
        {
            InitializeComponent();
            label2.Text = id;
            DenizCafeEntities db = new DenizCafeEntities();
            isTableFull = db.Tables.Find(Convert.ToInt32(id)).TableIsFull;


        }
        public int GetCategoryFromListBox()
        {
            if (lstCategories.DataSource != null)
            {
                DenizCafeEntities db = new DenizCafeEntities();
                string selectedCategoryName = lstCategories.SelectedItem.ToString();
                int selectedCategoryId = db.Categories.FirstOrDefault(x => x.CategoryName == selectedCategoryName).CategoryId;
                lstProducts.DataSource = db.Products.Where(x => x.CategoryId == selectedCategoryId).ToList();
                return selectedCategoryId;
            }
            return 0;

        }
        public void dgvResetLoad()
        {

            DenizCafeEntities db = new DenizCafeEntities();
            dgvOrderLines.Columns[0].HeaderText = "Sipariş No";
            dgvOrderLines.Columns[1].HeaderText = "Adet";
            dgvOrderLines.Columns[2].HeaderText = "Tutar ₺";
            dgvOrderLines.Columns[3].HeaderText = "Tarih";
            dgvOrderLines.Columns[4].HeaderText = "Ürün Id";
            dgvOrderLines.Columns[5].HeaderText = "Müşteri No";
            dgvOrderLines.Columns[6].Visible = false;
            dgvOrderLines.Columns[7].Visible = false;
            dgvOrderLines.Columns.Add("urunadi", "Ürün Adı");//id yerine productname yazdıracağımız alan
            var products = db.Products.ToList();
            dgvOrderLines.Columns[0].DisplayIndex = 0;//sıralama
            dgvOrderLines.Columns[5].DisplayIndex = 1;
            dgvOrderLines.Columns[8].DisplayIndex = 2;
            dgvOrderLines.Columns[1].DisplayIndex = 3;
            dgvOrderLines.Columns[2].DisplayIndex = 4;
            dgvOrderLines.Columns[3].DisplayIndex = 5;
            dgvOrderLines.Columns[4].DisplayIndex = 6;
            for (int i = 0; i < dgvOrderLines.Rows.Count; i++)
            {
                dgvOrderLines.Rows[i].Cells[8].Value = db.Products.Find(Convert.ToInt32(dgvOrderLines.Rows[i].Cells[4].Value)).ProductName;
            }//id yerine productname yazdırdık.

            //dgvOrderLines.Columns[4].CellTemplate.ValueType = typeof(string);
            //dgvOrderLines.Columns[4].ValueType = typeof(string);,
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            SiparisPaneli siparispaneli = new SiparisPaneli();
            this.Hide();
            siparispaneli.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MasaPaneli_Load(object sender, EventArgs e)
        {
            if (isTableFull == true)
            {
                DenizCafeEntities db = new DenizCafeEntities();
                var categories = db.Categories.Select(x => x.CategoryName).ToList();
                lstCategories.DataSource = categories;
                btnTable.Text = "DOLU";
                btnTable.BackColor = System.Drawing.Color.Red;
                var table = db.Tables.Find(Convert.ToInt32(label2.Text));
                var order = table.Orders.LastOrDefault();
                label6.Text = order.OrderId.ToString();
                lblTotal.Text = order.OrderLines.Sum(x => x.OrderLineTotal) + " ₺ ";
                if (order.OrderLines.Count != 0)
                {
                    var orderLines = order.OrderLines.ToList();
                    dgvOrderLines.DataSource = orderLines;
                    dgvResetLoad();
                }



            }
            else
            {
                btnTable.Text = "BOŞ";
                btnTable.BackColor = System.Drawing.Color.GreenYellow;
            }
        }
        private Orders CreateOrder()
        {
            DenizCafeEntities db = new DenizCafeEntities();
            Orders order = new Orders();
            order.OrderDate = DateTime.Now;
            order.TableId = db.Tables.Find(Convert.ToInt32(label2.Text)).TableId;
            db.Orders.Add(order);
            db.SaveChanges();
            return order;
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            if (isTableFull)
            {
                btnTable.Text = "BOŞ";
                lblTotal.Text = "0 ₺";
                btnTable.BackColor = System.Drawing.Color.GreenYellow;
                DenizCafeEntities db = new DenizCafeEntities();
                var table = db.Tables.Find(Convert.ToInt32(label2.Text));
                isTableFull = !isTableFull;
                table.TableIsFull = !table.TableIsFull;
                db.SaveChanges();
                var categories = db.Categories.Select(x => x.CategoryName).ToList();
                lstCategories.DataSource = null;
                lstProducts.DataSource = null;
                dgvOrderLines.DataSource = null;
                dgvOrderLines.Columns.Remove("urunadi");//load sırasındakj eklediğimiz bu kolon masa boşalınca silinmelidir dgv hata veriyor.


            }
            else
            {
                btnTable.Text = "DOLU";
                btnTable.BackColor = System.Drawing.Color.Red;
                DenizCafeEntities db = new DenizCafeEntities();
                var table = db.Tables.Find(Convert.ToInt32(label2.Text));
                isTableFull = !isTableFull;
                table.TableIsFull = !table.TableIsFull;
                db.SaveChanges();
                var categories = db.Categories.Select(x => x.CategoryName).ToList();
                lstCategories.DataSource = categories;
                this.order = new Orders();
                this.order = CreateOrder();
                label6.Text = order.OrderId.ToString();

            }
        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GetCategoryFromListBox() != 0)
            {
                DenizCafeEntities db = new DenizCafeEntities();
                int selectedCategoryId = GetCategoryFromListBox();
                lstProducts.DataSource = db.Categories.Find(selectedCategoryId).Products.Select(x => x.ProductName).ToList();

            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem != null && lstProducts.SelectedItem != null && label6.Text != "" && (rdb1.Checked == true || rdb2.Checked == true || rdb3.Checked == true || rdb4.Checked == true || rdb5.Checked == true || rdb6.Checked == true))
            {
                DenizCafeEntities db = new DenizCafeEntities();
                var table = db.Tables.Find(Convert.ToInt32(label2.Text));
                var product = db.Products.FirstOrDefault(x => x.ProductName == lstProducts.SelectedItem.ToString());
                var checkedButton = this.Controls.OfType<RadioButton>()
                                     .FirstOrDefault(r => r.Checked);//seçili radiobuttonu getirir.
                var CurrentOrder = db.Orders.Find(Convert.ToInt32(label6.Text));
                OrderLines orderline = new OrderLines();
                orderline.OrderId = CurrentOrder.OrderId;
                orderline.OrderLineDate = DateTime.Now;
                orderline.ProductId = product.ProductId;
                orderline.OrderLineProductCount = Convert.ToByte(checkedButton.Text);//tiny int .nette byte olarak okunur.
                orderline.OrderLineTotal = product.ProductPrice * Convert.ToInt32(checkedButton.Text);
                CurrentOrder.OrderLines.Add(orderline);
                db.SaveChanges();
                var orderLines = CurrentOrder.OrderLines.ToList();
                dgvOrderLines.DataSource = orderLines;
                lblTotal.Text = CurrentOrder.OrderLines.Sum(x => x.OrderLineTotal) + " ₺ ";
                if (CurrentOrder.OrderLines.Count == 1)
                {

                    dgvResetLoad();
                }

                //for (int i = 0; i < dgvOrderLines.Rows.Count; i++)
                //{
                //    dgvOrderLines.Rows[i].Cells[8].Value = db.Products.Find(Convert.ToInt32(dgvOrderLines.Rows[i].Cells[4].Value)).ProductName;
                //}


            }
            else
            {
                MessageBox.Show("Lütfen tüm seçimleri yaptığınızdan emin olunuz", "Hata !");
            }
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        public int RemoveOrderLineId { get; set; }
        private void btnRemoveOrderLine_Click(object sender, EventArgs e)
        {
            if (dgvOrderLines.SelectedRows.Count == 0)
            {

                MessageBox.Show("Lütfen silmek istediğiniz siparişi seçiniz", "Hata");

            }
            else if (RemoveOrderLineId == 0)
            {
                MessageBox.Show("Güvenlik nedeniyle tek seferde maksimum 1 adet sipariş silebilirsiniz !", "Hata");

            }

            else
            {

                DenizCafeEntities db = new DenizCafeEntities();
                var CurrentOrder = db.Orders.Find(Convert.ToInt32(label6.Text));
                //int OrderLineId = Convert.ToInt32(dgvOrderLines.SelectedRows[0].Cells[0].Value);
                var orderLine = db.OrderLines.Find(this.RemoveOrderLineId);
                //label8.Text = RemoveOrderLineId.ToString();
                db.OrderLines.Remove(orderLine);
                db.SaveChanges();
                var orderLines = CurrentOrder.OrderLines.ToList();
                dgvOrderLines.Refresh();
                dgvOrderLines.DataSource = orderLines;
                lblTotal.Text = CurrentOrder.OrderLines.Sum(x => x.OrderLineTotal) + " ₺ ";
                MessageBox.Show("Sipariş Başarıyla Silindi !", "İşlem Başarılı");

            }
        }

        private void dgvOrderLines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOrderLines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.RemoveOrderLineId = Convert.ToInt32(dgvOrderLines.SelectedRows[0].Cells[0].Value);

        }
    }
}
