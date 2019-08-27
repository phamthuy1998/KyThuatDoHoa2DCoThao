using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace dohoa2D
{
    public class elip
    {
        public Point tam;
        public int a, b;
        public Color mau;
        public elip()
        {
            tam = new Point(0, 0);
            a = b = 0;
            mau = Color.DarkGreen;
        }
        public elip(Point t, int aa, int bb, Color m)
        {
            tam = new Point(t.X, t.Y);
            a = aa; b = bb;
            mau = m;
        }
        public void setpro(Point t, int aa, int bb, Color m)
        {
            tam = t;
            a = aa; b = bb;
            mau = m;
        }
        public elip getpro()
        {
            elip item = new elip(tam, a, b, mau);
            return item;
        }
    }
}
