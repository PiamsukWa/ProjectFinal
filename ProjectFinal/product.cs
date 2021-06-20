using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectFinal
{
    public partial class product : UserControl
    {
        private List<Forprintstock> allproduct = new List<Forprintstock>(); /*liststock*/
        public product()
        {
            InitializeComponent();
        }

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bbcare_shop;";

            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void Showdataproduct()
        {
            MySqlConnection conn = databaseConnection();

            DataSet ds = new DataSet();

            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM stockproduct";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataproduct.DataSource = ds.Tables[0].DefaultView;
        }

        private void dataproduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataproduct.CurrentRow.Selected = true;
            txtid.Text = dataproduct.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
            txtkind.Text = dataproduct.Rows[e.RowIndex].Cells["kind"].FormattedValue.ToString();
            txtname.Text = dataproduct.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            textamount.Text = dataproduct.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();
            txtprice.Text = dataproduct.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
        }

        private void product_Load(object sender, EventArgs e)
        {
            Showdataproduct();
            if (Program.status_login == "admin")
            {
                txtkind.Enabled = true;
                txtname.Enabled = true;
                textamount.Enabled = true;
                txtprice.Enabled = true;
                delete.Enabled = true;
                insert.Enabled = true;
                update.Enabled = true;

            }
            else if (Program.status_login == "sales")
            {
                txtkind.Enabled = false;
                txtname.Enabled = false;
                textamount.Enabled = false;
                txtprice.Enabled = false;
                delete.Enabled = false;
                insert.Enabled = false;
                update.Enabled = false;
                delete.Hide();
                insert.Hide();
                update.Hide();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            int selectedRow = dataproduct.CurrentCell.RowIndex;
            int productupdate = Convert.ToInt32(dataproduct.Rows[selectedRow].Cells["ID"].Value);

            MySqlConnection conn = databaseConnection();
            string sql = "UPDATE stockproduct SET kind ='" + txtkind.Text + "' ,name ='" + txtname.Text + "' ,  amount = '" + textamount.Text + "' , price = '" + txtprice.Text + "' WHERE ID = '" + productupdate + "' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("แก้ไขข้อมูลสำเร็จ", "แจ้งเตือน");
                Showdataproduct();
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            string product = txtname.Text;
            cmd.CommandText = $"SELECT * FROM stockproduct WHERE name =\"{product}\"";
            MySqlDataReader adapter = cmd.ExecuteReader();
            if (adapter.HasRows)
            {
                conn.Close();
                MessageBox.Show("มีสินค้านี้ในคลังแล้ว", "ระบบแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MySqlConnection conn1 = databaseConnection();
                string sql = "INSERT INTO stockproduct (kind, name, amount, price) VALUES('" + txtkind.Text + "' , '" + txtname.Text + "','" + textamount.Text + "', '" + txtprice.Text + "')";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn1);

                conn1.Open();

                int rows = cmd1.ExecuteNonQuery();

                conn1.Close();

                if (rows > 0)
                {
                    MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "แจ้งเตือน");
                    Showdataproduct();
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int selectedRow = dataproduct.CurrentCell.RowIndex;
            int deletepro = Convert.ToInt32(dataproduct.Rows[selectedRow].Cells["ID"].Value);

            MySqlConnection conn = databaseConnection();
            string sql = "DELETE FROM stockproduct WHERE ID = '" + deletepro + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("ลบข้อมูลสำเร็จ", "แจ้งเตือน");
                Showdataproduct();
            }
        }
        public void combokind() //สร้าง method ขึ้นเอง
        {
            MySqlConnection conn = databaseConnection();

            DataSet ds = new DataSet();

            conn.Open();
            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM stockproduct WHERE kind =\"{comboBox1.SelectedItem.ToString()}\"";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataproduct.DataSource = ds.Tables[0].DefaultView;
        }

        Boolean allstock;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            allstock = true;
            combokind();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();

            DataSet ds = new DataSet();

            conn.Open();
            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM stockproduct WHERE name like \"%{searchbox.Text}%\" AND kind =\"{comboBox1.SelectedItem.ToString()}\"";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataproduct.DataSource = ds.Tables[0].DefaultView;
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            if (searchbox.Text == "")
            {
                combokind();
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            allstock = false;
            Showdataproduct();
            txtid.ResetText();
            txtkind.ResetText();
            txtname.ResetText();
            textamount.ResetText();
            txtprice.ResetText();
            searchbox.Text = "";
            comboBox1.Text = "ประเภทสินค้า";
        }

        private void txtkind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("กรุณากรอกเฉพาะตัวเลข", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("กรุณากรอกเฉพาะตัวเลข", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1; //ปริิ้น stock
            printPreviewDialog1.ShowDialog();
        }

        private void loaddata()
        {
            MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=bbcare_shop;");

            conn.Open();
            if (allstock == true)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM stockproduct WHERE kind = '" + comboBox1.SelectedItem.ToString() + "' AND name like '%" + searchbox.Text + "%'", conn);
                MySqlDataReader adapter = cmd.ExecuteReader();

                while (adapter.Read())
                {
                    Program.IDstock = adapter.GetString("ID");
                    Program.kindstock = adapter.GetString("kind");
                    Program.productstock = adapter.GetString("name");
                    Program.amountstock = adapter.GetString("amount");
                    Program.pricestock = adapter.GetString("price");
                    Forprintstock item = new Forprintstock()
                    {
                        IDstock = Program.IDstock,
                        kindstock = Program.kindstock,
                        productstock = Program.productstock,
                        amountstock = Program.amountstock,
                        pricestock = Program.pricestock
                    };
                    allproduct.Add(item);
                }
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM stockproduct", conn);
                MySqlDataReader adapter = cmd.ExecuteReader();

                while (adapter.Read())
                {
                    Program.IDstock = adapter.GetString("ID");
                    Program.kindstock = adapter.GetString("kind");
                    Program.productstock = adapter.GetString("name");
                    Program.amountstock = adapter.GetString("amount");
                    Program.pricestock = adapter.GetString("price");
                    Forprintstock item = new Forprintstock()
                    {
                        IDstock = Program.IDstock,
                        kindstock = Program.kindstock,
                        productstock = Program.productstock,
                        amountstock = Program.amountstock,
                        pricestock = Program.pricestock
                    };
                    allproduct.Add(item);
                }
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image logo = Image.FromFile(@"C:\Users\ACER\Desktop\ED COM\C#\Project Final\หน้าโปรแกรม\logo bbcare.png");
            e.Graphics.DrawImage(logo, new PointF(50, 50));
            e.Graphics.DrawString("BB Care Shop", new Font("TH SarabunPSK", 26, FontStyle.Bold), Brushes.Black, new PointF(650, 140));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 160));
            e.Graphics.DrawString("รายการจำหน่ายสินค้า", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 195));
            e.Graphics.DrawString("พิมพ์เมื่อ : \t " + System.DateTime.Now.ToString("dd / MM / yyyy   HH : mm : ss น."), new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 215));
            e.Graphics.DrawString(" \t พิมพ์โดย : \t " + Program.user, new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(400, 215));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 240));
            e.Graphics.DrawString("รหัสสินค้า", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(50, 255));
            e.Graphics.DrawString("ประเภท", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(160, 255));
            e.Graphics.DrawString("สินค้า", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(370, 255));
            e.Graphics.DrawString("จำนวนคงเหลือ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(530, 255));
            e.Graphics.DrawString("ราคา", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(695, 255));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 265));
            int y = 290;

            allproduct.Clear();
            loaddata();
            foreach (var i in allproduct)
            {
                e.Graphics.DrawString(i.IDstock, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(50, y));
                e.Graphics.DrawString(i.kindstock, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(155, y));
                e.Graphics.DrawString(i.productstock, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(365, y));
                e.Graphics.DrawString(i.amountstock, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(570, y));
                e.Graphics.DrawString(i.pricestock, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(700, y));
                y = y + 20;
            }
        }
    }
}
