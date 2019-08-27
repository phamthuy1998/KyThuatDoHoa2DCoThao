using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;

namespace dohoa2D
{
    public partial class Form1 : Form
    {
        public dthang[] lines;
        public htron[] circles;
        public hvuong[] squares;
        public hcn[] rectangles;
        public elip[] elippses;
        public hbh[] hinhbhs;
        int click = -1;
        int chonhinh = -1;//chonhinh=hinh se ve
        //int sodt = 0, soht = 0,sohv=0,sohcn=0,soelip=0,sohbh=0;
        Point[] points = new Point[100];//cac diem de thao tac ve hinh


        int chon = 0;// chon=kieubiendoi,chon=0 la ko bien doi
        int loaihinh = -1;//loaihinh se biendoi
        int stt = -1;//=xdinh hinh nao se bien doi
        Point[] diems = new Point[3];//3 diem de thao tac bien doi
        int sodiem = 0;
        int gocquay, hsbd, sx, sy;
        Color mauto = Color.White;


        doitoado s = new doitoado();
        public Color[,] arrcolor = new Color[201, 201];// mang chua mau cua tat ca cac diem

        public object Serif { get; private set; }
        private Label lbA, lbB, lbC, lbD, lbE, lbF, lbG, lbI, lbA1, lbB1, lbC1, lbD1, lbE1;
        int VeHinh3d = 0;
        public Form1()

        {
            lbA = new Label();
            lbB = new Label();
            lbC = new Label();
            lbD = new Label();
            lbE = new Label();
            lbA1 = new Label();
            lbB1 = new Label();
            lbC1 = new Label();
            lbD1 = new Label();
            lbE1 = new Label();
            lbF = new Label();
            lbG = new Label();
            lbI = new Label();
            lines = null; squares = null; rectangles = null; elippses = null;
            circles = null; hinhbhs = null;
            InitializeComponent();
            initcolor();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();
            label22.Hide();
            label23.Hide();
            label24.Hide();
            label25.Hide();
            label26.Hide();
            label27.Hide();
            label28.Hide();
            label30.Hide();
            label31.Hide();
            label32.Hide();
            label29.Hide();
            label33.Hide();
            label36.Visible = false;
            label42.Visible = false;
            label37.Visible = false;
            label38.Visible = false;
            label39.Visible = false;
            label40.Visible = false;
            label43.Visible = false;
            tbX.Visible = false;
            tbY.Visible = false;
            tbZ.Visible = false;
            tbCanh.Visible = false;
            tbH.Visible = false;
            btnVe.Visible = false;
        }
        // Dua 1 hinh vao mang
        public void Add(dthang dt)
        {
            if (lines == null)
            {
                lines = new dthang[1]; lines[0] = dt;
            }
            else
            {
                dthang[] temp = new dthang[lines.Length + 1];
                for (int i = 0; i < lines.Length; i++) temp[i] = lines[i];
                temp[lines.Length] = dt;
                lines = temp;
            }
        }
        public void Add(htron dt)
        {
            if (circles == null)
            {
                circles = new htron[1]; circles[0] = dt;
            }
            else
            {
                htron[] temp = new htron[circles.Length + 1];
                for (int i = 0; i < circles.Length; i++) temp[i] = circles[i];
                temp[circles.Length] = dt;
                circles = temp;
            }
        }
        public void Add(hvuong hv)
        {
            if (squares == null)
            {
                squares = new hvuong[1];
                squares[0] = hv;
            }
            else
            {
                hvuong[] temp = new hvuong[squares.Length + 1];
                for (int i = 0; i < squares.Length; i++) temp[i] = squares[i];
                temp[squares.Length] = hv;
                squares = temp;
            }
        }
        public void Add(hcn cn)
        {
            if (rectangles == null) { rectangles = new hcn[1]; rectangles[0] = cn; }
            else
            {
                hcn[] temp = new hcn[rectangles.Length + 1];
                for (int i = 0; i < rectangles.Length; i++) temp[i] = rectangles[i];
                temp[rectangles.Length] = cn;
                rectangles = temp;
            }
        }
        public void Add(hbh bh)
        {
            if (hinhbhs == null) { hinhbhs = new hbh[1]; hinhbhs[0] = bh; }
            else
            {
                hbh[] temp = new hbh[hinhbhs.Length + 1];
                for (int i = 0; i < hinhbhs.Length; i++) temp[i] = hinhbhs[i];
                temp[hinhbhs.Length] = bh;
                hinhbhs = temp;
            }
        }
        public void Add(elip el)
        {
            if (elippses == null) { elippses = new elip[1]; elippses[0] = el; }
            else
            {
                elip[] temp = new elip[elippses.Length + 1];
                for (int i = 0; i < elippses.Length; i++) temp[i] = elippses[i];
                temp[elippses.Length] = el;
                elippses = temp;
            }
        }

        //- bo 1 hinh thu j ra khoi mang-----------------------------

        public dthang[] Delete(int j, dthang[] DT)
        {
            int i;
            if (DT.Length == 1) lines = null;
            else
            {
                dthang[] temp = new dthang[DT.Length - 1];
                for (i = 0; i < j; i++)
                    temp[i] = DT[i];
                for (i = j + 1; i < DT.Length; i++)
                    temp[i - 1] = DT[i];
                DT = temp;

            }
            return DT;
        }
        public htron[] Delete(int j, htron[] DT)
        {
            int i;
            if (DT.Length == 1) DT = null;
            else
            {
                htron[] temp = new htron[DT.Length - 1];
                for (i = 0; i < j; i++)
                    temp[i] = DT[i];
                for (i = j + 1; i < DT.Length; i++)
                    temp[i - 1] = DT[i];
                DT = temp;
            }
            return DT;
        }
        public hvuong[] Delete(int j, hvuong[] DT)
        {
            int i;
            if (DT.Length == 1) DT = null;
            else
            {
                hvuong[] temp = new hvuong[DT.Length - 1];
                for (i = 0; i < j; i++)
                    temp[i] = DT[i];
                for (i = j + 1; i < DT.Length; i++)
                    temp[i - 1] = DT[i];
                DT = temp;
            }
            return DT;
        }
        public hcn[] Delete(int j, hcn[] DT)
        {
            int i;
            if (DT.Length == 1) DT = null;
            else
            {
                hcn[] temp = new hcn[DT.Length - 1];
                for (i = 0; i < j; i++)
                    temp[i] = DT[i];
                for (i = j + 1; i < DT.Length; i++)
                    temp[i - 1] = DT[i];
                DT = temp;
            }
            return DT;
        }
        public hbh[] Delete(int j, hbh[] DT)
        {
            int i;
            if (DT.Length == 1) DT = null;
            else
            {
                hbh[] temp = new hbh[DT.Length - 1];
                for (i = 0; i < j; i++)
                    temp[i] = DT[i];
                for (i = j + 1; i < DT.Length; i++)
                    temp[i - 1] = DT[i];
                DT = temp;
            }
            return DT;
        }
        public elip[] Delete(int j, elip[] DT)
        {
            int i;
            if (DT.Length == 1) DT = null;
            else
            {
                elip[] temp = new elip[DT.Length - 1];
                for (i = 0; i < j; i++)
                    temp[i] = DT[i];
                for (i = j + 1; i < DT.Length; i++)
                    temp[i - 1] = DT[i];
                DT = temp;
            }
            return DT;
        }
        //------------------------------------------------------

        public void khoitaobien()
        {
            click = -1;
            // chonhinh = -1;lab\\
            // sodt = soht = sohv = sohcn = soelip = sohbh = 0;
            lines = null; squares = null; rectangles = null; elippses = null;
            circles = null; hinhbhs = null;
        }
        public void heToaDo()
        {
           
            Graphics g = this.panel1.CreateGraphics();
  
            g.DrawLine(new Pen(Color.Red), 0, 350, 1000, 350);
            g.DrawLine(new Pen(Color.Red), 450, 0, 450, 1000);
            label36.Visible = false;
            label2.Text = "Y";

        }
        private void initbd()
        {
            chonhinh = -1;
            chon = 0;// chon=kieubiendoi
            loaihinh = -1;//loaihinh se biendoi
            stt = -1;//=xdinh hinh nao se bien doi
                     // chonhinh=-1;//chonhinh=hinh se ve
            diems = new Point[3];//2 diem de thao tac bien doi
            sodiem = 0;
            gocquay = 90;
            hsbd = sx = sy = 1;
            mauto = Color.White;
        }

        private void initcolor()
        {
            for (int i = 0; i < 201; i++)
                for (int j = 0; j < 201; j++)
                    arrcolor[i, j] = Color.White;
        }
        private void putcolor(int x, int y, Color m)
        {
            if (x < 0 || x > 1000 || y < 0 || y > 1000) return;
            arrcolor[s.round(y) / 5, s.round(x) / 5] = m;
        }
        private void putcolor1(int x, int y, int cx, int cy, Color m)
        {
            putcolor(x + cx, y + cy, m);
            putcolor(-x + cx, y + cy, m);
            putcolor(x + cx, -y + cy, m);
            putcolor(-x + cx, -y + cy, m);
        }
        private Color getcolor(int x, int y)
        {
            if (x < 0 || x > 1000 || y < 0 || y > 1000) return mauto;
            return arrcolor[s.round(y) / 5, s.round(x) / 5];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            initcolor();// 
            vehinh();
        }
        public void vehinh()
        {
            int i;
            if (lines != null)
            { for (i = 0; i < lines.Length; i++) DDA_Line(lines[i]); }
            if (circles != null)
            { for (i = 0; i < circles.Length; i++) Midpoint_htron(circles[i]); }
            if (squares != null)
            { for (i = 0; i < squares.Length; i++) hinhvuong(squares[i]); }
            if (rectangles != null)
            { for (i = 0; i < rectangles.Length; i++) hinhcn(rectangles[i]); }
            if (elippses != null)
            { for (i = 0; i < elippses.Length; i++) Midpoint_elip(elippses[i]); }
            if (hinhbhs != null)
            { for (i = 0; i < hinhbhs.Length; i++) hinhbinhhanh(hinhbhs[i]); }
        }
        
        private void putpixel(int x, int y, Color m)
        {
            if (x < 0 || x > 1000 || y < 0 || y > 1000) return;

            //Graphics grfx = this.panel1.CreateGraphics();
            //Pen p = new Pen(m);
            //SolidBrush b = new SolidBrush(m);
            //grfx.FillEllipse(b, x - 3, y - 3, 6, 6);

            Graphics grfx = this.panel1.CreateGraphics();
              
            Pen p = new Pen(m);
            SolidBrush b = new SolidBrush(m);
            grfx.FillRectangle(b, x, y, 5, 5);
            putcolor(x, y, m);
        }
        private void put4pitxel(int x, int y, int cx, int cy, Color m)
        {
            putpixel(x + cx, y + cy, m);
            putpixel(-x + cx, y + cy, m);
            putpixel(x + cx, -y + cy, m);
            putpixel(-x + cx, -y + cy, m);
        }
        private void put8pitxel(int x, int y, int cx, int cy, Color m)
        {
            putpixel(cx + x, cy + y, m);
            putpixel(cx + x, cy - y, m);
            putpixel(cx - x, cy + y, m);
            putpixel(cx - x, cy - y, m);
            putpixel(cx + y, cy + x, m);
            putpixel(cx + y, cy - x, m);
            putpixel(cx - y, cy + x, m);
            putpixel(cx - y, cy - x, m);
        }

