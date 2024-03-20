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
        VS.Блюда Блюда = new VS.Блюда();
        VS.Zacas zacas = new VS.Zacas();
        VS.courier courier = new VS.courier();

        public string lastName;
        public string firstName;
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
            if (Form1.роль_клон.Менеджер) this.Text = "Менеджер";
            else if (Form1.роль_клон.Повар) this.Text = "Повар";
            else if (Form1.роль_клон.Упаковшик) this.Text = "Упаковщик";

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, " ");
            }
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

                    string[] vpq0 = textBox1.Lines[i + 8].Split(new string[] { "=+=" }, StringSplitOptions.None); //первая часть 
                    string vpk1 = vpq0[1].Trim();
                     // Второая часть 
                                                   //  MessageBox.Show(vpk1);// проверка работы 
                    string[] fullStr = textBox1.Lines[i + 7].Split(new string[] { "=+=" }, StringSplitOptions.None);//первая часть
                    string fullNameCur0 = fullStr[1]; // "Иванов Иван Иванович"

                    string[] fullNameCur = fullNameCur0.Split(' '); // Разделение полного имени на части
                    lastName = fullNameCur[0]; // "Иванов"
                    firstName = fullNameCur[1]; // "Иван"
                    middleName = fullNameCur[2]; // "Иванович"

                    string[] fullNameZacashic = textBox1.Lines[i + 5].Split(new string[] { "=+=" }, StringSplitOptions.None);//первая часть
                    string fullZAc = fullNameZacashic[1]; //

                    string[] Zacname = fullZAc.Split(' '); // Разделение полного имени на части
                    string lastNameZ = Zacname[0]; // "Иванов"
                    string firstNameZ = Zacname[1]; // "Иван"
                    string middleNamez = Zacname[2]; // "Иванович"

                    string[] fullStrocaZACasaB = textBox1.Lines[i + 6].Split(new string[] { "=+=" }, StringSplitOptions.None); // Разделение строки на части
                    string fullZACBluda = fullStrocaZACasaB[1]; // Получаем вторую часть строки (список блюд)
                    List<string> nim = new List<string>();
                    List<int> col = new List<int>();
                    string[] Blyda = fullZACBluda.Split('.'); // Разделение полного имени на части
                    foreach (string blydoWithCount in Blyda)
                    {
                        string[] partsArray = blydoWithCount.Split(new string[] { "к:" }, StringSplitOptions.RemoveEmptyEntries); 
                        string название = parts[0].Trim(); // Получаем название блюда, удаляем лишние пробелы
                        int количество = 0; // Переменная для хранения количества блюд по умолчанию
                        if (parts.Length > 1) // Проверка на наличие количества
                        {
                            int.TryParse(parts[1].Trim(), out количество); // Пытаемся преобразовать количество в int
                        }

                        // Делаем что-то с названием и количеством блюда, например, записываем в список или выполняем другие операции
                        nim.Add(название);
                        col.Add(количество);

                    }
                    VS.Zacas zacas = new VS.Zacas();
                    zacas.заказчик = new Заказчик();
                    zacas.courierL = new courier();
                    zacas.Status_order = new Status();
                    zacas.CollectionБлюдаZ = Блюда.CV();
                    zacas.Number = Convert.ToInt32(orderNumber);
                    zacas.заказчик.полное_имя = fullZAc;// потом допиать остальные поля логика как у курьера 
                    zacas.заказчик.полный_список_заказа=fullZACBluda;

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


                    for  ( int f = 0; f < nim.Count; f++)
                    {

                        for (int j = 0; j < 22; j++) {
                            if (zacas.CollectionБлюдаZ[j].Название == nim[f]) {
                                zacas.CollectionБлюдаZ[j].Количество_заказе = col[f];
                                break;
                            }

                       }
                    }
                    zacasCollection.Add(zacas); // Пример добавления одного элемента  //////////////////////////////////////////////////////////////////////////////////          

                }
                if (textBox1.Lines[i].StartsWith("=_+_="))
                {
                    string[] parts = textBox1.Lines[i + 1].Split(new string[] { "=+=" }, StringSplitOptions.None);
                    string orderNumber = parts[1].Trim(); // Второая часть 
                    int g= Convert.ToInt32(orderNumber);
                    string[] strocastatusa  = textBox1.Lines[i + 3].Split(new string[] { "=+=" }, StringSplitOptions.None); //первая часть 
                    string status = strocastatusa[1].Trim();
                    string[] vps0 = textBox1.Lines[i + 4].Split(new string[] { "=+=" }, StringSplitOptions.None); //первая часть 
                    string vps1 = vps0[1].Trim();
                    for (int j = 0; j < zacasCollection.Count; j++)
                    {
                        if (zacasCollection[j].Number == g)
                        {
                            zacasCollection[j].Status_order.tecstat = status;
                            zacasCollection[j].Status_order.num = g;
                            {
                                DateTime arrivalTime;
                                if (DateTime.TryParse(vps1, out arrivalTime))
                                {
                                    zacasCollection[j].Status_order.vremz_ystanovki = arrivalTime;
                                }
                                if (DateTime.TryParse(vps1, out arrivalTime))
                                {
                                    zacasCollection[j].Status_order.vremz_ystanovki = arrivalTime;
                                }
                            }
                            

                        }
                    }
                    b++;

                }
                if (textBox1.Lines[i].StartsWith("Статус =+=")) { c++;  }
            }      
            for (NynZS=0; NynZS < zacasCollection.Count; NynZS++) {
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
                if (textBox1.Lines[i].StartsWith("******************************************************************"))
                {
                    string[] parts = textBox1.Lines[i+1].Split(new string[] { "=+=" }, StringSplitOptions.None);
                    string orderNumber = parts[1].Trim(); // Второая часть 
                    VS.Zacas zacas = new VS.Zacas();
                    zacas.Number = Convert.ToInt32(orderNumber);
                    zacasCollection.Add(zacas); // Пример добавления одного элемента
                    w= zacas.Number.ToString();
                    a++;
                }
                if (textBox1.Lines[i].StartsWith("=_+_=")) 
                {
                    b++;   
                }
                if (textBox1.Lines[i].StartsWith("Статус =+=")) 
                {
                    c++;
                }
            }
            MessageBox.Show(a + "       " + b + "     " + c); 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Hide();
            Form9 form9 = new Form9(zacas, zacasCollection );
            form9.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            // Генерация текста с текущей датой и временем
            string generatedText = $@"------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Начало дня 
{DateTime.Now.ToString("yyyy-MM-dd <> HH:mm:ss")}
Обработаны следующие строки <> 0 
// В начале тут 0  строк кода пишется конец для программы. Анализируется число строк, которые написаны за день, и пишется их число. Таким образом, на следующий день программа будет сразу перематываться к актуальной точке, не анализируя уже выполненные строки. // 
-----------------------------------------------------------------------------
";

            // Путь к текстовому файлу
           
            // Добавление сгенерированного текста в конец файла
            File.AppendAllText(filePath, Environment.NewLine + generatedText);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Генерация текста с текущей датой и временем для конца дня
            string endOfDayText = $@"-------------------------------------------------------------------------------- 
=+=  Конец дня =+= 
================================================================================
{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

            // Путь к текстовому файлу
           
            // Добавление сгенерированного текста в конец файла
            File.AppendAllText(filePath, Environment.NewLine + endOfDayText);
        }
    }
}
    
