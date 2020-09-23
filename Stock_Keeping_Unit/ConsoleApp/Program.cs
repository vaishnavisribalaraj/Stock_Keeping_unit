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
            //Adding the order details
            Order order1 = new Order();

            order1.SKUID = 'A';
            order1.Units = 3;
            Order order2 = new Order();

            order2.SKUID = 'B';
            order2.Units = 1;
            //Adding the order object to list of orders
            List<Order> Orders = new List<Order>();
            Orders.Add(order1);
            Orders.Add(order2);
            //Adding the price details in the dictionary
            Dictionary<char, int> price = new Dictionary<char, int>();
            price['A'] = 130;
            price['B'] = 2;
            Promotion_Calculator p = new Promotion_Calculator();
            
            
            
            //Calling the method to get the total price of the order
            int Total = p.PromotionCalculation(price, PromotionTYpes, Orders);
            Console.WriteLine(Total);


        }
    }
}
