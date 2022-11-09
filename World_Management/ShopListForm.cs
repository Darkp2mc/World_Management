using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace World_Management
{
    public partial class ShopListForm : Form
    {
        public ShopListForm()
        {
            InitializeComponent();
        }

        private void btn_building_Click(object sender, EventArgs e)
        {
            var teste = ((Button)sender).Text.Trim();
            switch (((Button)sender).Text.Trim())
            {
                case "Alchemy Shop":
                    AlchemyShop form = new AlchemyShop();
                    form.ShowDialog();
                    break;
            }
        }
    }
}
