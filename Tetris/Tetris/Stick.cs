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
         if (points[0].x == points[1].x)
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
            points[i].x = points[0].x;
            points[i].y = points[0].y + i;
         }
      }

      private void RotateHorisontal()
      {
         for (int i = 0; i < points.Length; i++)
         {
            points[i].y = points[0].y;
            points[i].x = points[0].x + i;
         }
      }
   }
}
