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
    public partial class newpassword : Form
    {
        public newpassword()
        {
            InitializeComponent();
        }
        
        
        string username = sendindcode.to;

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bbcare_shop;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        private void buttonclose1_Click(object sender, EventArgs e)
        {
            Sign_In form = new Sign_In();
            this.Hide();
            form.Show();
        }

        private void btnverifify_Click(object sender, EventArgs e)
        {
            if (txtnewpass.Text == txtconfirmpass.Text)
            {

                MySqlConnection conn = databaseConnection();
                string sql = "UPDATE admin SET password ='" + txtconfirmpass.Text + "' WHERE email = '" + username + "' ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("เปลี่ยนรหัสผ่านเรียบร้อย", "แจ้งเตือน");
                Sign_In form = new Sign_In();
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("โปรดตรวจสอบรหัสผ่านอีกครั้ง", "แจ้งเตือน");
            }
        }
    }
}
