using System;

namespace Tester
{
    public class AgeCalculator
    {
        private DateTime? _dt;
        public AgeCalculator()
        {
            _dt = null;
        }

        public AgeCalculator(DateTime date)
        {
            _dt = date;
        }

        public int CalcutaleAge(DateTime birth)
        {
            var date = _dt ?? DateTime.Now;
            var days = (date - birth).Days;
            var years = days / 365;             //Dåligt sätt att räkna ålder
            return years;
        }
    }
}