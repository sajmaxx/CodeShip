using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using CurveDigitzer.GeneralLib;
using CurveDigitzer.Models;


namespace CurveDigitzer
{
    public partial class MainDigitizerViiew : Form
    {
        private GridGenerator patternGen;

        private List<Point> gridPoints;
        
        private Rectangle FrameForCircle;
        private int PenWidth = 2;


        private Point CircleCenter, CirclRadPoint;
        private DigCircle ActiveCircle;
        
        private double  minRadius; 
        private double MaxRadius;

  

        public  MainDigitizerViiew()
        {
            InitializeComponent();
            patternGen = new GridGenerator(20, 20, 20, 20)
            {
                StartX = 20,
                StartY = 20
            };
            gridPoints = patternGen.GetStructure();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           
            CircleCenter.X = e.X;
            CircleCenter.Y = e.Y;
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //New code
            CirclRadPoint.X = e.X;
            CirclRadPoint.Y = e.Y;

            double rad = DigiLib.Distance2D(CirclRadPoint, CircleCenter);
            
            ActiveCircle = new DigCircle(CircleCenter.X, CircleCenter.Y, rad);

            //refresh graphics -v
            picboxDigitizer.Invalidate();
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

                DigCircle innerCircle = new DigCircle(ActiveCircle.CenterX, ActiveCircle.CenterY, minRadius);
                GetFrameForCircle(innerCircle);
                e.Graphics.DrawEllipse(new Pen(Color.Red, PenWidth), FrameForCircle);

                DigCircle outerCircle= new DigCircle(ActiveCircle.CenterX, ActiveCircle.CenterY, MaxRadius);
                GetFrameForCircle(outerCircle);
                e.Graphics.DrawEllipse(new Pen(Color.Red, PenWidth), FrameForCircle);

            }

        }


        private void DrawGrid(PaintEventArgs e)
        {
            List<bool> OnCirclStateList = null;
            if ((patternGen != null) && (ActiveCircle != null))
            {
                double touchtolerance = patternGen.GetMinPitch()*0.5;
                OnCirclStateList = patternGen.GetCircleApproxList((int)(touchtolerance), ActiveCircle, out   minRadius, out  MaxRadius);
            }

            for(int i =0; i <= gridPoints.Count-1; i++)
            {
                Point gpoint = gridPoints[i];
                if (( OnCirclStateList  != null) &&(OnCirclStateList[i]))
                    e.Graphics.FillRectangle(Brushes.DeepSkyBlue, gpoint.X, gpoint.Y, 5, 5);
                else
                    e.Graphics.FillRectangle(Brushes.LightGray, gpoint.X, gpoint.Y, 5, 5);
            }
        }

        private void GetFrameForCircle(DigCircle InputCircle)
        {  if (InputCircle == null) 
             return;
            InputCircle.GetMinMax(out int minx, out int miny, out _, out _);
            FrameForCircle.X = minx;
            FrameForCircle.Y = miny;
            FrameForCircle.Height =(int) (InputCircle.Radius*2);
            FrameForCircle.Width = FrameForCircle.Height;
          
        }

        private void MainDigitizerViiew_Load(object sender, EventArgs e)
        {
           // picboxDigitizer.Dock = DockStyle.Fill;
            picboxDigitizer.BackColor = Color.Azure;

        }
    }
}
