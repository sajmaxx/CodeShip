using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBinding101.MathLib2020
{
    public static class JustMath
    {
        public static long Factorial(long number)
        {
            if (number <= 1)
                return 1;
            return number * Factorial(number - 1);
        }
    }

    public static class SMStatistics
    {
        public static double TruncatedMean<T>(this IEnumerable<T> values, int discardcount)
        {
            var theValues = values.Select(value => Convert.ToDouble(value));

            var valuesArray = theValues.ToArray();

            Array.Sort(valuesArray);

            var lowerCnt = discardcount;
            var highCnt = valuesArray.Length - 1 - discardcount;
            var trimnum = highCnt - lowerCnt + 1;
            var trimmedarray = new double[trimnum];

            Array.Copy(valuesArray, lowerCnt, trimmedarray, 0, trimnum);
            return trimmedarray.Average();
        }

        public static double Median<T>(this IEnumerable<T> values)
        {
            var takeDoubles = values.Select(value => Convert.ToDouble(value));

            var doublesArray = takeDoubles.ToArray();

            Array.Sort(doublesArray);

            var count = doublesArray.Length;

            if (count % 2 == 1) //return middle for odd numbered lists
                return doublesArray[count / 2];

            var lowmiddle = doublesArray[count / 2 - 1];
            var himiddle = doublesArray[count / 2];
            return 0.5 * (lowmiddle + himiddle);
        }
    }
}