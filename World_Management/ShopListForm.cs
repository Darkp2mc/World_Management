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

            for (c = 0; c < layoutDims[0]; c++)
            {
                tlp_shopButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            for (r = 0; r < layoutDims[1]; r++)
            {
                tlp_shopButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            tlp_shopButtons.Size = new System.Drawing.Size(layoutDims[0] * 50, layoutDims[1] * 50);
            for (c = 0; c < layoutDims[0]; ++c)
            {
                for (r = 0; r < layoutDims[1]; ++r)
                {
                    //TODO
                    //IDK..
                    if (r > 0 && (c < 4 && r == 1))
                    {
                        var btn = new Button();
                        btn.Text = buildings[c + r * 4].name;
                        btn.Dock = DockStyle.Fill;
                        btn.UseCompatibleTextRendering = true;
                        btn.Click += new System.EventHandler(btn_building_Click);
                        tlp_shopButtons.Controls.Add(btn, c, r);
                    }
                }
            }
            ClientSize = new System.Drawing.Size(layoutDims[0] * 300, layoutDims[1] * 100);
        }

        private void btn_building_Click(object sender, EventArgs e)
        {
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
