using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GardenAndOgorodShop
{
    public partial class blockRecord : UserControl
    {
        public blockRecord()
        {
            InitializeComponent();
        }
        public string Header
        {
            get { return labelHeader.Text; }
            set
            {
                if (value.Length > 20)
                {
                    labelHeader.Text = value.Substring(0, 20) + "...";
                    toolTip.SetToolTip(labelHeader, value);
                }
                else
                {
                    labelHeader.Text = value;
                }
            }
        }

        public string Description
        {
            get { return labelDescription.Text; }
            set { labelDescription.Text = value; }
        }
        public int Amount
        {
            get { return int.Parse(labelAmount.Text); }
            set { labelAmount.Text = value.ToString(); }
        }

        private double _defaultPrice;
        private int _discount;
        private double _priceWithDiscount;

        public int Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                UpdatePriceWithDiscount();
                labelDiscount.Text = value.ToString()+"%";
            }
        }

        public double PriceWithDiscount
        {
            get { return _priceWithDiscount; }
            private set 
            {
                _priceWithDiscount = value;
                labelPrice1.Text = value.ToString("N2");  
            }
        }
        public double DefaultPrice
        {
            get { return _defaultPrice; }
            set
            {
                _defaultPrice = value;
                UpdatePriceWithDiscount();
                labelPrice2.Text = value.ToString("N2"); 
            }
        }
        private void UpdatePriceWithDiscount()
        {
            if (_defaultPrice > 0 && _discount > 0)
            {
                PriceWithDiscount = _defaultPrice * (1 - (double)_discount / 100);
            }
            else
            {
                PriceWithDiscount = 0;
            }
        }

        public Image ProductImage
        {
            get { return pictureBoxProduct.Image; }
            set 
            { 
                pictureBoxProduct.BackgroundImage = value;
            }
        }
    }
}
