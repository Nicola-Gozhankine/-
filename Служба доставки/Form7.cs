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
    public partial class Form7 : Form
    {
        private Zacas zacas;
        private List<Zacas> zacasCollection;
        private int index;
        public Form7(Zacas zacas, List<Zacas> zacasCollection, int index)
        {
            InitializeComponent();
            this.zacas = zacas;
            this.index = index;

            this.zacasCollection = zacasCollection;

        }
        public Form7(Zacas zacas, List<Zacas> zacasCollection)
        {
            InitializeComponent();
            this.zacas = zacas;
            this.index = index;

            this.zacasCollection = zacasCollection;

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }
    }
}
