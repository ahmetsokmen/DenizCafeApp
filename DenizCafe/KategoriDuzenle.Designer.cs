
namespace DenizCafe
{
    partial class KategoriDuzenle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.chkCategoryIsActive = new System.Windows.Forms.CheckBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtEditCategory = new System.Windows.Forms.TextBox();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(711, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // chkCategoryIsActive
            // 
            this.chkCategoryIsActive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkCategoryIsActive.AutoSize = true;
            this.chkCategoryIsActive.Location = new System.Drawing.Point(665, 431);
            this.chkCategoryIsActive.Name = "chkCategoryIsActive";
            this.chkCategoryIsActive.Size = new System.Drawing.Size(47, 17);
            this.chkCategoryIsActive.TabIndex = 35;
            this.chkCategoryIsActive.Text = "Aktif";
            this.chkCategoryIsActive.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBack.BackColor = System.Drawing.Color.GreenYellow;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBack.Location = new System.Drawing.Point(685, 249);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(85, 32);
            this.btnBack.TabIndex = 34;
            this.btnBack.Text = "Geri Dön";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // txtEditCategory
            // 
            this.txtEditCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEditCategory.Location = new System.Drawing.Point(665, 385);
            this.txtEditCategory.Name = "txtEditCategory";
            this.txtEditCategory.Size = new System.Drawing.Size(152, 20);
            this.txtEditCategory.TabIndex = 33;
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditCategory.BackColor = System.Drawing.Color.GreenYellow;
            this.btnEditCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEditCategory.Location = new System.Drawing.Point(685, 467);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(102, 32);
            this.btnEditCategory.TabIndex = 32;
            this.btnEditCategory.Text = "Kaydet";
            this.btnEditCategory.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(553, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Aktif";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(637, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 24);
            this.label3.TabIndex = 30;
            this.label3.Text = "Kategori Düzenle";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(553, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Kategori Adı";
            // 
            // KategoriDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkCategoryIsActive);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtEditCategory);
            this.Controls.Add(this.btnEditCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "KategoriDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KategoriDuzenle";
            this.Load += new System.EventHandler(this.KategoriDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox chkCategoryIsActive;
        private System.Windows.Forms.Button btnBack;
        public System.Windows.Forms.TextBox txtEditCategory;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}