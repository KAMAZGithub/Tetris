using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
   class Program
   {
      static void Main(string[] args)
      {
         Random rnd = new Random();
         Days day = (Days)rnd.Next(1, 8);
         string str = "";

         switch (day)
         {
            case Days.Monday:
               str = "Понедельние";
               break;
            case Days.Tuesday:
               str = "Вторник";
               break;
            case Days.Wednesday:
               str = "Среда";
               break;
            case Days.Thursday:
               str = "Четверг";
               break;
            case Days.Friday:
               str = "Пятница";
               break;
            case Days.Saturday:
               str = "Суббота";
               break;
            case Days.Sunday:
               str = "Воскресенье";
               break;
         }

         Console.WriteLine($"{str}");
      }
   }
}
