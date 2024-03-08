using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer
{
    class Program
    {
        private static int getCountElements(int value, int[] mass)
        {
            int count = 0;

            for(int i = 0; i < mass.Length; i++)
            {
                if (mass[i] == value)
                    count++;
            }

            return count;
        }
        static void Main(string[] args)
        {
            const int HIGH_ARRAY_BOUND = 10;

            Random rnd = new Random();
            int[] mass = new int[HIGH_ARRAY_BOUND];

            for(int i = 0; i < mass.Length; i++)
            {
                mass[i] = rnd.Next(0, 11);
            }

            int maxCount = getCountElements(mass[0], mass);
            int index = 0;

            for(int i = 0; i < mass.Length; i++)
            {
                int count = getCountElements(mass[i], mass);
                if (count > maxCount)
                {
                    maxCount = count;
                    index = i;
                }                    
            }

            foreach(int value in mass)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();

            Console.WriteLine($"maxCount = {maxCount} value = {mass[index]}");
            Console.WriteLine();

        }
    }
}
