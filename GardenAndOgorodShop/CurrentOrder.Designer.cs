
namespace GardenAndOgorodShop
{
    partial class CurrentOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxProductDesc = new System.Windows.Forms.TextBox();
            this.comboBoxBrands = new System.Windows.Forms.ComboBox();
            this.buttonToCategoryForm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.ImageHeader = new System.Windows.Forms.DataGridViewImageColumn();
            this.TitleHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labelTotalCost);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonToCategoryForm);
            this.panel1.Controls.Add(this.comboBoxBrands);
            this.panel1.Controls.Add(this.textBoxProductDesc);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 248);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(120)))), ((int)(((byte)(56)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Касса. Текущая продажа";
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AllowUserToResizeColumns = false;
            this.dataGridViewProducts.AllowUserToResizeRows = false;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImageHeader,
            this.TitleHeader,
            this.PriceHeader,
            this.Amount});
            this.dataGridViewProducts.Location = new System.Drawing.Point(9, 260);
            this.dataGridViewProducts.MultiSelect = false;
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewProducts.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewProducts.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewProducts.RowTemplate.Height = 150;
            this.dataGridViewProducts.Size = new System.Drawing.Size(844, 388);
            this.dataGridViewProducts.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Способ оплаты:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Заметки:";
            // 
            // textBoxProductDesc
            // 
            this.textBoxProductDesc.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProductDesc.Location = new System.Drawing.Point(100, 96);
            this.textBoxProductDesc.MaxLength = 1000;
            this.textBoxProductDesc.Multiline = true;
            this.textBoxProductDesc.Name = "textBoxProductDesc";
            this.textBoxProductDesc.Size = new System.Drawing.Size(732, 71);
            this.textBoxProductDesc.TabIndex = 6;
            this.textBoxProductDesc.Text = "Оплата прошла успешно";
            // 
            // comboBoxBrands
            // 
            this.comboBoxBrands.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxBrands.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxBrands.FormattingEnabled = true;
            this.comboBoxBrands.Items.AddRange(new object[] {
            "Наличными",
            "Безналичными"});
            this.comboBoxBrands.Location = new System.Drawing.Point(158, 56);
            this.comboBoxBrands.Name = "comboBoxBrands";
            this.comboBoxBrands.Size = new System.Drawing.Size(304, 33);
            this.comboBoxBrands.TabIndex = 23;
            this.comboBoxBrands.Visible = false;
            // 
            // buttonToCategoryForm
            // 
            this.buttonToCategoryForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(186)))), ((int)(((byte)(93)))));
            this.buttonToCategoryForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToCategoryForm.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonToCategoryForm.Location = new System.Drawing.Point(657, 12);
            this.buttonToCategoryForm.Name = "buttonToCategoryForm";
            this.buttonToCategoryForm.Size = new System.Drawing.Size(175, 40);
            this.buttonToCategoryForm.TabIndex = 24;
            this.buttonToCategoryForm.Text = "Завершить";
            this.buttonToCategoryForm.UseVisualStyleBackColor = false;
            this.buttonToCategoryForm.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(21, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "Сумма к оплате:";
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalCost.Location = new System.Drawing.Point(179, 195);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(32, 25);
            this.labelTotalCost.TabIndex = 26;
            this.labelTotalCost.Text = "00";
            // 
            // ImageHeader
            // 
            this.ImageHeader.HeaderText = "Картинка";
            this.ImageHeader.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ImageHeader.Name = "ImageHeader";
            this.ImageHeader.ReadOnly = true;
            this.ImageHeader.Width = 150;
            // 
            // TitleHeader
            // 
            this.TitleHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.TitleHeader.DefaultCellStyle = dataGridViewCellStyle6;
            this.TitleHeader.HeaderText = "Название";
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.ReadOnly = true;
            // 
            // PriceHeader
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.PriceHeader.DefaultCellStyle = dataGridViewCellStyle7;
            this.PriceHeader.HeaderText = "Цена";
            this.PriceHeader.Name = "PriceHeader";
            this.PriceHeader.ReadOnly = true;
            this.PriceHeader.Width = 150;
            // 
            // Amount
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle8;
            this.Amount.HeaderText = "Количество";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 200;
            // 
            // CurrentOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(186)))), ((int)(((byte)(93)))));
            this.ClientSize = new System.Drawing.Size(865, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewProducts);
            this.Name = "CurrentOrder";
            this.Text = "CurrentOrder";
            this.Load += new System.EventHandler(this.CurrentOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxProductDesc;
        private System.Windows.Forms.ComboBox comboBoxBrands;
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonToCategoryForm;
        private System.Windows.Forms.DataGridViewImageColumn ImageHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}