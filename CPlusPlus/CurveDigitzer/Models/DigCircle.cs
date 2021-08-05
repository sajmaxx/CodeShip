using System.Drawing;

namespace CurveDigitzer.Models
{
    public class DigCircle
    {
        public double Radius { get; set; }
        public double CenterX { get; set; }
        public double CenterY { get; set; }


        public DigCircle(double cx, double cy, double rad)
        {
            CenterX = cx;
            CenterY = cy;
            Radius = rad;
        }

        public void GetMinMax(out int minx, out int miny, out int maxx, out int maxy)
        {
            minx =  (int)(CenterX - Radius);
            miny = (int)(CenterY - Radius);
            maxx = (int)(CenterX + Radius);
            maxy = (int)(CenterY + Radius);
        }

        public Point CenterPoint()
        {
            return new Point((int)(CenterX), (int)(CenterY));
        }
    }
}