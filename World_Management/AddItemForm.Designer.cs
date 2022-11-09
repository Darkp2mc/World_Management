using Microsoft.Extensions.Configuration;

namespace World_Management
{
    partial class AddItemForm
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

        private void AddBuildingToCLB()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            configuration1 = builder.Build();
            ConnectDB db = new ConnectDB(configuration1);

            buildings = db.GetBuildings();

            this.clb_buildings.Items.AddRange(
                buildings.Select(b => b.name).ToList().ToArray()
            );
        }

        private void unlockAddItem()
        {
            if (!string.IsNullOrEmpty(this.tb_name.Text) &&
                !string.IsNullOrEmpty(this.tb_weight.Text) &&
                !string.IsNullOrEmpty(this.tb_base_cost.Text))
            {
                this.btn_addItem.Enabled = true;
            }
            else
            {
                this.btn_addItem.Enabled = false;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_addItem = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_base_cost = new System.Windows.Forms.TextBox();
            this.lbl_base_cost = new System.Windows.Forms.Label();
            this.tb_weight = new System.Windows.Forms.TextBox();
            this.lbl_weight = new System.Windows.Forms.Label();
            this.lbl_rarity = new System.Windows.Forms.Label();
            this.tb_type = new System.Windows.Forms.TextBox();
            this.lbl_type = new System.Windows.Forms.Label();
            this.cb_base_cost = new System.Windows.Forms.ComboBox();
            this.cb_rarity = new System.Windows.Forms.ComboBox();
            this.lbl_building = new System.Windows.Forms.Label();
            this.clb_buildings = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btn_addItem
            // 
            this.btn_addItem.Enabled = false;
            this.btn_addItem.Location = new System.Drawing.Point(12, 181);
            this.btn_addItem.Name = "btn_addItem";
            this.btn_addItem.Size = new System.Drawing.Size(125, 29);
            this.btn_addItem.TabIndex = 0;
            this.btn_addItem.Text = "Add Item";
            this.btn_addItem.UseVisualStyleBackColor = true;
            this.btn_addItem.Click += new System.EventHandler(this.btn_addItem_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(147, 181);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(125, 29);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(52, 20);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "Name:";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(91, 6);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(181, 27);
            this.tb_name.TabIndex = 3;
            this.tb_name.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            // 
            // tb_base_cost
            // 
            this.tb_base_cost.Location = new System.Drawing.Point(91, 38);
            this.tb_base_cost.Name = "tb_base_cost";
            this.tb_base_cost.Size = new System.Drawing.Size(125, 27);
            this.tb_base_cost.TabIndex = 5;
            this.tb_base_cost.TextChanged += new System.EventHandler(this.tb_base_cost_TextChanged);
            // 
            // lbl_base_cost
            // 
            this.lbl_base_cost.AutoSize = true;
            this.lbl_base_cost.Location = new System.Drawing.Point(12, 42);
            this.lbl_base_cost.Name = "lbl_base_cost";
            this.lbl_base_cost.Size = new System.Drawing.Size(76, 20);
            this.lbl_base_cost.TabIndex = 4;
            this.lbl_base_cost.Text = "Base Cost:";
            // 
            // tb_weight
            // 
            this.tb_weight.Location = new System.Drawing.Point(91, 71);
            this.tb_weight.Name = "tb_weight";
            this.tb_weight.Size = new System.Drawing.Size(181, 27);
            this.tb_weight.TabIndex = 7;
            this.tb_weight.TextChanged += new System.EventHandler(this.tb_weight_TextChanged);
            // 
            // lbl_weight
            // 
            this.lbl_weight.AutoSize = true;
            this.lbl_weight.Location = new System.Drawing.Point(12, 74);
            this.lbl_weight.Name = "lbl_weight";
            this.lbl_weight.Size = new System.Drawing.Size(59, 20);
            this.lbl_weight.TabIndex = 6;
            this.lbl_weight.Text = "Weight:";
            // 
            // lbl_rarity
            // 
            this.lbl_rarity.AutoSize = true;
            this.lbl_rarity.Location = new System.Drawing.Point(12, 107);
            this.lbl_rarity.Name = "lbl_rarity";
            this.lbl_rarity.Size = new System.Drawing.Size(50, 20);
            this.lbl_rarity.TabIndex = 8;
            this.lbl_rarity.Text = "Rarity:";
            // 
            // tb_type
            // 
            this.tb_type.Location = new System.Drawing.Point(91, 138);
            this.tb_type.Name = "tb_type";
            this.tb_type.Size = new System.Drawing.Size(181, 27);
            this.tb_type.TabIndex = 11;
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(12, 141);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(43, 20);
            this.lbl_type.TabIndex = 10;
            this.lbl_type.Text = "Type:";
            // 
            // cb_base_cost
            // 
            this.cb_base_cost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_base_cost.FormattingEnabled = true;
            this.cb_base_cost.Items.AddRange(new object[] {
            "cp",
            "sp",
            "ep",
            "gp",
            "pp"});
            this.cb_base_cost.Location = new System.Drawing.Point(222, 37);
            this.cb_base_cost.Name = "cb_base_cost";
            this.cb_base_cost.Size = new System.Drawing.Size(50, 28);
            this.cb_base_cost.TabIndex = 12;
            this.cb_base_cost.TabStop = false;
            // 
            // cb_rarity
            // 
            this.cb_rarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_rarity.FormattingEnabled = true;
            this.cb_rarity.Items.AddRange(new object[] {
            "Very Common",
            "Common",
            "Uncommon",
            "Rare",
            "Very Rare",
            "Epic",
            "Legendary",
            "Mythical",
            "Transcedent",
            "Divine",
            "Unique",
            "Artifact"});
            this.cb_rarity.Location = new System.Drawing.Point(91, 104);
            this.cb_rarity.Name = "cb_rarity";
            this.cb_rarity.Size = new System.Drawing.Size(181, 28);
            this.cb_rarity.TabIndex = 13;
            // 
            // lbl_building
            // 
            this.lbl_building.AutoSize = true;
            this.lbl_building.Location = new System.Drawing.Point(292, 9);
            this.lbl_building.Name = "lbl_building";
            this.lbl_building.Size = new System.Drawing.Size(73, 20);
            this.lbl_building.TabIndex = 14;
            this.lbl_building.Text = "Buildings:";
            // 
            // clb_buildings
            // 
            this.clb_buildings.CheckOnClick = true;
            this.clb_buildings.FormattingEnabled = true;
            this.clb_buildings.Location = new System.Drawing.Point(292, 38);
            this.clb_buildings.Name = "clb_buildings";
            this.clb_buildings.Size = new System.Drawing.Size(244, 158);
            this.clb_buildings.TabIndex = 16;
            // 
            // AddItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 215);
            this.Controls.Add(this.clb_buildings);
            this.Controls.Add(this.lbl_building);
            this.Controls.Add(this.cb_rarity);
            this.Controls.Add(this.cb_base_cost);
            this.Controls.Add(this.tb_type);
            this.Controls.Add(this.lbl_type);
            this.Controls.Add(this.lbl_rarity);
            this.Controls.Add(this.tb_weight);
            this.Controls.Add(this.lbl_weight);
            this.Controls.Add(this.tb_base_cost);
            this.Controls.Add(this.lbl_base_cost);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_addItem);
            this.Name = "AddItemForm";
            this.Text = "Add Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btn_addItem;
        private Button btn_cancel;
        private Label lbl_name;
        private TextBox tb_name;
        private TextBox tb_base_cost;
        private Label lbl_base_cost;
        private TextBox tb_weight;
        private Label lbl_weight;
        private Label lbl_rarity;
        private TextBox tb_type;
        private Label lbl_type;
        private ComboBox cb_base_cost;
        private ComboBox cb_rarity;
        private Label lbl_building;
        private CheckedListBox clb_buildings;
    }
}