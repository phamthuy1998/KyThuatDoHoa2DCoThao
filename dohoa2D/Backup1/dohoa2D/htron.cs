using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace dohoa2D
{
    public class htron
    {
        public int bkinh;
        public Point tam;
        public Color mau;
        public htron()
        {
            bkinh = 0;
            tam = new Point(0,0);
            mau = Color.DarkGreen;
        }
        public htron(int bk, Point tamht, Color m)
        {
            bkinh = bk;
            tam = new Point(tamht.X, tamht.Y);
            mau = m;
        }
        public void setpro(int bk, Point tamht, Color m)
        {
            bkinh = bk;
            tam = tamht;
            mau = m;
        }
        public htron getpro()
        {
            htron item = new htron(bkinh, tam, mau);
            return item;
        }
    }
}
