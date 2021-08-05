using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CurveDigitzer.GeneralLib;

namespace CurveDigitzer.Models
{
    interface IPatternGenerator
    {
        int GetMinPitch();
        List<Point> GetStructure();  //Simple List of Grid Points
        bool WithinSpan(int minVal, int maxVal, int actualVal, int touchTolerance); //tolerance based approximation of range

    }


    public struct Grid
    {
       public int x;
       public  int y;
       public  int xCount;
       public  int yCount;
    }

    public class GridGenerator : IPatternGenerator
    {
        private Grid patternGrid;

        public int StartX { get; set; }
        public int StartY { get; set; }



        public int GetMinPitch()
        {
            return Math.Min(patternGrid.x, patternGrid.y);
        }

        public GridGenerator(int xPitch, int YPitch, int xCount, int yCount)
        {
            StartX = 0;
            StartY = 0;
            patternGrid.x = xPitch;
            patternGrid.y = YPitch;
            patternGrid.xCount = xCount;
            patternGrid.yCount = yCount;
        }

        public List<Point> GetStructure()
        {
            List<Point> gridList = new List<Point>();
            int curX = StartX;
            for (int i = 0; i < patternGrid.xCount; i++)
            {
                var curY = StartY;
                for (int j = 0; j < patternGrid.yCount; j++)
                {
                    gridList.Add(new Point(curX, curY));
                    curY += patternGrid.y;
                }

                curX += patternGrid.x;
            }

            return gridList;
        }

        
        public bool WithinSpan(int minVal, int maxVal, int actualVal, int touchTolerance)
        {
            return ((actualVal > minVal-touchTolerance) && (actualVal < maxVal+touchTolerance));
        }

        public List<bool> GetCircleApproxList(int touchTolerance, DigCircle ActiveCircle, out  double minRadius, out double MaxRadius)
        {
            List<bool> OnCircleList = new List<bool>();
            OnCircleList.AddRange(Enumerable.Repeat(default(bool), patternGrid.xCount*patternGrid.yCount)); //initialize to false

            ActiveCircle.GetMinMax(out int circMinx, out int circMiny, out int circMaxx, out int circMmaxy);

            int linearCounter = 0;

            minRadius = ActiveCircle.Radius *3;
            MaxRadius = -1;

            //Coord Scan Grid Column-wise
            int curX = StartX;
            for (int i = 0; i < patternGrid.xCount; i++)
            {
                if (!WithinSpan(circMinx, circMaxx, curX, touchTolerance))
                {
                    curX += patternGrid.x;
                    linearCounter  += patternGrid.yCount;
                    continue;
                }

                int curY = StartY;
                for (int j = 0; j < patternGrid.yCount; j++)
                {
                    if (WithinSpan(circMiny, circMmaxy, curY, touchTolerance))
                    { 
                        Point currPoint = new Point(curX, curY);
                         double radialValue = DigiLib.Distance2D(ActiveCircle.CenterPoint(), currPoint);
                         if (Math.Abs(radialValue - ActiveCircle.Radius) <= touchTolerance)
                         {
                             if (radialValue < minRadius)
                             {
                                 minRadius = radialValue;
                             }

                             if (radialValue > MaxRadius)
                             {
                                 MaxRadius = radialValue;
                             }

                             OnCircleList[linearCounter] = true;
                         }
                    }

                    curY += patternGrid.y;
                    linearCounter  += 1;

                }

                curX += patternGrid.x;
            }

            return OnCircleList;
        }
    }
}
