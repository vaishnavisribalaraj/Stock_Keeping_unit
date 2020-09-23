using System;
using System.Collections.Generic;
using System.Text;

namespace SKU_Calculator
{
   public class Promotion_segregation
    {
        private char main_SKUID;
        public char Main_SKUID { get; set; }

        private char? secondary_SKUID;
        public char? Secondary_SKUID { get; set; }

        private int numberOfUnits;
        public int NumberOfUnits { get; set; }

        private int price;
        public int Price { get; set; }
    }
}
