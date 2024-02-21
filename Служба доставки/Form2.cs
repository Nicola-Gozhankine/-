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
        VS.courier courier = new VS.courier();

     public   string lastName;
       public  string firstName;
        public string middleName;
        public  List<Zacas> zacasCollection = new List<Zacas>();
        public int  NynZS;
        public List<UserControl1> panel = new List<UserControl1>();

        // Добавляем элементы в коллекцию
        //zacasCollection.Add(new VS.Zacas()); // Пример добавления второго элемента

        public string filePath = "Zacasi.txt"; // замените на реальный путь к вашему файлу
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

                    string[] vpq0 = textBox1.Lines[i + 8].Split(new string[] { "=+=" }, StringSplitOptions.None); //первая часть 
                    string vpk1 = vpq0[1].Trim(); // Второая часть 
                                                  //  MessageBox.Show(vpk1);// проверка работы 
                    string[] fullStr = textBox1.Lines[i + 7].Split(new string[] { "=+=" }, StringSplitOptions.None);//первая часть
                    string fullNameCur0 = fullStr[1]; // "Иванов Иван Иванович"

                    string[] fullNameCur = fullNameCur0.Split(' '); // Разделение полного имени на части
                     lastName = fullNameCur[0]; // "Иванов"
                     firstName = fullNameCur [1]; // "Иван"
                     middleName = fullNameCur[2]; // "Иванович"

                    string[] fullNameZacashic = textBox1.Lines[i + 5].Split(new string[] { "=+=" }, StringSplitOptions.None);//первая часть
                    string fullZAc = fullNameZacashic[1]; //

                    string[] Zacname = fullZAc.Split(' '); // Разделение полного имени на части
                    lastName = Zacname[0]; // "Иванов"
                    firstName = Zacname[1]; // "Иван"
                    middleName = Zacname[2]; // "Иванович"
                    VS.Zacas zacas = new VS.Zacas();
                    //      zacas.ZacasNS();
                    zacas.заказчик = new Заказчик();
                    zacas.courierL = new courier();
                    zacas.Number = Convert.ToInt32(orderNumber);
                    
                    zacas.заказчик.полное_имя=fullZAc;// потом допиать остальные поля логика как у курьера 


                    {
                        //zacas.ZacasNS();
                        zacas.courierL.Имя_целиком = fullNameCur0;
                        zacas.courierL.Name = firstName;
                        zacas.courierL.Patronymic = lastName;
                        zacas.courierL.Surname = middleName;
                    }

                    {
                        DateTime arrivalTime;
                        if (DateTime.TryParse(vpk1, out arrivalTime))
                        {
                            zacas.Время_брибытия_Курьера = arrivalTime;
                        }
                        if (DateTime.TryParse(vpk1, out arrivalTime))
                        {
                            courier.Время_брибытия = arrivalTime;
                        }
                    }

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
                  
                UserControl1 users = new UserControl1(zacasCollection[NynZS], zacasCollection, NynZS ,firstName, lastName , middleName  );
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
    
