using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
   static class Field
   {
      private static int _width = 40;
      private static int _heght = 30;

      public static int Width
      {
         get
         {
            return _width;
         }
         set
         {
            _width = value;
            Console.SetWindowSize(_width, _heght);
            Console.SetBufferSize(_width, _heght);

         }
      }

      public static int Height
      {
         get
         {
            return _heght;
         }
         set
         {
            _heght = value;
            Console.SetWindowSize(_width, _heght);
            Console.SetBufferSize(_width, _heght);
         }
      }

      private static bool[][] _heap;

      static Field()
      {
         _heap = new bool[Height][];
         for (int i = 0; i < Height; i++)
         {
            _heap[i] = new bool[Width];
         }
      }
      public static void AddFigure(Figure fig)
      {
         foreach(var p in fig.points)
         {
            _heap[p.Y][p.X] = true;
         }
      }
      public static bool CheckStrike(Point p)
      {
         return _heap[p.Y][p.X];
      }
   }
}
