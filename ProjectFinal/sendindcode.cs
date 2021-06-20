using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using MySql.Data.MySqlClient;

namespace ProjectFinal
{
    public partial class sendindcode : Form
    {
        string OTPCode;
        public static string to;
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bbcare_shop;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public sendindcode()
        {
            InitializeComponent();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            OTPCode = (rand.Next(999999)).ToString();

            MailMessage message = new MailMessage();
            to = (txtemail.Text).ToString();
            from = "BeeBcare.Shop@gmail.com";
            pass = "Bam11032544";
            messageBody = "Your Reset OTP code is " + OTPCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "รหัสยืนยันความปลอดภัย";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("ส่ง OTP สำเร็จ กรุณาตรวจสอบข้อความ E-mail ของคุณค่ะ", "ระบบแจ้งเตือน");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bntverify_Click(object sender, EventArgs e)
        {
            if (OTPCode == (txtotp.Text).ToString())
            {
                to = txtemail.Text;
                newpassword np = new newpassword();
                this.Hide();
                np.Show();
            }
            else
            {
                MessageBox.Show("รหัสไม่ถูกต้อง", "เเจ้งเตือน");
            }
        }

        public string txt; //รับค่ามาจากฟอร์ม log in
        private void sendindcode_Load(object sender, EventArgs e)
        {
            labelcheck1.Text = "* กรุณากรอกที่อยู่ E-mail";
            labelcheck2.Text = "* กรุณากรอกรหัสผ่านยืนยัน";
            label3.Text = txt;
            MySqlConnection conn = databaseConnection();
            conn.Open();
            string sqlcom = "SELECT * FROM admin WHERE username = '" + label3.Text + "'";
            MySqlCommand command = new MySqlCommand(sqlcom, conn);
            MySqlDataReader readdata = command.ExecuteReader();

            if (readdata.Read())
            {
                txtemail.Text = readdata.GetValue(5).ToString();
            }
            conn.Close();
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            if (txtemail.Text == "")
            {
                labelcheck1.Text = "* กรุณากรอกที่อยู่ E-mail";
            }
            else
            {
                labelcheck1.Text = "";
            }
        }

        private void txtotp_TextChanged(object sender, EventArgs e)
        {
            if (txtotp.Text == "")
            {
                labelcheck2.Text = "* กรุณากรอกรหัสผ่านยืนยัน";
            }
            else
            {
                labelcheck2.Text = "";
            }
        }

        private void buttonclose1_Click(object sender, EventArgs e)
        {
            Sign_In form = new Sign_In();
            this.Hide();
            form.Show();
        }
    }
}
