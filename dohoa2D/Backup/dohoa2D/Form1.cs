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
        public htron[] circles ;
        public hvuong[] squares;
        public hcn[] rectangles;
        public elip[] elippses;
        public hbh[] hinhbhs;
        int click=-1;
        int chonhinh = -1;//chonhinh=hinh se ve
        //int sodt = 0, soht = 0,sohv=0,sohcn=0,soelip=0,sohbh=0;
        Point[] points=new Point[3];//cac diem de thao tac ve hinh
       
      
        int chon=0;// chon=kieubiendoi,chon=0 la ko bien doi
        int loaihinh=-1;//loaihinh se biendoi
        int stt=-1;//=xdinh hinh nao se bien doi
        Point[] diems=new Point[3];//3 diem de thao tac bien doi
        int sodiem=0;
        int gocquay,hsbd,sx,sy;
        Color mauto=Color.White;

        doitoado s = new doitoado();
        public Color[,] arrcolor= new Color[81,81];// mang chua mau cua tat ca cac diem
        public Form1()
        {
            lines = null; squares = null; rectangles = null; elippses = null;
            circles = null; hinhbhs = null;
            InitializeComponent();initcolor();
          
           
        }
        // Dua 1 hinh vao mang
        public void Add(dthang dt)
        {
            if (lines == null)
            {
                lines = new dthang[1]; lines[0] = dt;
            }
            else { dthang[]temp=new dthang[lines.Length+1];
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
            else { hvuong[] temp = new hvuong[squares.Length + 1];
                   for (int i = 0; i < squares.Length; i++) temp[i] = squares[i];
                   temp[squares.Length] = hv;
                   squares = temp;
                     }
        }
        public void Add(hcn cn)
        {
            if (rectangles == null) { rectangles = new hcn[1]; rectangles[0] = cn; }
            else {hcn []temp=new hcn[rectangles.Length+1];
            for (int i = 0; i < rectangles.Length; i++) temp[i] = rectangles[i];
            temp[rectangles.Length] = cn;
            rectangles = temp;
        }
                    }
        public void Add(hbh bh)
        {
            if (hinhbhs == null) { hinhbhs = new hbh[1]; hinhbhs[0] = bh; }
            else { hbh []temp=new hbh[hinhbhs .Length+1];
            for (int i = 0; i < hinhbhs.Length; i++) temp[i] = hinhbhs[i];
            temp[hinhbhs.Length] = bh;
            hinhbhs = temp;
        }
        }
        public void Add(elip el)
        {
            if (elippses == null) { elippses = new elip[1]; elippses[0] = el; }
            else { elip[] temp = new elip[elippses.Length + 1];
            for (int i = 0; i < elippses.Length; i++) temp[i] = elippses[i];
            temp[elippses.Length] = el;
            elippses = temp;
        }
        }

        //- bo 1 hinh thu j ra khoi mang-----------------------------

        public dthang[] Delete(int j,dthang[]DT)
        {  int i;
            if (DT.Length == 1) lines= null;
            else { dthang []temp=new dthang[DT.Length-1];
            for ( i = 0; i < j; i++)
                temp[i] = DT[i];
            for (i = j + 1; i < DT.Length; i++)
                temp[i - 1] = DT[i];
            DT = temp;
          
        }
        return DT;     
        }
        public htron[]Delete(int j, htron[] DT)
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
            } return DT;
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
            } return DT;
        }
        public hbh[]Delete(int j, hbh[] DT)
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
            } return DT;
        }
        public elip[] Delete(int j,elip[] DT)
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
           // chonhinh = -1;
           // sodt = soht = sohv = sohcn = soelip = sohbh = 0;
            lines = null; squares = null; rectangles = null; elippses = null;
            circles = null; hinhbhs = null;
        }
        public void heToaDo()
        {
            Graphics g = this.panel1.CreateGraphics();
           // SolidBrush brush = new SolidBrush(Color.DarkSlateBlue);
            for (int i = 0; i <= 80; i++)
            {
                g.DrawLine(new Pen(Color.Black), 5* i, 0, 5* i, 400);
                g.DrawLine(new Pen(Color.Black), 0, 5* i, 400, 5* i);
            }
            g.DrawLine(new Pen(Color.Red), 0, 200, 400, 200);
            g.DrawLine(new Pen(Color.Red), 200, 0, 200, 400);

        }
        private void initbd()
        {
         chonhinh = -1;
         chon=0;// chon=kieubiendoi
         loaihinh=-1;//loaihinh se biendoi
         stt=-1;//=xdinh hinh nao se bien doi
        // chonhinh=-1;//chonhinh=hinh se ve
         diems=new Point[3];//2 diem de thao tac bien doi
         sodiem=0;
         gocquay=90;
         hsbd=sx=sy=1;
         mauto = Color.White;
        }

        private void initcolor()
        {
            for (int i = 0; i < 81; i++)
                for (int j = 0; j < 81; j++)
                    arrcolor[i, j] = Color.White;
        }
        private void putcolor(int x,int y, Color m)
        {
            if (x < 0 || x > 400 || y < 0 || y > 400) return;
            arrcolor[s.round(y)/5,s.round(x)/5]=m;
        }
        private void putcolor1(int x, int y, int cx, int cy, Color m)
        {
            putcolor(x + cx, y + cy, m);
            putcolor(-x + cx, y + cy, m);
            putcolor(x + cx, -y + cy, m);
            putcolor(-x + cx, -y + cy, m);
        }
        private Color getcolor(int x,int y)
        {
            if (x < 0 || x > 400 || y < 0 || y > 400) return mauto;
            return arrcolor[s.round(y)/ 5,s.round(x)/ 5];
        }
     
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
            heToaDo();initcolor();vehinh();
        }
        public void vehinh()
        {
            int i;
            if (lines!=null)
            { for (i = 0; i < lines.Length; i++) DDA_Line(lines[i]); }
            if (circles!=null)
            { for (i = 0; i < circles.Length; i++) Midpoint_htron(circles[i]); }
            if (squares!=null)
            { for (i = 0; i < squares.Length; i++) hinhvuong(squares[i]); }
            if (rectangles!=null)
            { for (i = 0; i < rectangles.Length; i++) hinhcn(rectangles[i]); }
            if (elippses!=null)
            { for (i = 0; i < elippses.Length; i++) Midpoint_elip(elippses[i]); }
            if (hinhbhs!=null)
            { for (i = 0; i < hinhbhs.Length; i++) hinhbinhhanh(hinhbhs[i]); }
         }
        private void putpixel(int x,int y,Color m)
        {
          if (x < 0 || x > 400 || y < 0 || y > 400) return;
          
          Graphics grfx = this.panel1.CreateGraphics();
          Pen p=new Pen(m);
          SolidBrush b=new SolidBrush(m);
          grfx.DrawEllipse(p, x, y, 2, 2);
          grfx.FillEllipse(b, x, y, 2, 2);
          grfx.DrawEllipse(p, x - 2, y - 2, 2, 2);
          grfx.FillEllipse(b, x - 2, y - 2, 2, 2);
          grfx.DrawEllipse(p, x , y - 2, 2, 2);
          grfx.FillEllipse(b, x , y - 2, 2, 2);
          grfx.DrawEllipse(p,x - 2, y , 2, 2);
          grfx.FillEllipse(b, x - 2, y, 2, 2);
         
          putcolor(x, y, m);
        }
        private void put4pitxel(int x,int y,int cx,int cy,Color m)
        {
            putpixel(x+cx,y+cy,m);
            putpixel(-x + cx, y + cy, m);
            putpixel(x+cx,-y+cy,m);
            putpixel(-x+cx,-y+cy,m);
        }
        private void put8pitxel(int x,int y,int cx,int cy,Color m)
        {
            putpixel(cx + x,cy + y, m);
            putpixel(cx + x,cy - y, m);
            putpixel(cx - x,cy + y, m);
            putpixel(cx - x,cy - y, m);
            putpixel(cx + y,cy + x, m);
            putpixel(cx + y,cy - x, m);
            putpixel(cx - y,cy + x, m);
            putpixel(cx - y,cy - x, m);
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
            if (diem_dthang(x, y, new dthang(T.d1, T.d2,m)) == 1 || diem_dthang(x, y, new dthang(T.d1, T.d3,m)) == 1 || diem_dthang(x, y, new dthang(T.d2, T.d4,m)) == 1 || diem_dthang(x, y, new dthang(T.d3, T.d4,m)) == 1)
             return 1;
            int maxx, minx, maxy, miny;
            if (T.d2.X > T.d1.X) { maxx = T.d2.X; minx = T.d1.X; }
            else { maxx = T.d1.X; minx = T.d2.X; }
            maxy = T.d1.Y+Math.Abs(T.d2.X - T.d1.X);
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
                x =T.diemdau.X;
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
            int x, y,cx,cy,p,R;
            Color m=T.mau;
            cx = T.tam.X; cy = T.tam.Y;
            x = 0;
            y =R= T.bkinh;
            int maxX = s.round( (float) (Math.Sqrt(2)/2*R));
           // int maxX = Math.Sqrt(2) / 2 * R;
            p = 1 - R;
            put8pitxel(x, y, cx, cy, m);
            while (x <= maxX)
            {
                if (p < 0) p += 2 * x+3;
                else { p += 2 * (x - y) +5; y-=5; }
                x+=5;
                put8pitxel(x,y,cx,cy, m);
            }
          
        }
        public void hinhvuong(hvuong T)
        {
            Color m=T.mau;
            DDA_Line(new dthang(T.d1,T.d2, m));
            DDA_Line(new dthang(T.d1,T.d3,m));
            DDA_Line(new dthang(T.d2, T.d4, m));
            DDA_Line(new dthang(T.d3, T.d4, m));
        }
        public void hinhcn(hcn T)
        {
          
            Color m=T.mau;
            DDA_Line(new dthang(T.d1,T.d4,m));
            DDA_Line(new dthang(T.d1,T.d3, m));
            DDA_Line(new dthang(T.d4, T.d2,m));
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
            int x,y,cx,cy, a, b;
            cx = T.tam.X; cy= T.tam.Y;
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
                    Dy -= 2 *A;
                    p += B+ Dx - Dy;
                }
                putcolor1(s.round(x), s.round(y), cx, cy, m);
                if(x%5==0) put4pitxel(x,s.round( y), cx, cy, m);

              
            }
           p = Math.Round(B * (x + 0.5f) * (x + 0.5f) + A * (y - 1) * (y - 1) - A* B);
            while (y > 0)
            {
                y--;
                Dy -= A * 2;
                if (p > 0)
                    p += A- Dy;
                else
                {
                    x++;
                    Dx += B * 2;
                    p +=A - Dy + Dx;
                }
                putcolor1(s.round(x), s.round(y), cx, cy, m);
              if(x%5==0)  put4pitxel(x,s.round(y), cx, cy, m);
               
            }
        
        }
      private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x, y;
            x = s.round(e.X); y = s.round(e.Y);
            if (e.Button == MouseButtons.Left)
            {

                if (chon == 0)//ko co bien doi
                {

                    if (chonhinh == -1)
                    {
                        MessageBox.Show("chua chon se ve hinh nao");
                        panel1.Refresh();

                        return;
                    }
                    ++click;

                    if (click == 0)
                    {
                        points[click].X = x;
                        points[click].Y = y;
                        putpixel(x, y, Color.DarkOrange);//to diem da chon
                        // putpixel(x, y,Color.White,1);//mau tai diem chon=maunen
                    }
                    if (click == 1)
                    {
                        points[click].X = x;
                        points[click].Y = y;
                        putpixel(x, y, Color.DarkOrange);
                        // putpixel(x, y,Color.White,1);
                        if (chonhinh == 0)
                        {
                            dthang dt = new dthang(points[0], points[1], Color.DarkGreen);
                            this.Add(dt);
                            DDA_Line(dt);
                        }
                        if (chonhinh == 1)
                        {
                            int bk = Math.Abs(points[1].X - points[0].X);
                            htron tr = new htron(bk, points[0], Color.DarkGreen);
                            this.Add(tr);
                            Midpoint_htron(tr);
                            //  tomau_dongquet(points[0].X, points[0].Y, Color.Yellow, Color.DarkGreen);

                        }
                        if (chonhinh == 2)
                        {

                            hvuong hv = new hvuong(points[0], points[1], Color.DarkGreen);
                            this.Add(hv);
                            hinhvuong(hv);

                        }
                        if (chonhinh == 3)
                        {

                            hcn cn = new hcn(points[0], points[1], Color.DarkGreen);
                            this.Add(cn);
                            hinhcn(cn);

                        }
                    }
                    if (click == 2)
                    {
                        points[click].X = x;
                        points[click].Y = y;
                        putpixel(x, y, Color.DarkOrange);
                        // putpixel(x, y,Color.White,1);
                        if (chonhinh == 4)
                        {

                            int aa = Math.Abs(points[1].X - points[0].X);
                            int bb = Math.Abs(points[2].Y - points[0].Y);
                            elip el = new elip(points[0], aa, bb, Color.DarkGreen);
                            this.Add(el);
                            Midpoint_elip(el);

                        }
                        if (chonhinh == 5)
                        {

                            hbh bh = new hbh(points[0], points[1], points[2], Color.DarkGreen);
                            this.Add(bh);
                            hinhbinhhanh(bh);
                        }

                    }
                    if (click == 3) click = -1;
                }


                else if (chon == 7 || chon == 8) { panel1.Refresh(); initbd(); }
                else
                {
                    panel1.Refresh();
                    if (sodiem < 2)
                    {
                        diems[sodiem++] = new Point(x, y);
                        if (sodiem == 1)
                        {

                            putpixel(x, y, Color.DarkOrange);
                            if (chon == 1) bd_doixung();
                            else if (chon == 3)
                            {
                                int dx, dy;
                                dx = diems[0].X - diems[2].X;
                                dy = diems[0].Y - diems[2].Y;
                                bd_tinhtien(dx, dy);
                            }
                            else if (chon == 4) bd_quay();
                            else if (chon == 5) bd_tyle();
                            else return;


                        }
                        else if (sodiem == 2)
                        {

                            putpixel(x, y, Color.DarkOrange);
                            Graphics grfx = panel1.CreateGraphics();
                            grfx.DrawLine(new Pen(Color.Red), diems[0], diems[1]);
                            if (chon == 2) bd_Doixung();
                            else if (chon == 6) bd_biendang();
                            else return;

                        }

                    }



                }

            }
              
          if(e.Button==MouseButtons.Right)
          {
            
             int i;
             if (lines!=null)
                { for (i = 0; i < lines.Length; i++)
                    if (diem_dthang(x, y, lines[i]) == 1) 
                      {
                          dthang temp = lines[i];
                          Formdth f = new Formdth(temp);
                          f.ShowDialog();
                          if (f.xoa == 1)//da chon nut xoa
                          {
                             lines=Delete(i,lines);
                          }
                          else lines[i] = f.getvalue();
                          panel1.Refresh();
                          chon = f.chon;
                          if (chon != 0)
                              {
                                  loaihinh = 0;//duong thang
                                  stt = i;//duongthang nao
                                  gocquay = f.gocquay;
                                  hsbd = f.hsbd;
                                  sx = f.sx;
                                  sy = f.sy;
                                  diems[2].X = x; diems[2].Y = y;
                              }
                          
                          return;
                     }
                         
                   }
                
             if (circles!=null)
               { for (i = 0; i <circles.Length; i++)
                   if (diem_dtron(x, y, circles[i]) == 1) 
                   {
                       htron temp = circles[i];
                       Formdtr f = new Formdtr(temp);
                       f.ShowDialog();
                       if (f.xoa == 1)//da chon nut xoa
                       {
                           circles=Delete(i,circles);

                       }
                       else circles[i] = f.getvalue();
                       panel1.Refresh();
                       chon = f.chon;
                       if (chon != 0)
                           {

                               if (chon == 7)
                               {
                                   mauto = f.mauto;
                                   tomau_dongquet(circles[i].tam, mauto, circles[i].mau); 
                               }
                               else
                               {
                                   loaihinh = 1;
                                   stt = i;
                                   gocquay = f.gocquay;
                                   hsbd = f.hsbd;
                                   sx = f.sx;
                                   sy = f.sy;
                                   diems[2].X = x; diems[2].Y = y;
                               }
                           }
                        
                        return;
                       }
                     
                   }
              
             
            if (squares!=null)
            { for (i = 0; i < squares.Length; i++) 
                if(diem_hvuong(x,y,squares[i])==1) 
                {
                    hvuong temp = squares[i];
                    Formhv f = new Formhv(temp);
                    f.ShowDialog();
                    if (f.xoa == 1)//da chon nut xoa
                    {
                        squares=Delete(i,squares);
                        
                    }
                    else squares[i] = f.getvalue();
                    panel1.Refresh();
                    chon = f.chon;
                    if (chon != 0)
                        {
                            if (chon == 7)
                            {
                                mauto = f.mauto;
                                Point tam = new Point(s.round(squares[i].d1.X + (squares[i].d2.X - squares[i].d1.X) / 2), s.round(squares[i].d1.Y + (squares[i].d3.Y - squares[i].d1.Y) / 2));
                                tomau_dongquet(tam,mauto, squares[i].mau);
                            }
                            else
                            {
                                loaihinh = 2;
                                stt = i;
                                gocquay = f.gocquay;
                                hsbd = f.hsbd;
                                sx = f.sx;
                                sy = f.sy;
                                diems[2].X = x; diems[2].Y = y;

                            }
                        }
                    
                    return;
                }
             }
            if (rectangles!=null)
            { for (i = 0; i <rectangles.Length; i++) 
                if(diem_hcn(x,y,rectangles[i])==1) 
                {
                    hcn temp = rectangles[i];
                    Formhcn f = new Formhcn(temp);
                    f.ShowDialog();
                    if (f.xoa == 1)//da chon nut xoa
                    {
                       rectangles=Delete(i,rectangles);
                    }
                    else rectangles[i] = f.getvalue();
                    panel1.Refresh();
                    chon = f.chon;
                    if (chon != 0)
                        {
                            if (chon == 7)
                            {
                                mauto = f.mauto;
                                Point tam = new Point(s.round(rectangles[i].d1.X + (rectangles[i].d2.X - rectangles[i].d1.X) / 2), s.round(rectangles[i].d1.Y + (rectangles[i].d2.Y - rectangles[i].d1.Y) / 2));
                                tomau_dongquet(tam, mauto, rectangles[i].mau);
                            }
                            else
                            {
                                loaihinh = 3;
                                stt = i;

                                gocquay = f.gocquay;
                                hsbd = f.hsbd;
                                sx = f.sx;
                                sy = f.sy;
                                diems[2].X = x; diems[2].Y = y;
                            }
                        }
                    
                    return;
                }
            }
            if (elippses!=null)
            {
                for (i = 0; i <elippses.Length; i++)
                    if (diem_elip(x, y, elippses[i]) == 1) 
                    {
                        elip temp = elippses[i];
                        Formelip f = new Formelip(temp);
                        f.ShowDialog();
                        if (f.xoa == 1)//da chon nut xoa
                        {
                           elippses=Delete(i,elippses);
                        }
                        else elippses[i] = f.getvalue();
                        panel1.Refresh();
                        chon = f.chon;
                        if (chon!=0)
                        {
                            if (chon == 7)
                            {
                                mauto = f.mauto;
                                tomau_dongquet(elippses[i].tam, mauto, elippses[i].mau);
                            }
                            else
                            {
                                loaihinh = 4;
                                stt = i;

                                gocquay = f.gocquay;
                                hsbd = f.hsbd;
                                sx = f.sx;
                                sy = f.sy;
                                diems[2].X = x; diems[2].Y = y;
                            }
                        }
                        return;
                    }
            }
           if (hinhbhs!=null)
            { for (i = 0; i <hinhbhs.Length; i++) 
                if(diem_hbh(x,y,hinhbhs[i])==1) 
                {
                    hbh  temp = hinhbhs[i];
                    Formhbh f = new Formhbh(temp);
                    f.ShowDialog();
                    if (f.xoa == 1)//da chon nut xoa
                    {
                       hinhbhs=Delete(i,hinhbhs);
                    }
                    else hinhbhs[i] = f.getvalue();
                    panel1.Refresh();
                    chon = f.chon;
                    if (chon!=0)
                    {
                        if (chon == 7)
                        {
                            mauto = f.mauto;
                            Point tam = new Point(s.round(hinhbhs[i].d1.X + (hinhbhs[i].d2.X - hinhbhs[i].d1.X) / 2), s.round(hinhbhs[i].d1.Y + (hinhbhs[i].d3.Y - hinhbhs[i].d1.Y) / 2));
                            tomau_dongquet(tam, mauto, hinhbhs[i].mau);
                        }
                        else
                        {
                            loaihinh = 5;
                            stt = i;
                            diems[2].X = x; diems[2].Y = y;
                            gocquay = f.gocquay;
                            hsbd = f.hsbd;
                            sx = f.sx;
                            sy = f.sy;
                        }
                    }
                    return;
                }
            }
       
            }

        }

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
        private void fillright(int x,int y,Color F,Color B)
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
            int x,y;
            x=diem.X;y=diem.Y;
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
        public Point nhanMT2(int[,] matran,int[] mang)
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
            if(loaihinh==0) //duongthang
            {
               // dthang temp1=new dthang(lines[stt].diemdau,lines[stt].diemcuoi,lines[stt].mau);
                dthang temp=new dthang(doixung(lines[stt].diemdau,diems[0]),doixung(lines[stt].diemcuoi,diems[0]),lines[stt].mau);
                DDA_Line(temp);
                lines[stt]=temp;
                DDA_Line(lines[stt]);
            }
            else if(loaihinh==1)//dtron
            {
                htron temp=new htron(circles[stt].bkinh,doixung (circles[stt].tam,diems[0]),circles[stt].mau);
                Midpoint_htron(temp);
               circles[stt]=temp;
                Midpoint_htron(circles[stt]);
            }
            else if(loaihinh==2)//hvuong
            {
               
                hvuong temp=new hvuong(doixung(squares[stt].d1,diems[0]),doixung(squares[stt].d2,diems[0]),doixung(squares[stt].d3,diems[0]),doixung(squares[stt].d4,diems[0]),squares[stt].mau);
                hinhvuong(temp);
                squares[stt]=temp;
                hinhvuong(squares[stt]);
            }
            else if(loaihinh==3)//hcn
            {
                hcn temp=new hcn(doixung(rectangles[stt].d1,diems[0]),doixung(rectangles[stt].d2,diems[0]),doixung(rectangles[stt].d3,diems[0]),doixung(rectangles[stt].d4,diems[0]),rectangles[stt].mau);
                hinhcn(temp);
                rectangles[stt]=temp;
                hinhcn(rectangles[stt]);
            }
            else if(loaihinh==4)//elip
            {
                elip temp=new elip(doixung(elippses[stt].tam,diems[0]),elippses[stt].a,elippses[stt].b,elippses[stt].mau);
                Midpoint_elip(temp);
                elippses[stt]=temp;
                Midpoint_elip(elippses[stt]);
            }
            else //(loaihinh==5)//hbh
            {
                hbh temp=new hbh(doixung(hinhbhs[stt].d1,diems[0]),doixung(hinhbhs[stt].d2,diems[0]),doixung(hinhbhs[stt].d3,diems[0]),doixung(hinhbhs[stt].d4,diems[0]),hinhbhs[stt].mau);
                hinhbinhhanh(temp);
               hinhbhs[stt]=temp;
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
        public void bd_tinhtien(int dx,int dy)
        {
           if (loaihinh == 0)//dthang
            {

                dthang temp = new dthang(Tinhtien(lines[stt].diemdau,dx,dy), Tinhtien(lines[stt].diemcuoi, dx,dy), lines[stt].mau);
                DDA_Line(temp);
                lines[stt] = temp;
            }
            else if (loaihinh == 1)//dtron
            {
                htron temp = new htron(circles[stt].bkinh, Tinhtien(circles[stt].tam,dx,dy), circles[stt].mau);
                Midpoint_htron(temp);
                circles[stt] = temp;
            }
            else if (loaihinh == 2)//hvuong
            {

                hvuong temp = new hvuong(Tinhtien(squares[stt].d1,dx,dy), Tinhtien(squares[stt].d2,dx,dy), Tinhtien(squares[stt].d3, dx,dy), Tinhtien(squares[stt].d4,dx,dy), squares[stt].mau);
                hinhvuong(temp);
                squares[stt] = temp;
            }
            else if (loaihinh == 3)//hcn
            {
                hcn temp = new hcn(Tinhtien(rectangles[stt].d1,dx,dy), Tinhtien(rectangles[stt].d2, dx,dy), Tinhtien(rectangles[stt].d3, dx,dy), Tinhtien(rectangles[stt].d4,dx,dy), rectangles[stt].mau);
                hinhcn(temp);
                rectangles[stt] = temp;
            }
            else if (loaihinh == 4)//elip
            {
                elip temp = new elip(Tinhtien(elippses[stt].tam, dx,dy), elippses[stt].a, elippses[stt].b, elippses[stt].mau);
                Midpoint_elip(temp);
                elippses[stt] = temp;
            }
            else //if (loaihinh == 5)//hbh
            {
                hbh temp = new hbh(Tinhtien(hinhbhs[stt].d1, dx,dy), Tinhtien(hinhbhs[stt].d2,dx,dy), Tinhtien(hinhbhs[stt].d3,dx,dy), Tinhtien(hinhbhs[stt].d4,dx,dy), hinhbhs[stt].mau);
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
                dthang temp = new dthang(tyle(lines[stt].diemdau, diems[0]),tyle(lines[stt].diemcuoi, diems[0]), lines[stt].mau);
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
                    rectangles = this.Delete(stt,rectangles);
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
                        circles = Delete(stt,circles);
                       

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
                   rectangles = this.Delete(stt,rectangles);
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
                        elippses = Delete(stt,elippses);
                           
                       
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
        public Point doixung(Point d1,Point d2)// ve diem doi xung cua (x1,y1)qua tam doi xung (x2,y2)
        {
            int x1,y1,x2,y2;
            x1=d1.X;y1=d1.Y;x2=d2.X;y2=d2.Y;
            int[,] matran1;
            int[,] matran2;
            int[] mang;
            int[] mangtam ={ 0, 0, 0 };
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
       public  Point dxungOy(Point diem, int x)
        {
            Point temp = new Point(0, 0);
            if (diem.X < x) temp.X = diem.X + 2 * (x - diem.X);
            else temp.X = diem.X - 2 * (diem.X - x);
            temp.Y = diem.Y;
            return temp;
        }
        //DOI XUNG QUA DUONG THANG BAT KI...
        public Point Doixung(double m, int b,Point diem)
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
        public Point BienDang( double m, int b,Point diem)
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
        public Point Tinhtien(Point d1,int dx,int dy)
        {
            int x,y;
            x=d1.X;y=d1.Y;
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
        public Point Quay(Point d1,Point d2)// Quay 1 diem (x,y)quanh diem(xo,yo)1 goc a;
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
        public Point tyle(Point d1,Point d2)
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
            int[] mangtam ={ 0, 0, 0 };
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

       /* private void panel1_DoubleClick(object sender, EventArgs e)
        {
            
        }*/

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr= MessageBox.Show("Ban muon thoat khoi chuong trinh?","",MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(dr==DialogResult.Yes)
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            khoitaobien();
            initbd();
            panel1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


      
    }
}