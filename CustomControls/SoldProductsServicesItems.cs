using ExamTracker.Helpers;
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
        public event Action<bool> ItemIsValid = delegate { };
        public SoldProductsServicesItems()
        {
            InitializeComponent();
            PopulateComboBoxList();
        }
        private void ValidateItem()
        {
            bool isValid = true;

            if (!int.TryParse(QuantityTextBox.Text, out _))
            {
                isValid = false;
            }
            if (!int.TryParse(PricePerUnitTextBox.Text, out _))
            {
                isValid = false;
            }

            if(!isValid)
            {
                ItemIsValid?.Invoke(isValid);
            }
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

        private void removeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PopulateComboBoxList()
        {
            if (LanguageHelper.Lang == "pl_pl")
            {
                string[] items = { "Sprzedaż (GTU_24)", "Języki (GTU_12)", "Sprzątanie (GTU_8)" };
                ItemsComboBox.Items.AddRange(items);
            }
            else if (LanguageHelper.Lang == "eng_us")
            {
                string[] items = { "Vending (GTU_24)", "Languages (GTU_12)", "Cleaning (GTU_8)" };
                ItemsComboBox.Items.AddRange(items);

            }
        }
    }
}
