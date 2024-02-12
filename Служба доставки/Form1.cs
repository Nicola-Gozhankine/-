using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.LinkLabel;

namespace Служба_доставки
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "Log.txt";
            string[] lines = File.ReadAllLines(filePath);

            string введенныйЛогин = textBoxLogin.Text;
            string введенныйПароль = textBoxPassword.Text;
            string выбраннаяРоль = comboBoxRole.SelectedItem.ToString();

            foreach (string line in lines)
            {
                string[] данные = line.Split(','); // Предполагается, что данные в файле разделены запятой

                string логин = данные[0];
                string пароль = данные[1];
                string роль = данные[2];

                if (введенныйЛогин == логин && введенныйПароль == пароль && выбраннаяРоль == роль)
                {
                    // Выполнение кода, если сочетание логина, пароля и роли соответствует данным из файла
                    if (роль == "менеджер")
                    {
                        // Обработка, если роль соответствует "менеджеру"
                        MessageBox.Show("Вы вошли как " +  роль );
                    }
                    else if (роль == "повар")
                    {
                        // Обработка, если роль соответствует "повару"
                        MessageBox.Show("Вы вошли как " + роль);
                    }
                    else if (роль == "упаковщик")
                    {
                        // Обработка, если роль соответствует "упаковщику"
                        MessageBox.Show("Вы вошли как " + роль);
                    }
                   
                }
              //  else MessageBox.Show("Not");
            }
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Здесь вы устанавливаете автоматический выбор роли "менеджер" в комбо боксе
            comboBoxRole.SelectedItem = "менеджер";

            // Устанавливаете логин и пароль для менеджера
            textBoxLogin.Text = "user1";
            textBoxPassword.Text = "password1";


        }
    }
}
