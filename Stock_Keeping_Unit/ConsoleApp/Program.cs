using System;
using System.Collections.Generic;
using SKU_Calculator;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> PromotionTYpes = new List<string>() { "3 of A's for 130", "2 of B's for 120", "C & B for 130" };
            Promotion_Calculator p = new Promotion_Calculator();
            //getting the promotion rules by calling the method
            List<Promotion_segregation> rules=p.Promotion_Segregations(PromotionTYpes);
            
            foreach (var i in rules) {
                Console.WriteLine(i.Main_SKUID);
            }

        }
    }
}
