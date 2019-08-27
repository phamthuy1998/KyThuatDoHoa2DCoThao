using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace dohoa2D
{
    public class hbh
    {
        public Point d1, d2, d3;
        public Color mau;
        public Point d4;
        public hbh()
        {
            d1 = new Point(0, 0);
            d2 = new Point(0, 0);
            d3 = new Point(0, 0);
            d4 = new Point(0, 0);
            mau = Color.DarkGreen;
        }
        public hbh(Point dd1, Point dd2, Point dd3, Color m)
        {
            d1 = new Point(dd1.X, dd1.Y);
            d2 = new Point(dd2.X, dd2.Y);
            d3 = new Point(dd3.X, dd3.Y);
            tinhd4();
            mau = m;
        }
        public void tinhd4()
        {
            d4 = new Point(d3.X - (d2.X - d1.X),d3.Y - (d2.Y - d1.Y));
        }
        public void setpro(Point dd1, Point dd2, Point dd3, Color m)
        {
            d1 = dd1;
            d2 = dd2;
            d3 = dd3;
            tinhd4();
            mau = m;
        }
        public hbh getpro()
        {
            hbh item = new hbh(d1, d2, d3, mau);
            return item;
        }
    }
}
