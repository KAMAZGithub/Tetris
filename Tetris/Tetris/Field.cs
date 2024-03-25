using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
   static class Field
   {
      private static int _width = 20;
      private static int _heght = 20;

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

      public static void TryDeleteLines()
      {
         for(int i = 0; i < Height; i++)
         {
            int counter = 0;
            for (int j = 0; j < Width; j++)
            {
               if (_heap[i][j])
                  counter++;
            }

            if (counter == Width)
            {
               DeleteLine(i);
               Redraw();
            }
         }
      }

      private static void Redraw()
      {
         for (int i = 0; i < Height; i++)
         {
            for (int j = 0; j < Width; j++)
            {
               if (_heap[i][j])
                  DrawerProvider.Drawer.DrawPoint(j, i);
               else
                  DrawerProvider.Drawer.HidePoint(j, i);
            }
         }
      }

      private static void DeleteLine(int line)
      {
         for (int i = line; i > 0; i--)
         {
            for (int j = 0; j < Width; j++)
            {
               if (j == 0)
                  _heap[i][j] = false;
               else
                  _heap[i][j] = _heap[i - 1][j];
            }
         }
      }

      public static bool CheckStrike(Point p)
      {
         return _heap[p.Y][p.X];
      }
   }
}
