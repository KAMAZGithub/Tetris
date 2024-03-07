using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
   abstract class Human
   {
      protected int age = 0;
      protected int height = 0;

      public Human(int age, int height)
      {
         this.age = age;
         this.height = height;
      }

      public Human() { }

      public abstract void Write();
   }
}
