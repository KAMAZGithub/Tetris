using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
   public class Point
   {
      public int X { get; set; }
      public int Y { get; set; }
      public char Ch { get; set; }

      public Point(Point p)
      {
         X = p.X;
         Y = p.Y;
         Ch = p.Ch;
      }

      public Point(int x, int y, char ch)
      {
         this.X = x;
         this.Y = y;
         this.Ch = ch;
      }

      public Point() { }
      public void Draw()
      {
         Console.SetCursorPosition(X, Y);
         Console.Write(Ch);
         Console.SetCursorPosition(0, 0);
      }

      internal void Move(Direction dir)
      {
         switch (dir)
         {
            case Direction.DOWN:
               Y += 1;
               break;
            case Direction.UP:
               Y -= 1;
               break;
            case Direction.LEFT:
               X -= 1;
               break;
            case Direction.RIGHT:
               X += 1;
               break;
         }
      }

      internal void Hide()
      {
         Console.SetCursorPosition(X, Y);
         Console.Write(" ");
      }
   }
}
