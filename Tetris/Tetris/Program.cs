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

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure fg = null;

            while (true)
            {
                FigureFall(out fg, generator);
                fg.Draw();
            }
        }

        private static void FigureFall(out Figure fg, FigureGenerator generator)
        {
            fg = generator.GetNewFigure();

            for (int i = 0; i < 20; i++)
            {
                fg.Hide();
                fg.Move(Direction.DOWN);
                fg.Draw();
                Thread.Sleep(500);
            }

        }
    }
}
