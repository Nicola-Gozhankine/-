﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Служба_доставки
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
              
              

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "Log.txt";
            string fileContents = File.ReadAllText(filePath);
            textBox3.Text = fileContents;


        }
    }
}
