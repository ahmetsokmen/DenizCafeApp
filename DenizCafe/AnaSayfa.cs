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
    public partial class AnaSayfa : Form
    {
        

        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Giris girisForm = new Giris();   
            this.Hide();
            girisForm.Show();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            SiparisPaneli siparispaneli = new SiparisPaneli();
           
            siparispaneli.Show();

            this.Hide();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            DenizCafeEntities db = new DenizCafeEntities();
            DateTime bugun = DateTime.Now;
            var todaysOrderLines = db.OrderLines.Where(a => a.OrderLineDate.Day==bugun.Day&&a.OrderLineDate.Month==bugun.Month&&a.OrderLineDate.Year==bugun.Year);
            decimal total= todaysOrderLines.Sum(x => x.OrderLineTotal);
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
                sw.Write("Sipariş Id = " +item.OrderLineId+ " Müşteri No " +item.OrderId+ " Ürün Adı =  " +product.ProductName+ " Adedi = " +item.OrderLineProductCount+ " Toplam Tutar = " +item.OrderLineTotal+ " ₺ " + " Tarih = " +item.OrderLineDate  );
                sw.Write("\n");
            }
            sw.Write("\n"); sw.Write("\n"); 
            sw.Write("Toplam = ");  sw.Write(total.ToString()); sw.Write(" ₺ ");
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
