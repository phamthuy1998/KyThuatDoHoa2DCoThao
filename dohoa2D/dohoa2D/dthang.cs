using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace dohoa2D
{
  public class dthang
    {
      public Point diemdau;
      public Point diemcuoi;
      public Color mau;
      public double hesogoc, b1;
      public int b;
      public dthang()
      {
          diemdau = new Point(0,0);
          diemcuoi = new Point(0,0);
          mau=Color.DarkGreen;
          hesogoc = 0;
          b1 = b = 0;
      }
      public dthang(Point dd, Point dc, Color m)
      {
          int d1 = dd.X; int r1 = dd.Y; int d2 = dc.X;int  r2 = dc.Y;
          diemdau =dd ;
          diemcuoi = dc;
          mau = m;
          if (d1 == d2) hesogoc = 0;
          else hesogoc = (r1 - r2) / (d1 - d2);
          b1 = r1 - hesogoc * d1;
          b = Convert.ToInt16(b1);
      }
     public void setpro(Point dd,Point dc,Color m)
      {
          diemdau = dd;
          diemcuoi = dc;
          mau = m;
      }
      public dthang getpro()
      {
          dthang item = new dthang(diemdau, diemcuoi, mau);
          return item;
      }
      public double gethsg()
      { return hesogoc; }
      public int getb()
      { return b; }
    }

}
