using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathExamples.MathLib2020
{
    public static class StatisticsExtension
    {
        public static double TruncatedMean<T>(this IEnumerable<T> values, int discardcount)
        {
            IEnumerable<double> theValues = values.Select(value => Convert.ToDouble(value));

            double[] valuesArray = theValues.ToArray();

            Array.Sort(valuesArray);

            int lowerCnt = discardcount;
            int highCnt = valuesArray.Length -1 - discardcount;
            int trimnum = highCnt-lowerCnt+1;
            double[] trimmedarray = new double[trimnum];
            
            Array.Copy(valuesArray, lowerCnt, trimmedarray, 0, trimnum );
            return trimmedarray.Average();

        }
    }
}
