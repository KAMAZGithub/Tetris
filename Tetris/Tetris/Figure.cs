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
      public Point[] points = new Point[LENGTH];

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
      internal Result TryMove(Direction dir)
      {
         Hide();
         Point[] clone = Clone();
         Move(clone, dir);

         Result result = VerifyPosition(clone);
         if (result == Result.SUCCESS)
            points = clone;
         //if (VerifyPosition(clone))
         //   points = clone;

         Draw();

         return result;
      }

      internal Result TryRotate()
      {
         Hide();
         Point[] clone = Clone();
         Rotate(clone);

         var result = VerifyPosition(clone);
         if (result == Result.SUCCESS)
            points = clone;

         //if (VerifyPosition(clone))
         //   points = clone;

         Draw();
         return result;
      }

      private Result VerifyPosition(Point[] clone)
      {
         foreach(Point p in clone)
         {
            if (p.Y >= Field.Height)
               return Result.DOWN_BORDER_STRIKE;

            if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
               return Result.BORDER_STRIKE;

            if (Field.CheckStrike(p))
               return Result.HEAP_STRIKE;

            //if (p.X <= 0 || p.Y < 0 || p.X >= Field.Width || p.Y >= Field.Height)
            //   return false;
         }

         return Result.SUCCESS;
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

      public abstract void Rotate(Point[] pList);

      public void Hide()
      {
         foreach(Point p in points)
         {
            p.Hide();
         }
      }

   }
}
