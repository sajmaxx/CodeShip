using System;
using System.Collections.Generic;
using System.Drawing;

namespace CurveDigitzer.Models
{
    
    public struct Grid
    {
       public int x;
       public  int y;
       public  int xCount;
       public  int yCount;
    }

    public class GridGenerator
    {
        private readonly Grid patternGrid;

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
    }
}
