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

      internal void Move(Direction dir)
      {
         foreach (var p in points)
         {
            p.Move(dir);
         }
      }

      internal Result TryMove(Direction dir)
      {
         Hide();

         Move(dir);

         Result result = VerifyPosition();
         if (result != Result.SUCCESS)
            Move(Reverse(dir));

         Draw();

         return result;
      }

      private Direction Reverse(Direction dir)
      {
         Direction result = dir;
         switch (dir)
         {
            case Direction.LEFT:
               result = Direction.RIGHT;
               break;
            case Direction.RIGHT:
               result = Direction.LEFT;
               break;
            case Direction.DOWN:
               result = Direction.UP;
               break;
            case Direction.UP:
               result = Direction.DOWN;
               break;
         }

         return result;
      }

      internal Result TryRotate()
      {
         Hide();
         Rotate();

         var result = VerifyPosition();
         if (result != Result.SUCCESS)
            Rotate();

         //if (VerifyPosition(clone))
         //   points = clone;

         Draw();
         return result;
      }

      private Result VerifyPosition()
      {
         foreach(Point p in points)
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

      internal bool IsOnTop()
      {
         return points[0].Y == 0;
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
