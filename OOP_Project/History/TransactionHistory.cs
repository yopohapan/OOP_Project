using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Person;
using OOP_Project.Product;

namespace OOP_Project.History
{
    public class TransactionHistory
    {
        PersonClass Client; //{ get; set; }
        ProductClass ClientsJewelry; //{ get; set; }

        public int UniqueCode { get; set; }
        public string HistoryDate { get; set; }
        public string PersonsFullName { get; set; }
        public string ProductJewelry { get; set; }
        public string ProductQuality { get; set; }
        public decimal ProductRate { get; set; }
        public decimal ProductWeight { get; set; }
        public decimal ProductInterest { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal ProductBalance { get; set; }
        public string HistoryStatus { get => GetStatus(); set { } }



        public TransactionHistory(PersonClass client, ProductClass clientsjewelry, int uniqueCode)
        {
            Client = client;
            ClientsJewelry = clientsjewelry;

            UniqueCode = uniqueCode;
            PersonsFullName = client.GetFullName();
            HistoryDate = clientsjewelry.DateOfPurchase.ToString();
            ProductJewelry = clientsjewelry.Product;
            ProductQuality = clientsjewelry.Quality;
            ProductRate = clientsjewelry.SelectedRate;
            ProductWeight = clientsjewelry.Weight;
            ProductInterest = clientsjewelry.MonthlyInterest;
            ProductDiscount = clientsjewelry.Discount;
            ProductBalance = clientsjewelry.AccruedAmountDueWithDiscount;
            HistoryStatus = GetStatus();
        }

        public string GetStatus()
        {
            if (ProductBalance == 0)
                return "Paid";
            else
                return "To Pay";
        }
    }
}
