using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
   class Oficer: Human
   {
      protected string rang = "";

      public Oficer(int age, int height, string rang)
      {
         this.age = age;
         this.height = height;
         this.rang = rang;
      }

      public override void Write()
      {
         Console.WriteLine($"age = {age}, height = {height}, rang = {rang}");
      }
   }
}
