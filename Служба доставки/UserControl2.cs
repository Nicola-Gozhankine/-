using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VS;

namespace Служба_доставки
{
    public partial class UserControl2 : UserControl
    {
        public string filePath = "Zacasi.txt"; // замените на реальный путь к вашему файлу
        string stat = " ";
        private Zacas zacas;
        private List<Zacas> zacasCollection;
        private int index;
        int index1;
        private Роль роль;
        int OrderNumber { get; set; }
        string Status { get; set; }
        DateTime InstallationTime { get; set; }

        public UserControl2(int orderNumber, string status, DateTime installationTime,Zacas zacas)
        {
            InitializeComponent();
            this.OrderNumber = orderNumber;
            this.Status = status;
            this.InstallationTime = installationTime;
            this.zacas = zacas;

        }
        public UserControl2(int orderNumber, string status, DateTime installationTime)
        {
            InitializeComponent();
            this.OrderNumber = orderNumber;
            this.Status = status;
            this.InstallationTime = installationTime;
            

        }
        public UserControl2()
        {
            InitializeComponent();
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }
    }
}
