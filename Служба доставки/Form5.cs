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
using Служба_доставки.Properties;
using Служба_доставки;


namespace Служба_доставки
{
    public partial class Form5 : Form
    {
        private Zacas zacas;
        private List<Zacas> zacasCollection;
        private int index;

        public Form5(Zacas zacas, List<Zacas> zacasCollection, int index, string firstName, string lastName, string middleName)
        {
            InitializeComponent();
            this.zacas = zacas;
            this.zacasCollection = zacasCollection;
            this.index = index;
            // Другие операции с элементами формы Form5
        }

        public void SetData(Zacas zacas, List<Zacas> zacasCollection, int index)
        {
            // Используйте информацию "zacas" и "zacasCollection" на форме "Form5"
        }


        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            Form2 form2 = new Form2();
            form2.Show();


        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label5.Text = zacasCollection[index].Время_брибытия_Курьера.ToString();
            label6.Text = zacasCollection[index].courierL.Surname;
            label7.Text = zacasCollection[index].courierL.Patronymic;
            label8.Text = zacasCollection[index].courierL.Name;



        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
