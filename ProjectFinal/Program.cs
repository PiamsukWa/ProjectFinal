using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFinal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BBCareShop());
        }

        public static string ID;
        public static string product;
        public static string price;
        public static string amount;

        public static string IDhis;
        public static string producthis;
        public static string datehis;
        public static string pricehis;
        public static string amounthis;
        public static string saleshis;

        public static string IDstock;
        public static string kindstock;
        public static string productstock;
        public static string pricestock;
        public static string amountstock;

        public static string user;
        public static string status_login;
    }
}
