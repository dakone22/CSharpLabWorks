using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR11
{
    class MyPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MyPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    
    class PointComparerByOrigin : IComparer<MyPoint>
    {

        public int Compare(MyPoint p1, MyPoint p2)
        {
            
            double distanceToOrigin = Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y);
            double otherDistanceToOrigin = Math.Sqrt(p2.X * p2.X + p2.Y * p2.Y);

            return distanceToOrigin.CompareTo(otherDistanceToOrigin);
        }
    }

    class PointComparerByX : IComparer<MyPoint>
    {
        public int Compare(MyPoint p1, MyPoint p2)
        {
            return Math.Abs(p1.Y).CompareTo(Math.Abs(p2.Y));
        }
    }

    class PointComparerByY : IComparer<MyPoint>
    {

        public int Compare(MyPoint p1, MyPoint p2)
        {
            return Math.Abs(p1.X).CompareTo(Math.Abs(p2.X));
        }
    }

    class PointComparerByDiagonal : IComparer<MyPoint>
    {

        public int Compare(MyPoint p1, MyPoint p2)
        {
            double distanceToDiagonalX = Math.Abs(p1.X - p1.Y);
            double otherDistanceToDiagonalX = Math.Abs(p2.X - p2.Y);

            return distanceToDiagonalX.CompareTo(otherDistanceToDiagonalX);
        }
    }

    public partial class Form1 : Form
    {
        private List<MyPoint> GenerateRandomPoints(int count)
        {
            var points = new List<MyPoint>();
            var random = new Random();

            for (var i = 0; i < count; i++) {
                var x = random.Next(canvas.Width) - canvas.Width / 2;
                var y = random.Next(canvas.Height) - canvas.Height / 2;
                points.Add(new MyPoint(x, y));
            }

            return points;
        }
        
        public Form1()
        {
            InitializeComponent();
            
            canvas.Paint += DrawPoints;
        }

        private List<MyPoint> _myPoints = new List<MyPoint>();

        private Point ConvertToPoint(MyPoint myPoint)
        {
            return new Point(myPoint.X + canvas.Width / 2, -myPoint.Y + canvas.Height / 2);
        }
        
        private void DrawPoints(object sender, PaintEventArgs e)
        {
            if (_myPoints.Count == 0) return;
            
            Graphics g = canvas.CreateGraphics();
            g.Clear(Color.White);
            
            Pen pen = new Pen(Color.Black, 3);
            
            // draw axis
            g.DrawLines(pen, new [] {
                new Point(0, canvas.Height / 2),
                new Point(canvas.Width, canvas.Height / 2),
            });
            
            g.DrawLines(pen, new [] {
                new Point(canvas.Width / 2, 0),
                new Point(canvas.Width / 2, canvas.Height),
            });
            
            var point_array = _myPoints.Select(ConvertToPoint).ToArray();

            double value = 255;
            double step = 256.0 / point_array.Length;
            
            int size = 15;
            foreach (var point in point_array) {
                pen.Color = Color.FromArgb((int) value, Color.Black);
                value -= step;
                
                g.DrawEllipse(pen, point.X, point.Y, size, size);
            }
            
            //Draw lines to screen.
            // g.DrawLines(pen, point_array);
        }

        private void btnNewPoints_Click(object sender, EventArgs e)
        {
            _myPoints = GenerateRandomPoints((int)nudPoints.Value);
            DrawPoints(canvas, null);
        }

        private void btnSort0_Click(object sender, EventArgs e)
        {
            _myPoints.Sort(new PointComparerByOrigin());
            DrawPoints(canvas, null);
        }

        private void btnSort1_Click(object sender, EventArgs e)
        {
            _myPoints.Sort(new PointComparerByX()); // Sorting by distance to X-axis
            DrawPoints(canvas, null);
        }

        private void btnSort2_Click(object sender, EventArgs e)
        {
            _myPoints.Sort(new PointComparerByY()); // Sorting by distance to Y-axis
            DrawPoints(canvas, null);
        }

        private void btnSort3_Click(object sender, EventArgs e)
        {
            _myPoints.Sort(new PointComparerByDiagonal());
            DrawPoints(canvas, null);
        }
    }
}