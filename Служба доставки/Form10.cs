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
using System.IO;

namespace Служба_доставки
{
    public partial class Form10 : Form
    {
        public string filePath = "Zacasi.txt"; // замените на реальный путь к вашему файлу
        string stat = " ";
        private Zacas zacas;
        private List<Zacas> zacasCollection;
        private int index;
        int index1;
        private Роль роль;
        public List<UserControl2> panel = new List<UserControl2>();
        List<UserControl2> userControlList = new List<UserControl2>(); // Создание списка пользовательских элементов управления
        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }
        public class OrderStatus

        {
            public int OrderNumber { get; set; }
            public string Status { get; set; }
            public DateTime InstallationTime { get; set; }
        }

        // Создание коллекции для хранения статусов
        List<OrderStatus> orderStatusList = new List<OrderStatus>();
        public Form10(Zacas zacas, List<Zacas> zacasCollection,  Роль роль)
        {
            InitializeComponent();
            this.zacas = zacas;
                        this.роль = роль;
            this.zacasCollection = zacasCollection; 
        }

        private void Form10_Load(object sender, EventArgs e)
        {
           
            string inputText = File.ReadAllText(filePath);
            textBox1.Text = inputText;

            // Цикл для обработки данных из textBox1 и заполнения коллекции
            for (int i = 0; i < textBox1.Lines.Length; i++)
            {
                if (textBox1.Lines[i].StartsWith("=_+_="))
                {
                    string[] parts = textBox1.Lines[i + 1].Split(new string[] { "=+=" }, StringSplitOptions.None);
                    int orderNumber = Convert.ToInt32(parts[1].Trim());

                    string[] statusParts = textBox1.Lines[i + 3].Split(new string[] { "=+=" }, StringSplitOptions.None);
                    string status = statusParts[1].Trim();

                    string[] timeParts = textBox1.Lines[i + 4].Split(new string[] { "=+=" }, StringSplitOptions.None);
                    string timeString = timeParts[1].Trim();
                    DateTime installationTime;

                    if (DateTime.TryParse(timeString, out installationTime))
                    {
                        MessageBox.Show("   NynZ");
                        OrderStatus newStatus = new OrderStatus
                        {
                            //MessageBox.Show("   NynZ");

                            OrderNumber = orderNumber,
                            Status = status,
                            InstallationTime = installationTime
                        };

                        orderStatusList.Add(newStatus);
                    }
                }
            }

            // Сортировка коллекции по времени установки статуса
            orderStatusList = orderStatusList.OrderBy(o => o.InstallationTime).ToList();
            //for (int NynZS = 0; NynZS < orderStatusList.Count; NynZS++)
            //{
            //    OrderStatus currentOrderStatus = orderStatusList[NynZS];
            //    MessageBox.Show("   NynZ");
            //    // UserControl2 userControl = new UserControl2(123, "status", DateTime.Now);

            //    UserControl2 userControl = new UserControl2(currentOrderStatus.OrderNumber, currentOrderStatus.Status, currentOrderStatus.InstallationTime, zacas);
            //    userControl.Location = new Point(userControl.Location.X, NynZS * userControl.Size.Height);

            //    panel.Add(userControl);
            //    panel1.Controls.Add(panel[NynZS]);
            //}
            for (int NynZS = 0; NynZS < orderStatusList.Count; NynZS++)
            {
                OrderStatus currentOrderStatus = orderStatusList[NynZS];
                UserControl2 userControl = new UserControl2(currentOrderStatus.OrderNumber, currentOrderStatus.Status, currentOrderStatus.InstallationTime, zacas);
                userControl.Location = new Point(userControl.Location.X, NynZS * userControl.Size.Height);
                panel1.Controls.Add(userControl); // Используйте метод Controls.Add для добавления UserControl2 на панель panel1
            }



        }
    }
}
