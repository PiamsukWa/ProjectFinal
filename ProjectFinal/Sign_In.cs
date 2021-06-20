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
    public partial class Sign_In : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bbcare_shop;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public Sign_In()
        {
            InitializeComponent();
        }

        private void textBoxuser_Leave(object sender, EventArgs e)
        {
            if (textBoxuser.Text == "")
            {
                textBoxuser.Text = "บัญชีผู้ใช้";
                textBoxuser.ForeColor = Color.Silver;
            }
        }

        private void textBoxuser_Enter(object sender, EventArgs e)
        {
            if (textBoxuser.Text == "บัญชีผู้ใช้")
            {
                textBoxuser.Text = "";
                textBoxuser.ForeColor = Color.Black;
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "รหัสผ่าน")
            {
                txtpassword.Text = "";
                txtpassword.PasswordChar = '*';
                txtpassword.ForeColor = Color.Black;
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                txtpassword.Text = "รหัสผ่าน";
                txtpassword.PasswordChar = '\0';
                txtpassword.ForeColor = Color.Silver;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //check password
        {
            if (checkBox1.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            BBCareShop form = new BBCareShop();
            form.Show();
            this.Close();
        }

        private void buttonnewacount_Click(object sender, EventArgs e)
        {
            register form = new register();
            form.Show();
            this.Close();
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            string user = textBoxuser.Text;
            string password = txtpassword.Text;

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM admin WHERE username=\"{user}\" AND password=\"{password}\"", conn);
            bool checkhave = false;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Program.status_login = reader.GetString("status").ToString();
                checkhave = true;
            }
            conn.Close();
            Program.user = user;
            //MessageBox.Show(Program.status_login + " " + Program.user + " " + checkhave.ToString());
            if (checkhave == true)
            {
                MessageBox.Show("เข้าสู่ระบบสำเร็จ", "แจ้งเตือน");
                MenuMain f4 = new MenuMain();
                this.Hide();
                f4.Show();


            }
            else if (checkhave == false)
            {

                labelcheckpass.Text = " บัญชีผู้ใช้หรือรหัสผ่านไม่ถูกต้อง";
            }
        }

        private void forgetpass_Click(object sender, EventArgs e) //In to Sending OTP
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            String user = textBoxuser.Text;
            cmd.CommandText = $"SELECT * FROM admin WHERE username=\"{user}\"";
            if (cmd.ExecuteReader().HasRows)
            {
                sendindcode sc = new sendindcode();
                sc.txt = textBoxuser.Text;
                this.Hide();
                sc.Show();
            }
            else
            {
                MessageBox.Show("ไม่มีชื่อพนักงาน", "ระบบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            conn.Close();
        }

        private void Sign_In_Load(object sender, EventArgs e)
        {
            buttonlogin.Enabled = false;
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.KeyCode == Keys.Enter)
                {
                    buttonlogin_Click(buttonlogin, e);
                }
            }
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtpassword.Text == "" && textBoxuser.Text != "")
            {
                buttonlogin.Enabled = false;
                labelcheckpass.ResetText();
            }
            else
            {
                buttonlogin.Enabled = true;
            }
        }
    }
}
