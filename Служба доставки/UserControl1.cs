﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Служба_доставки.Properties;
using VS;
using Служба_доставки;
using System.Reflection;
//using Служба_доставки;
//using Form2;

namespace Служба_доставки
{
    public partial class UserControl1 : UserControl
    {

        //VS.Zacas zacas = new Zacas();
        VS.Роль роль = new Роль();
        
        private Zacas zacas;
        private List<Zacas> zacasCollection;
         int panel_indexs;
         string lastName;
         string firstName;
         string middleName;

        public UserControl1(Zacas zacas, List<Zacas> zacasCollection, int index, string firstName, string lastName , string middleName  )
        {

            InitializeComponent();
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleName = middleName;
            роль.Менеджер = true;
            this.zacas = zacas;
            this.zacasCollection = zacasCollection;
            this.panel_indexs = index;
            label1.Text = zacasCollection[index].Number.ToString();
            label2.Text = zacasCollection[index].Время_брибытия_Курьера.ToString();


          if(   zacasCollection[index].Number == zacasCollection[index].Status_order.num)
            {
                button3.Text = zacasCollection[index].Status_order.tecstat;
                    
            }

            if (button3.Text == "завершённый(А)")
            {
                 button3.BackColor = Color.MediumVioletRed;
              //  button3.BackColor = Color.BurlyWood;

            }
            if (button3.Text == "завершённый")
            {
                button3.BackColor = Color.DarkOliveGreen;

            }
            if ((button3.Text != "завершённый(А)")&& (button3.Text != "завершённый"))
            {

                //  button3.BackColor = Color.BurlyWood;
                button3.BackColor = Color.MediumPurple;
            }
            // Другие операции с элементами UserControl1

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
    //        Form2 form2Instance = new Form2();
    //        Form2 form = new Form2();
    //        form.Form2_Load(this, e);
    //        //    form2Instance.ShowDialog();
    //     //   Служба_доставки.Form2.Form2_Load(this, e);
    //        // Служба_доставки.Form2.zacasCollection[1];
    //        List<UserControl1> Коллекция = form.panel;
    //        int a = form.NynZS;
    //      //  MessageBox.Show(a.ToString());
    //                    List<Zacas> полученнаяКоллекция = form.zacasCollection;

    //   //  полученнаяКоллекция.Add(zacas);
    ////   MessageBox.Show(полученнаяКоллекция.Count.ToString());
    //        // List<Zacas> полученнаяКоллекция = Служба_доставки.Form2.zacasCollection;
       
            
    //          //  MessageBox.Show(i.ToString());
    //            label1.Text = полученнаяКоллекция[a-1 ].Number.ToString();
         
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //курьер 
            Form2.ActiveForm.Hide();
            Form5 form5 = new Form5(zacas, zacasCollection, panel_indexs, firstName, lastName, middleName);


            form5.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Статус заказа 

            Form2.ActiveForm.Hide();
            Form8 form8 = new Form8(zacas, zacasCollection, panel_indexs,Form1.роль_клон);


            form8.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {//Информация о заказе 

            Form2.ActiveForm.Hide();
            Form6 form6 = new Form6(zacas, zacasCollection, panel_indexs);


            form6.Show();

        }
    }
}
