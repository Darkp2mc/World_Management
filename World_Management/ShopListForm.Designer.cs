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
            layoutDims[1] = (int)Math.Ceiling((Double)(buildings.Count / 3));
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
            for (int i = 0; i < layoutDims[0]; i++)
            {
                this.tlp_shopButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            this.tlp_shopButtons.Location = new System.Drawing.Point(0, 0);
            this.tlp_shopButtons.Name = "tlp_shopButtons";
            this.tlp_shopButtons.RowCount = layoutDims[1];
            for (int i = 0; i < layoutDims[1]; i++)
            {
                this.tlp_shopButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            this.tlp_shopButtons.Size = new System.Drawing.Size(layoutDims[0]*50, layoutDims[1]*50);
            this.tlp_shopButtons.TabIndex = 0;

            this.tlp_shopButtons.Dock = DockStyle.Fill;
            this.Controls.Add(this.tlp_shopButtons);

            for (int c = 0; c < layoutDims[0]; ++c)
            {
                for (int r = 0; r < layoutDims[1]; ++r)
                {   
                    if (r != layoutDims[1] - 1 || c < (buildings.Count % layoutDims[0]))
                    {
                        var btn = new Button();
                        btn.Text = buildings[c + r*4].name;
                        btn.Dock = DockStyle.Fill;
                        btn.UseCompatibleTextRendering = true;
                        btn.Click += new System.EventHandler(this.btn_building_Click);
                        this.tlp_shopButtons.Controls.Add(btn, c, r);
                    }
                }
            }

            // 
            // ShopListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(layoutDims[0] * 300, layoutDims[1] * 100);
            this.Controls.Add(this.tlp_shopButtons);
            this.Name = "ShopListForm";
            this.Text = "Shops";
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_shopButtons;
    }
}