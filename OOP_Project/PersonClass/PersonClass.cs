using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using OOP_Project;
using OOP_Project.Product;

namespace OOP_Project.Person
{
    public class PersonClass
    {
        public string LastName; //{ get; set; }
        public string FirstName; //{ get; set; }
        public string MiddleInitial; //{ get; set; }
        public string Birthdate; //{ get; set; }
        public string Address; //{ get; set; }
        public string ContactNumber; //{ get; set; }
        public string initialOnly; //{ get; set; }
        public string arbitraryFullName;

        public List<ProductClass> transactedProducts;

        public PersonClass( string lastName, string firstName, string birthdate, string address, string rawContactNumber, string middleInitial = "" )
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleInitial = middleInitial;
            Birthdate = birthdate;
            Address = address;
            ContactNumber = rawContactNumber;
        }

        public PersonClass(string fullName)
        {
            arbitraryFullName = fullName;
        }

        public string GetFullName( )
        {
            //string initialOnly;

            if ( string.IsNullOrEmpty( MiddleInitial ) )
                initialOnly = "" ;
            else
                initialOnly = CapitalizeFirstLetter( MiddleInitial ).Substring(0, 1) + "." ;

            //Format: First M. Last
            //string FullName = CapitalizeFirstLetter( FirstName ) + " " + initialOnly + " " + CapitalizeFirstLetter( LastName ) ;

            //Format: Last, First M.
            string FullName = CapitalizeFirstLetter(LastName) + ", " + CapitalizeFirstLetter(FirstName) + " " + initialOnly ;

            return FullName;
        }

        public string CapitalizeFirstLetter( string givenName )
        {
            string capitalizedName = "" ;

            string[] splitName = givenName.Split(' ');
            for ( int counterA = 0; counterA < splitName.Length; counterA++ )
            {
                char[] letterSplit = splitName[counterA].ToCharArray();
                letterSplit[0] = char.ToUpper(letterSplit[0]);

                for (int counterB = 1; counterB < letterSplit.Length; counterB++)
                    letterSplit[counterB] = char.ToLower(letterSplit[counterB]);
                
                capitalizedName = capitalizedName + " " + new string( letterSplit );
            }

            capitalizedName = capitalizedName.Remove(0, 1);

            return capitalizedName;
        }

        public int GetAge( ) 
        {
            return Calculation.CalculateAge( Birthdate );
        }

        public string GetBirthDate( )
        {
            return Birthdate;
        }

        public string GetAddress( )
        {
            return Address ;
        }

        public string GetContactNumber( )
        {
            return ContactNumber;
        }
    }
}