        public int diem_dthang(int x, int y, dthang T)
        {
            /* if ((x - T.diemdau.X) * (T.diemcuoi.Y - T.diemdau.Y) == (y - T.diemdau.Y) * (T.diemcuoi.X - T.diemdau.X))
                 return 1;
             return 0;*/
            int maxx, minx, maxy, miny;
            if (T.diemdau.X > T.diemcuoi.X) { maxx = T.diemdau.X; minx = T.diemcuoi.X; }
            else { maxx = T.diemcuoi.X; minx = T.diemdau.X; }
            if (T.diemdau.Y > T.diemcuoi.Y) { maxy = T.diemdau.Y; miny = T.diemcuoi.Y; }
            else { maxy = T.diemcuoi.Y; miny = T.diemdau.Y; }
            if (x >= minx && x <= maxx && y >= miny && y <= maxy) return 1;
            else return 0;
        }
        public int diem_dtron(int x, int y, htron T)
        {
            /* if (Math.Pow(x - T.tam.X, 2) + Math.Pow(y - T.tam.Y, 2) == T.bkinh)
                 return 1;
             return 0;*/
            int maxx, minx, maxy, miny;
            maxx = T.tam.X + T.bkinh;
            minx = T.tam.X - T.bkinh;
            maxy = T.tam.Y + T.bkinh;
            miny = T.tam.Y - T.bkinh;
            if (x >= minx && x <= maxx && y >= miny && y <= maxy) return 1;
            else return 0;
        }
        public int diem_elip(int x, int y, elip T)
        {
            /*if (Math.Pow(x - T.tam.X, 2) / (T.a * T.a) + Math.Pow(y - T.tam.Y, 2) / (T.b * T.b) == 1)
                return 1;
            return 0;*/
            int maxx, minx, maxy, miny;
            maxx = T.tam.X + T.a;
            minx = T.tam.X - T.a;
            maxy = T.tam.Y + T.b;
            miny = T.tam.Y - T.b;
            if (x >= minx && x <= maxx && y >= miny && y <= maxy) return 1;
            else return 0;

        }
        public int diem_hvuong(int x, int y, hvuong T)
        {
            Color m = T.mau;
            if (diem_dthang(x, y, new dthang(T.d1, T.d2, m)) == 1 || diem_dthang(x, y, new dthang(T.d1, T.d3, m)) == 1 || diem_dthang(x, y, new dthang(T.d2, T.d4, m)) == 1 || diem_dthang(x, y, new dthang(T.d3, T.d4, m)) == 1)
                return 1;
            int maxx, minx, maxy, miny;
            if (T.d2.X > T.d1.X) { maxx = T.d2.X; minx = T.d1.X; }
            else { maxx = T.d1.X; minx = T.d2.X; }
            maxy = T.d1.Y + Math.Abs(T.d2.X - T.d1.X);
            miny = T.d1.Y;
            if (x >= minx && x <= maxx && y >= miny && y <= maxy) return 1;
            else return 0;

        }
        public int diem_hcn(int x, int y, hcn T)
        {
            Color m = T.mau;
            if (diem_dthang(x, y, new dthang(T.d1, T.d4, m)) == 1 || diem_dthang(x, y, new dthang(T.d1, T.d3, m)) == 1 || diem_dthang(x, y, new dthang(T.d4, T.d2, m)) == 1 || diem_dthang(x, y, new dthang(T.d2, T.d3, m)) == 1)
                return 1;
            int maxx, minx, maxy, miny;
            if (T.d2.X > T.d1.X) { maxx = T.d2.X; minx = T.d1.X; }
            else { maxx = T.d1.X; minx = T.d2.X; }
            if (T.d2.Y > T.d1.Y) { maxy = T.d2.Y; miny = T.d1.Y; }
            else { maxy = T.d1.Y; miny = T.d2.Y; }
            if (x >= minx && x <= maxx && y >= miny && y <= maxy) return 1;
            else return 0;
        }
        public int diem_hbh(int x, int y, hbh T)
        {
            Color m = T.mau;
            if (diem_dthang(x, y, new dthang(T.d1, T.d2, m)) == 1 || diem_dthang(x, y, new dthang(T.d2, T.d3, m)) == 1 || diem_dthang(x, y, new dthang(T.d1, T.d4, m)) == 1 || diem_dthang(x, y, new dthang(T.d4, T.d3, m)) == 1)
                return 1;
            return 0;
        }
        public void DDA_Line_net_dut(dthang T) // Ve duong thang co dinh dang mau
        {
            Color m = T.mau;
            int Dx, Dy, count, temp_1, temp_2, dem = 1;
            //int temp_3, temp_4;
            Dx = T.diemcuoi.X - T.diemdau.X;
            Dy = T.diemcuoi.Y - T.diemdau.Y;
            if (Math.Abs(Dy) > Math.Abs(Dx)) count = Math.Abs(Dy);
            else count = Math.Abs(Dx);
            float x, y, delta_X, delta_Y;
            if (count > 0)
            {
                delta_X = Dx;
                delta_X /= count;
                delta_Y = Dy;
                delta_Y /= count;
                x = T.diemdau.X;
                y = T.diemdau.Y;
                int dem1 = 0;
                do
                {

                    temp_1 = s.round(x);
                    temp_2 = s.round(y);
                    if (dem < 10)
                    {
                        putpixel(temp_1, temp_2, m);
                       
                    }
                    x += delta_X;
                    y += delta_Y;
                    --count;
                    dem++;
                    if (dem == 20)
                    {
                        dem = 0;
                    }

                } while (count != -1);

            }
        }
        public void DDA_Line(dthang T) // Ve duong thang co dinh dang mau
        {
            Color m = T.mau;
            int Dx, Dy, count, temp_1, temp_2, dem = 1;
            //int temp_3, temp_4;
            Dx = T.diemcuoi.X - T.diemdau.X;
            Dy = T.diemcuoi.Y - T.diemdau.Y;
            if (Math.Abs(Dy) > Math.Abs(Dx)) count = Math.Abs(Dy);
            else count = Math.Abs(Dx);
            float x, y, delta_X, delta_Y;
            if (count > 0)
            {
                delta_X = Dx;
                delta_X /= count;
                delta_Y = Dy;
                delta_Y /= count;
                x = T.diemdau.X;
                y = T.diemdau.Y;
                do
                {
                    temp_1 = s.round(x);
                    temp_2 = s.round(y);
                    putpixel(temp_1, temp_2, m);
                    // temp_3 = temp_1;
                    // temp_4 = temp_2;
                    x += delta_X;
                    y += delta_Y;
                    --count;
                    dem++;
                } while (count != -1);

            }
        }
        public void Midpoint_htron(htron T)
        {
            int x, y, cx, cy, p, R;
            Color m = T.mau;
            cx = T.tam.X; cy = T.tam.Y;
            x = 0;
            y = R = T.bkinh;
            int maxX = s.round((float)(Math.Sqrt(2) / 2 * R));
            // int maxX = Math.Sqrt(2) / 2 * R;
            p = 1 - R;
            put8pitxel(x, y, cx, cy, m);
            while (x <= maxX)
            {
                if (p < 0) p += 2 * x + 3;
                else { p += 2 * (x - y) + 5; y -= 5; }
                x += 5;
                put8pitxel(x, y, cx, cy, m);
            }

        }
        public void hinhvuong(hvuong T)
        {
            Color m = T.mau;
            DDA_Line(new dthang(T.d1, T.d2, m));
            DDA_Line(new dthang(T.d1, T.d3, m));
            DDA_Line(new dthang(T.d2, T.d4, m));
            DDA_Line(new dthang(T.d3, T.d4, m));
        }
        public void hinhcn(hcn T)
        {

            Color m = T.mau;
            DDA_Line(new dthang(T.d1, T.d4, m));
            DDA_Line(new dthang(T.d1, T.d3, m));
            DDA_Line(new dthang(T.d4, T.d2, m));
            DDA_Line(new dthang(T.d2, T.d3, m));
        }
        public void hinhbinhhanh(hbh T)
        {
            Color m = T.mau;
            DDA_Line(new dthang(T.d1, T.d2, m));
            DDA_Line(new dthang(T.d2, T.d3, m));
            DDA_Line(new dthang(T.d1, T.d4, m));
            DDA_Line(new dthang(T.d4, T.d3, m));
        }
        public void Midpoint_elip(elip T)
        {
            int x, y, cx, cy, a, b;
            cx = T.tam.X; cy = T.tam.Y;
            a = T.a; b = T.b;
            Color m = T.mau;
            x = 0; y = b;
            int A, B;
            A = a * a;
            B = b * b;
            double p = B + A / 4 - A * b;
            x = 0;
            y = b;
            int Dx = 0;
            int Dy = 2 * A * y;
            put4pitxel(x, y, cx, cy, m);

            while (Dx < Dy)
            {
                x++;
                Dx += 2 * B;
                if (p < 0)
                    p += B + Dx;
                else
                {
                    y--;
                    Dy -= 2 * A;
                    p += B + Dx - Dy;
                }
                putcolor1(s.round(x), s.round(y), cx, cy, m);
                if (x % 5 == 0) put4pitxel(x, s.round(y), cx, cy, m);


            }
            p = Math.Round(B * (x + 0.5f) * (x + 0.5f) + A * (y - 1) * (y - 1) - A * B);
            while (y > 0)
            {
                y--;
                Dy -= A * 2;
                if (p > 0)
                    p += A - Dy;
                else
                {
                    x++;
                    Dx += B * 2;
                    p += A - Dy + Dx;
                }
                putcolor1(s.round(x), s.round(y), cx, cy, m);
                if (x % 5 == 0) put4pitxel(x, s.round(y), cx, cy, m);

            }

        }
        //private void panel1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    int x, y;
        //    x = s.round(e.X); y = s.round(e.Y);
        //    if (e.Button == MouseButtons.Left)
        //    {

        //        if (chon == 0)//ko co bien doi
        //        {

        //            if (chonhinh == -1)
        //            {
        //                MessageBox.Show("chua chon se ve hinh nao");
        //                panel1.Refresh();

        //                return;
        //            }
        //            ++click;

        //            if (click == 0)
        //            {
        //                points[click].X = x;
        //                points[click].Y = y;
        //                putpixel(x, y, Color.DarkOrange);//to diem da chon
        //                putpixel(x, y, Color.White, 1);//mau tai diem chon=maunen
        //            }
        //            if (click == 1)
        //            {
        //                points[click].X = x;
        //                points[click].Y = y;
        //                putpixel(x, y, Color.DarkOrange);
        //                putpixel(x, y, Color.White, 1);
        //                if (chonhinh == 0)
        //                {
        //                    dthang dt = new dthang(points[0], points[1], Color.DarkGreen);
        //                    this.Add(dt);
        //                    DDA_Line(dt);
        //                }
        //                if (chonhinh == 1)
        //                {
        //                    int bk = Math.Abs(points[1].X - points[0].X);
        //                    htron tr = new htron(bk, points[0], Color.DarkGreen);
        //                    this.Add(tr);
        //                    Midpoint_htron(tr);
        //                    tomau_dongquet(points[0].X, points[0].Y, Color.Yellow, Color.DarkGreen);

        //                }
        //                if (chonhinh == 2)
        //                {

        //                    hvuong hv = new hvuong(points[0], points[1], Color.DarkGreen);
        //                    this.Add(hv);
        //                    hinhvuong(hv);

        //                }
        //                if (chonhinh == 3)
        //                {

        //                    hcn cn = new hcn(points[0], points[1], Color.DarkGreen);
        //                    this.Add(cn);
        //                    hinhcn(cn);

        //                }
        //            }
        //            if (click == 2)
        //            {
        //                points[click].X = x;
        //                points[click].Y = y;
        //                putpixel(x, y, Color.DarkOrange);
        //                putpixel(x, y, Color.White, 1);
        //                if (chonhinh == 4)
        //                {

        //                    int aa = Math.Abs(points[1].X - points[0].X);
        //                    int bb = Math.Abs(points[2].Y - points[0].Y);
        //                    elip el = new elip(points[0], aa, bb, Color.DarkGreen);
        //                    this.Add(el);
        //                    Midpoint_elip(el);

        //                }
        //                if (chonhinh == 5)
        //                {

        //                    hbh bh = new hbh(points[0], points[1], points[2], Color.DarkGreen);
        //                    this.Add(bh);
        //                    hinhbinhhanh(bh);
        //                }

        //            }
        //            if (click == 3) click = -1;
        //        }


        //        else if (chon == 7 || chon == 8) { panel1.Refresh(); initbd(); }
        //        else
        //        {
        //            panel1.Refresh();
        //            if (sodiem < 2)
        //            {
        //                diems[sodiem++] = new Point(x, y);
        //                if (sodiem == 1)
        //                {

        //                    putpixel(x, y, Color.DarkOrange);
        //                    if (chon == 1) bd_doixung();
        //                    else if (chon == 3)
        //                    {
        //                        int dx, dy;
        //                        dx = diems[0].X - diems[2].X;
        //                        dy = diems[0].Y - diems[2].Y;
        //                        bd_tinhtien(dx, dy);
        //                    }
        //                    else if (chon == 4) bd_quay();
        //                    else if (chon == 5) bd_tyle();
        //                    else return;


        //                }
        //                else if (sodiem == 2)
        //                {

        //                    putpixel(x, y, Color.DarkOrange);
        //                    Graphics grfx = panel1.CreateGraphics();
        //                    grfx.DrawLine(new Pen(Color.Red), diems[0], diems[1]);
        //                    if (chon == 2) bd_Doixung();
        //                    else if (chon == 6) bd_biendang();
        //                    else return;

        //                }

        //            }



        //        }

        //    }

        //    if (e.Button == MouseButtons.Right)
        //    {

        //        int i;
        //        if (lines != null)
        //        {
        //            for (i = 0; i < lines.Length; i++)
        //                if (diem_dthang(x, y, lines[i]) == 1)
        //                {
        //                    dthang temp = lines[i];
        //                    Formdth f = new Formdth(temp);
        //                    f.ShowDialog();
        //                    if (f.xoa == 1)//da chon nut xoa
        //                    {
        //                        lines = Delete(i, lines);
        //                    }
        //                    else lines[i] = f.getvalue();
        //                    panel1.Refresh();
        //                    chon = f.chon;
        //                    if (chon != 0)
        //                    {
        //                        loaihinh = 0;//duong thang
        //                        stt = i;//duongthang nao
        //                        gocquay = f.gocquay;
        //                        hsbd = f.hsbd;
        //                        sx = f.sx;
        //                        sy = f.sy;
        //                        diems[2].X = x; diems[2].Y = y;
        //                    }

        //                    return;
        //                }

        //        }

        //        if (circles != null)
        //        {
        //            for (i = 0; i < circles.Length; i++)
        //                if (diem_dtron(x, y, circles[i]) == 1)
        //                {
        //                    htron temp = circles[i];
        //                    Formdtr f = new Formdtr(temp);
        //                    f.ShowDialog();
        //                    if (f.xoa == 1)//da chon nut xoa
        //                    {
        //                        circles = Delete(i, circles);

        //                    }
        //                    else circles[i] = f.getvalue();
        //                    panel1.Refresh();
        //                    chon = f.chon;
        //                    if (chon != 0)
        //                    {

        //                        if (chon == 7)
        //                        {
        //                            mauto = f.mauto;
        //                            tomau_dongquet(circles[i].tam, mauto, circles[i].mau);
        //                        }
        //                        else
        //                        {
        //                            loaihinh = 1;
        //                            stt = i;
        //                            gocquay = f.gocquay;
        //                            hsbd = f.hsbd;
        //                            sx = f.sx;
        //                            sy = f.sy;
        //                            diems[2].X = x; diems[2].Y = y;
        //                        }
        //                    }

        //                    return;
        //                }

        //        }


        //        if (squares != null)
        //        {
        //            for (i = 0; i < squares.Length; i++)
        //                if (diem_hvuong(x, y, squares[i]) == 1)
        //                {
        //                    hvuong temp = squares[i];
        //                    Formhv f = new Formhv(temp);
        //                    f.ShowDialog();
        //                    if (f.xoa == 1)//da chon nut xoa
        //                    {
        //                        squares = Delete(i, squares);

        //                    }
        //                    else squares[i] = f.getvalue();
        //                    panel1.Refresh();
        //                    chon = f.chon;
        //                    if (chon != 0)
        //                    {
        //                        if (chon == 7)
        //                        {
        //                            mauto = f.mauto;
        //                            Point tam = new Point(s.round(squares[i].d1.X + (squares[i].d2.X - squares[i].d1.X) / 2), s.round(squares[i].d1.Y + (squares[i].d3.Y - squares[i].d1.Y) / 2));
        //                            tomau_dongquet(tam, mauto, squares[i].mau);
        //                        }
        //                        else
        //                        {
        //                            loaihinh = 2;
        //                            stt = i;
        //                            gocquay = f.gocquay;
        //                            hsbd = f.hsbd;
        //                            sx = f.sx;
        //                            sy = f.sy;
        //                            diems[2].X = x; diems[2].Y = y;

        //                        }
        //                    }

        //                    return;
        //                }
        //        }
        //        if (rectangles != null)
        //        {
        //            for (i = 0; i < rectangles.Length; i++)
        //                if (diem_hcn(x, y, rectangles[i]) == 1)
        //                {
        //                    hcn temp = rectangles[i];
        //                    Formhcn f = new Formhcn(temp);
        //                    f.ShowDialog();
        //                    if (f.xoa == 1)//da chon nut xoa
        //                    {
        //                        rectangles = Delete(i, rectangles);
        //                    }
        //                    else rectangles[i] = f.getvalue();
        //                    panel1.Refresh();
        //                    chon = f.chon;
        //                    if (chon != 0)
        //                    {
        //                        if (chon == 7)
        //                        {
        //                            mauto = f.mauto;
        //                            Point tam = new Point(s.round(rectangles[i].d1.X + (rectangles[i].d2.X - rectangles[i].d1.X) / 2), s.round(rectangles[i].d1.Y + (rectangles[i].d2.Y - rectangles[i].d1.Y) / 2));
        //                            tomau_dongquet(tam, mauto, rectangles[i].mau);
        //                        }
        //                        else
        //                        {
        //                            loaihinh = 3;
        //                            stt = i;

        //                            gocquay = f.gocquay;
        //                            hsbd = f.hsbd;
        //                            sx = f.sx;
        //                            sy = f.sy;
        //                            diems[2].X = x; diems[2].Y = y;
        //                        }
        //                    }

