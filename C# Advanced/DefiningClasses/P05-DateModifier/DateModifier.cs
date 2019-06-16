using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace DefiningClasses
{
    public class DateModifier
    {
        private string firstDate;
        private string secondDate;

        public int TimeDifference(string firstDate, string secondDate)
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            TimeSpan result = (first - second);
            int resultInDays = result.Days;
            return resultInDays;
        }
    }
}
