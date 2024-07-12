using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTracker.CustomControls
{
    public partial class SoldProductsServicesItems : UserControl
    {
        public SoldProductsServicesItems()
        {
            InitializeComponent();
        }

        public string GetItemType()
        {
            return ItemsComboBox.Text;
        }
        public int GetQuantity()
        {
            return Convert.ToInt16(QuantityTextBox.Text);
        }
        public double GetPrice()
        {
            return Convert.ToDouble(PricePerUnitTextBox.Text);
        }
    }
}
