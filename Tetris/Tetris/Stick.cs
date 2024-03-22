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

      public override void Rotate()
      {
         if (points[0].X == points[1].X)
         {
            RotateHorisontal();
         }
         else
         {
            RotateVertical();
         }
      }

      private void RotateVertical()
      {
         for (int i = 0; i < points.Length; i++)
         {
            points[i].X = points[0].X;
            points[i].Y = points[0].Y + i;
         }
      }

      private void RotateHorisontal()
      {
         for (int i = 0; i < points.Length; i++)
         {
            points[i].Y = points[0].Y;
            points[i].X = points[0].X + i;
         }
      }
   }
}
