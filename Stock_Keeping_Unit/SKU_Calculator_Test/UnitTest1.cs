using NUnit.Framework;
using SKU_Calculator;
using System.Collections.Generic;
namespace SKU_Calculator_Test
{
    public class Tests
    {
        [Test]
        public void Promotion_Segregations_PositiveTest()
        {
            Promotion_Calculator calculator = new Promotion_Calculator();
            List<string> PromotionTYpes = new List<string>() { "3 of A's for 130" };
            Promotion_segregation promotion_Segregation = new Promotion_segregation();
            promotion_Segregation.Main_SKUID = 'A';
            promotion_Segregation.NumberOfUnits = 3;
            promotion_Segregation.Price = 130;
            List<Promotion_segregation> Expectedpromotion_Segregations = new List<Promotion_segregation>();
            Expectedpromotion_Segregations.Add(promotion_Segregation);
            List<Promotion_segregation> Actualpromotion_Segregations = calculator.Promotion_Segregations(PromotionTYpes);
            Assert.AreEqual(Expectedpromotion_Segregations, Actualpromotion_Segregations);
        }
        [Test]
        public void Promotion_Segregations_NegativeTest()
        {
            Promotion_segregation promotion_Segregation = new Promotion_segregation();
            promotion_Segregation.Main_SKUID = 'A';
            promotion_Segregation.NumberOfUnits = 3;
            promotion_Segregation.Price = 130;
            List<Promotion_segregation> Expectedpromotion_Segregations = new List<Promotion_segregation>();
            Expectedpromotion_Segregations.Add(promotion_Segregation);
            Promotion_Calculator calculator = new Promotion_Calculator();
            List<string> PromotionTYpes = new List<string>() { "3 of A's for 13" };
            List<Promotion_segregation> Actualpromotion_Segregations = calculator.Promotion_Segregations(PromotionTYpes);
            Assert.AreNotEqual(Expectedpromotion_Segregations, Actualpromotion_Segregations);
        }

        [Test]
        public void Promotion_Calculation_PositiveTest()
        {
            Promotion_Calculator calculator = new Promotion_Calculator();
            List<string> PromotionTYpes = new List<string>() { "3 of A's for 130", "2 of B's for 120", "C & B for 130" };
            Order order1 = new Order();

            order1.SKUID = 'A';
            order1.Units = 3;

            List<Order> Orders = new List<Order>();
            Orders.Add(order1);

            Dictionary<char, int> price = new Dictionary<char, int>();
            price['A'] = 130;
            price['B'] = 2;
            int ActualTotal = calculator.PromotionCalculation(price, PromotionTYpes, Orders);
            int ExpectedTotal = 130;

            Assert.AreEqual(ExpectedTotal, ActualTotal);
        }
        [Test]
        public void Promotion_Calculation_NegativeTest()
        {
            Promotion_Calculator calculator = new Promotion_Calculator();
            List<string> PromotionTYpes = new List<string>() { "3 of A's for 130", "2 of B's for 120", "C & B for 130" };
            Order order1 = new Order();

            order1.SKUID = 'A';
            order1.Units = 3;
            Order order2 = new Order();
            order2.SKUID = 'B';
            order2.Units = 1;
            List<Order> Orders = new List<Order>();
            Orders.Add(order1);
            Orders.Add(order2);
            Dictionary<char, int> price = new Dictionary<char, int>();
            price['A'] = 130;
            price['B'] = 2;
            int ActualTotal = calculator.PromotionCalculation(price, PromotionTYpes, Orders);
            int ExpectedTotal = 122;

            Assert.AreNotEqual(ExpectedTotal, ActualTotal);


        }
    }
}