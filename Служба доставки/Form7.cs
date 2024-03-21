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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;


namespace Служба_доставки
{
    public partial class Form7 : Form
    {
        VS.Роль роль = new Роль();
        VS.Блюда Блюда= new Блюда();
        private Zacas zacas;
        private List<Zacas> zacasCollection;
        private int index;
        public  List<Блюда> CollectionБлюдаZacas = new List<Блюда>();
        string filePath = "Zacasi.txt"; // замените на реальный путь к вашему файлу
        string spzac;
        int raz =0;

        public Form7(Zacas zacas, List<Zacas> zacasCollection)
        {
            InitializeComponent();
            this.zacas = zacas;
            

            this.zacasCollection = zacasCollection;

        }

        public Form7(Zacas zacas, List<Zacas> zacasCollection, int index)
        {
            InitializeComponent();
            this.zacas = zacas;
            this.index = index;

            this.zacasCollection = zacasCollection;

        }
        public Form7(Zacas zacas, List<Zacas> zacasCollection ,  Роль роль )
        {

            InitializeComponent();
            this.zacas = zacas;
            this.index = index;
            this.роль = роль;    

            this.zacasCollection = zacasCollection;

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            CollectionБлюдаZacas.Clear();
            CollectionБлюдаZacas = Блюда.CV();
            comboBox1.DataSource = CollectionБлюдаZacas;
            comboBox1.DisplayMember = "Название";
            //   comboBox1.ValueMember = "НомерБлюда";
            if (Form1.роль_клон.Менеджер)
            { 
                button1.Visible = true;
                button3.Visible = true;
            }

            

        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Блюда выбранноеБлюдо = (Блюда)comboBox1.SelectedItem;
            textBox2.Text = string.Join(", ", выбранноеБлюдо.Ингредиенты);


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем выбранное блюдо из первого комбобокса
            Блюда выбранноеБлюдо = (Блюда)comboBox1.SelectedItem;

            // Получаем количество из второго комбобокса
            int количество = Convert.ToInt32(comboBox2.SelectedItem);
            if (количество == 0)
            {
                MessageBox.Show("Нулевое количество ");
            }
            else 
            {

                // Формируем строку для добавления в листбокс
                string информация = $"{выбранноеБлюдо.Название} - Количество: {количество}";

                // Добавляем информацию в листбокс

                listBox1.Items.Add(информация);
                spzac=spzac+ выбранноеБлюдо.Название + "  " + "к:"+количество+" "+"."; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                // List Box пуст
                MessageBox.Show("Нулевое количество ");
            }
            else
            {
                if ( raz>=1)
                {
                    raz++;
                    MessageBox.Show("Заказ сформирован нажимая на этот раз ничего не прозойтет Это уже  "+raz + " нажатие"  );
                }
                if (raz==0)
                { 
                    raz = 1;

                    zacas.заказчик.полный_список_заказа = spzac;
                    // Генерация динамических данных
                    Random rnd = new Random();
                    int orderNumber = zacas.Number;

                    DateTime acceptTime = DateTime.Now; // Текущее время как время принятия заказа
                    string editor = "Менеджер";
                    string status = "получен";
                    string client = zacas.заказчик.полное_имя;
                    string dishes = zacas.заказчик.полный_список_заказа;
                    string courier = zacas.courierL.Имя_целиком;
                    DateTime courierArrivalTime = zacas.courierL.Время_брибытия; // Время прибытия курьера через 1.5 часа
                    string videoAddress = "// Тут ничего нет но в конце будет";

                    // Формирование текста заказа с динамическими данными
                    string orderText = $@"******************************************************************
Заказ под номером =+= {orderNumber}
Был принят =+= {acceptTime:HH:mm:ss} 
Редактор =+= {editor}
Статус =+= {status}
От следющего клиента =+= {client}
В заказе указан следующий список блюд =+= {dishes}
Курьер=+={courier}
Время прибытия курьера  =+= {courierArrivalTime:HH:mm:ss}
Адрес для загрузки видео =+= {videoAddress}
____________________________________________________________________________
";


                    File.AppendAllText(filePath, Environment.NewLine + orderText);

                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
