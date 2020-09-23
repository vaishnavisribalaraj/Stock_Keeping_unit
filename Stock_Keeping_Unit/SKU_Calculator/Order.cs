using System;
using System.Collections.Generic;
using System.Text;

namespace SKU_Calculator
{
    public class Order
    {
        private char sKUID;
        private int units;
        /// <summary>
        /// Getting and Setting the SKUID
        /// </summary>
        public char SKUID
        {
            get { return sKUID; }
            set { sKUID = value; }
        }
        /// <summary>
        /// Getting and setting the units for particular SKUID
        /// </summary>
        public int Units
        {
            get { return units; }
            set { units = value; }
        }
    }
}
