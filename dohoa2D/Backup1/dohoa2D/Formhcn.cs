using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dohoa2D
{
    public partial class Formhcn : Form
    {
        public hcn hcn;
        doitoado s = new doitoado();
        //Color c;
        public int xoa = 0;
        public Color mauto;
        public int gocquay, hsbd, sx, sy;
        public int chon=0;
       // public int lam = 0;
        public Formhcn()
        {
            InitializeComponent();
        }
        public Formhcn(hcn k)
        {
           // groupBox1.Text = "Hinh chu nhat "+i.ToString();
            InitializeComponent();
            hcn = new hcn(k.d1, k.d2, k.mau);
            Point d1 = s.toado1(k.d1.X,k.d1.Y);
            textBox1.Text = d1.X.ToString();
            textBox2.Text = d1.Y.ToString();
            d1 = s.toado1(k.d3.X, k.d3.Y);
            textBox3.Text = d1.X.ToString();
            textBox4.Text = d1.Y.ToString();
            d1 = s.toado1(k.d4.X, k.d4.Y);
            textBox5.Text = d1.X.ToString();
            textBox6.Text = d1.Y.ToString();
            d1 = s.toado1(k.d2.X, k.d2.Y);
            textBox7.Text = d1.X.ToString();
            textBox8.Text = d1.Y.ToString();
            int dai, rong, t, tt;
            t = (int)(Math.Abs(k.d1.X - k.d2.X)/5);
            tt = (int)(Math.Abs(k.d1.Y - k.d2.Y)/5);
            if (t > tt) { dai = t; rong = tt; }
            else { dai = tt; rong = t; }
            textBox9.Text = dai.ToString();
            textBox10.Text = rong.ToString();
            textBox11.ForeColor = k.mau;
        }
        public hcn getvalue()
        {
            return hcn;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Warning: Khong nen chon mau duong \ntrung voi mau nen (=mau trang)!");
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            MyDialog.Color = textBox11.ForeColor;
            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                if (MyDialog.Color == Color.White)
                {
                    MessageBox.Show("Hay chon mau duong \nkhac voi mau nen(=mau trang)");
                }
                else
                    textBox11.ForeColor = MyDialog.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt16(textBox1.Text);
            int y1 = Convert.ToInt16(textBox2.Text);
            int x2 = Convert.ToInt16(textBox7.Text);
            int y2 = Convert.ToInt16(textBox8.Text);

            if (radioButton1.Checked == true) { xoa = 1; chon = 0; }
            if (chon != 0 && mauto == textBox11.ForeColor)
            {
                MessageBox.Show("Mau to da bi trung mau duong ve");
                return;
            }
            hcn = new hcn(s.toado2(x1, y1), s.toado2(x2, y2), textBox11.ForeColor);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormBiendoi f = new FormBiendoi(textBox11.ForeColor, 1);
            f.ShowDialog();
            chon = f.chon;
            if (chon != 0)
            {
                gocquay = f.gocquay;
                hsbd = f.hsbd;
                sx = f.sx; sy = f.sy;
                mauto = f.mauto;
                // lam = 1;
            }
        }
    }
}