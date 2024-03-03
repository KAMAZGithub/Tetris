using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Point
    {
        public int x;
        public int y;
        public char ch;

        public Point(int x, int y, char ch)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
        }

        public Point() { }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }
    }
}
