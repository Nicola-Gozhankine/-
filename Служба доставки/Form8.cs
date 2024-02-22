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
    public partial class Form8 : Form
    {
        private Zacas zacas;
        private List<Zacas> zacasCollection;
        private int index;
        int index1;
        public Form8(Zacas zacas, List<Zacas> zacasCollection, int index)
        {
            InitializeComponent();
            this.zacas = zacas;
            this.index = index;
            this.zacasCollection = zacasCollection;
        }

        private void Form8_Load(object sender, EventArgs e)
        {


        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }
    }
}
