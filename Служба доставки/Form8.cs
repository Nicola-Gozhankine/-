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
        int index1;
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
            this.роль =роль;
            this.zacasCollection = zacasCollection;
        }

        private void Form8_Load(object sender, EventArgs e)
        {

            if (роль.Менеджер==true )
            {

                label4.Text = "Менеджер ";
                button6.BackColor= Color.DarkSlateGray;
                button3.BackColor = Color.DarkSlateGray;
                button4.BackColor = Color.DarkSlateGray;
                button8.BackColor = Color.DarkSlateGray;
                button7.BackColor= Color.Yellow;
                button9.BackColor = Color.Yellow;
                button1.Visible = false;
                if (zacasCollection[index].Number == zacasCollection[index].Status_order.num)
                {
                    label6.Text = zacasCollection[index].Number.ToString();

                }

            }

            if (zacasCollection[index].Number == zacasCollection[index].Status_order.num)
            {
                label2.Text = zacasCollection[index].Status_order.tecstat;

            }

            button7.DoubleClick += Button_DoubleClick;
            button6.DoubleClick += Button_DoubleClick;
            button12.DoubleClick += Button_DoubleClick;
            button2.DoubleClick += Button_DoubleClick;
            button14.DoubleClick += Button_DoubleClick;
            button3.DoubleClick += Button_DoubleClick;
            button4.DoubleClick += Button_DoubleClick;
            button8.DoubleClick += Button_DoubleClick;
            button9.DoubleClick += Button_DoubleClick;
            button10.DoubleClick += Button_DoubleClick;
            button11.DoubleClick += Button_DoubleClick;
            button5.DoubleClick += Button_DoubleClick;
            button1.DoubleClick += Button_DoubleClick;

        }
        // Метод для вызова логики обработчика button14_Click
        public void PerformButton14ClickLogic()
        {
            button14_Click(null, null);
        }
        private void Button_DoubleClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

           
                if (clickedButton == button7 || clickedButton == button6 || clickedButton == button2 ||
                    clickedButton == button8 || clickedButton == button9 || clickedButton == button10 ||
                    clickedButton == button11)
                {
                    stat = clickedButton.Text;
                    label8.Text = stat;
                    PerformButton14ClickLogic();
                }
                else if (clickedButton == button12 || clickedButton == button1 || clickedButton == button5)
                {
                    stat = "завершённый(А)";
                    label8.Text = stat;
                    PerformButton14ClickLogic();
                }
                // Добавьте другие условия для других кнопок, если необходимо
            
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            stat = button7.Text;
            label8.Text = stat;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            stat = button6.Text;
            label8.Text = stat;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            stat = "завершённый";
            label8.Text = stat;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stat = button2.Text;
            label8.Text=stat;
        }

        private void button14_Click(object sender, EventArgs e)
        {

            string VEr;
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
            string status = stat; // Статус
          

            string orderText = $"=_+_={ Environment.NewLine }"
            + $"Заказ под номером =+= {orderNumber}" +
                $"{Environment.NewLine}Редактор =+= {editor}{Environment.NewLine}Статус =+= {status}" +
                $"{Environment.NewLine}Время =+= {DateTime.Now.ToString("yyyy-MM-dd <> HH:mm:ss")}{Environment.NewLine}=+===";
            File.AppendAllText(filePath, Environment.NewLine + orderText);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            stat = button3.Text;
            label8.Text = stat;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stat = button4.Text;
            label8.Text = stat;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            stat = button8.Text;
            label8.Text = stat;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            stat = button9.Text;
            label8.Text = stat;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            stat = button10.Text;
            label8.Text = stat;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            stat = button11.Text;
            label8.Text = stat;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stat = "завершённый(А)";
            label8.Text = stat;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stat = "завершённый(А)";
            label8.Text = stat;
        }

        private void Form8_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10(zacas, zacasCollection, роль);
            form10.Show();

        }
    }
}
