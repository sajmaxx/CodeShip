using MathExamples.MathLib2020;
using System.Collections.Generic;

namespace MathExamples.BootStrap
{
    public class MainViewModel 
    {
        public List<double> SalesPerMonth2020;
        public double TrimmedMeanVal { get; set;}
        public MainViewModel()
        {
            SalesPerMonth2020 = new List<double>(10);
            SalesPerMonth2020.Add(44.56);
            SalesPerMonth2020.Add(144.56);
            SalesPerMonth2020.Add(434.56);
            SalesPerMonth2020.Add(334.56);
            SalesPerMonth2020.Add(134.56);
            SalesPerMonth2020.Add(434.56);
            SalesPerMonth2020.Add(634.56);

            var themeanvalueTrimmed = SalesPerMonth2020.TruncatedMean(2);
            TrimmedMeanVal = themeanvalueTrimmed;
        }

    }
}
