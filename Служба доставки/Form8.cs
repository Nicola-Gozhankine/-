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

namespace Служба_доставки
{
    public partial class Form8 : Form
    {
        private Zacas zacas;
        private List<Zacas> zacasCollection;
        private int index;
        int index1;
        public Form8(Zacas zacas, List<Zacas> zacasCollection, int index  )
        {
            InitializeComponent();
            this.zacas = zacas;
            this.index = index;
            this.zacasCollection = zacasCollection;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            if (zacasCollection[index].Number == zacasCollection[index].Status_order.num)
            {
                label2.Text = zacasCollection[index].Status_order.tecstat;

            }


        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
