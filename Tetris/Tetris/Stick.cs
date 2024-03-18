using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
   class Stick : Figure
   {
      public Stick(int x, int y, char ch)
      {
         points[0] = new Point(x, y, ch);
         points[1] = new Point(x, y + 1, ch);
         points[2] = new Point(x, y + 2, ch);
         points[3] = new Point(x, y + 3, ch);
         Draw();
      }

      public override void Rotate(Point[] pList)
      {
         if (pList[0].X == pList[1].X)
         {
            RotateHorisontal(pList);
         }
         else
         {
            RotateVertical(pList);
         }
      }

      private void RotateVertical(Point[] pList)
      {
         for (int i = 0; i < pList.Length; i++)
         {
            pList[i].X = pList[0].X;
            pList[i].Y = pList[0].Y + i;
         }
      }

      private void RotateHorisontal(Point[] pList)
      {
         for (int i = 0; i < pList.Length; i++)
         {
            pList[i].Y = pList[0].Y;
            pList[i].X = pList[0].X + i;
         }
      }
   }
}
