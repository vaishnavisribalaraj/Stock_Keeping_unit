using System;
using System.Collections.Generic;
using System.Text;

namespace SKU_Calculator
{
    public class Promotion_Calculator
    {
        //Instatiation of the class for segregating the promotion engine rule
        Promotion_segregation promotion_Segregation = new Promotion_segregation();
        //creating method for segregating the promotion engine rules
        public List<Promotion_segregation> Promotion_Segregations(List<string> promotionTypes)
        {
            List<Promotion_segregation> promotion_Segregations = new List<Promotion_segregation>();
            int index = 0;
            for (int i = 0; i < promotionTypes.Count; i++)
            {
                Promotion_segregation promotion_Segregation = new Promotion_segregation();
                if (promotionTypes[i].Contains("of"))
                {
                    //Capturing the number of units and SKU ID for "no of units of SKUID's for price" pattern
                    index = promotionTypes[i].IndexOf("of");
                    char temp = promotionTypes[i][index - 2];
                    promotion_Segregation.NumberOfUnits = (int)char.GetNumericValue(temp);

                    promotion_Segregation.Main_SKUID = promotionTypes[i][index + 3];
                    promotion_Segregation.Secondary_SKUID = null;
                }
                if (promotionTypes[i].Contains("for"))
                {
                    //Capturing the Price for "no of units of SKUID's for price" & "SKUID1 & SKUID2 for price" pattern
                    index = promotionTypes[i].IndexOf("for");

                    promotion_Segregation.Price = Int16.Parse(promotionTypes[i].Substring(index + 4)); ;
                }
                if (promotionTypes[i].Contains("&"))
                {
                    //Capturing 2 SKUID for "SKUID1 & SKUID2 for price" pattern
                    index = promotionTypes[i].IndexOf("&");
                    promotion_Segregation.Main_SKUID = promotionTypes[i][index - 2];
                    promotion_Segregation.Secondary_SKUID = promotionTypes[i][index + 2];
                    promotion_Segregation.NumberOfUnits = 1;
                }
                promotion_Segregations.Add(promotion_Segregation);

            }
            return promotion_Segregations;
        }
    }
}
