using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project.Product
{
    public class ProductClass
    {
        public string Product;
        public string Description;
        public decimal Price;
        public int Items;
        public decimal MonthlyInterest;
        public decimal Discount;
        public string Quality;
        public decimal Weight;
        public string Condition;

        public int BraceletItems;
        public int RingItems;
        public int NecklaceItems;
        public int EarringsItems;
        
        public decimal Rate10K;
        public decimal Rate18K;
        public decimal Rate21K;

        public string Status;

        public DateTime DateOfPurchase;

        public decimal SelectedRate { get => GetSelectedRate(); set { }}
        public decimal MonthsPassed { get => GetMonthsPassed(); set { } }
        public decimal CalculatedInterest { get => GetCalculatedInterest(); set { } }
        public decimal AccruedAmountDue { get => GetAccruedAmount(); set { } }
        public decimal AccruedAmountDueWithDiscount { get => GetDiscountedAccruedAmount(); set { } }

        public ProductClass(string product, string condition, string quality, decimal weight, decimal rate10K, decimal rate18K, decimal rate21K, decimal monthlyInterest , decimal discount, DateTime dateTime)
        {
            Product = product;
            Condition = condition;
            Quality = quality;
            Weight = weight;
            Rate10K = rate10K;
            Rate18K = rate18K;
            Rate21K = rate21K;
            Price = GetPrinciplePrice(weight);
            MonthlyInterest = monthlyInterest;
            Discount = discount;
            Status = GetStatus();
            DateOfPurchase = dateTime;
        }

        public ProductClass(decimal rate10K, decimal rate18K, decimal rate21K)
        {
            Rate10K = rate10K;
            Rate18K = rate18K;
            Rate21K = rate21K;
        }

        public decimal GetMonthsPassed()
        {
            return Calculation.CalculateAge(DateOfPurchase.ToString(), true);
        }

        public decimal GetCalculatedInterest()
        {
            return CalculatedInterest = Calculation.CalculateInterest(Price, MonthlyInterest);
        }

        public decimal GetAccruedAmount()
        {
            return AccruedAmountDue = Calculation.CalculateAccruedAmount(Price, MonthlyInterest, MonthsPassed);
        }

        public decimal GetDiscountedAccruedAmount()
        {
            return AccruedAmountDueWithDiscount = Calculation.CalculateAccruedAmountWithDiscount(Price, MonthlyInterest, MonthsPassed, Discount);
        }

        public void DeductItems(int items = 0)
        {
            if (items != 0)
                Items = Items - items;
            else
                --items;
            Console.WriteLine("Items left on chosen jewelry: " + Items);
        }

        public decimal GetSelectedRate()
        {
            switch(Quality)
            {
                case "10K":
                    return Rate10K;

                case "18K":
                    return Rate18K;

                case "21K":
                    return Rate21K;

                default:
                    return 0;
            }
        }

        public decimal GetPrinciplePrice( decimal weight)
        {
            return SelectedRate * weight;

        }

        public string GetStatus()
        {
            if (Price == 0)
                return "Paid";
            else
                return "To Pay";
        }
    }    
}
