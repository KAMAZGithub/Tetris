﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
   static class DrawerProvider
   {
      private static IDrawer _drawer = new ConsoleDrawing2();

      public static IDrawer Drawer
      {
         get
         {
            return _drawer;
         }
      }
   }
}
