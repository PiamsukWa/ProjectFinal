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
    public partial class UserControladmin : UserControl
    {
        public UserControladmin()
        {
            InitializeComponent();
        }

        string userold;
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=bbcare_shop;");
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bbcare_shop;";

            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void ShowGridViewadmin()
        {
            MySqlConnection conn = databaseConnection();

            DataSet ds = new DataSet();

            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM admin";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            GridViewadmin.DataSource = ds.Tables[0].DefaultView;
        }

        private void ShowGridViewSale()
        {
            MySqlConnection conn = databaseConnection();

            DataSet ds = new DataSet();

            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM admin WHERE username = '" + Program.user + "'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            GridViewadmin.DataSource = ds.Tables[0].DefaultView;
        }

        private void GridViewadmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GridViewadmin.CurrentRow.Selected = true;
            username.Text = GridViewadmin.Rows[e.RowIndex].Cells["username"].FormattedValue.ToString();
            userold = GridViewadmin.Rows[e.RowIndex].Cells["username"].FormattedValue.ToString();
            password.Text = GridViewadmin.Rows[e.RowIndex].Cells["password"].FormattedValue.ToString();
            fname.Text = GridViewadmin.Rows[e.RowIndex].Cells["fname"].FormattedValue.ToString();
            lname.Text = GridViewadmin.Rows[e.RowIndex].Cells["lname"].FormattedValue.ToString();
            textBoxemail.Text = GridViewadmin.Rows[e.RowIndex].Cells["email"].FormattedValue.ToString();
        }

        private void UserControladmin_Load(object sender, EventArgs e)
        {
            if (Program.status_login == "admin")
            {
                ShowGridViewadmin();
                username.ReadOnly = false;
                textBoxemail.ReadOnly = false;
                newaccount.Enabled = true;
                saveaccount.Enabled = true;
                searchbox.Enabled = true;
                searchbutton.Enabled = true;
                username.Enabled = false;
                textBoxemail.Enabled = false;
                btndelete.Enabled = true;
            }
            else if (Program.status_login == "sales")
            {
                ShowGridViewSale();
                username.ReadOnly = true;
                textBoxemail.ReadOnly = true;
                newaccount.Enabled = false;
                saveaccount.Enabled = false;
                searchbox.Enabled = false;
                searchbutton.Enabled = false;
                username.Enabled = false;
                textBoxemail.Enabled = false;
                btndelete.Enabled = false;
                btndelete.Hide();
                saveaccount.Hide();
                newaccount.Hide();
            }
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();

            DataSet ds = new DataSet();

            conn.Open();
            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM admin WHERE username like \"%{searchbox.Text}%\"";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            GridViewadmin.DataSource = ds.Tables[0].DefaultView;
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            if (searchbox.Text == "")
            {
                ShowGridViewadmin();
            }
        }

        private void newaccount_Click(object sender, EventArgs e)
        {
            btnupdate.Enabled = false; //ปุ่มอัปเดตปิด
            username.ResetText();
            password.ResetText();
            fname.ResetText();
            lname.ResetText();
            textBoxemail.ResetText();
            textBoxemail.Enabled = true; //textboxemail เปิดใช้งาน
            username.Enabled = true;
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            label8.ResetText();
        }

        private void textBoxemail_TextChanged(object sender, EventArgs e)
        {
            label9.ResetText();
        }

        private void saveaccount_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            MySqlConnection conn2 = databaseConnection();
            conn2.Open();

            MySqlCommand cmd;
            MySqlCommand cmd2;
            cmd = conn.CreateCommand();
            cmd2 = conn2.CreateCommand();
            string email = textBoxemail.Text + "@gmail.com";
            string usename = username.Text;
            cmd.CommandText = $"SELECT * FROM admin WHERE username =\"{usename}\"";
            cmd2.CommandText = $"SELECT * FROM admin WHERE  email =\"{email}\"";
            MySqlDataReader adapter = cmd.ExecuteReader();
            MySqlDataReader adapter2 = cmd2.ExecuteReader();
            label8.ResetText();
            label9.ResetText();
            if (adapter.HasRows)
            {
                conn.Close();
                label8.Text = "*ชื่อผู้ใช้มีบัญชีผู้ใช้งานแล้ว";
            }
            else if (adapter2.HasRows)
            {
                conn2.Close();
                label9.Text = "* E-mail มีบัญชีผู้ใช้งานแล้ว";
            }
            else
            {
                MySqlConnection condata = databaseConnection();
                string sql = "INSERT INTO admin (username, password, fname, lname, email,status) VALUES" + $"(\"{username.Text}\",\"{password.Text}\",\"{fname.Text}\",\"{lname.Text}\",\"{textBoxemail.Text + "@gmail.com"}\",\"{"sales"}\")";
                MySqlCommand dt = new MySqlCommand(sql, condata);
                condata.Open();
                dt.ExecuteNonQuery();
                condata.Close();
                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "แจ้งเตือน");
                label8.ResetText();
                label9.ResetText();
                ShowGridViewadmin();
            }
            btnupdate.Enabled = true;
            textBoxemail.Enabled = false;
            username.Enabled = false;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            string sql = $"UPDATE admin SET `username` =\"{username.Text}\", `password` = \"{password.Text}\",  `fname` = \"{ fname.Text}\", `lname` = \"{lname.Text}\" WHERE `username` =\"{userold}\"";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();
            MessageBox.Show("แก้ไขข้อมูลสำเร็จ", "แจ้งเตือน");
            if (Program.status_login == "admin")
            {
                ShowGridViewadmin();
                username.ReadOnly = false;
                textBoxemail.ReadOnly = false;
                newaccount.Enabled = true;
                saveaccount.Enabled = true;
            }
            else if (Program.status_login == "sales")
            {
                ShowGridViewSale();
                username.ReadOnly = true;
                textBoxemail.ReadOnly = true;
                newaccount.Enabled = false;
                saveaccount.Enabled = false;

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int selectedRow = GridViewadmin.CurrentCell.RowIndex;
            int deleteuser = Convert.ToInt32(GridViewadmin.Rows[selectedRow].Cells["ID"].Value);

            MySqlConnection conn = databaseConnection();
            string sql = "DELETE FROM admin WHERE ID = '" + deleteuser + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("ลบข้อมูลสำเร็จ", "แจ้งเตือน");
                ShowGridViewadmin();
            }
        }

        private void fname_KeyPress(object sender, KeyPressEventArgs e) //ใช้ภาษาไทย ห้ามใช้ตัวเลข
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 13)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 13)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void textBoxemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 13 || (int)e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
