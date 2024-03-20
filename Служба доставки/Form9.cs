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
using System.IO; 

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
                n = lastNumber + 1;
                label2.Text = n.ToString();
                dateTimePicker1.Format = DateTimePickerFormat.Time;
                dateTimePicker1.ShowUpDown = true;
                label3.Text = DateTime.Now.ToString();
                zacas.заказчик = new Заказчик(); // Создание и инициализация объекта заказчика
                zacas.courierL = new courier();
                zacas.Number = n ;

            } else {
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

            string fullNameCustomer = zacas.заказчик.полное_имя;
            string fullNameCourier = zacas.courierL.Имя_целиком;

            if (!string.IsNullOrEmpty(fullNameCustomer) && !string.IsNullOrEmpty(fullNameCourier))
            {
                // Оба поля заполнены - разрешить определенное действие
                // Например, продолжить выполнение операции или отобразить сообщение об успешном заполнении
                VS.Роль роль = new Роль();
                роль.Менеджер = true;

                Form7 form7 = new Form7(zacas, zacasCollection, роль);

                form7.Show();

            }
            else if (string.IsNullOrEmpty(fullNameCustomer))
            {
                // Поле заказчика не заполнено
                MessageBox.Show("Пожалуйста, заполните информацию о заказчике.");
            }
            else
            {
                // Поле курьера не заполнено
                MessageBox.Show("Пожалуйста, заполните информацию о курьере.");
            }

            



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            zacas.courierL.Время_брибытия = dateTimePicker1.Value; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

            // Проверка корректности ввода, например, можно проверить, что все поля заполнены
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                // Сбор данных из текстовых полей
                string fullNameCur0 = $"{textBox1.Text} {textBox2.Text} {textBox3.Text}";
                // Добавление данных в коллекцию комбобокса
                comboBox1.Items.Add(fullNameCur0);
                // Сохранение элементов в файл
                string[] items = new string[comboBox1.Items.Count];
                comboBox1.Items.CopyTo(items, 0);
                File.WriteAllLines("combobox_items.txt", items);
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Проверка корректности ввода, например, можно проверить, что все поля заполнены
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                // Сбор данных из текстовых полей
                string fullNameCur0 = $"{textBox4.Text} {textBox5.Text} {textBox6.Text}";
                // Добавление данных в коллекцию комбобокса
                comboBox2.Items.Add(fullNameCur0);
                // Сохранение элементов в файл
                string[] items = new string[comboBox2.Items.Count];
                comboBox2.Items.CopyTo(items, 0);
                File.WriteAllLines("combobox_items1.txt", items);

            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
        //    string[] items = new string[comboBox1.Items.Count];
        //    comboBox2.Items.CopyTo(items, 0);
        //    File.WriteAllLines("combobox_items.txt", items);
        //    string[] items1 = new string[comboBox2.Items.Count];
        //    comboBox2.Items.CopyTo(items1, 0);
        //    File.WriteAllLines("combobox_items1.txt", items1);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
