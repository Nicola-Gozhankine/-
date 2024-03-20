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
            //MessageBox.Show(zacasCollection[index].заказчик.полный_список_заказа);
            //MessageBox.Show(zacas.заказчик.полный_список_заказа);
            string[] arr = zacasCollection[index].заказчик.полный_список_заказа.Split('.');
            for(int i = 0; i < arr.Length; i++)
            {
                // Делаем второе деление по разделителю 'к:'
                string[] parts = arr[i].Split(new string[] { "к:" }, StringSplitOptions.None);

                if (parts.Length == 2) // Проверяем, что получилась пара частей после второго деления
                {
                    string firstPart = parts[0].Trim(); // Первая часть строки
                    int quantity; // Переменная для хранения количества

                    if (int.TryParse(parts[1].Trim(), out quantity)) // Пытаемся конвертировать вторую часть в число
                    {
                        // Формируем новую строку в форме "первая часть [количество]"
                        string newString = $"{firstPart} || в  количестве [{quantity}]||";
                        listBox1.Items.Add(newString); // Добавляем сформированную строку в listBox1
                    }
                    else
                    {
                        // Обработка ситуации, когда вторая часть не является числом
                        // Можно добавить сообщение об ошибке или другую логику
                    }
                }
                else
                {
                    // Обработка ситуации, когда деление по 'к:' не дает две части
                    // Можно добавить сообщение об ошибке или другую логику
                }
            }
            if (zacasCollection[index].Number == zacasCollection[index].Status_order.num)
            {
                label8.Text = zacasCollection[index].Status_order.tecstat;

            }
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
