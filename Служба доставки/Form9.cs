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

namespace Служба_доставки
{
    public partial class Form9 : Form
    {
        private Zacas zacas;
        private List<Zacas> zacasCollection;
        
        public Form9(Zacas zacas, List<Zacas> zacasCollection)
        {
            InitializeComponent();
            this.zacas = zacas;
            this.zacasCollection = zacasCollection;

        }

        private void Form9_Load(object sender, EventArgs e)
        {

            int n;
            int lastNumber = zacasCollection[zacasCollection.Count - 1].Number;
            n = lastNumber+1;
            label2.Text=n.ToString();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;



        }

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
