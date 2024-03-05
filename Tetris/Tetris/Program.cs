﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.SetWindowSize(40, 30);
         Console.SetBufferSize(40, 30);

         Figure[] figures = new Figure[2];
         figures[0] = new Square(2, 2, '+');
         figures[1] = new Stick(5, 2, '-');

         foreach (Figure f in figures)
            f.Draw();
      }

   }
}
