﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
   class Program
   {
      static FigureGenerator generator = new FigureGenerator(20, 0, '*');
      static void Main(string[] args)
      {
         //Console.SetWindowSize(Field.WIDTH, Field.HEGHT);
         //Console.SetBufferSize(Field.WIDTH, Field.HEGHT);

         Field.Width = 40;
         Field.Height = 30;

         //FigureGenerator generator = new FigureGenerator(20, 0, '*');
         Figure currentFigure = generator.GetNewFigure();

         while (true)
         {
            if (Console.KeyAvailable)
            {
               var key = Console.ReadKey();
               var result = HandleKey(currentFigure, key);
               ProcessResult(result, ref currentFigure);
            }
         }
      }

      private static bool ProcessResult(Result result, ref Figure currentFigure)
      {
         if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
         {
            Field.AddFigure(currentFigure);
            currentFigure = generator.GetNewFigure();
            return true;
         }
         else
            return false;
      }

      private static Result HandleKey(Figure currentFigure, ConsoleKeyInfo key)
      {
         switch (key.Key)
         {
            case ConsoleKey.LeftArrow:
               return currentFigure.TryMove(Direction.LEFT);               
            case ConsoleKey.RightArrow:
               return currentFigure.TryMove(Direction.RIGHT);
            case ConsoleKey.DownArrow:
               return currentFigure.TryMove(Direction.DOWN);               
            case ConsoleKey.Spacebar:
               return currentFigure.TryRotate();
         }

         return Result.SUCCESS;
      }
   }
}
