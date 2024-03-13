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
            CollectionБлюдаZacas.Clear();
            CollectionБлюдаZacas = Блюда.CV();
            comboBox1.DataSource = CollectionБлюдаZacas;
            comboBox1.DisplayMember = "Название";
         //   comboBox1.ValueMember = "НомерБлюда";


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
            }
        }
    }
}
