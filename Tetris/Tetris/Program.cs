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

         Figure sq = new Stick(10, 5, '*');         
         sq.Draw();
         Thread.Sleep(1000);

         sq.Hide();
         sq.Rotate();
         sq.Draw();

         Thread.Sleep(1000);

      }

   }
}
