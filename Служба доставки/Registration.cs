using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Служба_доставки
{
    public partial class Registration : Form
    {
        public int flag;
        public Registration( /*Показвает есть ли файл или нет, если файл есть то 0 если нет то 1*/)
        {
            InitializeComponent();
        }
        public static string hash_function(string input)/*Хеш функция*/
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lines = textBox2.Text + "," + textBox3.Text;
            string str_file = hash_function(lines) + "," + comboBox1.Text;//преобразование в хеш
            string filePath = "Log.txt";
            if (File.Exists(filePath)){
                var user = File.ReadLines(filePath).ToList();
                user.Add(str_file);
                File.WriteAllLines(filePath, user);
            }
            else
            {
                File.WriteAllText(filePath, str_file);
            }
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                comboBox1.Text = "Администратор";
                comboBox1.Enabled = false;
            }
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
