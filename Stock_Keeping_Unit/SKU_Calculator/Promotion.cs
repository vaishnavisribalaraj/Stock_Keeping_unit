using System;
using System.Collections.Generic;
using System.Text;

namespace SKU_Calculator
{
    class Promotion
    {
        private List<string> promotion_types;
        /// <summary>
        /// Getting and setting of Promotion_types
        /// </summary>
        public List<string> Promotion_types
        {
            get
            {
                return promotion_types;
            }
            set
            {
                promotion_types = value;
            }
        }
    }
}
