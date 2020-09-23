using System;
using System.Collections.Generic;
using System.Text;

namespace SKU_Calculator
{
    public class Promotion_Calculator
    {
        //Instatiation of the class for segregating the promotion engine rule
        Promotion_segregation promotion_Segregation = new Promotion_segregation();
        //Method for calculating the price
        public int PromotionCalculation(Dictionary<char, int> skuPrice, List<string> promotionTypes, List<Order> orders)
        {
            int total = 0;
            bool rememberflag = false;
            string rememberSKUID = "";
            List<Promotion_segregation> promotions = Promotion_Segregations(promotionTypes);
            for (int i = 0; i < orders.Count; i++)
            {
                for (int j = 0; j < promotions.Count; j++)
                {
                    //Checking the ordered SKUID in promotions type  of "no of units of SKUID's for price" pattern
                    if (orders[i].SKUID == promotions[j].Main_SKUID && promotions[j].Secondary_SKUID == null)
                    {
                        if (orders[i].Units == promotions[j].NumberOfUnits)
                        {
                            total += promotions[j].Price;
                            break;
                        }
                    }

                    //Checking the ordered SKUID in promotions type  of "SKUID1 & SKUID2 for price" pattern 
                    else if (orders[i].SKUID == promotions[j].Main_SKUID && promotions[j].Secondary_SKUID != null)
                    {
                        rememberflag = true;
                        rememberSKUID = orders[i].SKUID.ToString();
                    }
                    else if (rememberflag && rememberSKUID != "" && orders[i].SKUID == promotions[j].Secondary_SKUID)
                    {
                        if (orders[i].Units == promotions[j].NumberOfUnits)
                        {
                            total += promotions[j].Price;
                        }
                    }
                    //Calcuating the price if the pattern is not matvhing with any promotions
                    else
                    {
                                               
                        if (j + 1 == promotions.Count)
                        {
                            int price = skuPrice[orders[i].SKUID];
                            total += price * orders[i].Units;
                        }
                       
                    }


                }
            }
            return total;
        }
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
