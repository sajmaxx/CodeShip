using CurveDigitzer.GeoAlgoirthms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace CurveDigitzer.Models
{
    public class CircleMaker
    {
        private readonly List<Point> rawDataPoints;

        private readonly string Errormessage = "At least 3 points needed for fitting";

        public CircleMaker(List<Point> rawDataPoints)
        {
            this.rawDataPoints = rawDataPoints;
        }


        
        //Credit for this Formula comes from:	https://www.programmersought.com/article/31797379418/ 
        public  DigCircle GetFittingCircle()
        {
            DigCircle locCircle = new DigCircle(1, 1, 1);
            if (rawDataPoints.Count < 3)
            {
                MessageBox.Show(Errormessage);
                return locCircle;
            }

            double X1 = 0;
            double Y1 = 0;

            //Sum Squared
            double X2 = 0;
            double Y2 = 0;

            //Sum Cubed
            double X3 = 0;
            double Y3 = 0;

            //Sum products xi*yi
            double X1Y1 = 0;
            //Sum product xi * yi^2
            double X1Y2 = 0;
            //Sum product xi^2 * yi
            double X2Y1 = 0;

            foreach (Point dpoint in rawDataPoints)
            {
                X1 += dpoint.X;
                Y1 += dpoint.Y;
                X2 += dpoint.X * dpoint.X;
                Y2 += dpoint.Y * dpoint.Y;
                X3 += dpoint.X * dpoint.X * dpoint.X;
                Y3 += dpoint.Y * dpoint.Y * dpoint.Y;
                X1Y1 = X1Y1 + dpoint.X * dpoint.Y;
                X1Y2 = X1Y2 + dpoint.X * dpoint.Y * dpoint.Y;
                X2Y1 = X2Y1 + dpoint.X * dpoint.X * dpoint.Y;
            }

            CalculateCircleParameters(X1, Y1, X2, Y2, X3, Y3, X1Y1, X1Y2, X2Y1, out var a, out var b, out var c);

            locCircle.CenterX = a / (-2);
            locCircle.CenterY = b / (-2);
            locCircle.Radius = Math.Sqrt(a * a + b * b - 4 * c) / 2;

            return locCircle;
        }

        private void CalculateCircleParameters(double X1, double Y1, double X2, double Y2, double X3, double Y3, double X1Y1, double X1Y2, double X2Y1, out double a, out double b, out double c)
        {
            
            var numPoints = rawDataPoints.Count;
            var C = numPoints * X2 - X1 * X1;
            var D = numPoints * X1Y1 - X1 * Y1;
            var E = numPoints * X3 + numPoints * X1Y2 - (X2 + Y2) * X1;
            var G = numPoints * Y2 - Y1 * Y1;
            var H = numPoints * X2Y1 + numPoints * Y3 - (X2 + Y2) * Y1;

            a = (H * D - E * G) / (C * G - D * D);
            b = (H * C - E * D) / (D * D - G * C);
            c = -(a * X1 + b * Y1 + X2 + Y2) / numPoints;
        }


        private void ExpandArcForBestFit(DigCircle initialCircle)
        {

        }

        public  DigCircle GetHeuristicFittingCircle()
        {
            DigCircle locCircle = new DigCircle(1, 1, 1);

            if (rawDataPoints.Count >= 2)
            {
                GeoLib.GetMinMaxForPoints(rawDataPoints, out int minx, out int maxx, out int miny, out int maxy);

                var avgX = 0.5*(minx + maxx);
                var avgY = 0.5*(miny + maxy);
                var avgRad = Math.Min((maxx-minx), (maxy-miny));
                DigCircle initialCircle = new DigCircle(avgX,avgY, avgRad);
            }
            
            return locCircle;
        }

    }

}
