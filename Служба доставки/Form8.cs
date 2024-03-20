using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VS;
using System.IO;


namespace Служба_доставки
{
    public partial class Form8 : Form
    {
        public string filePath = "Zacasi.txt"; // замените на реальный путь к вашему файлу
        string stat=" ";
        private Zacas zacas;
        private List<Zacas> zacasCollection;
        private int index;
        int index_status;
        private Роль роль;



public class DoubleClickButton : Button
    {
        public DoubleClickButton()
        {
            this.DoubleClick += DoubleClickButton_DoubleClick;
        }

        private void DoubleClickButton_DoubleClick(object sender, EventArgs e)
        {
           
        }
    }


    public Form8(Zacas zacas, List<Zacas> zacasCollection, int index , Роль роль  )
        {
            InitializeComponent();
            this.zacas = zacas;
            this.index = index;
            this.роль = роль;
            this.zacasCollection = zacasCollection;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            if (роль.Менеджер == true)
            {
                label4.Text = "Менеджер";
                comboBox1.Items.Add("передан на кухню");
                comboBox1.Items.Add("принят на кухне");
                comboBox1.Items.Add("готовиться");
                comboBox1.Items.Add("передан на упаковку");
                comboBox1.Items.Add("упаковывается");
                comboBox1.Items.Add("упакован");
                comboBox1.Items.Add("готовиться к выдаче");
                comboBox1.Items.Add("отдан курьеру");
            } else if (роль.Повар == true) {
                label4.Text = "Повар";
                comboBox1.Items.Add("принят на кухне");
                comboBox1.Items.Add("готовиться");
                comboBox1.Items.Add("передан на упаковку");
            } else if (роль.Упаковшик == true) {
                label4.Text = "Упаковщик";
                comboBox1.Items.Add("упаковывается");
                comboBox1.Items.Add("упакован");
            }

            if (роль.Менеджер==true )
            {
                if (zacasCollection[index].Number == zacasCollection[index].Status_order.num)
                {
                    label6.Text = zacasCollection[index].Number.ToString();

                }

            }

            if (zacasCollection[index].Number == zacasCollection[index].Status_order.num)
            {
                label2.Text = zacasCollection[index].Status_order.tecstat;
                for(int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (label2.Text == comboBox1.Items[i].ToString())
                    {
                        index = i;
                    }
                }
            }


        }
        // Метод для вызова логики обработчика button14_Click
        public void PerformButton14ClickLogic()
        {
            button14_Click(null, null);
        }
        private void Button_DoubleClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        

        private void button14_Click(object sender, EventArgs e)
        {

            string VEr;
            Console.WriteLine(zacas.Status_order.tecstat);

            VEr = "Менеджер";
            if (роль.Менеджер == true)
            {
                VEr = "Менеджер";
            }
            if (роль.Упаковшик == true)
            {
                VEr = "Упаковшик";
            }
            if (роль.Повар == true)
            {
                VEr = "Повар";
            }
            if (роль.Администратор == true)
            {
                VEr = "Администратор";
            }
            int orderNumber = zacas.Number; // Номер заказа
            string editor = VEr ; // Редактор

            string status = stat;
          

            string orderText = $"=_+_={ Environment.NewLine }"
            + $"Заказ под номером =+= {orderNumber}" +
                $"{Environment.NewLine}Редактор =+= {editor}{Environment.NewLine}Статус =+= {status}" +
                $"{Environment.NewLine}Время =+= {DateTime.Now.ToString("yyyy-MM-dd <> HH:mm:ss")}{Environment.NewLine}=+===";

            Console.WriteLine(orderText);

            File.AppendAllText(filePath, Environment.NewLine + orderText);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            stat = "завершённый(А)";
            label8.Text = stat;
        }


        private void button13_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10(zacas, zacasCollection, роль);
            form10.Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Отдан курьеру")
            {
                stat = "завершённый(А)";
            }
            else
            {
                if (comboBox1.SelectedIndex > index)
                {
                    stat = comboBox1.Text;
                }
                else
                {
                    MessageBox.Show("Статус заказа не может иметь ранее имеющийся статус   " + index );
                    comboBox1.Text = "";
                }
            }
            label8.Text = stat;
        }
    }
}
