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
using System.Text.RegularExpressions;
using VS;
using System.Security.Cryptography.X509Certificates;



namespace Служба_доставки
{
    
    public partial class Form2 : Form
    {
        VS.Zacas zacas = new VS.Zacas();

      public  List<Zacas> zacasCollection = new List<Zacas>();
        public int  NynZS;
        public List<UserControl1> panel = new List<UserControl1>();

        // Добавляем элементы в коллекцию
        //zacasCollection.Add(new VS.Zacas()); // Пример добавления второго элемента

        string filePath = "Zacasi.txt"; // замените на реальный путь к вашему файлу
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        public void Form2_Load(object sender, EventArgs e)
        {

            //   string filePath = "Zacasi.txt"; // замените на реальный путь к вашему файлу

            string inputText = File.ReadAllText(filePath);
            textBox1.Text = inputText;
            int a = 0;
            int b = 0;
            int c = 0;
            string q;
            string w;
            for (int i = 0; i < textBox1.Lines.Length; i++)
            {               

                if (textBox1.Lines[i].StartsWith("******************************************************************"))
                {
                    
                    string[] parts = textBox1.Lines[i + 1].Split(new string[] { "=+=" }, StringSplitOptions.None);
                    string orderNumber = parts[1].Trim(); // Второая часть 
                                                          // MessageBox.Show(orderNumber);
                    VS.Zacas zacas = new VS.Zacas();
                    zacas.Number = Convert.ToInt32(orderNumber);

                    zacasCollection.Add(zacas); // Пример добавления одного элемента
                                  

                }
                if (textBox1.Lines[i].StartsWith("=_+_="))
                {
                    //q = textBox1.Lines[i + 1];
                    //MessageBox.Show(q + "b"+"       "+i);
                    //q = textBox1.Lines[i + 3];
                    //MessageBox.Show(q + "S" + "       " + "       " + (i + 3));


                    b++;

                }
                if (textBox1.Lines[i].StartsWith("Статус =+="))
                {
                    //q = textBox1.Lines[i];
                    //MessageBox.Show(q + "C" + "       " + i);
                    c++;

                }
            }                  
                   
                for (  NynZS=0  ; NynZS < zacasCollection.Count ; NynZS++)
                {

              //  MessageBox.Show(NynZS.ToString() + "   NynZ");
                  
                UserControl1 users = new UserControl1(zacasCollection[NynZS], zacasCollection, NynZS);
                users.Location = new Point(users.Location.X, NynZS * users.Size.Height);
                    panel.Add(users);
                    panel1.Controls.Add(panel[NynZS]);

                }
           

        }
            private void Form2_FormClosed(object sender, FormClosedEventArgs e)
            {
                Application.Exit();
            }

        private void button2_Click(object sender, EventArgs e)
        {
            string inputText = File.ReadAllText(filePath);
            textBox1.Text = inputText;
            int a = 0;
            int b = 0;
            int c = 0;
            string q;
            string w;
            for (int i = 0; i < textBox1.Lines.Length  ; i++)
            {

           // q = textBox1.Lines[i];
             // MessageBox.Show(q);
      
                if (textBox1.Lines[i].StartsWith("******************************************************************"))
                {
                    //q = textBox1.Lines[i+1];
                    //MessageBox.Show(q + "a");
                    string[] parts = textBox1.Lines[i+1].Split(new string[] { "=+=" }, StringSplitOptions.None);
                    string orderNumber = parts[1].Trim(); // Второая часть 
                                                          // MessageBox.Show(orderNumber);
                    VS.Zacas zacas = new VS.Zacas();
                    zacas.Number = Convert.ToInt32(orderNumber);
                 

                    zacasCollection.Add(zacas); // Пример добавления одного элемента
                    w= zacas.Number.ToString();
          

                    a++;
                    

            }
                if (textBox1.Lines[i].StartsWith("=_+_=")) 
                {
                    //q = textBox1.Lines[i + 1];
                    //MessageBox.Show(q + "b"+"       "+i);
                    //q = textBox1.Lines[i + 3];
                    //MessageBox.Show(q + "S" + "       " + "       " + (i + 3));
                    

                    b++;
                      
                }
                if (textBox1.Lines[i].StartsWith("Статус =+=")) 
                {

                    //q = textBox1.Lines[i];
                    //MessageBox.Show(q + "C" + "       " + i);

                    c++;

                }
            }
            MessageBox.Show(a + "       " + b + "     " + c); 
       //  if (textBox1.Lines[] .in0 ) { }
               


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    
