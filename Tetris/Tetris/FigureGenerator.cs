using System;

namespace Tetris
{
    internal class FigureGenerator
    {
        private int _x;
        private int _y;
        private char _ch;

        private Random _rnd = new Random();

        public FigureGenerator(int x, int y, char ch)
        {
            _x = x;
            _y = y;
            _ch = ch;
        }

        public Figure GetNewFigure()
        {
            if(_rnd.Next(0, 2) == 0)
            {
                return new Square(_x, _y, _ch);
            }
            else
            {
                return new Stick(_x, _y, _ch);
            }
        }
    }
}