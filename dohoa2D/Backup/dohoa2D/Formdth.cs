using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dohoa2D
{
    public partial class Formdth : Form
    {
        public dthang dth;
        doitoado s = new doitoado();
        public int xoa = 0;
        //public Color mauto;
        public int gocquay, hsbd, sx, sy;
        public int chon=0;
       // public int lam = 0;
        public Formdth()
        {
            InitializeComponent();
        }
         public Formdth(dthang ddth)
        {
          //  groupBox1.Text = "Duong thang "+i.ToString();
            InitializeComponent();
            dth = new dthang(ddth.diemdau, ddth.diemcuoi, ddth.mau);
            Point d1 = s.toado1(ddth.diemdau.X, ddth.diemdau.Y);
            textBox1.Text = d1.X.ToString();
            textBox2.Text = d1.Y.ToString();
            d1 =s.toado1(ddth.diemcuoi.X, ddth.diemcuoi.Y);
            textBox3.Text = d1.X.ToString();
            textBox4.Text = d1.Y.ToString();
            textBox5.ForeColor = ddth.mau;
        }
        public dthang getvalue()
        {
            return dth;
        }

      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Warning: Khong nen chon mau duong \ntrung voi mau nen (=mau trang)!");
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            MyDialog.Color = textBox5.ForeColor;
            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                if (MyDialog.Color == Color.White)
                {
                    MessageBox.Show("Hay chon mau duong \nkhac voi mau nen(=mau trang)");
                }
                else
                    textBox5.ForeColor = MyDialog.Color;
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt16(textBox1.Text);
            int y1 = Convert.ToInt16(textBox2.Text);
            int x2 = Convert.ToInt16(textBox3.Text);
            int y2 = Convert.ToInt16(textBox4.Text);
            if (radioButton1.Checked == true) { xoa = 1; chon = 0; }
            dth=new dthang(s.toado2(x1, y1), s.toado2(x2, y2),textBox5.ForeColor);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormBiendoi f = new FormBiendoi(textBox5.ForeColor, 0);
            f.ShowDialog();
           // lam = f.lam;
            chon = f.chon;
            if (chon != 0)
            {
                gocquay = f.gocquay;
                hsbd = f.hsbd;
                sx = f.sx; sy = f.sy;
               // lam = 1;
            }
           // else lam = 0;

        }
    }
}