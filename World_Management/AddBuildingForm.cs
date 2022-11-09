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
    public partial class AddBuildingForm : Form
    {

        private static IConfiguration configuration1;
        public AddBuildingForm()
        {
            InitializeComponent();
        }

        private void btn_addBuilding_Click(object sender, EventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            configuration1 = builder.Build();
            ConnectDB db = new ConnectDB(configuration1);

            Building building = new Building
            {
                name = this.tb_name.Text
            };


            db.AddBuilding(building);
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
    }
}
