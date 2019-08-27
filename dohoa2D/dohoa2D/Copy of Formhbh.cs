using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dohoa2D
{
    public partial class Formhbh : Form
    {
        public hbh hbh;
        doitoado s = new doitoado();
        //Color c;
        public int xoa = 0;
        public Formhbh()
        {
            InitializeComponent();
        }
        public Formhbh(hbh k)
        {
           // groupBox1.Text = "Hinh chu nhat "+i.ToString();
            InitializeComponent();
            hbh = new hbh(k.d1, k.d2,k.d3, k.mau);
            Point d1 = s.toado1(k.d1.X,k.d1.Y);
            textBox1.Text = d1.X.ToString();
            textBox2.Text = d1.Y.ToString();
            d1 = s.toado1(k.d2.X, k.d2.Y);
            textBox3.Text = d1.X.ToString();
            textBox4.Text = d1.Y.ToString();
            d1 = s.toado1(k.d4.X, k.d4.Y);
            textBox5.Text = d1.X.ToString();
            textBox6.Text = d1.Y.ToString();
            d1 = s.toado1(k.d3.X, k.d3.Y);
            textBox7.Text = d1.X.ToString();
            textBox8.Text = d1.Y.ToString();
            int c1, c2;
            c1 =(int)( Math.Abs(k.d2.X - k.d1.X)/5);
            c2 = (int)(Math.Abs(k.d3.Y - k.d2.Y)/5);
            textBox9.Text = c1.ToString();
            textBox10.Text = c2.ToString();
            textBox11.ForeColor = k.mau;
        }
        public hbh getvalue()
        {
            return hbh;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Warning: Khong nen chon mau trung voi mau nen!");
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            MyDialog.Color = textBox11.ForeColor;
            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)

                textBox11.ForeColor = MyDialog.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt16(textBox1.Text);
            int y1 = Convert.ToInt16(textBox2.Text);
            int x3 = Convert.ToInt16(textBox7.Text);
            int y3= Convert.ToInt16(textBox8.Text);
            int x2 = Convert.ToInt16(textBox3.Text);
            int y2= Convert.ToInt16(textBox4.Text);
            if (radioButton1.Checked == true) xoa = 1;
            hbh = new hbh(s.toado2(x1, y1), s.toado2(x2, y2), s.toado2(x3, y3), textBox11.ForeColor);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}