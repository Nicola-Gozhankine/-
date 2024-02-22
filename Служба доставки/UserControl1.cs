using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Служба_доставки.Properties;
using VS;
using System.IO;

namespace Служба_доставки
{
    public partial class UserControl1 : UserControl
    {
        public int usercontrol;
        public UserControl1(int x)
        {
            usercontrol = x;
            InitializeComponent();
        }
        VS.Zacas zacas = new VS.Zacas();
        private void label4_Click(object sender, EventArgs e)
        {

        }
        
        public Zacas daser()
        {
            Zacas pilot = new Zacas();
            string filePath = "Zacasi.txt";
            var user = File.ReadLines(filePath).ToList();
            int flag = 0, flag_control = 0;
            foreach (string line in user)
            {
                if (line.Contains("*"))
                {
                    flag_control++;
                    if (flag_control == usercontrol) flag += 2;
                    Console.WriteLine("UserControl " + flag_control);
                    Console.WriteLine(flag + " " + flag_control);
                }
                if (line.Contains("Заказ под номером") && flag == 2 && flag_control == this.usercontrol)
                {
                    this.label1.Text = line.Substring(line.IndexOf("=+=") + 4);
                    pilot.Number = Convert.ToInt32(line.Substring(line.IndexOf("=+=") + 4));
                    flag--;
                }
                if (line.Contains("Время прибытия курьера") && flag == 1 && flag_control == this.usercontrol)
                {
                    this.label2.Text = line.Substring(line.IndexOf("=+=") + 4);
                    pilot.Date_courier = Convert.ToDateTime(line.Substring(line.IndexOf("=+=") + 4));
                    flag--;
                    return pilot;
                }
            }
            return null;
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Hide();
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
