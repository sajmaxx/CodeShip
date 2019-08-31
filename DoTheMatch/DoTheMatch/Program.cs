using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DoTheMatch
{
    class Program
    {

        static long digPow(int n, int p)
        {
            long [] longar = new long[n*2];
            int curval = n;
            int i = 0;
            while(curval > 0)
            {
                int digival = curval%10;
                if ((digival > 0) && (digival !=10))
                {
                    longar[i] = digival;
                    
                    
                }
                else
                    longar[i] =0;
                i++;
                curval = curval/10;
            }
    
            double specialtot = 0;
    
            for(int j =i-1; j >=0; j--)
            {
                specialtot = (double)specialtot + Math.Pow(longar[j],p);
                p++;
            }
            if ( ((specialtot%n) == 0) && (specialtot >= n) )
                return ((long)specialtot/n);
            return -1;
        }


        static void Main(string[] args)
        {
           long mumbo =  digPow(695, 2);
           mumbo = mumbo+0;

           mumbo = digPow(46288,3);
           mumbo = 333;
        }
    }
}
