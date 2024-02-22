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
    public partial class Form9 : Form
    {
        private Zacas zacas;
        private List<Zacas> zacasCollection;
        
        public Form9(Zacas zacas, List<Zacas> zacasCollection)
        {
            InitializeComponent();
            this.zacas = zacas;
            this.zacasCollection = zacasCollection;

        }

        private void Form9_Load(object sender, EventArgs e)
        {

            int n;
            int lastNumber = zacasCollection[zacasCollection.Count - 1].Number;
            n = lastNumber+1;
            label2.Text=n.ToString();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            label3.Text=DateTime.Now.ToString();



        }

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string fullNameCur0 = comboBox2.Text; // "Иванов Иван Иванович"

            //MessageBox.Show(fullNameCur0);// проверка работы 
            string[] fullNameCur = fullNameCur0.Split(' '); // Разделение полного имени на части
           string lastName = fullNameCur[0]; // "Иванов"
           string  firstName = fullNameCur[1]; // "Иван"
          string  middleName = fullNameCur[2]; // "Иванович"
            textBox4.Text = lastName;
            textBox5.Text = firstName;
            textBox6.Text = middleName;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fullNameCur0 = comboBox1.Text; // "Иванов Иван Иванович"

            //MessageBox.Show(fullNameCur0);// проверка работы 
            string[] fullNameCur = fullNameCur0.Split(' '); // Разделение полного имени на части
            string lastName = fullNameCur[0]; // "Иванов"
            string firstName = fullNameCur[1]; // "Иван"
            string middleName = fullNameCur[2]; // "Иванович"
            textBox1.Text = lastName;
            textBox2.Text = firstName;
            textBox3.Text = middleName;
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
    }
}
