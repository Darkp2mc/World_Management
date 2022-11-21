using Microsoft.Extensions.Configuration;
using static System.Windows.Forms.AxHost;
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

                addStateGB(tab, state);
                addTabControlToStateTab(tab, state.id);
            }
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

        private void addTabControlToStateTab(TabPage selectedTbState, int stateId)
        {
            TabControl tc = new System.Windows.Forms.TabControl();

            selectedTbState.Controls.Add(tc);
            tc.Location = new System.Drawing.Point(270, 10);
            tc.Name = "tb" + stateId;
            tc.SelectedIndex = 0;
            tc.Size = new System.Drawing.Size(880, 490);
            tc.TabIndex = stateId;

            addProvinceTab(tc, stateId);
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

                addProvinceGB(tab, province);
                addTabControlToProvinceTab(tab, province.id);
            }
        }

        private void addProvinceGB(TabPage tab, Province province)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            ConnectDB db = new ConnectDB(builder.Build());

            GroupBox gpProvince = new System.Windows.Forms.GroupBox();
            gpProvince.Location = new System.Drawing.Point(0, 0);
            gpProvince.Name = province.name;
            gpProvince.Size = new System.Drawing.Size(250, 450);
            gpProvince.TabIndex = 0;
            gpProvince.TabStop = false;
            gpProvince.Text = "Info:";
            tab.Controls.Add(gpProvince);

            Label lb_Provincename = new System.Windows.Forms.Label();
            gpProvince.Controls.Add(lb_Provincename);
            lb_Provincename.AutoSize = true;
            lb_Provincename.Location = new System.Drawing.Point(5, 25);
            lb_Provincename.Name = "lb_Provincename";
            lb_Provincename.Size = new System.Drawing.Size(50, 20);
            lb_Provincename.TabIndex = 0;
            lb_Provincename.Text = "Name: " + province.name;

            Label lb_ProvinceState = new System.Windows.Forms.Label();
            gpProvince.Controls.Add(lb_ProvinceState);
            lb_ProvinceState.AutoSize = true;
            lb_ProvinceState.Location = new System.Drawing.Point(5, 50);
            lb_ProvinceState.Name = "lb_ProvinceState";
            lb_ProvinceState.Size = new System.Drawing.Size(50, 20);
            lb_ProvinceState.TabIndex = 0;
            lb_ProvinceState.Text = "State: " + db.GetStateById(province.state).name;

            Label lb_ProvinceForm = new System.Windows.Forms.Label();
            gpProvince.Controls.Add(lb_ProvinceForm);
            lb_ProvinceForm.AutoSize = true;
            lb_ProvinceForm.Location = new System.Drawing.Point(5, 75);
            lb_ProvinceForm.Name = "lb_ProvinceForm";
            lb_ProvinceForm.Size = new System.Drawing.Size(50, 20);
            lb_ProvinceForm.TabIndex = 0;
            lb_ProvinceForm.Text = "Form: " + province.form;
            
            Label lb_ProvinceArea = new System.Windows.Forms.Label();
            gpProvince.Controls.Add(lb_ProvinceArea);
            lb_ProvinceArea.AutoSize = true;
            lb_ProvinceArea.Location = new System.Drawing.Point(5, 100);
            lb_ProvinceArea.Name = "lb_StateArea";
            lb_ProvinceArea.Size = new System.Drawing.Size(50, 20);
            lb_ProvinceArea.TabIndex = 0;
            lb_ProvinceArea.Text = "Area: " + province.area + " km²";

            Label lb_ProvincePopulation = new System.Windows.Forms.Label();
            gpProvince.Controls.Add(lb_ProvincePopulation);
            lb_ProvincePopulation.AutoSize = true;
            lb_ProvincePopulation.Location = new System.Drawing.Point(5, 125);
            lb_ProvincePopulation.Name = "lb_StatePopulation";
            lb_ProvincePopulation.Size = new System.Drawing.Size(50, 20);
            lb_ProvincePopulation.TabIndex = 0;
            lb_ProvincePopulation.Text = "Population: " + province.population;
            
        }

        private void addTabControlToProvinceTab(TabPage selectedTbProvince, int provinceId)
        {
            TabControl tc = new System.Windows.Forms.TabControl();

            selectedTbProvince.Controls.Add(tc);
            tc.Location = new System.Drawing.Point(270, 10);
            tc.Name = "tb" + provinceId;
            tc.SelectedIndex = 0;
            tc.Size = new System.Drawing.Size(600, 440);
            tc.TabIndex = provinceId;

            addSettlementTab(tc, provinceId);
        }

        private void addSettlementTab(TabControl tc, int provinceId)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            ConnectDB db = new ConnectDB(builder.Build());

            List<Settlement> settlements = db.GetSettlementsOfProvinces(provinceId);

            foreach (var settlement in settlements)
            {
                TabPage tab = new System.Windows.Forms.TabPage();
                tab.Location = new System.Drawing.Point(4, 29);
                tab.Name = settlement.name;
                tab.Padding = new System.Windows.Forms.Padding(3);
                tab.Size = new System.Drawing.Size(200, 0);
                tab.TabIndex = settlement.id;
                tab.Text = settlement.name;
                tab.UseVisualStyleBackColor = true;

                tc.Controls.Add(tab);

                addSettlementGB(tab, settlement);
            }
        }

        private void addSettlementGB(TabPage tab, Settlement settlement)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            ConnectDB db = new ConnectDB(builder.Build());

            GroupBox gpSettlement = new System.Windows.Forms.GroupBox();
            gpSettlement.Location = new System.Drawing.Point(0, 0);
            gpSettlement.Name = settlement.name;
            gpSettlement.Size = new System.Drawing.Size(250, 400);
            gpSettlement.TabIndex = 0;
            gpSettlement.TabStop = false;
            gpSettlement.Text = "Info:";
            tab.Controls.Add(gpSettlement);
            
            Label lb_Settlementname = new System.Windows.Forms.Label();
            gpSettlement.Controls.Add(lb_Settlementname);
            lb_Settlementname.AutoSize = true;
            lb_Settlementname.Location = new System.Drawing.Point(5, 25);
            lb_Settlementname.Name = "lb_Settlementname";
            lb_Settlementname.Size = new System.Drawing.Size(50, 20);
            lb_Settlementname.TabIndex = 0;
            lb_Settlementname.Text = "Name: " + settlement.name;

            Label lb_SettlementProvince = new System.Windows.Forms.Label();
            gpSettlement.Controls.Add(lb_SettlementProvince);
            lb_SettlementProvince.AutoSize = true;
            lb_SettlementProvince.Location = new System.Drawing.Point(5, 50);
            lb_SettlementProvince.Name = "lb_SettlementState";
            lb_SettlementProvince.Size = new System.Drawing.Size(50, 20);
            lb_SettlementProvince.TabIndex = 0;
            lb_SettlementProvince.Text = "Province: " + db.GetProvinceById(settlement.province).name;

            Label lb_SettlementState = new System.Windows.Forms.Label();
            gpSettlement.Controls.Add(lb_SettlementState);
            lb_SettlementState.AutoSize = true;
            lb_SettlementState.Location = new System.Drawing.Point(5, 75);
            lb_SettlementState.Name = "lb_SettlementState";
            lb_SettlementState.Size = new System.Drawing.Size(50, 20);
            lb_SettlementState.TabIndex = 0;
            lb_SettlementState.Text = "State: " + db.GetStateById(settlement.state).name;

            Label lb_SettlementPopulation = new System.Windows.Forms.Label();
            gpSettlement.Controls.Add(lb_SettlementPopulation);
            lb_SettlementPopulation.AutoSize = true;
            lb_SettlementPopulation.Location = new System.Drawing.Point(5, 100);
            lb_SettlementPopulation.Name = "lb_SettlemenPopulation";
            lb_SettlementPopulation.Size = new System.Drawing.Size(50, 20);
            lb_SettlementPopulation.TabIndex = 0;
            lb_SettlementPopulation.Text = "Population: " + settlement.population;
            
            Label lb_SettlementCityType = new System.Windows.Forms.Label();
            gpSettlement.Controls.Add(lb_SettlementCityType);
            lb_SettlementCityType.AutoSize = true;
            lb_SettlementCityType.Location = new System.Drawing.Point(5, 125);
            lb_SettlementCityType.Name = "lb_SettlementCityType";
            lb_SettlementCityType.Size = new System.Drawing.Size(50, 20);
            lb_SettlementCityType.TabIndex = 0;
            lb_SettlementCityType.Text = "City Type: " + db.GetCityTypeById(settlement.cityType);
            
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
        private List<TabPage> tabs_settlements = new List<TabPage>();
        private List<TabControl> tcs_provinces = new List<TabControl>();
    }
}