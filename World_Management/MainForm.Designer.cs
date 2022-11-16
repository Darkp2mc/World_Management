using Microsoft.Extensions.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace World_Management
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private void addStateTab()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            ConnectDB db = new ConnectDB(builder.Build());

            List<State> states = db.GetStates();

            foreach (var state in states)
            {
                TabPage tab = new System.Windows.Forms.TabPage();
                tab.Location = new System.Drawing.Point(4, 29);
                tab.Name = state.name;
                tab.Padding = new System.Windows.Forms.Padding(3);
                tab.Size = new System.Drawing.Size(200, 0);
                tab.TabIndex = state.id;
                tab.Text = state.name;
                tab.UseVisualStyleBackColor = true;

                this.tc_states.Controls.Add(tab);
                this.tabs_states.Add(tab);

                addTabControlToStateTab(tab, state.id);
                addStateGB(tab, state);
            }
        }

        private void addTabControlToStateTab(TabPage selectedTbState, int stateId)
        {
            TabControl tc = new System.Windows.Forms.TabControl();

            selectedTbState.Controls.Add(tc);
            tc.Location = new System.Drawing.Point(300, 10);
            tc.Name = "tb"+ stateId;
            tc.SelectedIndex = 0;
            tc.Size = new System.Drawing.Size(800, 490);
            tc.TabIndex = stateId;

            addProvinceTab(tc, stateId);
        }

        private void addStateGB(TabPage tab, State state)
        {
            GroupBox gpState = new System.Windows.Forms.GroupBox();
            gpState.Location = new System.Drawing.Point(0, 0);
            gpState.Name = state.name;
            gpState.Size = new System.Drawing.Size(250, 500);
            gpState.TabIndex = 0;
            gpState.TabStop = false;
            gpState.Text = "Info:";
            tab.Controls.Add(gpState);

            Label lb_Statename = new System.Windows.Forms.Label();
            gpState.Controls.Add(lb_Statename);
            lb_Statename.AutoSize = true;
            lb_Statename.Location = new System.Drawing.Point(5, 25);
            lb_Statename.Name = "lb_Statename";
            lb_Statename.Size = new System.Drawing.Size(50, 20);
            lb_Statename.TabIndex = 0;
            lb_Statename.Text = "Name: " + state.name;

            Label lb_StateForm = new System.Windows.Forms.Label();
            gpState.Controls.Add(lb_StateForm);
            lb_StateForm.AutoSize = true;
            lb_StateForm.Location = new System.Drawing.Point(5, 50);
            lb_StateForm.Name = "lb_StateForm";
            lb_StateForm.Size = new System.Drawing.Size(50, 20);
            lb_StateForm.TabIndex = 0;
            lb_StateForm.Text = "Form: " + state.form;

            Label lb_StateArea = new System.Windows.Forms.Label();
            gpState.Controls.Add(lb_StateArea);
            lb_StateArea.AutoSize = true;
            lb_StateArea.Location = new System.Drawing.Point(5, 75);
            lb_StateArea.Name = "lb_StateArea";
            lb_StateArea.Size = new System.Drawing.Size(50, 20);
            lb_StateArea.TabIndex = 0;
            lb_StateArea.Text = "Area: " + state.area + " km²";

            Label lb_StatePopulation = new System.Windows.Forms.Label();
            gpState.Controls.Add(lb_StatePopulation);
            lb_StatePopulation.AutoSize = true;
            lb_StatePopulation.Location = new System.Drawing.Point(5, 100);
            lb_StatePopulation.Name = "lb_StatePopulation";
            lb_StatePopulation.Size = new System.Drawing.Size(50, 20);
            lb_StatePopulation.TabIndex = 0;
            lb_StatePopulation.Text = "Population: " + state.population;

        }

        private void addProvinceTab(TabControl tc, int stateId)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            ConnectDB db = new ConnectDB(builder.Build());

            List<Province> provinces = db.GetProvincesOfStates(stateId);

            foreach (var province in provinces)
            {
                TabPage tab = new System.Windows.Forms.TabPage();
                tab.Location = new System.Drawing.Point(4, 29);
                tab.Name = province.name;
                tab.Padding = new System.Windows.Forms.Padding(3);
                tab.Size = new System.Drawing.Size(200, 0);
                tab.TabIndex = province.id;
                tab.Text = province.name;
                tab.UseVisualStyleBackColor = true;

                tc.Controls.Add(tab);
                this.tabs_provinces.Add(tab);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_shop = new System.Windows.Forms.Button();
            this.btn_addItem = new System.Windows.Forms.Button();
            this.btn_addBuilding = new System.Windows.Forms.Button();
            this.tc_states = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // btn_shop
            // 
            this.btn_shop.Location = new System.Drawing.Point(247, 559);
            this.btn_shop.Name = "btn_shop";
            this.btn_shop.Size = new System.Drawing.Size(94, 29);
            this.btn_shop.TabIndex = 0;
            this.btn_shop.Text = "Shops";
            this.btn_shop.UseVisualStyleBackColor = true;
            this.btn_shop.Click += new System.EventHandler(this.btn_shop_Click);
            // 
            // btn_addItem
            // 
            this.btn_addItem.Location = new System.Drawing.Point(12, 559);
            this.btn_addItem.Name = "btn_addItem";
            this.btn_addItem.Size = new System.Drawing.Size(112, 29);
            this.btn_addItem.TabIndex = 1;
            this.btn_addItem.Text = "Add Item";
            this.btn_addItem.UseVisualStyleBackColor = true;
            this.btn_addItem.Click += new System.EventHandler(this.btn_addItem_Click);
            // 
            // btn_addBuilding
            // 
            this.btn_addBuilding.Location = new System.Drawing.Point(130, 559);
            this.btn_addBuilding.Name = "btn_addBuilding";
            this.btn_addBuilding.Size = new System.Drawing.Size(111, 29);
            this.btn_addBuilding.TabIndex = 2;
            this.btn_addBuilding.Text = "Add Building";
            this.btn_addBuilding.UseVisualStyleBackColor = true;
            this.btn_addBuilding.Click += new System.EventHandler(this.btn_addBuilding_Click);
            // 
            // tc_states
            // 
            this.tc_states.Location = new System.Drawing.Point(1, 0);
            this.tc_states.Name = "tc_states";
            this.tc_states.SelectedIndex = 0;
            this.tc_states.Size = new System.Drawing.Size(1187, 553);
            this.tc_states.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.tc_states);
            this.Controls.Add(this.btn_addBuilding);
            this.Controls.Add(this.btn_addItem);
            this.Controls.Add(this.btn_shop);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_shop;
        private System.Windows.Forms.Button btn_addItem;
        private System.Windows.Forms.Button btn_addBuilding;
        private TabControl tc_states;
        private List<TabPage> tabs_states = new List<TabPage>();
        private List<TabPage> tabs_provinces = new List<TabPage>();
        private List<TabControl> tcs_provinces = new List<TabControl>();
    }
}