﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
   class ConsoleDrawing : IDrawer
   {
      public void DrawPoint(int x, int y)
      {
         Console.SetCursorPosition(x, y);
         Console.Write("*");
         Console.SetCursorPosition(0, 0);
      }

      public void HidePoint(int x, int y)
      {
         Console.SetCursorPosition(x, y);
         Console.Write(" ");
         Console.SetCursorPosition(0, 0);
      }
   }
}