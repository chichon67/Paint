using System;
using System.Drawing;
using System.Windows.Forms;
using vectorLib;
using Point = vectorLib.Point;

namespace geometryLib
{

    public class Line : Curve
    {


        public Point StartPoint { get; set; } = new Point(0, 0);
        public Point EndPoint { get; set; } = new Point(200, 500);


        public Vector Direction
        {
            get
            {

                Vector v = new Vector();
                v.X = EndPoint.X - StartPoint.X;
                v.Y = EndPoint.Y - StartPoint.Y;
                v.Z = EndPoint.Z - StartPoint.Z;

                return v;
            }
        }

        public override double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow((EndPoint.X - StartPoint.X), 2) + Math.Pow((EndPoint.Y - StartPoint.Y), 2) + Math.Pow((EndPoint.Z - StartPoint.Z), 2));

            }

        }

        public Line()
        {

        }

        public Line(double startPointX, double startPointY, double endPointX, double endPointY)
        {
            this.StartPoint.X = startPointX;
            this.StartPoint.Y = startPointY;

            this.EndPoint.X = endPointX;
            this.EndPoint.Y = endPointY;
        }




        public override void Draw(Graphics g)
        {
            g.DrawLine(DrawPen, (float)StartPoint.X, (float)StartPoint.Y, (float)EndPoint.X, (float)EndPoint.Y);

        }

        public static ClickResult ClickHandler(System.Drawing.Point pt, MouseButtons but, ref Curve curElement)
        {


            if (but == MouseButtons.Right)
            {
                return ClickResult.canceled;
            }


            else if (but == MouseButtons.Left)


            {
                //var startPoint = new Point();     


                if (curElement == null || curElement.GetType() != typeof(Line)) // prüft ob es nur linie ist
                {
                    var endpoint = new Point();

                    Line line1 = new Line(pt.X, pt.Y, pt.X, pt.Y);
                    curElement = line1;


                    return ClickResult.created;

                }


                else
                {
                    (curElement as Line).EndPoint = new Point(pt.X, pt.Y);

                    return ClickResult.finished;

                }

            }

            return ClickResult.canceled;




        }


    }

}
