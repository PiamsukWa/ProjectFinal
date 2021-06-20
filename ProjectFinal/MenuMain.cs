using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFinal
{
    public partial class MenuMain : Form
    {
        public MenuMain()
        {
            InitializeComponent();
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonlogout_Click(object sender, EventArgs e)
        {
            BBCareShop form = new BBCareShop();
            form.Show();
            this.Close();
        }
        public void showControl(Control control)
        {
            content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();

            content.Controls.Add(control);
        }

        private void btnproduct_Click(object sender, EventArgs e)
        {
            panelslide.Height = panelslide.Height;
            product hc = new product();
            showControl(hc);
        }

        private void btnhistory_Click(object sender, EventArgs e)
        {
            panelslide.Height = panelslide.Height;
            history hc = new history();
            showControl(hc);
        }

        private void buttonadmin_Click(object sender, EventArgs e)
        {
            panelslide.Height = panelslide.Height;
            UserControladmin hc = new UserControladmin();
            showControl(hc);
        }

        public string txt; //รับค่ามาจากฟอร์ม log in
        private void MenuMain_Load(object sender, EventArgs e)
        {
            label3.Text = Program.user;
        }
    }
}
