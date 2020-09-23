using System;
using System.Collections.Generic;
using System.Text;

namespace SKU_Calculator
{
    class SKU_Price
    {
        //Adding the Properties
        private char sKU_ID;
        private int price;
        /// <summary>
        /// Getting and Setting the SKU_ID
        /// </summary>
        public char SKU_ID
        {
            get { return sKU_ID; }
            set { sKU_ID = value; }
        }
        /// <summary>
        /// Getting and setting the price for particular SKUID
        /// </summary>
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
