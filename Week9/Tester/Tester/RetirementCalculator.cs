using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Tester
{
    public class RetirementCalculator
    {
        public RetirementCalculator(int year, int month)
        {
            this.year = year;
            this.month = month;
        }
        private int year;
        private int month;

        public DateTime CalculateRetirementDate(Person person)
        {
            var date = person.Birthday;
            date = date.AddYears(year);
            date = date.AddMonths(month);
            return date;
        }
    }

    public class Country
    {
        private RetirementCalculator retirementCalculator;
        private RetirementCalculator womenRetirementCalculator;

        public Country(int year, int month)     //för länder med samma pensionsålder för män och kvinnor
        {
            retirementCalculator = new RetirementCalculator(year, month);
            womenRetirementCalculator = new RetirementCalculator(year, month);
        }

        public Country(int maleYear, int maleMonth, int womenYear, int womenMonth)     //för länder med olika pensionsålder för män och kvinnor
        {
            retirementCalculator = new RetirementCalculator(maleYear, maleMonth);
            womenRetirementCalculator = new RetirementCalculator(womenYear, womenMonth);
        }


        public bool isRetired(Person person)
        {
            DateTime retirementDate;

            if (person.isMale)
            {
                retirementDate = retirementCalculator.CalculateRetirementDate(person);
            }
            else
            {
                retirementDate = womenRetirementCalculator.CalculateRetirementDate(person);
            }

            return DateTime.Now > retirementDate;
        }
    }

    public class Sweden : Country
    {
        public Sweden() : base(65, 0)
        {

        }
    }

    public class Bulgaria : Country
    {
        public Bulgaria() : base(64, 4, 61, 4)
        {

        }
    }
}