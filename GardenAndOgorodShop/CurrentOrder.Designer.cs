
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrentOrder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelExistClient = new System.Windows.Forms.Label();
            this.panelCheckExistClient = new System.Windows.Forms.Panel();
            this.textBoxClient = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonWarning = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.comboBoxPayMethod = new System.Windows.Forms.ComboBox();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDoneOrder = new System.Windows.Forms.Button();
            this.textBoxOrderNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.ImageHeader = new System.Windows.Forms.DataGridViewImageColumn();
            this.TitleHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelPoints = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.labelPoints);
            this.panel1.Controls.Add(this.labelExistClient);
            this.panel1.Controls.Add(this.panelCheckExistClient);
            this.panel1.Controls.Add(this.textBoxClient);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.buttonWarning);
            this.panel1.Controls.Add(this.buttonMinus);
            this.panel1.Controls.Add(this.buttonAddProduct);
            this.panel1.Controls.Add(this.buttonDeleteProduct);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Controls.Add(this.comboBoxPayMethod);
            this.panel1.Controls.Add(this.labelTotalCost);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonDoneOrder);
            this.panel1.Controls.Add(this.textBoxOrderNotes);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 304);
            this.panel1.TabIndex = 4;
            // 
            // labelExistClient
            // 
            this.labelExistClient.AutoSize = true;
            this.labelExistClient.BackColor = System.Drawing.Color.White;
            this.labelExistClient.ForeColor = System.Drawing.Color.Red;
            this.labelExistClient.Location = new System.Drawing.Point(108, 280);
            this.labelExistClient.Name = "labelExistClient";
            this.labelExistClient.Size = new System.Drawing.Size(164, 13);
            this.labelExistClient.TabIndex = 36;
            this.labelExistClient.Text = "*такого клиента нет в системе";
            this.labelExistClient.Visible = false;
            // 
            // panelCheckExistClient
            // 
            this.panelCheckExistClient.BackColor = System.Drawing.Color.Red;
            this.panelCheckExistClient.Location = new System.Drawing.Point(260, 244);
            this.panelCheckExistClient.Name = "panelCheckExistClient";
            this.panelCheckExistClient.Size = new System.Drawing.Size(5, 33);
            this.panelCheckExistClient.TabIndex = 35;
            this.panelCheckExistClient.Visible = false;
            // 
            // textBoxClient
            // 
            this.textBoxClient.BackColor = System.Drawing.Color.White;
            this.textBoxClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxClient.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxClient.Location = new System.Drawing.Point(111, 244);
            this.textBoxClient.MaxLength = 8;
            this.textBoxClient.Name = "textBoxClient";
            this.textBoxClient.Size = new System.Drawing.Size(154, 33);
            this.textBoxClient.TabIndex = 34;
            this.textBoxClient.TextChanged += new System.EventHandler(this.textBoxClient_TextChanged);
            this.textBoxClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxClient_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(28, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 25);
            this.label5.TabIndex = 33;
            this.label5.Text = "Клиент:";
            // 
            // buttonWarning
            // 
            this.buttonWarning.BackgroundImage = global::GardenAndOgorodShop.Properties.Resources.warning_115257;
            this.buttonWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonWarning.FlatAppearance.BorderSize = 0;
            this.buttonWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWarning.Location = new System.Drawing.Point(356, 59);
            this.buttonWarning.Name = "buttonWarning";
            this.buttonWarning.Size = new System.Drawing.Size(31, 29);
            this.buttonWarning.TabIndex = 32;
            this.buttonWarning.UseVisualStyleBackColor = true;
            // 
            // buttonMinus
            // 
            this.buttonMinus.BackgroundImage = global::GardenAndOgorodShop.Properties.Resources.minus;
            this.buttonMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMinus.FlatAppearance.BorderSize = 0;
            this.buttonMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMinus.Location = new System.Drawing.Point(700, 194);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(40, 40);
            this.buttonMinus.TabIndex = 31;
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.BackgroundImage = global::GardenAndOgorodShop.Properties.Resources.add_icon;
            this.buttonAddProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddProduct.FlatAppearance.BorderSize = 0;
            this.buttonAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddProduct.Location = new System.Drawing.Point(746, 194);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(40, 40);
            this.buttonAddProduct.TabIndex = 30;
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.BackgroundImage = global::GardenAndOgorodShop.Properties.Resources.delete;
            this.buttonDeleteProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDeleteProduct.FlatAppearance.BorderSize = 0;
            this.buttonDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteProduct.Location = new System.Drawing.Point(792, 194);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(40, 40);
            this.buttonDeleteProduct.TabIndex = 29;
            this.buttonDeleteProduct.UseVisualStyleBackColor = true;
            this.buttonDeleteProduct.Click += new System.EventHandler(this.buttonDeleteProduct_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Yellow;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBack.Location = new System.Drawing.Point(8, 8);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(117, 40);
            this.buttonBack.TabIndex = 28;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // comboBoxPayMethod
            // 
            this.comboBoxPayMethod.BackColor = System.Drawing.Color.White;
            this.comboBoxPayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPayMethod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxPayMethod.FormattingEnabled = true;
            this.comboBoxPayMethod.Items.AddRange(new object[] {
            "Наличными",
            "Безналичными"});
            this.comboBoxPayMethod.Location = new System.Drawing.Point(158, 59);
            this.comboBoxPayMethod.Name = "comboBoxPayMethod";
            this.comboBoxPayMethod.Size = new System.Drawing.Size(192, 29);
            this.comboBoxPayMethod.TabIndex = 27;
            this.comboBoxPayMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPayMethod_SelectedIndexChanged);
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalCost.ForeColor = System.Drawing.Color.Red;
            this.labelTotalCost.Location = new System.Drawing.Point(179, 189);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(63, 32);
            this.labelTotalCost.TabIndex = 26;
            this.labelTotalCost.Text = "0.00";
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
            // buttonDoneOrder
            // 
            this.buttonDoneOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(186)))), ((int)(((byte)(93)))));
            this.buttonDoneOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDoneOrder.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDoneOrder.Location = new System.Drawing.Point(657, 8);
            this.buttonDoneOrder.Name = "buttonDoneOrder";
            this.buttonDoneOrder.Size = new System.Drawing.Size(175, 40);
            this.buttonDoneOrder.TabIndex = 24;
            this.buttonDoneOrder.Text = "Завершить";
            this.buttonDoneOrder.UseVisualStyleBackColor = false;
            this.buttonDoneOrder.Click += new System.EventHandler(this.buttonDoneOrder_Click);
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
            this.label1.Location = new System.Drawing.Point(164, -4);
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
            this.dataGridViewProducts.Location = new System.Drawing.Point(9, 316);
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
            this.dataGridViewProducts.Size = new System.Drawing.Size(844, 332);
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
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPoints.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelPoints.Location = new System.Drawing.Point(271, 244);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(28, 32);
            this.labelPoints.TabIndex = 37;
            this.labelPoints.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(383, 246);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(158, 29);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.Text = "списать баллы";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Location = new System.Drawing.Point(547, 243);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 33);
            this.numericUpDown1.TabIndex = 40;
            this.numericUpDown1.Visible = false;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // CurrentOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(186)))), ((int)(((byte)(93)))));
            this.ClientSize = new System.Drawing.Size(865, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewProducts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CurrentOrder";
            this.Text = "CurrentOrder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CurrentOrder_FormClosed);
            this.Load += new System.EventHandler(this.CurrentOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.Button buttonDoneOrder;
        private System.Windows.Forms.DataGridViewImageColumn ImageHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.ComboBox comboBoxPayMethod;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonDeleteProduct;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Button buttonWarning;
        private System.Windows.Forms.TextBox textBoxClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelExistClient;
        private System.Windows.Forms.Panel panelCheckExistClient;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}