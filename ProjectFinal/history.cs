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
    public partial class history : UserControl
    {
        private List<Forprinthis> allhisstock = new List<Forprinthis>(); /*listประวัติ*/
        public history()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bbcare_shop;";

            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void Showdataproduct() //sales
        {
            MySqlConnection conn = databaseConnection();

            DataSet ds = new DataSet();

            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM history WHERE sales = '" + Program.user + "'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            datahistory.DataSource = ds.Tables[0].DefaultView;
        }

        private void ShowdataproductAdmin()
        {
            MySqlConnection conn = databaseConnection();

            DataSet ds = new DataSet();

            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM history";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            datahistory.DataSource = ds.Tables[0].DefaultView;
        }

        private void history_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = System.DateTime.Now;
            dateTimePicker2.Value = System.DateTime.Now;
            if (Program.status_login == "sales")
            {
                Showdataproduct();

            }
            else if (Program.user == "admin")
            {
                ShowdataproductAdmin();

            }
        }

        int sum = 0;
        int total = 0;
        int date; //ตัวแปรปฏิทิน
        private void btnsearch_Click(object sender, EventArgs e)
        {
            //admin
            if (Program.status_login == "admin")
            {

                if (dateTimePicker1.Value.ToString("yyyy-MM-dd") == dateTimePicker2.Value.ToString("yyyy-MM-dd"))
                {
                    MySqlConnection conn1 = databaseConnection();

                    DataSet ds1 = new DataSet();

                    conn1.Open();
                    MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM history WHERE sale_date like '%" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "%' AND name like '%" + searchbox.Text + "%'", conn1);


                    MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);

                    da1.Fill(ds1);
                    conn1.Close();
                    datahistory.DataSource = ds1.Tables[0].DefaultView;
                    sum = 0; //ตัวแปรจำนวนเงิน
                    total = 0; //ตัวแปรยอดรวมจำนวนสินค้า
                    conn1.Open();
                    MySqlDataReader read = cmd1.ExecuteReader();
                    while (read.Read())
                    {
                        sum = sum + int.Parse(read.GetString(3));
                        total = total + int.Parse(read.GetString(2));
                    }
                    textBoxTotal.Text = $"{sum}";
                    totalpro.Text = $"{total}";
                    conn1.Close();
                }
                else if (searchbox.Text != "")
                {
                    date = int.Parse(dateTimePicker2.Value.ToString("dd")) + 1;
                    MySqlConnection conn = databaseConnection();

                    DataSet ds = new DataSet();

                    conn.Open();
                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM history WHERE sale_date between @date1 and @date2 and name=@data";

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("yyyy-MM-" + date + ""));
                    da.SelectCommand.Parameters.AddWithValue("@data", searchbox.Text);
                    da.Fill(ds);
                    conn.Close();
                    datahistory.DataSource = ds.Tables[0].DefaultView;
                    sum = 0; //ตัวแปรจำนวนสินค้า
                    total = 0; //ตัวแปรยอดรวมจำนวนเงิน
                    conn.Open();
                    MySqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        sum = sum + int.Parse(read.GetString(3));
                        total = total + int.Parse(read.GetString(2));
                    }
                    textBoxTotal.Text = $"{sum}";
                    totalpro.Text = $"{total}";
                    conn.Close();
                }
                else
                {
                    date = int.Parse(dateTimePicker2.Value.ToString("dd")) + 1;
                    MySqlConnection conn = databaseConnection();

                    DataSet ds = new DataSet();

                    conn.Open();
                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM history WHERE sale_date between @date1 and @date2";

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("yyyy-MM-" + date + ""));
                    da.Fill(ds);
                    conn.Close();
                    datahistory.DataSource = ds.Tables[0].DefaultView;
                    sum = 0; //ตัวแปรจำนวนสินค้า
                    total = 0; //ตัวแปรยอดรวมจำนวนเงิน
                    conn.Open();
                    MySqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        sum = sum + int.Parse(read.GetString(3));
                        total = total + int.Parse(read.GetString(2));
                    }
                    textBoxTotal.Text = $"{sum}";
                    totalpro.Text = $"{total}";
                    conn.Close();

                }
            }
            //sale
            else if (Program.status_login == "sales")
            {

                if (dateTimePicker1.Value.ToString("yyyy-MM-dd") == dateTimePicker2.Value.ToString("yyyy-MM-dd"))
                {
                    MySqlConnection conn = databaseConnection();

                    DataSet ds2 = new DataSet();

                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM history WHERE sale_date like '%" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "%' AND name like '%" + searchbox.Text + "%' AND sales = '" + Program.user + "'", conn);

                    MySqlDataAdapter da2 = new MySqlDataAdapter(cmd);

                    da2.Fill(ds2);
                    conn.Close();
                    datahistory.DataSource = ds2.Tables[0].DefaultView;
                    sum = 0; //ตัวแปรจำนวนเงิน
                    total = 0; //ตัวแปรยอดรวมจำนวนสินค้า
                    conn.Open();
                    MySqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        sum = sum + int.Parse(read.GetString(3));
                        total = total + int.Parse(read.GetString(2));
                    }
                    textBoxTotal.Text = $"{sum}";
                    totalpro.Text = $"{total}";
                    conn.Close();
                }
                else if (searchbox.Text != "")
                {
                    date = int.Parse(dateTimePicker2.Value.ToString("dd")) + 1;
                    MySqlConnection conn = databaseConnection();

                    DataSet ds = new DataSet();

                    conn.Open();
                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM history WHERE sale_date between @date1 and @date2 and name=@data and sales=@user";

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("yyyy-MM-" + date + ""));
                    da.SelectCommand.Parameters.AddWithValue("@data", searchbox.Text);
                    da.SelectCommand.Parameters.AddWithValue("@user", Program.user);
                    da.Fill(ds);
                    conn.Close();
                    datahistory.DataSource = ds.Tables[0].DefaultView;
                    sum = 0; //ตัวแปรจำนวนสินค้า
                    total = 0; //ตัวแปรยอดรวมจำนวนเงิน
                    conn.Open();
                    MySqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        sum = sum + int.Parse(read.GetString(3));
                        total = total + int.Parse(read.GetString(2));
                    }
                    textBoxTotal.Text = $"{sum}";
                    totalpro.Text = $"{total}";
                    conn.Close();
                }
                else
                {
                    date = int.Parse(dateTimePicker2.Value.ToString("dd")) + 1;
                    MySqlConnection conn = databaseConnection();

                    DataSet ds = new DataSet();

                    conn.Open();
                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM history WHERE sale_date between @date1 and @date2 and sales=@user";

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("yyyy-MM-" + date + ""));
                    da.SelectCommand.Parameters.AddWithValue("@user", Program.user);
                    da.Fill(ds);
                    conn.Close();
                    datahistory.DataSource = ds.Tables[0].DefaultView;
                    sum = 0; //ตัวแปรจำนวนสินค้า
                    total = 0; //ตัวแปรยอดรวมจำนวนเงิน
                    conn.Open();
                    MySqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        sum = sum + int.Parse(read.GetString(3));
                        total = total + int.Parse(read.GetString(2));
                    }
                    textBoxTotal.Text = $"{sum}";
                    totalpro.Text = $"{total}";
                    conn.Close();
                }
            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            if (searchbox.Text == "")
            {
                if (Program.status_login == "sales")
                {
                    Showdataproduct();
                }
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void loaddata()
        {
            //admin
            if (Program.status_login == "admin")
            {

                if (dateTimePicker1.Value.ToString("yyyy-MM-dd") == dateTimePicker2.Value.ToString("yyyy-MM-dd"))
                {
                    MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=bbcare_shop;");
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM history WHERE sale_date like '%" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "%' AND name like '%" + searchbox.Text + "%'", conn);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    MySqlDataReader adapter = cmd.ExecuteReader();

                    while (adapter.Read())
                    {
                        Program.IDhis = adapter.GetString("ID");
                        Program.producthis = adapter.GetString("name");
                        Program.pricehis = adapter.GetString("sum");
                        Program.amounthis = adapter.GetString("amount");
                        Program.datehis = adapter.GetString("sale_date");
                        Program.saleshis = adapter.GetString("sales");

                        Forprinthis item = new Forprinthis()
                        {
                            IDhis = Program.IDhis,
                            producthis = Program.producthis,
                            pricehis = Program.pricehis,
                            amounthis = Program.amounthis,
                            datehis = Program.datehis,
                            saleshis = Program.saleshis

                        };
                        allhisstock.Add(item);
                    }
                }
                else if (searchbox.Text != "")
                {
                    date = int.Parse(dateTimePicker2.Value.ToString("dd")) + 1;
                    MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=bbcare_shop;");
                    conn.Open();

                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM history WHERE sale_date between @date1 and @date2 and name=@data";

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("yyyy-MM-" + date + ""));
                    da.SelectCommand.Parameters.AddWithValue("@data", searchbox.Text);

                    MySqlDataReader adapter = cmd.ExecuteReader();

                    while (adapter.Read())
                    {
                        Program.IDhis = adapter.GetString("ID");
                        Program.producthis = adapter.GetString("name");
                        Program.pricehis = adapter.GetString("sum");
                        Program.amounthis = adapter.GetString("amount");
                        Program.datehis = adapter.GetString("sale_date");
                        Program.saleshis = adapter.GetString("sales");
                        Forprinthis item = new Forprinthis()
                        {
                            IDhis = Program.IDhis,
                            producthis = Program.producthis,
                            pricehis = Program.pricehis,
                            amounthis = Program.amounthis,
                            datehis = Program.datehis,
                            saleshis = Program.saleshis

                        };
                        allhisstock.Add(item);
                    }
                }
                else
                {
                    date = int.Parse(dateTimePicker2.Value.ToString("dd")) + 1;
                    MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=bbcare_shop;");
                    conn.Open();

                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM history WHERE sale_date between @date1 and @date2";

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("yyyy-MM-" + date + ""));

                    MySqlDataReader adapter = cmd.ExecuteReader();

                    while (adapter.Read())
                    {
                        Program.IDhis = adapter.GetString("ID");
                        Program.producthis = adapter.GetString("name");
                        Program.pricehis = adapter.GetString("sum");
                        Program.amounthis = adapter.GetString("amount");
                        Program.datehis = adapter.GetString("sale_date");
                        Program.saleshis = adapter.GetString("sales");
                        Forprinthis item = new Forprinthis()
                        {
                            IDhis = Program.IDhis,
                            producthis = Program.producthis,
                            pricehis = Program.pricehis,
                            amounthis = Program.amounthis,
                            datehis = Program.datehis,
                            saleshis = Program.saleshis

                        };
                        allhisstock.Add(item);
                    }
                }
            }
            else if (Program.status_login == "sales")
            {
                if (dateTimePicker1.Value.ToString("yyyy-MM-dd") == dateTimePicker2.Value.ToString("yyyy-MM-dd"))
                {
                    MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=bbcare_shop;");
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM history WHERE sale_date like '%" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "%' AND name like '%" + searchbox.Text + "%' AND sales = '" + Program.user + "'", conn);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    MySqlDataReader adapter = cmd.ExecuteReader();

                    while (adapter.Read())
                    {
                        Program.IDhis = adapter.GetString("ID");
                        Program.producthis = adapter.GetString("name");
                        Program.pricehis = adapter.GetString("sum");
                        Program.amounthis = adapter.GetString("amount");
                        Program.datehis = adapter.GetString("sale_date");
                        Program.saleshis = adapter.GetString("sales");

                        Forprinthis item = new Forprinthis()
                        {
                            IDhis = Program.IDhis,
                            producthis = Program.producthis,
                            pricehis = Program.pricehis,
                            amounthis = Program.amounthis,
                            datehis = Program.datehis,
                            saleshis = Program.saleshis

                        };
                        allhisstock.Add(item);
                    }
                }
                else if (searchbox.Text != "")
                {
                    date = int.Parse(dateTimePicker2.Value.ToString("dd")) + 1;
                    MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=bbcare_shop;");
                    conn.Open();

                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM history WHERE sale_date between @date1 and @date2 and name=@data and sales=@user";

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("yyyy-MM-" + date + ""));
                    da.SelectCommand.Parameters.AddWithValue("@data", searchbox.Text);
                    da.SelectCommand.Parameters.AddWithValue("@user", Program.user); ;

                    MySqlDataReader adapter = cmd.ExecuteReader();

                    while (adapter.Read())
                    {
                        Program.IDhis = adapter.GetString("ID");
                        Program.producthis = adapter.GetString("name");
                        Program.pricehis = adapter.GetString("sum");
                        Program.amounthis = adapter.GetString("amount");
                        Program.datehis = adapter.GetString("sale_date");
                        Program.saleshis = adapter.GetString("sales");
                        Forprinthis item = new Forprinthis()
                        {
                            IDhis = Program.IDhis,
                            producthis = Program.producthis,
                            pricehis = Program.pricehis,
                            amounthis = Program.amounthis,
                            datehis = Program.datehis,
                            saleshis = Program.saleshis

                        };
                        allhisstock.Add(item);
                    }
                }
                else
                {
                    date = int.Parse(dateTimePicker2.Value.ToString("dd")) + 1;
                    MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=bbcare_shop;");
                    conn.Open();

                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM history WHERE sale_date between @date1 and @date2 and sales=@user";

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("yyyy-MM-" + date + ""));
                    da.SelectCommand.Parameters.AddWithValue("@user", Program.user);
                    MySqlDataReader adapter = cmd.ExecuteReader();

                    while (adapter.Read())
                    {
                        Program.IDhis = adapter.GetString("ID");
                        Program.producthis = adapter.GetString("name");
                        Program.pricehis = adapter.GetString("sum");
                        Program.amounthis = adapter.GetString("amount");
                        Program.datehis = adapter.GetString("sale_date");
                        Program.saleshis = adapter.GetString("sales");
                        Forprinthis item = new Forprinthis()
                        {
                            IDhis = Program.IDhis,
                            producthis = Program.producthis,
                            pricehis = Program.pricehis,
                            amounthis = Program.amounthis,
                            datehis = Program.datehis,
                            saleshis = Program.saleshis

                        };
                        allhisstock.Add(item);
                    }
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image logo = Image.FromFile(@"C:\Users\ACER\Desktop\ED COM\C#\Project Final\หน้าโปรแกรม\logo bbcare.png");
            e.Graphics.DrawImage(logo, new PointF(50, 50));
            e.Graphics.DrawString("ประวัติการจำหน่ายสินค้า", new Font("TH SarabunPSK", 26, FontStyle.Bold), Brushes.Black, new PointF(370, 120));
            e.Graphics.DrawString("BB Care Shop", new Font("TH SarabunPSK", 26, FontStyle.Bold), Brushes.Black, new PointF(650, 120));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 160));
            e.Graphics.DrawString("ประวัติการจำหน่ายสินค้า", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 195));
            e.Graphics.DrawString("พิมพ์เมื่อ " + System.DateTime.Now.ToString("dd / MM / yyyy   HH : mm : ss น."), new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 215));
            e.Graphics.DrawString("พิมพ์โดย BB Care Shop ", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(400, 215));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 240));
            e.Graphics.DrawString("รหัสสินค้า", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(50, 255));
            e.Graphics.DrawString("รายการ", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(160, 255));
            e.Graphics.DrawString("ราคา", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(300, 255));
            e.Graphics.DrawString("จำนวน", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(400, 255));
            e.Graphics.DrawString("วันที่", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(490, 255));
            e.Graphics.DrawString("ผู้จำหน่าย", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(670, 255));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 265));
            int y = 290;
            allhisstock.Clear();
            loaddata();
            foreach (var i in allhisstock)
            {
                e.Graphics.DrawString(i.IDhis, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(50, y));
                e.Graphics.DrawString(i.producthis, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(160, y));
                e.Graphics.DrawString(i.pricehis, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(300, y));
                e.Graphics.DrawString(i.amounthis, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(400, y));
                e.Graphics.DrawString(i.datehis, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(470, y));
                e.Graphics.DrawString(i.saleshis, new Font("TH SarabunPSK", 14, FontStyle.Regular), Brushes.Black, new PointF(670, y));
                y = y + 20;
            }
            e.Graphics.DrawString("จำนวนสินค้า", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(520, y + 20));
            e.Graphics.DrawString("ยอดรวม", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(520, y + 20 + 20));
            e.Graphics.DrawString(totalpro.Text, new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(650, y + 20));
            e.Graphics.DrawString(textBoxTotal.Text, new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(650, y + 20 + 20));
            e.Graphics.DrawString("ชิ้น", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(750, y + 20));
            e.Graphics.DrawString("บาท", new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(750, y + 20 + 20));
        }
    }
}
