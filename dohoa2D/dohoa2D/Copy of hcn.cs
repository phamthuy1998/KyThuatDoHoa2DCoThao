using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace dohoa2D
{
    public class hcn
    {
        public Point d1, d2;
        public Color mau;
        public Point d3, d4;
        public hcn()
        {
            d1 = new Point(0, 0);
            d2 = new Point(0, 0);
            d3 = new Point(0, 0);
            d4 = new Point(0, 0);
            mau = Color.DarkGreen;
        }
        public hcn(Point dd1, Point dd2, Color m)
        {
            d1 = new Point(dd1.X, dd1.Y);
            d2 = new Point(dd2.X, dd2.Y);
            d3d4();
            mau = m;
        }
        public void d3d4()
        {
            d3= new Point(d2.X, d1.Y);
            d4 = new Point(d1.X, d2.Y);
        }
        public void setpro(Point dd1, Point dd2, Color m)
        {
            d1 = dd1;
            d2 = dd2;
            d3d4();
            mau = m;
        }
        public hcn getpro()
        {
            hcn item = new hcn(d1, d2, mau);
            return item;
        }
    }
}
