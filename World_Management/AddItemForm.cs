using Microsoft.Extensions.Configuration;
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
    public partial class AddItemForm : Form
    {
        private static IConfiguration configuration1;
        private List<Building> buildings;
        public AddItemForm()
        {
            InitializeComponent();
            AddBuildingToCLB();
        }

        private void btn_addItem_Click(object sender, EventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            configuration1 = builder.Build();
            ConnectDB db = new ConnectDB(configuration1);

            int base_cost_value = Convert.ToInt32(this.tb_base_cost.Text);
            switch (this.cb_base_cost.Text)
            {
                case "sp":
                    base_cost_value *= 10;
                    break;
                case "ep":
                    base_cost_value *= 50;
                    break;
                case "gp":
                    base_cost_value *= 100;
                    break;
                case "pp":
                    base_cost_value *= 1000;
                    break;
            }

            Item item = new Item
            {
                name = this.tb_name.Text,
                base_cost = base_cost_value,
                weight = Convert.ToSingle(this.tb_weight.Text),
                rarity = this.cb_rarity.Text,
                type = this.tb_type.Text
            };
            db.AddItem(item);
            var lastItem = db.GetItems().Last();

            foreach (var selectedBuildingsIdx in this.clb_buildings.CheckedIndices)
            {
                BuildingToItem buildingToItem = new BuildingToItem
                {
                    id_building = buildings[(int)selectedBuildingsIdx].id,
                    id_item = lastItem.id
                };
                db.AddBuildingToItem(buildingToItem);
            }
            
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to exit?", "Cancel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            unlockAddItem();
        }

        private void tb_base_cost_TextChanged(object sender, EventArgs e)
        {
            unlockAddItem();
        }

        private void tb_weight_TextChanged(object sender, EventArgs e)
        {
            unlockAddItem();
        }
    }
}
