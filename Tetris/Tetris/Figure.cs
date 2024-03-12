using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
   abstract class Figure
   {
      const int LENGTH = 4;
      protected Point[] points = new Point[LENGTH];

      public void Draw()
      {
         foreach (Point p in points)
            p.Draw();
      }

      internal void Move(Point[] pList, Direction dir)
      {
         foreach (var p in pList)
         {
            p.Move(dir);
         }
      }

      public void Move(Direction dir)
      {
         Hide();
         foreach(Point p in points)
         {
            p.Move(dir);
         }
         Draw();
      }
      internal void TryMove(Direction dir)
      {
         Hide();
         Point[] clone = Clone();

         Move(clone, dir);
         if (VerifyPosition(clone))
            points = clone;

         Draw();
      }

      private bool VerifyPosition(Point[] clone)
      {
         foreach(Point p in clone)
         {
            if (p.x <= 0 || p.y < 0 || p.x >= 40 || p.y >= 30)
               return false;
         }

         return true;
      }

      private Point[] Clone()
      {
         var newPoints = new Point[points.Length];
         for(int i = 0; i < newPoints.Length; i++)
         {
            newPoints[i] = new Tetris.Point(points[i]);
         }

         return newPoints;
      }

      public abstract void Rotate();

      public void Hide()
      {
         foreach(Point p in points)
         {
            p.Hide();
         }
      }

   }
}
