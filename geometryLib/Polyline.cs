using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using vectorLib;
using Point = vectorLib.Point;

namespace geometryLib
{
    public class Polyline : Curve, IArea
    {
        //private readonly List<Point> _points = new List<Point>();
        private readonly List<Point> _Points = new List<Point>(); //{ /*get { return this._points; }*/ }
        private static List<Point> Points;



        public override double Length
        {
            get
            {
                double sum = 0;

                // outOfRange exception ??
                for (int i = 0; i < _Points.Count; i++)
                {
                    sum += _Points[i].DistanceTo(_Points[i + 1]);
                }

                return sum;
            }
        }

        public bool IsCLosed
        {
            get
            {

                if (_Points[0] == _Points[_Points.Count - 1])
                    return true;
                else
                    return false;

            }

        }


        public bool IsPlanar
        {
            get
            {

                Vector ab = (_Points[1] - _Points[0]).AsVector;


                for (int i = 1; i < _Points.Count - 1; i++)
                {
                    Vector next = (_Points[i + 1] - _Points[i]).AsVector;
                    Vector crossVector = ab.CrossProduct(next); // because areCollinear isn't static I have to create a variable 

                    if (ab.AreCollinear(crossVector))       // ab is the original vector which is gonna be compared to all other vectors
                    {
                        return true;
                    }
                }

                return false;
            }
        }


        public bool IsValid
        {
            get
            {
                if (_Points.Count >= 2)
                    return true;

                return false;
            }
        }

        public double Area
        {
            get
            {
                if (!(IsCLosed))
                    return 0;

                const double half = 1 / 2;
                double area = 0;
                double area2 = 0;

                for (int i = 0; i < _Points.Count; i++)
                {
                    area += _Points[i].X * _Points[i + 1].Y;

                    area2 += _Points[i].Y * _Points[i + 1].X;

                    if (i == _Points.Count - 1)        // last index with the first one
                    {
                        area += _Points[i].X * _Points[0].Y;

                        area2 += _Points[i].Y * _Points[0].Z;
                    }
                }

                double finalArea = half * (area - area2);

                return finalArea;
            }
        }

        public Polyline()
        {
            Points = new List<Point>();
        }

        public Polyline(List<Point> ListOfPoints)
        {
            _Points = ListOfPoints;
            Points = ListOfPoints;
        }

        public void AddPoint(Point newPoint)
        {
            _Points.Add(newPoint);
        }

        public void InsertPointAt(int position, Point newPoint)
        {
            _Points.Insert(position, newPoint);
        }

        public override void Draw(Graphics g)
        {
            //var points = _Points.Select(p => new PointF((float)p.X, (float)p.Y));
            //g.DrawLines(DrawPen, points.ToArray());


            for (int i = 0; i < _Points.Count - 1; i++)
            {
                g.DrawLine(DrawPen, (float)_Points[i].X, (float)_Points[i].Y, (float)_Points[i + 1].X, (float)_Points[i + 1].Y);
            }


        }

        public static ClickResult ClickHandler(System.Drawing.Point pt, MouseButtons but, ref Curve curElement)
        {


            if (curElement == null)
            {
                return ClickResult.canceled;
            }

            if (curElement.GetType() != typeof(Circle) && but == MouseButtons.Left) // prüft ob es nur linie ist
            {
                var point = new Point(pt.X, pt.Y);

                Points.Add(point);
                Polyline pl = new Polyline(Points);
                curElement = new Polyline(Points);
                return ClickResult.created;

            }
            else
            {
                Polyline poly = curElement as Polyline;
                if (but == MouseButtons.Left)
                {
                    var point2 = new Point(pt.X, pt.Y);
                    poly.AddPoint(point2);

                    return ClickResult.pointHandled;

                }
                else if (Points.Count < 2 && but == MouseButtons.Right)
                {
                    return ClickResult.canceled;
                }
                else
                {
                    return ClickResult.finished;
                }
            }
        }
    }
}
