using Microsoft.Extensions.Configuration;

namespace World_Management
{
    partial class ShopListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private List<int> layoutDims = new List<int> { 0, 0 };
        private List<Building> buildings;
        private int r = 0;
        private int c = 0;

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

        private void calculateLayoutDimentions()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            ConnectDB db = new ConnectDB(builder.Build());

            buildings = db.GetBuildings();
            layoutDims[0] = buildings.Count < 4 ? buildings.Count : 4;
            layoutDims[1] = (int)Math.Ceiling(buildings.Count / 4.0);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            calculateLayoutDimentions();

            this.tlp_shopButtons = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tlp_shopButtons
            // 
            this.tlp_shopButtons.ColumnCount = layoutDims[0];
           
            this.tlp_shopButtons.Location = new System.Drawing.Point(0, 0);
            this.tlp_shopButtons.Name = "tlp_shopButtons";
            this.tlp_shopButtons.RowCount = layoutDims[1];
            this.tlp_shopButtons.TabIndex = 0;

            this.tlp_shopButtons.Dock = DockStyle.Fill;

            

            // 
            // ShopListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300,100);
            this.Controls.Add(this.tlp_shopButtons);
            this.Name = "ShopListForm";
            this.Text = "Shops";
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_shopButtons;
    }
}