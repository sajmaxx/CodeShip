using System;
using System.Collections.Generic;
using System.Drawing;


namespace CurveDigitzer.GeoAlgoirthms
{

    public static class GeoLib
    {
        public static  double Distance2D(Point Point1, Point Point2)
        {
            return Math.Sqrt( Math.Pow((Point1.X - Point2.X),2) + Math.Pow((Point1.Y - Point2.Y),2) );
        }

        public static int FindIndexofNearestPoint(Point AMousePt, List<Point> PointList, double touchGap)
        {
            foreach (Point lpoint in PointList)
            {
                if (Distance2D(AMousePt, lpoint) <= touchGap)
                {
                    return PointList.IndexOf(lpoint);
                }
            }

            return -1;
        }

        public static void GetMinMaxForPoints(List<Point> PointList, out int Minx, out int Maxx, out int Miny, out int Maxy)
        {
             Minx = int.MaxValue;
             Miny = int.MaxValue;
             Maxx = int.MinValue;
             Maxy = int.MinValue;
            foreach (var point in PointList)
            {
                if (point.X < Minx)
                {
                    Minx = point.X;
                }

                if (point.Y < Miny)
                {
                    Miny = point.Y;
                }

                if (point.X > Maxx)
                {
                    Maxx = point.X;
                }

                if (point.Y > Maxy)
                {
                    Maxy = point.Y;
                }
            }
        }

    }
    
}
