
namespace DenizCafe
{
    partial class KategoriEkle
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
            this.chkCategoryIsActive = new System.Windows.Forms.CheckBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtAddCategory = new System.Windows.Forms.TextBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkCategoryIsActive
            // 
            this.chkCategoryIsActive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkCategoryIsActive.AutoSize = true;
            this.chkCategoryIsActive.Checked = true;
            this.chkCategoryIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCategoryIsActive.Location = new System.Drawing.Point(665, 380);
            this.chkCategoryIsActive.Name = "chkCategoryIsActive";
            this.chkCategoryIsActive.Size = new System.Drawing.Size(47, 17);
            this.chkCategoryIsActive.TabIndex = 19;
            this.chkCategoryIsActive.Text = "Aktif";
            this.chkCategoryIsActive.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBack.BackColor = System.Drawing.Color.GreenYellow;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBack.Location = new System.Drawing.Point(732, 429);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(85, 32);
            this.btnBack.TabIndex = 18;
            this.btnBack.Text = "Geri Dön";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // txtAddCategory
            // 
            this.txtAddCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAddCategory.Location = new System.Drawing.Point(665, 334);
            this.txtAddCategory.Name = "txtAddCategory";
            this.txtAddCategory.Size = new System.Drawing.Size(152, 20);
            this.txtAddCategory.TabIndex = 17;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddCategory.BackColor = System.Drawing.Color.GreenYellow;
            this.btnAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddCategory.Location = new System.Drawing.Point(600, 429);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(102, 32);
            this.btnAddCategory.TabIndex = 16;
            this.btnAddCategory.Text = "Ekle";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(553, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Aktif";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(661, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Kategori Ekle";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(553, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Kategori Adı";
            // 
            // KategoriEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.chkCategoryIsActive);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtAddCategory);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "KategoriEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KategoriEkle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCategoryIsActive;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtAddCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}