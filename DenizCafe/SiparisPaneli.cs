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
    public partial class SiparisPaneli : Form
    {
        public SiparisPaneli()
        {
            InitializeComponent();
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            this.Hide();
            anasayfa.Show();
        }
        int sayac = 0;
        private void SiparisPaneli_Load(object sender, EventArgs e)
        {
            DenizCafeEntities db = new DenizCafeEntities();
            var tables = db.Tables.ToList();
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    sayac++;
                    Button btn = new Button();
                    btn.Text = sayac.ToString();
                   btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    btn.Name = sayac.ToString();
                    btn.Size = new Size(120, 120);
                    if (tables[sayac-1].TableIsFull==false)
                    {
                        btn.BackColor = System.Drawing.Color.GreenYellow;
                    }
                    else if (tables[sayac-1].TableIsFull == true)
                    {
                        btn.BackColor = System.Drawing.Color.Red;
                    }
                    btn.Location = new Point(130 * (j+1), 130 * (i+1));    
                    Controls.Add(btn);
                    btn.Click += Btn_Click;

                    //this.btnAdmin.BackColor = System.Drawing.Color.GreenYellow;
                    //this.btnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    //this.btnAdmin.Location = new System.Drawing.Point(213, 297);
                    //this.btnAdmin.Name = "btnAdmin";
                    //this.btnAdmin.Size = new System.Drawing.Size(139, 58);
                    //this.btnAdmin.TabIndex = 3;
                    //this.btnAdmin.Text = "Yönetici Paneli";
                    //this.btnAdmin.UseVisualStyleBackColor = false;
                    //this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);

                }
            }
        }
        string tableNumber = null;
        private void Btn_Click(object sender, EventArgs e)
        {
             tableNumber=((Button)sender).Text;
            MasaPaneli masaPaneli = new MasaPaneli(tableNumber);
            this.Hide();
            masaPaneli.Show();
           
        }
    }
}
