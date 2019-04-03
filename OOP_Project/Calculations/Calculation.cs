using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class Calculation
    {
        public static int CalculateAge( string birthDate, bool returnInMonths = false )
        {
            int age;
            DateTime now = DateTime.UtcNow;
            DateTime past = Convert.ToDateTime(birthDate);

            if (past.Day <= now.Day)
                age = now.Year - past.Year;

            else
            age = now.Year - past.Year - 1;

            if (returnInMonths)
            {
                if (past.Day <= now.Day)
                    age = 12 * (now.Year - past.Year) + (now.Month - past.Month);
                else
                    age = (12 * (now.Year - past.Year) + (now.Month - past.Month)) - 1;
             }           
            //age = age / 12;
            return age;
        }

        public static decimal CalculateInterest( decimal principleAmount, decimal monthlyRate )
        {
            return principleAmount * monthlyRate;
        }

        public static decimal CalculateAccruedAmount( decimal principleAmount, decimal monthlyRate, decimal dueDateInMonths )
        {
            return principleAmount + ( CalculateInterest(principleAmount, monthlyRate) * dueDateInMonths );
        }

        public static decimal CalculateAccruedAmountWithDiscount(decimal principleAmount, decimal monthlyRate, decimal dueDateInMonths, decimal discount)
        {
            decimal amount;
            amount = principleAmount + (CalculateInterest(principleAmount, monthlyRate) * dueDateInMonths - 
                (principleAmount + CalculateInterest(principleAmount, monthlyRate) * dueDateInMonths) * discount);

            return amount;
        }
    }
}
