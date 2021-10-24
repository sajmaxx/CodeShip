using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using CurveDigitzer.GeoAlgoirthms;
using CurveDigitzer.Models;


namespace CurveDigitzer
{
    public partial class CirclFitterWindow : Form
    {
        private readonly List<Point> gridPoints;
        private readonly List<Point> selectedGridPoints;
                  
        private Rectangle FrameForCircle;
        private int PenWidth = 2;


        private DigCircle ActiveCircle;
        
        private double  minRadius; 
        private double MaxRadius;
        private readonly double touchtolerance; 
  

        public  CirclFitterWindow()
        {
            InitializeComponent();
            GridGenerator patternGen = new GridGenerator(20, 20, 20, 20)
            {
                StartX = 40,
                StartY = 40
            };
            gridPoints = patternGen.GetStructure();
            selectedGridPoints = new List<Point>();
            touchtolerance = patternGen.GetMinPitch()*0.5;

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
             Point mousePoint = new Point(e.X,e.Y);
             int selectedIndex = GeoLib.FindIndexofNearestPoint(mousePoint, gridPoints, touchtolerance);
             if (selectedIndex >= 0)
             {
                 selectedGridPoints.Add(gridPoints[selectedIndex]);
                 picboxDigitizer.Invalidate();
             }

        }




        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.LemonChiffon);
            e.Graphics.Flush();
            
            DrawGrid(e);

            if (ActiveCircle != null)
            {
                GetFrameForCircle(ActiveCircle);
                e.Graphics.DrawEllipse(new Pen(Color.Blue, PenWidth), FrameForCircle);

                //DigCircle innerCircle = new DigCircle(ActiveCircle.CenterX, ActiveCircle.CenterY, minRadius);
                 
                //DigCircle outerCircle= new DigCircle(ActiveCircle.CenterX, ActiveCircle.CenterY, MaxRadius);

            }

        }


        private void DrawGrid(PaintEventArgs e)
        {

            for(int i =0; i < gridPoints.Count-1; i++)
            {
                Point gpoint = gridPoints[i];
                e.Graphics.FillRectangle(Brushes.LightGray, gpoint.X, gpoint.Y, 5, 5);
            }

            foreach (var gpoint in selectedGridPoints)
            {
                e.Graphics.FillRectangle(Brushes.Blue, gpoint.X, gpoint.Y, 5, 5);   
            }
        }

        private void GetFrameForCircle(DigCircle InputCircle)
        {  if (InputCircle == null) 
             return;
            InputCircle.GetMinMax(out int minx, out int miny, out int _, out int _);
            FrameForCircle.X = minx;
            FrameForCircle.Y = miny;
            FrameForCircle.Height =(int) (InputCircle.Radius*2);
            FrameForCircle.Width = FrameForCircle.Height;
          
        }



        private void buttonGenerate_Click(object sender, EventArgs e)
        {
          CircleMaker CircleMakercol = new CircleMaker(selectedGridPoints);
          ActiveCircle =  CircleMakercol.GetFittingCircle();

         var ActiveCircleHeuristic = CircleMakercol.GetHeuristicFittingCircle();

          picboxDigitizer.Invalidate();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            selectedGridPoints.Clear();
            ActiveCircle = null;
            picboxDigitizer.Invalidate();
        }

        private void MainDigitizerViiew_Load(object sender, EventArgs e)
        {
           // picboxDigitizer.Dock = DockStyle.Fill;
            picboxDigitizer.BackColor = Color.Azure;

        }
    }
}
