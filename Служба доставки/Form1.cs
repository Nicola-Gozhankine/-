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
using System.Security.Cryptography;
using System.Data.SqlTypes;
using VS;

namespace Служба_доставки
{
    public partial class Form1 : Form
    {
        static public Роль роль_клон = new Роль();
        public Form1()
        {
            InitializeComponent();
        }

        public static string hash_function(string input)
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
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxLogin.Select();
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
            string роль = "";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Нужно создать учетную запись администратора");
                Registration form = new Registration();
                form.flag = 1;
                this.Hide();
                form.Show();
            }
            else
            {
                string введенныйЛогин = textBoxLogin.Text;
                string введенныйПароль = textBoxPassword.Text;
                string user = введенныйЛогин + "," + введенныйПароль;
                user = hash_function(user);
                string[] readText = File.ReadAllLines(filePath);
                foreach (string s in readText)
                {
                    if (s.Contains(user))
                    {
                        роль = s.Split(',')[1];
                    }
                }
            }
            if (роль == "Администратор")
            {
                роль_клон.Администратор = true;
                Registration form = new Registration();
                form.flag = 0;
                this.Hide();
                form.Show();
            }
            else if (роль == "Менеджер")
            {
                роль_клон.Менеджер = true;
                Form2 form = new Form2();
                this.Hide();
                form.Show();
            }
            else if (роль == "Повар")
            {
                роль_клон.Повар = true;
                Form2 form = new Form2();
                this.Hide();
                form.Show();
            }
            else if (роль == "Упаковщик")
            {
                роль_клон.Упаковшик = true;
                Form2 form = new Form2();
                this.Hide();
                form.Show();
            }
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPassword.Select();
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            роль_клон.Менеджер = true;
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }
    }
}
