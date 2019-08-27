using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dohoa2D
{
    public partial class FormBiendoi : Form
    {
        public Color mauto;
        public int gocquay, hsbd, sx, sy;
        public int chon = 0;
       
        public FormBiendoi()
        {
            InitializeComponent();
        }
        public FormBiendoi(Color m,int i)
        {
            InitializeComponent();
            if (i == 0)//duong thang
            {
                radioButton7.Enabled = false;
                button4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
            }
            mauto = textBox7.ForeColor;
            textBox5.ForeColor = m;
            gocquay = 90;
            hsbd = sx = sy = 1;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
                textBox2.Enabled = true;
            else textBox2.Enabled = false;
        }

       private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
                textBox1.Enabled = true;
            else textBox1.Enabled = false;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
                button4.Enabled = true;
            else button4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                chon = 1;
            else if (radioButton2.Checked == true)
                chon = 2;
            else if (radioButton3.Checked == true)
                chon = 3;
            else if (radioButton4.Checked == true)
            {
                if (textBox2.Text == "")
                { MessageBox.Show("Hay nhap goc quay"); return; }
                gocquay = Convert.ToInt16(textBox2.Text);
                chon = 4;
            }
            else if (radioButton5.Checked == true)
            {
                if (textBox3.Text == "" || textBox4.Text == "")
                { MessageBox.Show("Hay nhap day du sx va sy"); return; }
                sx = Convert.ToInt16(textBox3.Text);
                sy = Convert.ToInt16(textBox4.Text);
                chon = 5;
            }
            else if (radioButton6.Checked == true)
            {
                if (textBox1.Text == "")
                { MessageBox.Show("Hay nhap he so bien dang"); return; }
                hsbd = Convert.ToInt16(textBox1.Text);
                chon = 6;
            }
            else if (radioButton7.Checked == true)
            {
                if (mauto == Color.White || mauto == textBox5.ForeColor)
                { MessageBox.Show("Hay chon mau to khac \nmau duong va mau nen."); return; }
                chon = 7;
            }
          /*  else if (radioButton8.Checked == true)
            {
                chon = 8;
            }*/
            else chon = 0;
            if (chon != 0) button2.Enabled = true;
            else button2.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Khong nen chon mau trung voi mau nen hoac mau duong!");
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            MyDialog.Color = textBox7.ForeColor;
            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)

                mauto=textBox7.ForeColor = MyDialog.Color;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}