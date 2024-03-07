using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
   class Employer :  Human
   {
      protected int solary;
      public Employer(int age, int height, int solary)
      {
         this.age = age;
         this.height = height;
         this.solary = solary;
      }

      public override void Write()
      {
         Console.WriteLine($"age = {age}, height = {height}, solary = {solary}");
      }
   }
}
