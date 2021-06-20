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
    public partial class register : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bbcare_shop;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public register()
        {
            InitializeComponent();
        }

        private void Boxemail_Enter(object sender, EventArgs e)
        {
            if (Boxemail.Text == "ที่อยู่ E-mail")
            {
                Boxemail.Text = "";
                Boxemail.ForeColor = Color.Black;
            }
        }

        private void Boxemail_Leave(object sender, EventArgs e)
        {
            if (Boxemail.Text == "")
            {
                Boxemail.Text = "ที่อยู่ E-mail";
                Boxemail.ForeColor = Color.Silver;
            }
        }

        private void textBoxfname_Enter(object sender, EventArgs e)
        {
            if (textBoxfname.Text == "ชื่อจริง")
            {
                textBoxfname.Text = "";
                textBoxfname.ForeColor = Color.Black;
            }
        }

        private void textBoxfname_Leave(object sender, EventArgs e)
        {
            if (textBoxfname.Text == "")
            {
                textBoxfname.Text = "ชื่อจริง";
                textBoxfname.ForeColor = Color.Silver;
            }
        }

        private void textBoxlname_Enter(object sender, EventArgs e)
        {
            if (textBoxlname.Text == "นามสกุล")
            {
                textBoxlname.Text = "";
                textBoxlname.ForeColor = Color.Black;
            }
        }

        private void textBoxlname_Leave(object sender, EventArgs e)
        {
           
            if (textBoxlname.Text == "")
            {
                textBoxlname.Text = "นามสกุล";
                textBoxlname.ForeColor = Color.Silver;
            }

        }

        private void nameaccount_Enter(object sender, EventArgs e)
        {
            if (nameaccount.Text == "ชื่อผู้ใช้")
            {
                nameaccount.Text = "";
                nameaccount.ForeColor = Color.Black;
            }
        }

        private void nameaccount_Leave(object sender, EventArgs e)
        {
            if (nameaccount.Text == "")
            {
                nameaccount.Text = "ชื่อผู้ใช้";
                nameaccount.ForeColor = Color.Silver;
            }
        }

        private void Boxpassword1_Enter(object sender, EventArgs e)
        {
            if (Boxpassword1.Text == "รหัสผ่าน")
            {
                Boxpassword1.Text = "";
                Boxpassword1.ForeColor = Color.Black;
            }
        }

        private void Boxpassword1_Leave(object sender, EventArgs e)
        {
            if (Boxpassword1.Text == "")
            {
                Boxpassword1.Text = "รหัสผ่าน";
                Boxpassword1.ForeColor = Color.Silver;
            }
        }

        private void Boxpassword2_Enter(object sender, EventArgs e)
        {
            if (Boxpassword2.Text == "ยืนยันรหัสผ่าน")
            {
                Boxpassword2.Text = "";
                Boxpassword2.ForeColor = Color.Black;
            }

        }

        private void Boxpassword2_Leave(object sender, EventArgs e)
        {
            if (Boxpassword2.Text == "")
            {
                Boxpassword2.Text = "ยืนยันรหัสผ่าน";
                Boxpassword2.ForeColor = Color.Silver;
            }
        }

        private void createnew_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            MySqlConnection conn2 = databaseConnection();
            conn2.Open();

            MySqlCommand cmd;
            MySqlCommand cmd2;
            cmd = conn.CreateCommand();
            cmd2 = conn2.CreateCommand();
            string email = Boxemail.Text + "@gmail.com";
            string username = nameaccount.Text;
            cmd.CommandText = $"SELECT * FROM admin WHERE email =\"{email}\"";
            cmd2.CommandText = $"SELECT * FROM admin WHERE  username =\"{username}\"";
            MySqlDataReader adapter = cmd.ExecuteReader();
            MySqlDataReader adapter2 = cmd2.ExecuteReader();

            if (adapter.HasRows)
            {
                conn.Close();
                labelcheckmail.Text = "* E-mail มีบัญชีผู้ใช้งานแล้ว";
            }
            else if (adapter2.HasRows)
            {
                conn2.Close();
                label5.Text = "*ชื่อผู้ใช้มีบัญชีผู้ใช้งานแล้ว";
            }
            else
            {
                MySqlConnection condata = databaseConnection();
                string sql = "INSERT INTO admin (username, password, fname, lname, email,status) VALUES" + $"(\"{nameaccount.Text}\",\"{Boxpassword1.Text}\",\"{textBoxfname.Text}\",\"{textBoxlname.Text}\",\"{Boxemail.Text + "@gmail.com"}\",\"{"sales"}\")";
                MySqlCommand dt = new MySqlCommand(sql, condata);
                condata.Open();
                dt.ExecuteNonQuery();
                condata.Close();
                MessageBox.Show("ลงทะเบียนสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK);
                labelcheckmail.ResetText();
                BBCareShop form = new BBCareShop();
                form.Show();
                this.Hide();
            }
        }

        private void Boxpassword2_TextChanged(object sender, EventArgs e)
        {
            if (Boxpassword1.Text != "" && Boxpassword2.Text == Boxpassword1.Text && Boxpassword2.Text != "" && Boxemail.Text != "" && nameaccount.Text != "")
            {
                createnew.Enabled = true;
                errorProvider1.SetError(Boxpassword2, "");
                label3.ResetText();
            }
            else
            {
                createnew.Enabled = false;
                errorProvider1.SetError(Boxpassword2, "รหัสผ่านไม่ตรง");
                label3.Text = "โปรดตรวจสอบรหัสผ่านอีกครั้ง";
            }
        }

        private void Boxpassword1_TextChanged(object sender, EventArgs e)
        {
            if (Boxpassword1.Text == "")
            {
                errorProvider1.SetError(Boxpassword2, "");
                label3.ResetText();
            }
        }

        private void register_Load(object sender, EventArgs e)
        {
            createnew.Enabled = false;
        }

        private void createemail_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://accounts.google.com/signup/v2/webcreateaccount?flowName=GlifWebSignIn&flowEntry=SignUp");
        }

        private void Boxemail_TextChanged(object sender, EventArgs e)
        {
            labelcheckmail.Text = ""; //รีเซ็ตตอน e-mail ซ้ำ
        }

        private void nameaccount_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void Boxemail_KeyPress(object sender, KeyPressEventArgs e) //ห้ามใช้อักษรไทย อักขระพิเศษยกเว้น . _
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 13 || (int)e.KeyChar == 46)
            {
                e.Handled = false; // OS will handle this event.
            }
            else
            {
                e.Handled = true;  // OS will not handle this event.
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxfname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxlname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void nameaccount_KeyPress(object sender, KeyPressEventArgs e) //ห้ามใช้อักษรไทย อักขระพิเศษ
        {
            if(((int)e.KeyChar >= 65 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 13)
            {
                e.Handled = false; // OS will handle this event.
            }


            else
            {
                e.Handled = true;  // OS will not handle this event.
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Boxpassword1_KeyPress(object sender, KeyPressEventArgs e) //ห้ามใช้อักษรไทย อักขระพิเศษ
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 13)
            {
                e.Handled = false; // OS will handle this event.
            }
            else
            {
                e.Handled = true;  // OS will not handle this event.
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Boxpassword2_KeyPress(object sender, KeyPressEventArgs e) //ห้ามใช้อักษรไทย อักขระพิเศษ
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 13)
            {
                e.Handled = false; // OS will handle this event.
            }
            else
            {
                e.Handled = true;  // OS will not handle this event.
                MessageBox.Show("กรุณาตรวจสอบอักขระ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            Sign_In form = new Sign_In();
            this.Hide();
            form.Show();
        }
    }
}
