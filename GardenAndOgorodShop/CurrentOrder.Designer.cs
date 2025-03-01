
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonToCategoryForm = new System.Windows.Forms.Button();
            this.textBoxOrderNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.ImageHeader = new System.Windows.Forms.DataGridViewImageColumn();
            this.TitleHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxPayMethod = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.comboBoxPayMethod);
            this.panel1.Controls.Add(this.labelTotalCost);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonToCategoryForm);
            this.panel1.Controls.Add(this.textBoxOrderNotes);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 248);
            this.panel1.TabIndex = 4;
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
            // textBoxOrderNotes
            // 
            this.textBoxOrderNotes.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxOrderNotes.Location = new System.Drawing.Point(100, 96);
            this.textBoxOrderNotes.MaxLength = 1000;
            this.textBoxOrderNotes.Multiline = true;
            this.textBoxOrderNotes.Name = "textBoxOrderNotes";
            this.textBoxOrderNotes.Size = new System.Drawing.Size(732, 71);
            this.textBoxOrderNotes.TabIndex = 6;
            this.textBoxOrderNotes.Text = "Оплата прошла успешно";
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewProducts.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewProducts.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewProducts.RowTemplate.Height = 150;
            this.dataGridViewProducts.Size = new System.Drawing.Size(844, 388);
            this.dataGridViewProducts.TabIndex = 3;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.TitleHeader.DefaultCellStyle = dataGridViewCellStyle1;
            this.TitleHeader.HeaderText = "Название";
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.ReadOnly = true;
            // 
            // PriceHeader
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.PriceHeader.DefaultCellStyle = dataGridViewCellStyle2;
            this.PriceHeader.HeaderText = "Цена";
            this.PriceHeader.Name = "PriceHeader";
            this.PriceHeader.ReadOnly = true;
            this.PriceHeader.Width = 150;
            // 
            // Amount
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.Amount.HeaderText = "Количество";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 200;
            // 
            // comboBoxPayMethod
            // 
            this.comboBoxPayMethod.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxPayMethod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxPayMethod.FormattingEnabled = true;
            this.comboBoxPayMethod.Items.AddRange(new object[] {
            "Наличными",
            "Безналичными"});
            this.comboBoxPayMethod.Location = new System.Drawing.Point(158, 59);
            this.comboBoxPayMethod.Name = "comboBoxPayMethod";
            this.comboBoxPayMethod.Size = new System.Drawing.Size(192, 29);
            this.comboBoxPayMethod.TabIndex = 27;
            this.comboBoxPayMethod.Visible = false;
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
        private System.Windows.Forms.TextBox textBoxOrderNotes;
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonToCategoryForm;
        private System.Windows.Forms.DataGridViewImageColumn ImageHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.ComboBox comboBoxPayMethod;
    }
}