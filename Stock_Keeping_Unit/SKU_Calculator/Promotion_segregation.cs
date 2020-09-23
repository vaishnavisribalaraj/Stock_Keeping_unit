using System;
using System.Collections.Generic;
using System.Text;

namespace SKU_Calculator
{
   public class Promotion_segregation
    {
        // Promotion segregation is mainly for extracting the promotion rule
        /// <summary>
        /// Storing the Main SKUID and secondary SKUID
        /// </summary>
        private char main_SKUID;
        public char Main_SKUID { get; set; }

        private char? secondary_SKUID;
        public char? Secondary_SKUID { get; set; }

        /// <summary>
        /// Number of units given in the pattern
        /// </summary>
        private int numberOfUnits;
        public int NumberOfUnits { get; set; }
        /// <summary>
        /// Price given in the pattern
        /// </summary>
        private int price;
        public int Price { get; set; }
    }
}
