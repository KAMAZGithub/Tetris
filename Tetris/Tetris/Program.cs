using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Tetris
{
   class Program
   {
      const int TIMER_INTERVAL = 500;
      static System.Timers.Timer timer;
      static private Object _lockObject = new Object();

      static Figure currentFigure;
      static FigureGenerator generator = new FigureGenerator(Field.Width / 2, 0, Drawer.DEFAULT_SYMBOL);
      static void Main(string[] args)
      {
         Console.SetWindowSize(Field.Width+1, Field.Height+1);
         Console.SetBufferSize(Field.Width+1, Field.Height+1);
       
         //Field.Width = 20;
         //Field.Height = 20;

         //FigureGenerator generator = new FigureGenerator(20, 0, '*');
         currentFigure = generator.GetNewFigure();
         SetTimer();

         while (true)
         {
            if (Console.KeyAvailable)
            {
               var key = Console.ReadKey();
               Monitor.Enter(_lockObject);
               var result = HandleKey(currentFigure, key);
               ProcessResult(result, ref currentFigure);
               Monitor.Exit(_lockObject);
            }
         }
      }

      private static void SetTimer()
      {
         timer = new System.Timers.Timer(TIMER_INTERVAL);

         timer.Elapsed += OnTimedEvent;
         timer.AutoReset = true;
         timer.Enabled = true;
      }

      private static void OnTimedEvent(object sender, ElapsedEventArgs e)
      {
         Monitor.Enter(_lockObject);
         var result = currentFigure.TryMove(Direction.DOWN);
         ProcessResult(result, ref currentFigure);
         Monitor.Exit(_lockObject);
      }

      private static bool ProcessResult(Result result, ref Figure currentFigure)
      {
         if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
         {
            Field.AddFigure(currentFigure);
            Field.TryDeleteLines();

            if (currentFigure.IsOnTop())
            {
               WriteGameOver();
               timer.Elapsed -= OnTimedEvent;
               return true;
            }
            else
            {
               currentFigure = generator.GetNewFigure();
               return false;
            }

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
      private static void WriteGameOver()
      {
         Console.SetCursorPosition(Field.Width / 2 - 8, Field.Width / 2);
         Console.WriteLine("GAME OVER");
      }
   }
}