        //                    return;
        //                }
        //        }
        //        if (elippses != null)
        //        {
        //            for (i = 0; i < elippses.Length; i++)
        //                if (diem_elip(x, y, elippses[i]) == 1)
        //                {
        //                    elip temp = elippses[i];
        //                    Formelip f = new Formelip(temp);
        //                    f.ShowDialog();
        //                    if (f.xoa == 1)//da chon nut xoa
        //                    {
        //                        elippses = Delete(i, elippses);
        //                    }
        //                    else elippses[i] = f.getvalue();
        //                    panel1.Refresh();
        //                    chon = f.chon;
        //                    if (chon != 0)
        //                    {
        //                        if (chon == 7)
        //                        {
        //                            mauto = f.mauto;
        //                            tomau_dongquet(elippses[i].tam, mauto, elippses[i].mau);
        //                        }
        //                        else
        //                        {
        //                            loaihinh = 4;
        //                            stt = i;

        //                            gocquay = f.gocquay;
        //                            hsbd = f.hsbd;
        //                            sx = f.sx;
        //                            sy = f.sy;
        //                            diems[2].X = x; diems[2].Y = y;
        //                        }
        //                    }
        //                    return;
        //                }
        //        }
        //        if (hinhbhs != null)
        //        {
        //            for (i = 0; i < hinhbhs.Length; i++)
        //                if (diem_hbh(x, y, hinhbhs[i]) == 1)
        //                {
        //                    hbh temp = hinhbhs[i];
        //                    Formhbh f = new Formhbh(temp);
        //                    f.ShowDialog();
        //                    if (f.xoa == 1)//da chon nut xoa
        //                    {
        //                        hinhbhs = Delete(i, hinhbhs);
        //                    }
        //                    else hinhbhs[i] = f.getvalue();
        //                    panel1.Refresh();
        //                    chon = f.chon;
        //                    if (chon != 0)
        //                    {
        //                        if (chon == 7)
        //                        {
        //                            mauto = f.mauto;
        //                            Point tam = new Point(s.round(hinhbhs[i].d1.X + (hinhbhs[i].d2.X - hinhbhs[i].d1.X) / 2), s.round(hinhbhs[i].d1.Y + (hinhbhs[i].d3.Y - hinhbhs[i].d1.Y) / 2));
        //                            tomau_dongquet(tam, mauto, hinhbhs[i].mau);
        //                        }
        //                        else
        //                        {
        //                            loaihinh = 5;
        //                            stt = i;
        //                            diems[2].X = x; diems[2].Y = y;
        //                            gocquay = f.gocquay;
        //                            hsbd = f.hsbd;
        //                            sx = f.sx;
        //                            sy = f.sy;
        //                        }
        //                    }
        //                    return;
        //                }
        //        }

        //    }

        //}

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            chonhinh = 0;//ve duong thang
            click = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chonhinh = 1;//ve duong tron
            click = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chonhinh = 2;//ve hinh vuong
            click = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chonhinh = 3;//ve hcn
            click = -1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chonhinh = 4;//ve elip
            click = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            chonhinh = 5;//ve hbh
            click = -1;
        }

