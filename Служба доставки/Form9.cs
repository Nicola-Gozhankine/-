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
       
        private List<Zacas> zacasCollection;
        int index1;
       private  VS.Zacas zacas1 = new VS.Zacas();
        private Zacas zacas;

        public Form9(Zacas zacas, List<Zacas> zacasCollection)
        {
            InitializeComponent();
           
            this.zacasCollection = zacasCollection;
            this.zacas = zacas;

        }

        private void Form9_Load(object sender, EventArgs e)
        {

            int n;
            int lastNumber;
            if (zacasCollection != null && zacasCollection.Count > 0)
            {
                lastNumber = zacasCollection[zacasCollection.Count - 1].Number;
               // lastNumber = zacasCollection[zacasCollection.Count ].Number;
                n = lastNumber + 1;
                label2.Text = n.ToString();
                dateTimePicker1.Format = DateTimePickerFormat.Time;
                dateTimePicker1.ShowUpDown = true;
                label3.Text = DateTime.Now.ToString();
                zacas.заказчик = new Заказчик(); // Создание и инициализация объекта заказчика
                zacas.courierL = new courier();
                zacas.Number = n ;

            }

            else
            {
                n = 0 + 1;
                label2.Text = n.ToString();
                dateTimePicker1.Format = DateTimePickerFormat.Time;
                dateTimePicker1.ShowUpDown = true;
                label3.Text = DateTime.Now.ToString();
                zacas.заказчик = new Заказчик(); // Создание и инициализация объекта заказчика
                zacas.courierL = new courier();
                zacas.Number = n;
            }

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
            zacas.courierL.Patronymic= textBox6.Text;
            zacas.courierL .Name = textBox5.Text;
            zacas.courierL.Surname = textBox4.Text;
            zacas.courierL.Имя_целиком = fullNameCur0;


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

            zacas.заказчик.фамилия=textBox1.Text;
            zacas.заказчик.имя=textBox2.Text;
            zacas.заказчик.отчество=textBox3.Text;
            zacas.заказчик.полное_имя = fullNameCur0;
                
                
                }

        private void button1_Click(object sender, EventArgs e)
        {
            VS.Роль роль = new Роль();
            роль.Менеджер = true;

            Form7 form7 = new Form7(zacas, zacasCollection ,роль );

            form7.Show();



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            zacas.courierL.Время_брибытия = dateTimePicker1.Value; 
        }
    }
}
