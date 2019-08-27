using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dohoa2D
{
    public partial class Formelip : Form
    {
        public elip el;
        doitoado s = new doitoado();
       // Color c;
        public int xoa = 0;
        public Color mauto;
        public int gocquay, hsbd, sx, sy;
        public int chon=0;
      //  public int lam = 0;
        public Formelip()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
         public Formelip(elip k)
        {
          //  groupBox1.Text = "Elip "+i.ToString();
            InitializeComponent();
            el = new elip(k.tam, k.a, k.b, k.mau);
            Point d1 = s.toado1(k.tam.X,k.tam.Y);
            textBox1.Text = d1.X.ToString();
            textBox2.Text = d1.Y.ToString();
            int a, b;
            a = (int)(k.a / 5);
            b = (int)(k.b / 5);
            textBox3.Text = a.ToString();
            textBox4.Text = b.ToString();
            textBox5.ForeColor = k.mau;
        }
        public elip getvalue()
        { return el; }
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
            if (chon != 0 && mauto == textBox5.ForeColor)
            {
                MessageBox.Show("Mau to da bi trung mau duong ve");
                return;
            }
            el = new elip(s.toado2(x1, y1),x2*5,y2*5, textBox5.ForeColor);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormBiendoi f = new FormBiendoi(textBox5.ForeColor, 1);
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