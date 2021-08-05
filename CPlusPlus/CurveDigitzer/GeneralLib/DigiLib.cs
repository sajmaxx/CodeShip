using System;
using System.Drawing;

namespace CurveDigitzer.GeneralLib
{
    public static class DigiLib
    {
        public static  double Distance2D(Point Point1, Point Point2)
        {
            return Math.Sqrt( Math.Pow((Point1.X - Point2.X),2) + Math.Pow((Point1.Y - Point2.Y),2) );
        }
    }
}
