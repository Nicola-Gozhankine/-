using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VS;
using System.Security.Cryptography.X509Certificates;

namespace Служба_доставки
{
    public partial class Form6 : Form
    {
        private Zacas zacas;
        private List<Zacas> zacasCollection;
         private int index;
        int index1;
        public Form6(Zacas zacas, List<Zacas> zacasCollection, int index)
        {
            InitializeComponent();
            this.zacas = zacas;
            this.index = index;
            this.zacasCollection = zacasCollection;
        }
        public void SetData(Zacas zacas, List<Zacas> zacasCollection, int index)
        {
            // Используйте информацию "zacas" и "zacasCollection" на форме "Form5"
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            label1.Text = zacasCollection[index].заказчик.полное_имя;
            label4.Text = zacasCollection[index].courierL.Имя_целиком;
        }
        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {

            Form2 form2 = new Form2();
            form2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6.ActiveForm.Hide();
            Form7 form6 = new Form7(zacas, zacasCollection, index1);


            form6.Show();
        }
    }
}
