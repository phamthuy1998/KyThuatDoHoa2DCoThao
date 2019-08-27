using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace dohoa2D
{
    public class hvuong
    {
        public Point d1, d2;
        public Color mau;
        public Point d3, d4;
        public hvuong()
        {
            d1 = new Point(0, 0);
            d2 = new Point(0, 0);
            d3 = new Point(0, 0);
            d4 = new Point(0, 0);
            mau = Color.DarkGreen;
        }
        public hvuong(Point dd1, Point dd2, Color m)
        {
            d1 = new Point(dd1.X, dd1.Y);
            d2 = new Point(dd2.X, dd2.Y);
            d3d4();
            mau = m;
        }
        public void d3d4()
        {
            int canh = Math.Abs(d2.X - d1.X);
            d3 = new Point(d1.X, d1.Y + canh);
            d4 = new Point(d2.X, d2.Y + canh);
        }
        public void setpro(Point dd1, Point dd2, Color m)
        {
            d1 = dd1;
            d2 = dd2;
            d3d4();
            mau = m;
        }
        public hvuong getpro()
        {
            hvuong item = new hvuong(d1, d2, mau);
            return item;
        }
    }
}