        private void fillleft(int x, int y, Color F, Color B)
        {
            Color mauhientai = getcolor(x, y);
            if (mauhientai != F && mauhientai != B)
            {
                putpixel(x, y, F);
                fillleft(x - 5, y, F, B);
                filltop(x, y + 5, F, B);
                fillbottom(x, y - 5, F, B);
            }
        }
        private void filltop(int x, int y, Color F, Color B)
        {
            Color mauhientai = getcolor(x, y);
            if (mauhientai != F && mauhientai != B)
            {
                putpixel(x, y, F);
                fillleft(x - 5, y, F, B);
                filltop(x, y + 5, F, B);
                fillright(x + 5, y, F, B);
            }
        }
        private void fillright(int x, int y, Color F, Color B)
        {
            Color mauhientai = getcolor(x, y);
            if (mauhientai != F && mauhientai != B)
            {
                putpixel(x, y, F);
                filltop(x, y + 5, F, B);
                fillright(x + 5, y, F, B);
                fillbottom(x, y - 5, F, B);
            }
        }
        private void fillbottom(int x, int y, Color F, Color B)
        {
            Color mauhientai = getcolor(x, y);
            if (mauhientai != F && mauhientai != B)
            {
                putpixel(x, y, F);
                fillleft(x - 5, y, F, B);
                fillright(x + 5, y, F, B);
                fillbottom(x, y - 5, F, B);
            }
        }
        public void tomau_dongquet(Point diem, Color F, Color B)
        {
            int x, y;
            x = diem.X; y = diem.Y;
            Color mauhientai = getcolor(x, y);
            if (mauhientai != F && mauhientai != B)
            {
                putpixel(x, y, F);
                fillleft(x - 5, y, F, B);
                filltop(x, y + 5, F, B);
                fillright(x + 5, y, F, B);
                fillbottom(x, y - 5, F, B);
            }
        }
        ///////////////////////////////////////////////////////////////////
        public Point nhanMT2(int[,] matran, int[] mang)
        {
            int[] mangtam;
            mangtam = new int[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(mangtam[0], mangtam[1]);
            return pt;
        }
        public Point nhanMT2(float[,] matran, float[] mang)//
        {
            float[] mangtam;

            mangtam = new float[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(Convert.ToInt16(mangtam[0]), Convert.ToInt16(mangtam[1]));
            return pt;
        }
        public Point nhanMT2(double[,] matran, double[] mang)
        {
            double[] mangtam;
            mangtam = new double[3];

            int dem = 0;
            for (int i = 0; i < 3; i++)
            {
                mangtam[i] = mang[0] * matran[0, dem] + mang[1] * matran[1, dem] + mang[2] * matran[2, dem];
                dem++;
            }

            Point pt = new Point(Convert.ToInt16(mangtam[0]), Convert.ToInt16(mangtam[1]));
            return pt;
        }
        //////////////////////////////////////////////////////////
        public void bd_doixung()
        {
            if (loaihinh == 0) //duongthang
            {
                // dthang temp1=new dthang(lines[stt].diemdau,lines[stt].diemcuoi,lines[stt].mau);
                dthang temp = new dthang(doixung(lines[stt].diemdau, diems[0]), doixung(lines[stt].diemcuoi, diems[0]), lines[stt].mau);
                DDA_Line(temp);
                lines[stt] = temp;
                DDA_Line(lines[stt]);
            }
            else if (loaihinh == 1)//dtron
            {
                htron temp = new htron(circles[stt].bkinh, doixung(circles[stt].tam, diems[0]), circles[stt].mau);
                Midpoint_htron(temp);
                circles[stt] = temp;
                Midpoint_htron(circles[stt]);
            }
            else if (loaihinh == 2)//hvuong
            {

                hvuong temp = new hvuong(doixung(squares[stt].d1, diems[0]), doixung(squares[stt].d2, diems[0]), doixung(squares[stt].d3, diems[0]), doixung(squares[stt].d4, diems[0]), squares[stt].mau);
                hinhvuong(temp);
                squares[stt] = temp;
                hinhvuong(squares[stt]);
            }
            else if (loaihinh == 3)//hcn
            {
                hcn temp = new hcn(doixung(rectangles[stt].d1, diems[0]), doixung(rectangles[stt].d2, diems[0]), doixung(rectangles[stt].d3, diems[0]), doixung(rectangles[stt].d4, diems[0]), rectangles[stt].mau);
                hinhcn(temp);
                rectangles[stt] = temp;
                hinhcn(rectangles[stt]);
            }
            else if (loaihinh == 4)//elip
            {
                elip temp = new elip(doixung(elippses[stt].tam, diems[0]), elippses[stt].a, elippses[stt].b, elippses[stt].mau);
                Midpoint_elip(temp);
                elippses[stt] = temp;
                Midpoint_elip(elippses[stt]);
            }
            else //(loaihinh==5)//hbh
            {
                hbh temp = new hbh(doixung(hinhbhs[stt].d1, diems[0]), doixung(hinhbhs[stt].d2, diems[0]), doixung(hinhbhs[stt].d3, diems[0]), doixung(hinhbhs[stt].d4, diems[0]), hinhbhs[stt].mau);
                hinhbinhhanh(temp);
                hinhbhs[stt] = temp;
                hinhbinhhanh(hinhbhs[stt]);
            }


            chon = 8;//ketthucbiendoi(de click chuot them 1 lan nua thi ket thuc bien doi)
        }


        public void bd_Doixung()
        {
            if (diems[1].X == diems[0].X)
            {
                int x = diems[0].X;
                if (loaihinh == 0)//dthang
                {
                    dthang temp = new dthang(dxungOy(lines[stt].diemdau, x), dxungOy(lines[stt].diemcuoi, x), lines[stt].mau);
                    DDA_Line(temp);
                    // lines[stt] = temp;
                }
                else if (loaihinh == 1)//dtron
                {
                    htron temp = new htron(circles[stt].bkinh, dxungOy(circles[stt].tam, x), circles[stt].mau);
                    Midpoint_htron(temp);
                    //  circles[stt] = temp;
                }
                else if (loaihinh == 2)//hvuong
                {
                    hvuong temp = new hvuong(dxungOy(squares[stt].d1, x), dxungOy(squares[stt].d2, x), dxungOy(squares[stt].d3, x), dxungOy(squares[stt].d4, x), squares[stt].mau);
                    hinhvuong(temp);
                    // squares[stt] = temp;
                }
                else if (loaihinh == 3)//hcn
                {
                    hcn temp = new hcn(dxungOy(rectangles[stt].d1, x), dxungOy(rectangles[stt].d2, x), dxungOy(rectangles[stt].d3, x), dxungOy(rectangles[stt].d4, x), rectangles[stt].mau);
                    hinhcn(temp);
                    //  rectangles[stt] = temp;
                }
                else if (loaihinh == 4)//elip
                {
                    elip temp = new elip(dxungOy(elippses[stt].tam, x), elippses[stt].a, elippses[stt].b, elippses[stt].mau);
                    Midpoint_elip(temp);
                    //  elippses[stt] = temp;
                }
                else //if(loaihinh==5)//hbh
                {
                    hbh temp = new hbh(dxungOy(hinhbhs[stt].d1, x), dxungOy(hinhbhs[stt].d2, x), dxungOy(hinhbhs[stt].d3, x), dxungOy(hinhbhs[stt].d4, x), hinhbhs[stt].mau);
                    hinhbinhhanh(temp);
                    //  hinhbhs[stt] = temp;
                }
            }
            else
            {
                Point dd1, dd2;
                dd1 = this.s.toado1(diems[0].X, diems[0].Y);
                dd2 = this.s.toado1(diems[1].X, diems[1].Y);
                double hsg = (dd2.Y - dd1.Y) / (dd2.X - dd1.X);
                int b = (int)(dd1.Y - hsg * dd1.X);
                if (loaihinh == 0)//dthang
                {
                    dthang temp = new dthang(Doixung(hsg, b, lines[stt].diemdau), Doixung(hsg, b, lines[stt].diemcuoi), lines[stt].mau);
                    DDA_Line(temp);
                    // lines[stt] = temp;
                }
                else if (loaihinh == 1)//dtron
                {
                    htron temp = new htron(circles[stt].bkinh, Doixung(hsg, b, circles[stt].tam), circles[stt].mau);
                    Midpoint_htron(temp);
                    // circles[stt] = temp;
                }
                else if (loaihinh == 2)//hvuong
                {
                    hvuong temp = new hvuong(Doixung(hsg, b, squares[stt].d1), Doixung(hsg, b, squares[stt].d2), Doixung(hsg, b, squares[stt].d3), Doixung(hsg, b, squares[stt].d4), squares[stt].mau);
                    hinhvuong(temp);
                    //  squares[stt] = temp;
                }
                else if (loaihinh == 3)//hcn
                {
                    hcn temp = new hcn(Doixung(hsg, b, rectangles[stt].d1), Doixung(hsg, b, rectangles[stt].d2), Doixung(hsg, b, rectangles[stt].d3), Doixung(hsg, b, rectangles[stt].d4), rectangles[stt].mau);
                    hinhcn(temp);
                    //  rectangles[stt] = temp;
                }
                else if (loaihinh == 4)//elip
                {
                    elip temp = new elip(Doixung(hsg, b, elippses[stt].tam), elippses[stt].a, elippses[stt].b, elippses[stt].mau);
                    Midpoint_elip(temp);
                    //  elippses[stt] = temp;
                }
                else //if(loaihinh==5)//hbh
                {
                    hbh temp = new hbh(Doixung(hsg, b, hinhbhs[stt].d1), Doixung(hsg, b, hinhbhs[stt].d2), Doixung(hsg, b, hinhbhs[stt].d3), Doixung(hsg, b, hinhbhs[stt].d4), hinhbhs[stt].mau);
                    hinhbinhhanh(temp);
                    //  hinhbhs[stt] = temp;
                }
            }
            chon = 8;
        }
        /* public void bd_Doixung() //
          {
              Point p1;
              Point p2;
              Point p3;

              dthang truc = new dthang(diems[0],diems[1],Color.DarkGreen);

              /*Point dd1, dd2;
              dd1 = this.s.toado1(diems[0].X, diems[0].Y);
              dd2 = this.s.toado1(diems[1].X, diems[1].Y);
              double hsg = (dd2.Y - dd1.Y) / (dd2.X - dd1.X);
              int b = (int)(dd1.Y - hsg * dd1.X);*/
        /*    double m=truc.gethsg();
             int b=truc.getb();
              if (loaihinh == 0)// doi xung 1 duong thang qua 1 duong thang
              {
                  if (truc.diemdau.X == truc.diemcuoi.X)// doi xung qua duong thang //voi truc tung
                  {
                      p1 = new Point(truc.diemdau.X - lines[stt].diemdau.X, lines[stt].diemdau.Y);
                      p2 = new Point(truc.diemdau.X- lines[stt].diemcuoi.X, lines[stt].diemcuoi.Y);
                  }
                  else
                  {
                      p1 = this.Doixung(m, b, lines[stt].diemdau);
                      p2 = this.Doixung(m, b, lines[stt].diemcuoi);
                  }
                  dthang dx = new dthang(p1, p2,Color.DarkGreen);
                  this.DDA_Line(lines[stt]);
                  this.DDA_Line(dx);
                  //this.drawdt(truc.diemdau.x, truc.diemdau.y, truc.diemcuoi.x, truc.diemcuoi.y); }
              }
              if (loaihinh == 1)// doi xung 1 hinh tron qua 1 duong thang
              {
                  if (truc.diemdau.X == truc.diemcuoi.X)// doi xung qua duong thang //voi truc tung
                      p1 = new Point(truc.diemdau.X - circles[stt].tam.X, circles[stt].tam.Y);
                  else p1 = Doixung(m, b, circles[stt].tam);
                  htron dx = new htron(circles[stt].bkinh, p1, Color.DarkGreen);
                  Midpoint_htron(circles[stt]);

                  this.Midpoint_htron(dx);
              }
                  // this.drawdt(truc.diemdau.x, truc.diemdau.y, truc.diemcuoi.x, truc.diemcuoi.y); }

                  if (loaihinh == 4)// doi xung 1 ellip qua 1 duong thang
                  {
                      if (truc.diemdau.X == truc.diemcuoi.X)// doi xung qua duong thang //voi truc tung
                          p1 = new Point(truc.diemdau.X - elippses[stt].tam.X, elippses[stt].tam.Y);
                      else p1 = this.Doixung(m, b, elippses[stt].tam);
                    elip dx = new elip(p1, elippses[stt].a, elippses[stt].b, Color.DarkGreen);
                      Midpoint_elip(elippses[stt]);
                      Midpoint_elip(dx);

                      //  this.drawdt(truc.diemdau.X, truc.diemdau.Y, truc.diemcuoi.X, truc.diemcuoi.Y);
                  }
                  if (loaihinh == 3)// doi xung 1 hinh chu nhat qua 1 duong thang
                  {
                      if (truc.diemdau.X == truc.diemcuoi.X)// doi xung qua duong thang //voi truc tung
                      {
                          p1 = new Point(truc.diemdau.X - rectangles[stt].d1.X, rectangles[stt].d1.Y);
                          p2 = new Point(truc.diemdau.X - rectangles[stt].d2.X, rectangles[stt].d2.Y);
                      }
                      else
                      {
                          p1 = this.Doixung(m, b, rectangles[stt].d1);
                          p2 = this.Doixung(m, b, rectangles[stt].d2);
                      }
                      hcn dx = new hcn(p1, p2, Color.DarkGreen);
                      hinhcn(rectangles[stt]);
                      hinhcn(dx);
                      //this.drawdt(truc.diemdau.x, truc.diemdau.y, truc.diemcuoi.x, truc.diemcuoi.y);
                  }
                  if (loaihinh == 2)// doi xung 1 hinh vuong qua 1 duong thang
                  {
                      if (truc.diemdau.X == truc.diemcuoi.X)// doi xung qua duong thang //voi truc tung
                      {
                          p1 = new Point(truc.diemdau.Y - squares[stt].d1.X, squares[stt].d1.Y);
                          p2 = new Point(truc.diemdau.X - squares[stt].d2.X, squares[stt].d2.Y);
                      }
                      else
                      {
                          p1 = this.Doixung(m, b, squares[stt].d1);
                          p2 = this.Doixung(m, b, squares[stt].d2);
                      }
                      p3 = new Point(p2.X, p2.Y- squares[stt].canh);
                      hcn dx = new hcn(p1, p3, Color.DarkGreen);
                      hinhvuong(squares[stt]);
                      hinhcn(dx);
                      // this.drawdt(truc.diemdau.x, truc.diemdau.y, truc.diemcuoi.x, truc.diemcuoi.y);
                  }
                  if (loaihinh == 5)// doi xung 1 hinh binh hanh qua 1 duong thang
                  {
                      if (truc.diemdau.X == truc.diemcuoi.X)// doi xung qua duong thang //voi truc tung
                      {
                          p1 = new Point(truc.diemdau.X - hinhbhs[stt].d1.X, hinhbhs[stt].d1.Y);
                          p2 = new Point(truc.diemdau.X- hinhbhs[stt].d2.X, hinhbhs[stt].d2.Y);
                          p3 = new Point(truc.diemdau.X - hinhbhs[stt].d3.X, hinhbhs[stt].d3.Y);
                      }
                      else
                      {
                          p1 = this.Doixung(m, b, hinhbhs[stt].d1);
                          p2 = this.Doixung(m, b, hinhbhs[stt].d2) ;
                          p3 = this.Doixung(m, b, hinhbhs[stt].d3);
                      }
                      hbh dx = new hbh(p1, p2, p3, Color.DarkGreen);
                      hinhbinhhanh(hinhbhs[stt]);
                      hinhbinhhanh(dx); ;
                      // this.drawdt(truc.diemdau.x, truc.diemdau.y, truc.diemcuoi.x, truc.diemcuoi.y);
                  }

                  //else MessageBox.Show("Chua cung cap du du lieu de ve !!!");

              chon = 8;
          }*/
        public void bd_tinhtien(int dx, int dy)
        {
            if (loaihinh == 0)//dthang
            {

                dthang temp = new dthang(Tinhtien(lines[stt].diemdau, dx, dy), Tinhtien(lines[stt].diemcuoi, dx, dy), lines[stt].mau);
                DDA_Line(temp);
                lines[stt] = temp;
            }
            else if (loaihinh == 1)//dtron
            {
                htron temp = new htron(circles[stt].bkinh, Tinhtien(circles[stt].tam, dx, dy), circles[stt].mau);
                Midpoint_htron(temp);
                circles[stt] = temp;
            }
            else if (loaihinh == 2)//hvuong
            {

                hvuong temp = new hvuong(Tinhtien(squares[stt].d1, dx, dy), Tinhtien(squares[stt].d2, dx, dy), Tinhtien(squares[stt].d3, dx, dy), Tinhtien(squares[stt].d4, dx, dy), squares[stt].mau);
                hinhvuong(temp);
                squares[stt] = temp;
            }
            else if (loaihinh == 3)//hcn
            {
                hcn temp = new hcn(Tinhtien(rectangles[stt].d1, dx, dy), Tinhtien(rectangles[stt].d2, dx, dy), Tinhtien(rectangles[stt].d3, dx, dy), Tinhtien(rectangles[stt].d4, dx, dy), rectangles[stt].mau);
                hinhcn(temp);
                rectangles[stt] = temp;
            }
            else if (loaihinh == 4)//elip
            {
                elip temp = new elip(Tinhtien(elippses[stt].tam, dx, dy), elippses[stt].a, elippses[stt].b, elippses[stt].mau);
                Midpoint_elip(temp);
                elippses[stt] = temp;
            }
            else //if (loaihinh == 5)//hbh
            {
                hbh temp = new hbh(Tinhtien(hinhbhs[stt].d1, dx, dy), Tinhtien(hinhbhs[stt].d2, dx, dy), Tinhtien(hinhbhs[stt].d3, dx, dy), Tinhtien(hinhbhs[stt].d4, dx, dy), hinhbhs[stt].mau);
                hinhbinhhanh(temp);
                hinhbhs[stt] = temp;
            }

            chon = 8;
        }
        public void bd_quay()
        {
            if (loaihinh == 0)//dthang
            {
                dthang temp = new dthang(Quay(lines[stt].diemdau, diems[0]), Quay(lines[stt].diemcuoi, diems[0]), lines[stt].mau);
                DDA_Line(temp);
                lines[stt] = temp;
            }
            else if (loaihinh == 1)//dtron
            {
                htron temp = new htron(circles[stt].bkinh, Quay(circles[stt].tam, diems[0]), circles[stt].mau);
                Midpoint_htron(temp);
                circles[stt] = temp;
            }
            else if (loaihinh == 2)//hvuong
            {

                hvuong temp = new hvuong(Quay(squares[stt].d1, diems[0]), Quay(squares[stt].d2, diems[0]), Quay(squares[stt].d3, diems[0]), Quay(squares[stt].d4, diems[0]), squares[stt].mau);
                hinhvuong(temp);
                squares[stt] = temp;
            }
            else if (loaihinh == 3)//hcn
            {
                hcn temp = new hcn(Quay(rectangles[stt].d1, diems[0]), Quay(rectangles[stt].d2, diems[0]), Quay(rectangles[stt].d3, diems[0]), Quay(rectangles[stt].d4, diems[0]), rectangles[stt].mau);
                hinhcn(temp);
                rectangles[stt] = temp;
            }
            else if (loaihinh == 4)//elip
            {
                elip temp = new elip(Quay(elippses[stt].tam, diems[0]), elippses[stt].a, elippses[stt].b, elippses[stt].mau);
                Midpoint_elip(temp);
                elippses[stt] = temp;
            }
            else //if (loaihinh == 5)//hbh
            {
                hbh temp = new hbh(Quay(hinhbhs[stt].d1, diems[0]), Quay(hinhbhs[stt].d2, diems[0]), Quay(hinhbhs[stt].d3, diems[0]), Quay(hinhbhs[stt].d4, diems[0]), hinhbhs[stt].mau);
                hinhbinhhanh(temp);
                hinhbhs[stt] = temp;
            }

            chon = 8;
        }
        public void bd_tyle()
        {
            if (loaihinh == 0)//dthang
            {
                dthang temp = new dthang(tyle(lines[stt].diemdau, diems[0]), tyle(lines[stt].diemcuoi, diems[0]), lines[stt].mau);
                DDA_Line(temp);
                lines[stt] = temp;
            }
            else if (loaihinh == 1)//dtron
            {
                htron temp = new htron(circles[stt].bkinh, tyle(circles[stt].tam, diems[0]), circles[stt].mau);
                Midpoint_htron(temp);
                circles[stt] = temp;
            }
            else if (loaihinh == 2)//hvuong
            {

                hbh temp = new hbh(tyle(squares[stt].d1, diems[0]), tyle(squares[stt].d2, diems[0]), tyle(squares[stt].d4, diems[0]), tyle(squares[stt].d3, diems[0]), squares[stt].mau);
                hinhbinhhanh(temp);
                this.Add(temp);
                squares = this.Delete(stt, squares);
            }
            else if (loaihinh == 3)//hcn
            {
                hbh temp = new hbh(tyle(rectangles[stt].d1, diems[0]), tyle(rectangles[stt].d4, diems[0]), tyle(rectangles[stt].d2, diems[0]), tyle(rectangles[stt].d3, diems[0]), rectangles[stt].mau);
                hinhbinhhanh(temp);
                this.Add(temp);
                rectangles = this.Delete(stt, rectangles);
            }
            else if (loaihinh == 4)//elip
            {
                elip temp = new elip(tyle(elippses[stt].tam, diems[0]), elippses[stt].a, elippses[stt].b, elippses[stt].mau);
                Midpoint_elip(temp);
                elippses[stt] = temp;
            }
            else //if (loaihinh == 5)//hbh
            {
                hbh temp = new hbh(tyle(hinhbhs[stt].d1, diems[0]), tyle(hinhbhs[stt].d2, diems[0]), tyle(hinhbhs[stt].d3, diems[0]), tyle(hinhbhs[stt].d4, diems[0]), hinhbhs[stt].mau);
                hinhbinhhanh(temp);
                hinhbhs[stt] = temp;
            }

            chon = 8;
        }

        public void bd_biendang()
        {
            if (diems[1].X == diems[0].X)
            {
                int x = diems[0].X / 5 - 40;
                if (loaihinh == 0)//dthang
                {
                    dthang temp = new dthang(biendangOy(lines[stt].diemdau, x), biendangOy(lines[stt].diemcuoi, x), lines[stt].mau);
                    DDA_Line(temp);
                    lines[stt] = temp;
                }
                else if (loaihinh == 1)//dtron
                {
                    Point d1, d2, d3;
                    d1 = biendangOy(circles[stt].tam, x);
                    d2 = biendangOy(new Point(circles[stt].tam.X + circles[stt].bkinh, circles[stt].tam.Y), x);
                    d3 = biendangOy(new Point(circles[stt].tam.X, circles[stt].tam.Y + circles[stt].bkinh), x);
                    int c1, c2;
                    c1 = Math.Abs(d2.X - d1.X);
                    c2 = Math.Abs(d3.Y - d1.Y);
                    if (c1 == c2)
                    {
                        htron temp = new htron(c1, d1, circles[stt].mau);
                        Midpoint_htron(temp);
                        circles[stt] = temp;
                    }
                    else //dtron bi bien dang thanh elip
                    {
                        elip temp = new elip(d1, c1, c2, circles[stt].mau);
                        Midpoint_elip(temp);
                        Add(temp);
                        circles = this.Delete(stt, circles);

                    }
                }
                else if (loaihinh == 2)//hvuong
                {
                    hbh temp = new hbh(biendangOy(squares[stt].d1, x), biendangOy(squares[stt].d2, x), biendangOy(squares[stt].d4, x), biendangOy(squares[stt].d3, x), squares[stt].mau);
                    hinhbinhhanh(temp);
                    this.Add(temp);
                    squares = this.Delete(stt, squares);
                }
                else if (loaihinh == 3)//hcn
                {
                    hbh temp = new hbh(biendangOy(rectangles[stt].d1, x), biendangOy(rectangles[stt].d4, x), biendangOy(rectangles[stt].d2, x), biendangOy(rectangles[stt].d3, x), rectangles[stt].mau);
                    hinhbinhhanh(temp);
                    this.Add(temp);
                    rectangles = this.Delete(stt, rectangles);
                }
                else if (loaihinh == 4)//elip
                {
                    Point d1, d2, d3;
                    d1 = biendangOy(elippses[stt].tam, x);
                    d2 = biendangOy(new Point(elippses[stt].tam.X + elippses[stt].a, elippses[stt].tam.Y), x);
                    d3 = biendangOy(new Point(elippses[stt].tam.X, elippses[stt].tam.Y + elippses[stt].b), x);
                    int c1, c2;
                    c1 = Math.Abs(d2.X - d1.X);
                    c2 = Math.Abs(d3.Y - d1.Y);
                    if (c1 != c2)
                    {
                        elip temp = new elip(d1, c1, c2, elippses[stt].mau);
                        Midpoint_elip(temp);
                        elippses[stt] = temp;
                    }
                    else//elip bi bien dang thanh hinh tron
                    {
                        htron temp = new htron(c1, d1, elippses[stt].mau);
                        Midpoint_htron(temp);
                        this.Add(temp);
                        elippses = this.Delete(stt, elippses);
                    }
                }
                else //if (loaihinh == 5)//hbh
                {
                    hbh temp = new hbh(biendangOy(hinhbhs[stt].d1, x), biendangOy(hinhbhs[stt].d2, x), biendangOy(hinhbhs[stt].d3, x), biendangOy(hinhbhs[stt].d4, x), hinhbhs[stt].mau);
                    hinhbinhhanh(temp);
                    hinhbhs[stt] = temp;
                }
            }
            else
            {
                Point dd1, dd2;
                dd1 = this.s.toado1(diems[0].X, diems[0].Y);
                dd2 = this.s.toado1(diems[1].X, diems[1].Y);
                double hsg = (dd2.Y - dd1.Y) / (dd2.X - dd1.X);
                int b = (int)(dd1.Y - hsg * dd1.X);
                if (loaihinh == 0)//dthang
                {
                    dthang temp = new dthang(BienDang(hsg, b, lines[stt].diemdau), BienDang(hsg, b, lines[stt].diemcuoi), lines[stt].mau);
                    DDA_Line(temp);
                    lines[stt] = temp;
                }
                else if (loaihinh == 1)//dtron
                {
                    Point d1, d2, d3;
                    d1 = BienDang(hsg, b, circles[stt].tam);
                    d2 = BienDang(hsg, b, new Point(circles[stt].tam.X + circles[stt].bkinh, circles[stt].tam.Y));
                    d3 = BienDang(hsg, b, new Point(circles[stt].tam.X, circles[stt].tam.Y + circles[stt].bkinh));
                    int c1, c2;
                    c1 = Math.Abs(d2.X - d1.X);
                    c2 = Math.Abs(d3.Y - d1.Y);
                    if (c1 == c2)
                    {
                        htron temp = new htron(c1, d1, circles[stt].mau);
                        Midpoint_htron(temp);
                        circles[stt] = temp;
                    }
                    else //dtron bi bien dang thanh duong thang
                    {
                        elip temp = new elip(d1, c1, c2, circles[stt].mau);
                        Midpoint_elip(temp);

                        this.Add(temp);
                        circles = Delete(stt, circles);


                    }
                }
                else if (loaihinh == 2)//hvuong
                {
                    hbh temp = new hbh(BienDang(hsg, b, squares[stt].d1), BienDang(hsg, b, squares[stt].d2), BienDang(hsg, b, squares[stt].d4), BienDang(hsg, b, squares[stt].d3), squares[stt].mau);
                    hinhbinhhanh(temp);
                    Add(temp);
                    squares = this.Delete(stt, squares);
                }
                else if (loaihinh == 3)//hcn
                {
                    hbh temp = new hbh(BienDang(hsg, b, rectangles[stt].d1), BienDang(hsg, b, rectangles[stt].d4), BienDang(hsg, b, rectangles[stt].d2), BienDang(hsg, b, rectangles[stt].d3), rectangles[stt].mau);
                    hinhbinhhanh(temp);
                    this.Add(temp);
                    rectangles = this.Delete(stt, rectangles);
                }
                else if (loaihinh == 4)//elip
                {
                    Point d1, d2, d3;
                    d1 = BienDang(hsg, b, elippses[stt].tam);
                    d2 = BienDang(hsg, b, new Point(elippses[stt].tam.X + elippses[stt].a, elippses[stt].tam.Y));
                    d3 = BienDang(hsg, b, new Point(elippses[stt].tam.X, elippses[stt].tam.Y + elippses[stt].b));
                    int c1, c2;
                    c1 = Math.Abs(d2.X - d1.X);
                    c2 = Math.Abs(d3.Y - d1.Y);
                    if (c1 != c2)
                    {
                        elip temp = new elip(d1, c1, c2, elippses[stt].mau);
                        Midpoint_elip(temp);
                        elippses[stt] = temp;
                    }
                    else//elip bi bien dang thanh hinh tron
                    {
                        htron temp = new htron(c1, d1, elippses[stt].mau);
                        Midpoint_htron(temp);
                        this.Add(temp);
                        elippses = Delete(stt, elippses);


                    }
                }
                else //if (loaihinh == 5)//hbh
                {
                    hbh temp = new hbh(BienDang(hsg, b, hinhbhs[stt].d1), BienDang(hsg, b, hinhbhs[stt].d2), BienDang(hsg, b, hinhbhs[stt].d3), BienDang(hsg, b, hinhbhs[stt].d4), hinhbhs[stt].mau);
                    hinhbinhhanh(temp);
                    hinhbhs[stt] = temp;
                }
            }
            //luu = 1;
            chon = 8;
        }

        /////////////////////////////////////////////
        //DOI XUNG...
        public Point doixung(Point d1, Point d2)// ve diem doi xung cua (x1,y1)qua tam doi xung (x2,y2)
        {
            int x1, y1, x2, y2;
            x1 = d1.X; y1 = d1.Y; x2 = d2.X; y2 = d2.Y;
            int[,] matran1;
            int[,] matran2;
            int[] mang;
            int[] mangtam = { 0, 0, 0 };
            mangtam = new int[3];
            mang = new int[3];
            matran1 = new int[3, 3];
            matran2 = new int[3, 3];
            // putpixel(x1, x2, getcolor(x1, y1)); putpixel(pt2.X, pt2.Y, getcolor(x1, y1));
            // putPixel(x1, y1, x1, y1, 0, 0, 0);// diem P...
            // putPixel(x2, y2, x2, y2, 0, 0, 1);// Tam doi xung...
            //Ma tran tinh tien ve tam I rki sau do lay doi xung p' qua tam I
            matran1[0, 0] = -1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = -1; matran1[1, 2] = 0;
            matran1[2, 0] = x2; matran1[2, 1] = y2; matran1[2, 2] = 1;
            mang[0] = x1; mang[1] = y1; mang[2] = 1;
            Point pt1 = nhanMT2(matran1, mang);
            matran2[0, 0] = 1; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = 0; matran2[1, 1] = 1; matran2[1, 2] = 0;
            matran2[2, 0] = x2; matran2[2, 1] = y2; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = nhanMT2(matran2, mang);
            Point kq = new Point(s.round(pt2.X), s.round(pt2.Y));
            return kq;
        }
        public Point dxungOy(Point diem, int x)
        {
            Point temp = new Point(0, 0);
            if (diem.X < x) temp.X = diem.X + 2 * (x - diem.X);
            else temp.X = diem.X - 2 * (diem.X - x);
            temp.Y = diem.Y;
            return temp;
        }
        //DOI XUNG QUA DUONG THANG BAT KI...
        public Point Doixung(double m, int b, Point diem)
        {   // tim diem doi xung cua 1 diem (x,y) qua 1 duong thang y=mx+b
            Point dd = this.s.toado1(diem.X, diem.Y);
            float s = 0, c = 0;
            float[,] matran1;
            float[,] matran2;
            float[,] matran3;
            float[,] matran;
            float[] mang;
            int x, y;
            x = dd.X; y = dd.Y;
            mang = new float[3];
            matran1 = new float[3, 3];
            matran2 = new float[3, 3];
            matran3 = new float[3, 3];
            matran = new float[3, 3];
            mang = new float[3];
            float tam = Convert.ToSingle(Math.Pow(m, 2));
            float a = -1 * Convert.ToSingle(Math.Atan(m));
            c = Convert.ToSingle(Math.Cos(a));
            s = Convert.ToSingle(Math.Sin(a));

            // ma tran tinh tien duong thang ve thanh duong thang di qua goc t/d O...
            matran[0, 0] = 1; matran[0, 1] = 0; matran[0, 2] = 0;
            matran[1, 0] = 0; matran[1, 1] = 1; matran[1, 2] = 0;
            matran[2, 0] = 0; matran[2, 1] = -b; matran[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt = nhanMT2(matran, mang);

            //ma tran quay duong thang ve trung truc Ox
            matran1[0, 0] = c; matran1[0, 1] = s; matran1[0, 2] = 0;
            matran1[1, 0] = -1 * s; matran1[1, 1] = c; matran1[1, 2] = 0;
            matran1[2, 0] = 0; matran1[2, 1] = 0; matran1[2, 2] = 1;
            mang[0] = pt.X; mang[1] = pt.Y; mang[2] = 1;
            Point pt1 = nhanMT2(matran1, mang);

            //Ma tran cua phep lay doi xung qua truc 0x
            matran2[0, 0] = 1; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = 0; matran2[1, 1] = -1; matran2[1, 2] = 0;
            matran2[2, 0] = 0; matran2[2, 1] = 0; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = nhanMT2(matran2, mang);

            //Ma tran cua phep quay nguoc lai vi tri cu
            matran3[0, 0] = c; matran3[0, 1] = -s; matran3[0, 2] = 0;
            matran3[1, 0] = s; matran3[1, 1] = c; matran3[1, 2] = 0;
            matran3[2, 0] = 0; matran3[2, 1] = 0; matran3[2, 2] = 1;
            mang[0] = pt2.X; mang[1] = pt2.Y; mang[2] = 1;
            Point pt3 = nhanMT2(matran3, mang);

            //Ma tran cua phep tinh tien diem do ve vi tri ban dau 
            matran[0, 0] = 1; matran[0, 1] = 0; matran[0, 2] = 0;
            matran[1, 0] = 0; matran[1, 1] = 1; matran[1, 2] = 0;
            matran[2, 0] = 0; matran[2, 1] = b; matran[2, 2] = 1;
            mang[0] = pt3.X; mang[1] = pt3.Y; mang[2] = 1;
            Point pt4 = nhanMT2(matran, mang);
            Point kq = this.s.toado2(pt4.X, pt4.Y);
            return kq;
        }
        public Point biendangOy(Point diem, int xx)
        {
            Point dd = this.s.toado1(diem.X, diem.Y);
            int x, y;
            x = dd.X; y = dd.Y;
            int shxy = hsbd;
            double[,] matran0;
            double[,] matran1;
            double[,] matran2;

            double[] mang;

            mang = new double[3];
            matran0 = new double[3, 3];
            matran1 = new double[3, 3];
            matran2 = new double[3, 3];

            matran0[0, 0] = 1; matran0[0, 1] = 0; matran0[0, 2] = 0;
            matran0[1, 0] = 0; matran0[1, 1] = 1; matran0[1, 2] = 0;
            matran0[2, 0] = -xx; matran0[2, 1] = 0; matran0[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt0 = nhanMT2(matran0, mang);

            matran1[0, 0] = 1; matran1[0, 1] = shxy; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = 1; matran1[1, 2] = 0;
            matran1[2, 0] = 0; matran1[2, 1] = 0; matran1[2, 2] = 1;
            mang[0] = pt0.X; mang[1] = pt0.Y; mang[2] = 1;
            Point pt1 = nhanMT2(matran1, mang);

            matran2[0, 0] = 1; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = 0; matran2[1, 1] = 1; matran2[1, 2] = 0;
            matran2[2, 0] = xx; matran2[2, 1] = 0; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = nhanMT2(matran2, mang);
            Point kq = this.s.toado2(pt2.X, pt2.Y);
            return kq;
        }
        public Point BienDang(double m, int b, Point diem)
        {// Bien dang diem (x,y)theo phuong duong thang y=mx+b, he so bien dang la shxy
            Point dd = this.s.toado1(diem.X, diem.Y);
            int x, y;
            x = dd.X; y = dd.Y;
            int shxy = hsbd;
            double[,] matran0;
            double[,] matran1;
            double[,] matran2;
            double[,] matran3;
            double[,] matran4;
            double[] mang;
            double c, s, _c, _s;
            mang = new double[3];
            matran0 = new double[3, 3];
            matran1 = new double[3, 3];
            matran2 = new double[3, 3];
            matran3 = new double[3, 3];
            matran4 = new double[3, 3];
            double gocQuay = -1 * Math.Atan(m);

            matran0[0, 0] = 1; matran0[0, 1] = 0; matran0[0, 2] = 0;
            matran0[1, 0] = 0; matran0[1, 1] = 1; matran0[1, 2] = 0;
            matran0[2, 0] = 0; matran0[2, 1] = -b; matran0[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt0 = nhanMT2(matran0, mang);
            //  putPixel(x, y, x, y, 0, 0, 0);

            //Ma tran quay quanh goc toa do mot goc a;
            s = Math.Sin(gocQuay);
            c = Math.Cos(gocQuay);
            matran1[0, 0] = c; matran1[0, 1] = s; matran1[0, 2] = 0;
            matran1[1, 0] = -1 * s; matran1[1, 1] = c; matran1[1, 2] = 0;
            matran1[2, 0] = 0; matran1[2, 1] = 0; matran1[2, 2] = 1;
            mang[0] = pt0.X; mang[1] = pt0.Y; mang[2] = 1;
            Point pt1 = nhanMT2(matran1, mang);

            matran2[0, 0] = 1; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = shxy; matran2[1, 1] = 1; matran2[1, 2] = 0;
            matran2[2, 0] = 0; matran2[2, 1] = 0; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = nhanMT2(matran2, mang);

            _s = -s;
            _c = c;
            matran3[0, 0] = _c; matran3[0, 1] = _s; matran3[0, 2] = 0;
            matran3[1, 0] = -1 * _s; matran3[1, 1] = _c; matran3[1, 2] = 0;
            matran3[2, 0] = 0; matran3[2, 1] = 0; matran3[2, 2] = 1;
            mang[0] = pt2.X; mang[1] = pt2.Y; mang[2] = 1;
            Point pt3 = nhanMT2(matran3, mang);

            matran4[0, 0] = 1; matran4[0, 1] = 0; matran4[0, 2] = 0;
            matran4[1, 0] = 0; matran4[1, 1] = 1; matran4[1, 2] = 0;
            matran4[2, 0] = 0; matran4[2, 1] = b; matran4[2, 2] = 1;
            mang[0] = pt3.X; mang[1] = pt3.Y; mang[2] = 1;
            Point pt4 = nhanMT2(matran4, mang);
            Point kq = this.s.toado2(pt4.X, pt4.Y);
            return kq;
        }
        /*public Point quayvatinhtien(int x, int y, int a, int dx, int dy)
        {  // diem p(x,y)tinh tien theo vecto(dx,dy)roi quay 1 goc a quanh goc toa do 

            double[,] matran1;
            double[,] matran2;
            double[] mang;
            double c, s;
            mang = new double[3];
            matran1 = new double[3, 3];
            matran2 = new double[3, 3];
            //Ma tran quay quanh goc toa do mot goc a;
            s = Math.Sin((Math.PI * a) / 180);
            c = Math.Cos((Math.PI * a) / 180);
            matran1[0, 0] = c; matran1[0, 1] = s; matran1[0, 2] = 0;
            matran1[1, 0] = -1 * s; matran1[1, 1] = c; matran1[1, 2] = 0;
            matran1[2, 0] = 0; matran1[2, 1] = 0; matran1[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt1 = nhanMT2(matran1, mang);
            //Ma tran cua phep tinh tien diem p theo vecter(dx,dy);
            matran2[0, 0] = 1; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = 0; matran2[1, 1] = 1; matran2[1, 2] = 0;
            matran2[2, 0] = dx; matran2[2, 1] = dy; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = nhanMT2(matran2, mang);
          //  putpixel(pt2.X, pt2.Y, getcolor(x, y));
            return pt2;
        }*/
        public Point Tinhtien(Point d1, int dx, int dy)
        {
            int x, y;
            x = d1.X; y = d1.Y;
            double[,] matran1;
            double[] mang;
            mang = new double[3];
            matran1 = new double[3, 3];

            //Ma tran cua phep tinh tien diem p theo vecter(dx,dy);
            matran1[0, 0] = 1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = 1; matran1[1, 2] = 0;
            matran1[2, 0] = dx; matran1[2, 1] = dy; matran1[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt2 = nhanMT2(matran1, mang);
            Point kq = new Point(s.round(pt2.X), s.round(pt2.Y));
            return kq;
        }
        /*  public void heToado1(int a, int dx, int dy)
          {
              Graphics g = this.panel1.CreateGraphics();
              Point pt1, pt2, pt3, pt5, pt4;
              pt1 = quayvatinhtien(0, 200, a, dx, dy);
              pt2 = quayvatinhtien(0, -200, a, dx, dy);
              pt4 = quayvatinhtien(-200, 0, a, dx, dy);
              pt3 = quayvatinhtien(200, 0, a, dx, dy);
              pt5 = quayvatinhtien(0, 0, a, dx, dy);
              g.DrawLine(new Pen(Color.Black), 200 + pt1.x * 10, 200 - pt1.y * 10, pt2.x * 10 + 200, 200 - pt2.y * 10);
              g.DrawLine(new Pen(Color.Black), pt3.x * 10 + 200, 200 - pt3.y * 10, pt4.x * 10 + 200, 200 - pt4.y * 10);
              putPixel(pt5.x, pt5.y, pt5.x, pt5.y, 0, 0, 2);

          }*/
        public Point Quay(Point d1, Point d2)// Quay 1 diem (x,y)quanh diem(xo,yo)1 goc a;
        {
            Point dd1, dd2;
            dd1 = this.s.toado1(d1.X, d1.Y);
            dd2 = this.s.toado1(d2.X, d2.Y);
            int x, y, xo, yo;
            x = dd1.X; y = dd1.Y; xo = dd2.X; yo = dd2.Y;
            int a = gocquay;
            double[,] matran1;
            double[,] matran2;
            double[,] matran3;
            double[] mang;
            double c, s;
            mang = new double[3];
            matran1 = new double[3, 3];
            matran2 = new double[3, 3];
            matran3 = new double[3, 3];
            // ma tran tinh tien (xo,yo)ve goc toa do
            matran1[0, 0] = 1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = 1; matran1[1, 2] = 0;
            matran1[2, 0] = -xo; matran1[2, 1] = -yo; matran1[2, 2] = 1;
            mang[0] = x; mang[1] = y; mang[2] = 1;
            Point pt = nhanMT2(matran1, mang);
            //Ma tran quay quanh goc toa do mot goc a;
            s = Math.Sin((Math.PI * a) / 180);
            c = Math.Cos((Math.PI * a) / 180);
            matran2[0, 0] = c; matran2[0, 1] = s; matran2[0, 2] = 0;
            matran2[1, 0] = -1 * s; matran2[1, 1] = c; matran2[1, 2] = 0;
            matran2[2, 0] = 0; matran2[2, 1] = 0; matran2[2, 2] = 1;
            mang[0] = pt.X; mang[1] = pt.Y; mang[2] = 1;
            Point pt1 = nhanMT2(matran2, mang);
            // ma tran doi diem ve toa do cu
            matran3[0, 0] = 1; matran3[0, 1] = 0; matran3[0, 2] = 0;
            matran3[1, 0] = 0; matran3[1, 1] = 1; matran3[1, 2] = 0;
            matran3[2, 0] = xo; matran3[2, 1] = yo; matran3[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = nhanMT2(matran3, mang);
            Point kq = this.s.toado2(pt2.X, pt2.Y);
            return kq;
        }
        private void HienThiToaDo(Point n, String tenDiem)
        {
            int x = n.X;
            int y = n.Y;
            x = x-450;
            y = 350 - y;
            RTToaDo.Text += tenDiem+ ": X = " + x + ", Y = " + y + "\n";
           
            
            
        }
        
        private void button3_Click_1(object sender, EventArgs e)
        {
            btnVe.Visible = false;
            label42.Visible = false;
            label37.Visible = false;
            label38.Visible = false;
            label39.Visible = false;
            label40.Visible = false;
            label43.Visible = false;
            tbX.Visible = false;
            tbY.Visible = false;
            tbZ.Visible = false;
            tbCanh.Visible = false;
            tbH.Visible = false;
            lbA1.Visible = false;
            lbB1.Visible = false;
            lbC1.Visible = false;
            lbD1.Visible = false;
            lbE1.Visible = false;
            lbA.Visible = false;
            lbB.Visible = false;
            lbC.Visible = false;
            lbD.Visible = false;
            lbE.Visible = false;
            lbF.Visible = false;
            lbG.Visible = false;
            lbI.Visible = false;
            label5.Show();
            label6.Show();
            label8.Show();
            label9.Show();
            label10.Show();
            label11.Show();
            label12.Show();
            label13.Show();
            label14.Show();
            label15.Show();
            label16.Show();
            label17.Show();
            label18.Show();
            label19.Show();
            label20.Show();
            label21.Show();
            label22.Show();
            label23.Show();
            label24.Show();
            label25.Show();
            label26.Show();
            label27.Show();
            label28.Show();
            label30.Show();
            label31.Show();
            label32.Show();
            label29.Show();
            label33.Show();

            //xóa màn hình cũ
            RTToaDo.Clear();
            khoitaobien();
            initbd();
            panel1.Refresh();
            heToaDo();

            // vẽ khung xe
            points[0].X = 300;
            points[0].Y = 300;
            HienThiToaDo(points[0],"B");
            points[1].X = 200;
            points[1].Y = 500;
            HienThiToaDo(points[1],"A");
            dthang dt = new dthang(points[0], points[1], Color.Crimson);
            this.Add(dt);
            DDA_Line(dt);

            points[0].X = 300;
            points[0].Y = 300;
            points[1].X = 700;
            points[1].Y = 300;
            HienThiToaDo(points[1], "C");
            dthang dt2 = new dthang(points[0], points[1], Color.Crimson);
            this.Add(dt2);
            DDA_Line(dt2);

            points[0].X = 700;
            points[0].Y = 300;
            points[1].X = 800;
            points[1].Y = 500;
            HienThiToaDo(points[1], "D");
            dthang dt1 = new dthang(points[0], points[1], Color.Crimson);
            this.Add(dt1);
            DDA_Line(dt1);

            points[0].X = 200;
            points[0].Y = 500;
            points[1].X = 290;
            points[1].Y = 500;
            HienThiToaDo(points[1], "E");
            dthang dt3 = new dthang(points[0], points[1], Color.Crimson);
            this.Add(dt3);
            DDA_Line(dt3);

            points[0].X = 800;
            points[0].Y = 500;
            points[1].X = 710;
            points[1].Y = 500;
            HienThiToaDo(points[1], "F");
            dthang dt5 = new dthang(points[0], points[1], Color.Crimson);
            this.Add(dt5);
            DDA_Line(dt5);


            points[0].X = 410;
            points[0].Y = 500;
            HienThiToaDo(points[0], "G");
            points[1].X = 590;
            points[1].Y = 500;
            HienThiToaDo(points[1], "H");
            dthang dt6 = new dthang(points[0], points[1], Color.Crimson);
            this.Add(dt6);
            DDA_Line(dt6);

            // vẽ nóc xe
            points[0].X = 420;
            points[0].Y = 200;
            HienThiToaDo(points[0], "I");
            points[1].X = 580;
            points[1].Y = 200;
            HienThiToaDo(points[1], "K");
            points[2].X = 630;
            points[2].Y = 300;
            HienThiToaDo(points[2], "L");
            points[3].X = 370;
            points[3].Y = 300;
            HienThiToaDo(points[3], "M");
            hbh hbh = new hbh(points[0], points[1], points[2], points[3], Color.Crimson);
            this.Add(hbh);
            hinhbinhhanh(hbh);

            //kính xe
            points[0].X = 475;
            points[0].Y = 250;
            HienThiToaDo(points[0], "N");
            points[1].X = 555;
            points[1].Y = 300;
            HienThiToaDo(points[1], "O");
            hcn cn = new hcn(points[0], points[1], Color.LightSkyBlue);
            this.Add(cn);
            hinhcn(cn);
            //đường thẳng dọc trong kính xe
            points[0].X = 515;
            points[0].Y = 250;
            HienThiToaDo(points[0], "P");
            points[1].X = 515;
            points[1].Y = 300;
            HienThiToaDo(points[1], "Q");
            dthang dt7 = new dthang(points[0], points[1], Color.LightSkyBlue);
            this.Add(dt7);
            DDA_Line(dt7);

            //đường thẳng ngang trong kính xe
            points[0].X = 475;
            points[0].Y = 275;
            HienThiToaDo(points[0], "R");
            points[1].X = 555;
            points[1].Y = 275;
            HienThiToaDo(points[1], "S");
            dthang dt8 = new dthang(points[0], points[1], Color.LightSkyBlue);
            this.Add(dt8);
            DDA_Line(dt8);



            // tọa độ vạch kẻ đường
            points[10].X = 700;
            points[10].Y = 600;
            points[11].X =900;
            points[11].Y = 630;
            

            //bánh xe1
            int bk = 60;
            points[4].X = 350;
            points[4].Y = 500;
            RTToaDo.Text += "Bán kính vòng tâm T lớn: 60\n";

            HienThiToaDo(points[4], "T");
            htron tr = new htron(bk, points[4], Color.Black);
            this.Add(tr);
            Midpoint_htron(tr);
            htron tr4 = new htron(30, points[4], Color.Black);
            RTToaDo.Text += "Bán kính vòng tâm Y nhỏ: 30\n";

            this.Add(tr4);
            Midpoint_htron(tr4);


            //tăm 1 xe bánh xe  1
            points[0].X = 320;
            points[0].Y = 500;
            HienThiToaDo(points[0], "W");
            points[1].X = 380;
            points[1].Y = 500;
            HienThiToaDo(points[1], "X");
            dthang dt9 = new dthang(points[0], points[1], Color.Green);
            this.Add(dt9);
            DDA_Line(dt9);

            //tăm 2 bánh xe 1
            points[2].X = 350;
            points[2].Y = 470;
            HienThiToaDo(points[2], "U");
            points[3].X = 350;
            points[3].Y = 530;
            HienThiToaDo(points[3], "V");
            dthang dt11 = new dthang(points[2], points[3], Color.Green);
            this.Add(dt11);
            DDA_Line(dt11);

            //bánh xe 2
            points[5].X = 650;
            points[5].Y = 500;
            RTToaDo.Text += "Bán kính vòng tâm Y lớn: 60\n";
            HienThiToaDo(points[5], "Y");
            //vòng tròn lớn bánh xe 2
            htron tr1 = new htron(bk, points[5], Color.Black);
            this.Add(tr1);
            Midpoint_htron(tr1);
            RTToaDo.Text += "Bán kính vòng tròn Y nhỏ: 30\n";
            //vòng tròn nhỏ bánh xe
            htron tr2 = new htron(30, points[5], Color.Black);
            this.Add(tr2);
            Midpoint_htron(tr2);

            //tăm bánh xe 2
            points[6].X = 650;
            points[6].Y = 470;
            HienThiToaDo(points[6], "Z");
            points[7].X = 650;
            points[7].Y = 530;
            HienThiToaDo(points[7], "C1");
            dthang dt12 = new dthang(points[6], points[7], Color.Green);
            this.Add(dt12);
            DDA_Line(dt12);

            //tăm bánh xe 2
            points[8].X = 620;
            points[8].Y = 500;
            HienThiToaDo(points[8], "B1");
            points[9].X = 680;
            points[9].Y = 500;
            HienThiToaDo(points[9], "C1");
            dthang dt10 = new dthang(points[8], points[9], Color.Green);
            this.Add(dt10);
            DDA_Line(dt10);

            int i = 20;


            RTToaDo.Text += "\nPhép quay: \n\n";
            Graphics g = this.panel1.CreateGraphics();
            for (gocquay = 0; gocquay <= 600; gocquay += 15)
            {
                //vẽ hình chữ nhật vạch kẻ đường
                hcn vachduong = new hcn(Tinhtien(points[10],i, 0), Tinhtien(points[11], i, 0), Color.SlateBlue);
                hinhcn(vachduong);

                //quay tăm 1 bánh xe 1
                dthang temp = new dthang(Quay(points[0], points[4]), Quay(points[1], points[4]), Color.Green);
                DDA_Line(temp);
                HienThiToaDo(Quay(points[0], points[4]), "W");
                HienThiToaDo(Quay(points[1], points[4]), "X");

                //quay tăm 1 bánh xe 2
                dthang temp3 = new dthang(Quay(points[6], points[5]), Quay(points[7], points[5]), Color.Green);
                DDA_Line(temp3);
                HienThiToaDo(Quay(points[6], points[5]), "Z");
                HienThiToaDo(Quay(points[7], points[5]), "C1");

                // quay tăm 2 bánh xe 1
                dthang temp2 = new dthang(Quay(points[2], points[4]), Quay(points[3], points[4]), Color.Red);
                DDA_Line(temp2);
                HienThiToaDo(Quay(points[2], points[4]), "U");
                HienThiToaDo(Quay(points[3], points[4]), "V");


                // quay tăm 2 bánh xe 2
                dthang temp4 = new dthang(Quay(points[8], points[5]), Quay(points[9], points[5]), Color.Red);
                DDA_Line(temp4);
                HienThiToaDo(Quay(points[8], points[5]), "B1");
                HienThiToaDo(Quay(points[9], points[5]), "C1");

                ////vẽ hình chữ nhật trắng đè dô
                hcn vachduongtrang = new hcn(Tinhtien(points[10], i, 0), Tinhtien(points[11], i, 0), Color.White);
                hinhcn(vachduongtrang);
                //if (20 + i > 800)
                //{
                //    i -= 180;
                //}
                i -= 20;
            }

        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnVe_Click(object sender, EventArgs e)
        {
            btnVe.Visible = false;
            label42.Visible = false;
            label37.Visible = false;
            label38.Visible = false;
            label39.Visible = false;
            label40.Visible = false;
            label43.Visible = false;
            tbX.Visible = false;
            tbY.Visible = false;
            tbZ.Visible = false;
            tbCanh.Visible = false;
            tbH.Visible = false;
            //vẽ hình lập phương
            if (VeHinh3d == 1)
            {
                
                if (tbX.Text.Equals(""))
                {
                    DialogResult dlr = MessageBox.Show("Bạn chưa nhập tọa độ x", "Thông báo", MessageBoxButtons.OK);
                    if (dlr == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else if (tbY.Text.Equals(""))
                {
                    DialogResult dlr = MessageBox.Show("Bạn chưa nhập tọa độ y", "Thông báo", MessageBoxButtons.OK);
                    if (dlr == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else if (tbZ.Text.Equals(""))
                {
                    DialogResult dlr = MessageBox.Show("Bạn chưa nhập tọa độ Z", "Thông báo", MessageBoxButtons.OK);
                    if (dlr == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else if (tbCanh.Text.Equals(""))
                {
                    DialogResult dlr = MessageBox.Show("Bạn chưa nhập độ dài cạnh", "Thông báo", MessageBoxButtons.OK);
                    if (dlr == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    HinhLapPhuong(int.Parse(tbX.Text), int.Parse(tbY.Text), int.Parse(tbZ.Text), int.Parse(tbCanh.Text));
                    heToaDo3D();
                }
            }

            //vẽ hình chóp
            else if(VeHinh3d == 2)
            {
               
                if (tbX.Text.Equals(""))
                {
                    DialogResult dlr = MessageBox.Show("Bạn chưa nhập tọa độ x", "Thông báo", MessageBoxButtons.OK);
                    if (dlr == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else if (tbY.Text.Equals(""))
                {
                    DialogResult dlr = MessageBox.Show("Bạn chưa nhập tọa độ y", "Thông báo", MessageBoxButtons.OK);
                    if (dlr == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else if (tbZ.Text.Equals(""))
                {
                    DialogResult dlr = MessageBox.Show("Bạn chưa nhập tọa độ Z", "Thông báo", MessageBoxButtons.OK);
                    if (dlr == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else if (tbCanh.Text.Equals(""))
                {
                    DialogResult dlr = MessageBox.Show("Bạn chưa nhập độ dài cạnh", "Thông báo", MessageBoxButtons.OK);
                    if (dlr == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else if (tbCanh.Text.Equals(""))
                {
                    DialogResult dlr = MessageBox.Show("Bạn chưa nhập chiều cao", "Thông báo", MessageBoxButtons.OK);
                    if (dlr == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    HinhChop(int.Parse(tbX.Text), int.Parse(tbY.Text), int.Parse(tbZ.Text), int.Parse(tbH.Text), int.Parse(tbCanh.Text));
                    heToaDo3D();
                }
            }
            tbX.Text = "";
            tbY.Text = "";
            tbZ.Text = "";
            tbH.Text = "";
            tbCanh.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        //đổi từ tọa độ máy qua tọa độ người dùng
        private Point doiToaDoMayQuaNguoiDung(Point p)
        {
            p.X = p.X - 450;
            p.Y = 350-p.Y;
            return p;
        }

        //đổi từ tọa độ người dùng qua tọa độ máy
        private Point doiToaDoNguoiDungQuaMay(Point p)
        {
            p.X = p.X*5 + 450;
            p.Y =350 - p.Y*5;
            return p;
        }

        private void HinhLapPhuong(int x3, int y3, int z3, int h)
        {
            //xóa màn hình hiển thị trước đó
            RTToaDo.Clear();
            Point a,b,c,d,e,f,g,i  = new Point();
            a = cabinet(x3,y3,z3);
            RTToaDo.Text += "A: x = " + x3 + ", y = " + y3 + ", z = "+z3+"\n";
            a = doiToaDoNguoiDungQuaMay(a);

            lbA.Location = new System.Drawing.Point(a.X, a.Y);
            lbA.Text = "A";
            lbA.Name = "lbA";
            lbA.AutoSize = true;
            lbA.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbA.Size = new System.Drawing.Size(34, 32);
            lbA.TabIndex = 81;
            lbA.Visible = true;
            panel1.Controls.Add(lbA);

            b = cabinet(x3+h, y3, z3);
            RTToaDo.Text += "B: x = " + (x3+h) + ", y = " + y3 + ", z = " + z3 + "\n";

            b = doiToaDoNguoiDungQuaMay(b);
            lbB.Location = new Point(b.X, b.Y);
            lbB.Text = "B";
            lbB.Name = "lbB";
            lbB.AutoSize = true;
            lbB.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbB.Size = new System.Drawing.Size(34, 32);
            lbB.TabIndex = 81;
            lbB.Visible = true;
            panel1.Controls.Add(lbB);

            c = cabinet(x3 + h, y3+h, z3);
            RTToaDo.Text += "C: x = " + (x3 + h) + ", y = " + (y3+h) + ", z = " + z3 + "\n";
            c = doiToaDoNguoiDungQuaMay(c);
            lbC.Location = new Point(c.X, c.Y);
            lbC.Text = "C";
            lbC.Name = "lbC";
            lbC.AutoSize = true;
            lbC.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbC.Size = new System.Drawing.Size(34, 32);
            lbC.TabIndex = 81;
            lbC.Visible = true;
            panel1.Controls.Add(lbC);

            d = cabinet(x3, y3+h, z3);
            RTToaDo.Text += "D: x = " + (x3 ) + ", y = " + (y3+h) + ", z = " + z3 + "\n";
            d = doiToaDoNguoiDungQuaMay(d);
            lbD.Location = new Point(d.X, d.Y);
            lbD.Text = "D";
            lbD.Name = "lbD";
            lbD.AutoSize = true;
            lbD.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbD.Size = new System.Drawing.Size(34, 32);
            lbD.TabIndex = 81;
            lbD.Visible = true;
            panel1.Controls.Add(lbD);

            e = cabinet(x3, y3, z3+h);
            RTToaDo.Text += "E: x = " + x3  + ", y = " + y3 + ", z = " +( z3+h) + "\n";
            e = doiToaDoNguoiDungQuaMay(e);
            lbE.Location = new Point(e.X, e.Y);
            lbE.Text = "E";
            lbE.Name = "lbE";
            lbE.AutoSize = true;
            lbE.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbE.Size = new System.Drawing.Size(34, 32);
            lbE.TabIndex = 81;
            lbE.Visible = true;
            panel1.Controls.Add(lbE);

            f = cabinet(x3+h, y3, z3+h);
            RTToaDo.Text += "F: x = " + (x3+h) + ", y = " + y3 + ", z = " + (z3+h) + "\n";
            f = doiToaDoNguoiDungQuaMay(f);
            lbF.Location = new Point(f.X, f.Y);
            lbF.Text = "F";
            lbF.Name = "lbF";
            lbF.AutoSize = true;
            lbF.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbF.Size = new System.Drawing.Size(34, 32);
            lbF.TabIndex = 81;
            lbF.Visible = true;
            panel1.Controls.Add(lbF);

            g = cabinet(x3+h ,y3+h, z3+h);
            RTToaDo.Text += "G: x = " + (x3 +h)+ ", y = " + (y3+h) + ", z = " + (z3+h) + "\n";
            g = doiToaDoNguoiDungQuaMay(g);
            lbG.Location = new Point(g.X, g.Y);
            lbG.Text = "G";
            lbG.Name = "lbG";
            lbG.AutoSize = true;
            lbG.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbG.Size = new System.Drawing.Size(34, 32);
            lbG.TabIndex = 81;
            lbG.Visible = true;
            panel1.Controls.Add(lbG);

            i = cabinet(x3, y3+h, z3+h);
            RTToaDo.Text += "I: x = " + x3 + ", y = " + (y3 +h)+ ", z = " + (z3+h) + "\n";
            i = doiToaDoNguoiDungQuaMay(i);
            lbI.Location = new Point(i.X, i.Y);
            lbI.Text = "I";
            lbI.Name = "lbI";
            lbI.AutoSize = true;
            lbI.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbI.Size = new System.Drawing.Size(34, 32);
            lbI.TabIndex = 81;
            lbI.Visible = true;
            panel1.Controls.Add(lbI);

            dthang ab = new dthang(a, b, Color.Black);
            this.Add(ab);
            DDA_Line_net_dut(ab);
            dthang ad = new dthang(a, d, Color.Black);
            this.Add(ad);
            DDA_Line_net_dut(ad);
            dthang ae = new dthang(a, e, Color.Black);
            this.Add(ae);
            DDA_Line_net_dut(ae);
           
            dthang bc = new dthang(b, c, Color.Black);
            this.Add(bc);
            DDA_Line(bc);

            dthang cd = new dthang(c, d, Color.Black);
            this.Add(cd);
            DDA_Line(cd);
            dthang fb = new dthang(f, b, Color.Black);
            this.Add(fb);
            DDA_Line(fb);
            dthang cg = new dthang(c, g, Color.Black);
            this.Add(cg);
            DDA_Line(cg);
            dthang di = new dthang(d, i, Color.Black);
            this.Add(di);
            DDA_Line(di);
            dthang fg = new dthang(f, g, Color.Black);
            this.Add(fg);
            DDA_Line(fg);
            dthang gh = new dthang(g, i, Color.Black);
            this.Add(gh);
            DDA_Line(gh);
            dthang ie = new dthang(i, e, Color.Black);
            this.Add(ie);
            DDA_Line(ie);
            dthang ef = new dthang(e, f, Color.Black);
            this.Add(ef);
            DDA_Line(ef);

            dthang gi = new dthang(i, g, Color.Black);
            this.Add(gi);
            DDA_Line(gi);

        }

        //khử trục z
        private Point cabinet(int x, int y, int z) 
        {
            Point p2d = new Point();
            p2d.X = (int)(x - ((Math.Sqrt(2) * y) / 4));
            p2d.Y =(int) (z-((Math.Sqrt(2) * y) / 4));
            return p2d;
        }
        public void heToaDo3D()
        {
            Graphics g = this.panel1.CreateGraphics();
            label2.Text = "Z";
            label36.Visible=true;
            g.DrawLine(new Pen(Color.Red), 450, 350, 1000, 350);
            g.DrawLine(new Pen(Color.Red), 450, 0, 450, 350);
            g.DrawLine(new Pen(Color.Red), 450, 350, 0, 800);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            label42.Visible = true;
            label42.Text = "Hình lập phương";
            label37.Visible = true;
            label38.Visible = true;
            label39.Visible = true;
            label40.Visible = true;
            label43.Visible = false;
            tbX.Visible = true;
            tbY.Visible = true;
            tbZ.Visible = true;
            tbCanh.Visible = true;
            tbH.Visible = false;

            btnVe.Visible = true;
            lbA.Visible = false;
            lbB.Visible = false;
            lbC.Visible = false;
            lbD.Visible = false;
            lbE.Visible = false;
            lbF.Visible = false;
            lbG.Visible = false;
            lbI.Visible = false;
            lbA1.Visible = false;
            lbB1.Visible = false;
            lbC1.Visible = false;
            lbD1.Visible = false;
            lbE1.Visible = false;
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();
            label22.Hide();
            label23.Hide();
            label24.Hide();
            label25.Hide();
            label26.Hide();
            label27.Hide();
            label28.Hide();
            label30.Hide();
            label31.Hide();
            label32.Hide();
            label29.Hide();
            label33.Hide();
            RTToaDo.Clear();
            //hàm xóa màn hình
            khoitaobien();
            initbd();
            panel1.Refresh();

            heToaDo3D();

            VeHinh3d = 1;


        }
        private void HinhChop(int x3, int y3, int z3, int h, int canh)
        {
            //xóa màn hình hiển thị trước đó
            RTToaDo.Clear();
            Point a, b, c, d, e, f, g, i = new Point();
            a = cabinet(x3, y3, z3);
            RTToaDo.Text += "A: x = " + x3 + ", y = " + y3 + ", z = " + z3+ "\n";
            a = doiToaDoNguoiDungQuaMay(a);

            lbA1.Location = new System.Drawing.Point(a.X, a.Y);
            lbA1.Text = "A";
            lbA1.Name = "lbA";
            lbA1.AutoSize = true;
            lbA1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbA1.Size = new System.Drawing.Size(34, 32);
            lbA1.TabIndex = 81;
            lbA1.Visible = true;
            panel1.Controls.Add(lbA1);

            b = cabinet(x3 + canh, y3, z3);
            RTToaDo.Text += "B: x = " + (x3+canh) + ", y = " + y3 + ", z = " + z3 + "\n";
            b = doiToaDoNguoiDungQuaMay(b);
            lbB1.Location = new Point(b.X, b.Y);
            lbB1.Text = "B";
            lbB1.Name = "lbB";
            lbB1.AutoSize = true;
            lbB1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbB1.Size = new System.Drawing.Size(34, 32);
            lbB1.TabIndex = 81;
            lbB1.Visible = true;
            panel1.Controls.Add(lbB1);

            c = cabinet(x3 + canh, y3 + canh, z3);
            RTToaDo.Text += "C: x = " + (x3+canh) + ", y = " + (y3+canh) + ", z = " + z3 + "\n";
            c = doiToaDoNguoiDungQuaMay(c);
            lbC1.Location = new Point(c.X, c.Y);
            lbC1.Text = "C";
            lbC1.Name = "lbC";
            lbC1.AutoSize = true;
            lbC1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbC1.Size = new System.Drawing.Size(34, 32);
            lbC1.TabIndex = 81;
            lbC1.Visible = true;
            panel1.Controls.Add(lbC1);

            d = cabinet(x3, y3 + canh, z3);
            RTToaDo.Text += "D: x = " + x3 + ", y = " + (y3 +canh)+ ", z = " + z3 + "\n";
            d = doiToaDoNguoiDungQuaMay(d);
            lbD1.Location = new Point(d.X, d.Y);
            lbD1.Text = "D";
            lbD1.Name = "lbD";
            lbD1.AutoSize = true;
            lbD1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbD1.Size = new System.Drawing.Size(34, 32);
            lbD1.TabIndex = 81;
            lbD1.Visible = true;
            panel1.Controls.Add(lbD1);

            e = cabinet(x3, y3, z3 + h);
            RTToaDo.Text += "E: x = " + x3 + ", y = " + y3 + ", z = " + (z3+h) + "\n";
            e = doiToaDoNguoiDungQuaMay(e);
            lbE1.Location = new Point(e.X, e.Y);
            lbE1.Text = "E";
            lbE1.Name = "lbE";
            lbE1.AutoSize = true;
            lbE1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            lbE1.Size = new System.Drawing.Size(34, 32);
            lbE1.TabIndex = 81;
            lbE1.Visible = true;
            panel1.Controls.Add(lbE1);

            dthang ab = new dthang(a, b, Color.Black);
            this.Add(ab);
            DDA_Line_net_dut(ab);
            dthang ad = new dthang(a, d, Color.Black);
            this.Add(ad);
            DDA_Line_net_dut(ad);
            dthang ae = new dthang(a, e, Color.Black);
            this.Add(ae);
            DDA_Line_net_dut(ae);

            dthang bc = new dthang(b, c, Color.Black);
            this.Add(bc);
            DDA_Line(bc);

            dthang cd = new dthang(c, d, Color.Black);
            this.Add(cd);
            DDA_Line(cd);
            dthang be = new dthang(b, e, Color.Black);
            this.Add(be);
            DDA_Line(be);
            dthang ce = new dthang(c, e, Color.Black);
            this.Add(ce);
            DDA_Line(ce);
            dthang de = new dthang(d, e, Color.Black);
            this.Add(de);
            DDA_Line(de);
        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            btnVe.Visible = true;
            label42.Visible = true;
            label42.Text = "Hình chóp";
            label37.Visible = true;
            label38.Visible = true;
            label39.Visible = true;
            label40.Visible = true;
            label43.Visible = true;
            tbX.Visible = true;
            tbY.Visible = true;
            tbZ.Visible = true;
            tbCanh.Visible = true;
            tbH.Visible = true;
            lbA1.Visible = false;
            lbB1.Visible = false;
            lbC1.Visible = false;
            lbD1.Visible = false;
            lbE1.Visible = false;
            lbA.Visible = false;
            lbB.Visible = false;
            lbC.Visible = false;
            lbD.Visible = false;
            lbE.Visible = false;
            lbF.Visible = false;
            lbG.Visible = false;
            lbI.Visible = false;
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();
            label22.Hide();
            label23.Hide();
            label24.Hide();
            label25.Hide();
            label26.Hide();
            label27.Hide();
            label28.Hide();
            label30.Hide();
            label31.Hide();
            label32.Hide();
            label29.Hide();
            label33.Hide();
            RTToaDo.Clear();
            //hàm xóa màn hình
            khoitaobien();
            initbd();
            panel1.Refresh();
            //___________________________________________________
            heToaDo3D();
         
            VeHinh3d = 2;
        }

        private void RTToaDo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            btnVe.Visible = false;
            label42.Visible = false;
            label37.Visible = false;
            label38.Visible = false;
            label39.Visible = false;
            label40.Visible = false;
            label43.Visible = false;
            tbX.Visible = false;
            tbY.Visible = false;
            tbZ.Visible = false;
            tbCanh.Visible = false;
            tbH.Visible = false;

            lbA1.Visible = false;
            lbB1.Visible = false;
            lbC1.Visible = false;
            lbD1.Visible = false;
            lbE1.Visible = false;
            lbA.Visible = false;
            lbB.Visible = false;
            lbC.Visible = false;
            lbD.Visible = false;
            lbE.Visible = false;
            lbF.Visible = false;
            lbG.Visible = false;
            lbI.Visible = false;
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();
            label22.Hide();
            label23.Hide();
            label24.Hide();
            label25.Hide();
            label26.Hide();
            label27.Hide();
            label28.Hide();
            label30.Hide();
            label31.Hide();
            label32.Hide();
            label29.Hide();
            label33.Hide();
            RTToaDo.Clear();
            //hàm xóa màn hình
            khoitaobien();
            initbd();
            panel1.Refresh();
            heToaDo();


            //tọa đồ hình bình hành cái bàn
            points[0].X = 300;
            points[0].Y = 300;
            HienThiToaDo(points[0], "\n Tọa độ cái bàn: \n");
            points[1].X = 800;
            points[1].Y = 300;
            HienThiToaDo(points[1], "");
            points[2].X = 600;
            points[2].Y = 500;
            HienThiToaDo(points[2], "");
            points[3].X = 100;
            points[3].Y = 500;
            HienThiToaDo(points[3], "");
            hbh bh = new hbh(points[0], points[1], points[2], points[3], Color.SaddleBrown);
            this.Add(bh);
            hinhbinhhanh(bh);

            //Hình chữ nhật chân 1 csi bàn
            points[0].X = 100;
            points[0].Y = 500;
            points[1].X = 120;
            points[1].Y = 700;
            HienThiToaDo(points[1], "\n Chân bàn: ");
            hcn cn = new hcn(points[0], points[1], Color.SaddleBrown);
            this.Add(cn);
            hinhcn(cn);

           
            //chân 2 hình chữ nhật cái bàn
            points[0].X = 580;
            points[0].Y = 500;
            HienThiToaDo(points[0], "");
            points[1].X = 600;
            points[1].Y = 700;
            HienThiToaDo(points[1], "");
            hcn cn1 = new hcn(points[0], points[1], Color.SaddleBrown);
            this.Add(cn1);
            hinhcn(cn1);

            //chân 3 hình chữ nhật cái bàn
            points[0].X = 780;
            points[0].Y = 300;
            HienThiToaDo(points[0], "");
            points[1].X = 800;
            points[1].Y = 600;
            HienThiToaDo(points[1], "");
            hcn cn2 = new hcn(points[0], points[1], Color.SaddleBrown);
            this.Add(cn2);
            hinhcn(cn2);

            //chân 4 cái bàn
            points[0].X = 280;
            points[0].Y = 500;
            HienThiToaDo(points[0], "");
            points[1].X = 300;
            points[1].Y = 600;
            HienThiToaDo(points[1], "");
            hcn cn3 = new hcn(points[0], points[1], Color.SaddleBrown);
            this.Add(cn3);
            hinhcn(cn3);

            //đế quạt
            points[0].X = 460;
            points[0].Y = 400;
            HienThiToaDo(points[0], "Tâm hình elip đế quạt: ");
            elip el = new elip(points[0], 140, 60, Color.DeepSkyBlue);
            this.Add(el);
            Midpoint_elip(el);

            //nút bấm
            points[0].X = 405;
            points[0].Y = 425;
            points[1].X = 410;
            points[1].Y = 430;
            points[8].X = 405;
            points[8].Y = 425;
            //hcn cn31 = new hcn(points[0], points[1], Color.SaddleBrown);
            //this.Add(cn31);
            //hinhcn(cn31);
            //thu phóng
            sx = 2;
            sy = 2;
            hcn tempT = new hcn(tyle(points[0], points[8]), tyle(points[1], points[8]), Color.Green);
            hinhcn(tempT);
            this.Add(tempT);
            //nút 2
            points[15].X = 440;
            points[15].Y = 425;
            points[16].X = 445;
            points[16].Y = 430;
            points[9].X = 440;
            points[9].Y = 425;
            //hcn cn32 = new hcn(points[2], points[3], Color.SaddleBrown);
            //this.Add(cn32);
            //hinhcn(cn32);
            sx = 2;
            sy = 2;
            hcn tempTp = new hcn(tyle(points[15], points[9]), tyle(points[16], points[9]), Color.Green);
            hinhcn(tempTp);
            this.Add(tempTp);
            //nút 3
            points[4].X = 475;
            points[4].Y = 425;

            points[5].X = 480;
            points[5].Y = 430;
            points[10].X = 475;
            points[10].Y = 425;
            //hcn cn33 = new hcn(points[4], points[5], Color.SaddleBrown);
            //this.Add(cn33);
            //hinhcn(cn33);
            sx = 2;
            sy = 2;
            hcn tempTp1 = new hcn(tyle(points[4], points[10]), tyle(points[5], points[10]), Color.Green);
            hinhcn(tempTp1);
            this.Add(tempTp1);
            ////nút 4
            //points[6].X = 510;
            //points[6].Y = 425;
            //points[7].X = 515;
            //points[7].Y = 430;
            //points[11].X = 510;
            //points[11].Y = 425;
            ////hcn cn323 = new hcn(points[0], points[1], Color.SaddleBrown);
            ////this.Add(cn323);
            ////hinhcn(cn323);

            //sx = 2;
            //sy = 2;
            //hcn tempTp2 = new hcn(tyle(points[6], points[11]), tyle(points[7], points[11]), Color.Green);
            //hinhcn(tempTp2);
            //this.Add(tempTp2);
            // (tyle(points[4], points[10]), tyle(points[5], points[10])
            hcn tempp11 = new hcn(Tinhtien(tyle(points[4], points[10]), 35, 0), Tinhtien(tyle(points[5], points[10]), 35, 0), Color.Green);
            hinhcn(tempp11);


            //hình bình hành trụ quạt
            points[0].X = 435;
            points[0].Y = 322;
            HienThiToaDo(points[0], "Tọa độ trụ quạt: ");
            points[1].X = 485;
            points[1].Y = 322;
            HienThiToaDo(points[1], "");
            points[2].X = 500;
            points[2].Y = 400;
            HienThiToaDo(points[2], "");
            points[3].X = 420;
            points[3].Y = 400;
            HienThiToaDo(points[3], "");
            hbh cn4 = new hbh(points[0], points[1], points[2], points[3], Color.DeepSkyBlue);
            this.Add(cn4);
            hinhbinhhanh(cn4);

            //tâm quạt
            points[8].X = 460;
            points[8].Y = 170;
            HienThiToaDo(points[8], "Tọa độ tâm quạt: ");
            //vành quạt
            int bk1 = 150;
            htron tr1 = new htron(bk1, points[8], Color.DeepSkyBlue);
            this.Add(tr1);
            Midpoint_htron(tr1);
            RTToaDo.Text += "Bán kính: 150";


            // hình thang cánh quạt 1
            points[0].X = 420;
            points[0].Y = 40;
            HienThiToaDo(points[0], "");
            points[1].X = 500;
            points[1].Y = 40;
            points[2].X = 465;
            points[2].Y = 170;
            points[3].X = 455;
            points[3].Y = 170;
            hbh cn5 = new hbh(points[0], points[1], points[2], points[3], Color.Green);
            this.Add(cn5);
            hinhbinhhanh(cn5);

            //hình thang cánh quạt 2
            points[4].X = 330;
            points[4].Y = 130;
            HienThiToaDo(points[4], "Tọa độ cánh quạt: \n");
            points[5].X = 460;
            points[5].Y = 165;
            HienThiToaDo(points[5], "");
            points[6].X = 460;
            points[6].Y = 175;
            HienThiToaDo(points[6], "");
            points[7].X = 330;
            points[7].Y = 210;
            HienThiToaDo(points[7], "");
            hbh cn6 = new hbh(points[4], points[5], points[6], points[7], Color.Red);
            this.Add(cn6);
            hinhbinhhanh(cn6);

            //đối xứng cánh quạt 1 qua tâm o
            hbh temp = new hbh(doixung(points[0], points[8]), doixung(points[1], points[8]), doixung(points[2], points[8]), doixung(points[3], points[8]), Color.Green);
            hinhbinhhanh(temp);


            //đối xứng cánh quạt 2 qua tâm o
            hbh temp2 = new hbh(doixung(points[4], points[8]), doixung(points[5], points[8]), doixung(points[6], points[8]), doixung(points[7], points[8]), Color.Red);
            hinhbinhhanh(temp2);

            //bật nút
            points[20].X = 440;
            points[20].Y = 425;
            HienThiToaDo(points[20], "");
            points[21].X = 445;
            points[21].Y = 430;
            HienThiToaDo(points[21], "");
            points[91].X = 440;
            points[91].Y = 425;
            HienThiToaDo(points[91], "");
            //////xóa hình cũ
            sx = 2;
            sy = 2;
            hcn tempT1 = new hcn(tyle(points[20], points[91]), tyle(points[21], points[91]), Color.White);
            hinhcn(tempT1);
            this.Add(tempT1);
            hcn cn32 = new hcn(points[20], points[21], Color.SaddleBrown);
            this.Add(cn32);
            hinhcn(cn32);
            HienThiToaDo(points[91], "\n Quay cánh quạt\n");
            int dem = 0;
            for (gocquay = 20; gocquay < 361; gocquay += 20)
            {

                //cánh quạt một xóa
                gocquay -= 20;
                hbh tem31 = new hbh(Quay(points[0], points[8]), Quay(points[1], points[8]), Quay(points[2], points[8]), Quay(points[3], points[8]), Color.White);
                hinhbinhhanh(tem31);
                HienThiToaDo(Quay(points[0], points[8]), "Cánh quạt 1\n");
                HienThiToaDo(Quay(points[1], points[8]), "");
                HienThiToaDo(Quay(points[2], points[8]), "");
                HienThiToaDo(Quay(points[3], points[8]), "");


                gocquay += 20;
                //cánh quạt một có màu
                hbh tem3 = new hbh(Quay(points[0], points[8]), Quay(points[1], points[8]), Quay(points[2], points[8]), Quay(points[3], points[8]), Color.Green);
                hinhbinhhanh(tem3);

                gocquay -= 20;
                //cánh quạt 2 không màu
                hbh tem41 = new hbh(Quay(points[4], points[8]), Quay(points[5], points[8]), Quay(points[6], points[8]), Quay(points[7], points[8]), Color.White);
                hinhbinhhanh(tem41);

                gocquay += 20;
                //cánh quạt 2 có màu
                hbh tem4 = new hbh(Quay(points[4], points[8]), Quay(points[5], points[8]), Quay(points[6], points[8]), Quay(points[7], points[8]), Color.Red);
                hinhbinhhanh(tem4);

                gocquay -= 20;
                //cánh quạt 3 không màu
                hbh tem51 = new hbh(Quay(doixung(points[0], points[8]), points[8]), Quay(doixung(points[1], points[8]), points[8]), Quay(doixung(points[2], points[8]), points[8]), Quay(doixung(points[3], points[8]), points[8]), Color.White);
                hinhbinhhanh(tem51);

                gocquay += 20;
                //cánh quạt 3 có màu
                hbh tem5 = new hbh(Quay(doixung(points[0], points[8]), points[8]), Quay(doixung(points[1], points[8]), points[8]), Quay(doixung(points[2], points[8]), points[8]), Quay(doixung(points[3], points[8]), points[8]), Color.Green);
                hinhbinhhanh(tem5);

                gocquay -= 20;
                //cánh quạt 4 không màu
                hbh tem61 = new hbh(Quay(doixung(points[4], points[8]), points[8]), Quay(doixung(points[5], points[8]), points[8]), Quay(doixung(points[6], points[8]), points[8]), Quay(doixung(points[7], points[8]), points[8]), Color.White);
                hinhbinhhanh(tem61);

                gocquay += 20;
                //cánh quạt 4 có màu
                hbh tem6 = new hbh(Quay(doixung(points[4], points[8]), points[8]), Quay(doixung(points[5], points[8]), points[8]), Quay(doixung(points[6], points[8]), points[8]), Quay(doixung(points[7], points[8]), points[8]), Color.Red);
                hinhbinhhanh(tem6);
                dem++;
                if (dem == 25)
                {
                    break;
                }

            }
            //tat quat
            //////xóa hình cũ
            ///
            hcn cn33 = new hcn(points[20], points[21], Color.White);
            this.Add(cn33);
            hinhcn(cn33);
            sx = 2;
            sy = 2;
            hcn tempT2 = new hcn(tyle(points[20], points[91]), tyle(points[21], points[91]), Color.Green);
            hinhcn(tempT2);
            this.Add(tempT2);
            


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            heToaDo(); initcolor(); vehinh();
        }

        

        public Point tyle(Point d1, Point d2)
        {
            Point dd1, dd2;
            dd1 = this.s.toado1(d1.X, d1.Y);
            dd2 = this.s.toado1(d2.X, d2.Y);
            int x1, y1, xo, yo;
            x1 = dd1.X; y1 = dd1.Y; xo = dd2.X; yo = dd2.Y;
            int[,] matran1;
            int[,] matran2;
            int[,] matran3;

            int[] mang;
            int[] mangtam = { 0, 0, 0 };
            mangtam = new int[3];
            mang = new int[3];
            matran1 = new int[3, 3];
            matran2 = new int[3, 3];
            matran3 = new int[3, 3];
            //    putPixel(x1, y1, x1, y1, 0, 0, 0);// diem P...
            //    putPixel(xo, yo, xo, yo, 0, 0, 1);// Tam ty le ...
            //Ma tran tinh tien ve tam O ...
            matran1[0, 0] = 1; matran1[0, 1] = 0; matran1[0, 2] = 0;
            matran1[1, 0] = 0; matran1[1, 1] = 1; matran1[1, 2] = 0;
            matran1[2, 0] = -xo; matran1[2, 1] = -yo; matran1[2, 2] = 1;
            mang[0] = x1; mang[1] = y1; mang[2] = 1;
            Point pt1 = nhanMT2(matran1, mang);
            //Ma tran ty le ...
            matran2[0, 0] = sx; matran2[0, 1] = 0; matran2[0, 2] = 0;
            matran2[1, 0] = 0; matran2[1, 1] = sy; matran2[1, 2] = 0;
            matran2[2, 0] = 0; matran2[2, 1] = 0; matran2[2, 2] = 1;
            mang[0] = pt1.X; mang[1] = pt1.Y; mang[2] = 1;
            Point pt2 = nhanMT2(matran2, mang);
            //Ma tran tinh tien nguoc ve vi tri cu...
            matran3[0, 0] = 1; matran3[0, 1] = 0; matran3[0, 2] = 0;
            matran3[1, 0] = 0; matran3[1, 1] = 1; matran3[1, 2] = 0;
            matran3[2, 0] = xo; matran3[2, 1] = yo; matran3[2, 2] = 1;
            mang[0] = pt2.X; mang[1] = pt2.Y; mang[2] = 1;
            Point pt3 = nhanMT2(matran3, mang);
            Point kq = s.toado2(pt3.X, pt3.Y);
            return kq;
        }



        //private void button7_Click(object sender, EventArgs e)
        //{
        //    khoitaobien();
        //    initbd();
        //    panel1.Refresh();
        //}





    }
}