using static System.Net.Mime.MediaTypeNames;

namespace World_Management
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_shop_Click(object sender, EventArgs e)
        {
            ShopListForm sf = new ShopListForm();
            sf.ShowDialog();
        }

        private void btn_addItem_Click(object sender, EventArgs e)
        {
            AddItemForm af = new AddItemForm();
            af.ShowDialog();
        }

        private void btn_addBuilding_Click(object sender, EventArgs e)
        {
            AddBuildingForm af = new AddBuildingForm();
            af.ShowDialog();
        }
    }
}