using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
   class Program
   {
      static void Main(string[] args)
      {
         //Employer em1 = new Employer(25, 180, 200000);
         //em1.Write();

         //Human hum1 = new Human(30, 150);
         //hum1.Write();

         //Human hum2 = new Employer(33, 160, 100000);
         //hum2.Write();

         //Oficer of1 = new Oficer(50, 155, "капитан");
         //of1.Write();

         Human[] humans = new Human[2];         
         humans[0] = new Employer(20, 150, 20000);
         humans[1] = new Oficer(30, 170, "Подпол");

         foreach(Human h in humans)
         {
            h.Write();
         }

      }
   }
}
