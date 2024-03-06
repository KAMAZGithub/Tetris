using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.SetWindowSize(40, 30);
         Console.SetBufferSize(40, 30);

         Square sq = new Square(5, 5, '*');         
         sq.Draw();

         Thread.Sleep(1000);
         sq.Hide();
         sq.Move(Direction.LEFT);
         sq.Draw();

         Thread.Sleep(1000);
         sq.Hide();
         sq.Move(Direction.DOWN);
         sq.Draw();

         Thread.Sleep(1000);
         sq.Hide();
         sq.Move(Direction.LEFT);
         sq.Draw();

         Thread.Sleep(1000);
         sq.Hide();
         sq.Move(Direction.DOWN);
         sq.Draw();

         Thread.Sleep(1000);
         sq.Hide();
         sq.Move(Direction.RIGHT);
         sq.Draw();

         Thread.Sleep(1000);
         sq.Hide();
         sq.Move(Direction.DOWN);
         sq.Draw();

         Thread.Sleep(1000);
         sq.Hide();
         sq.Move(Direction.RIGHT);
         sq.Draw();

         Thread.Sleep(1000);
         sq.Hide();
         sq.Move(Direction.DOWN);
         sq.Draw();

         Thread.Sleep(1000);
         sq.Hide();
         sq.Move(Direction.RIGHT);
         sq.Draw();



         //Figure[] figures = new Figure[2];
         //figures[0] = new Square(2, 2, '+');
         //figures[1] = new Stick(5, 2, '-');

         //foreach (Figure f in figures)
         //   f.Draw();
      }

   }
}
