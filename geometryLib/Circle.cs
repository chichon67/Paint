using System;
using System.Drawing;
using System.Windows.Forms;
using vectorLib;
using Point = vectorLib.Point;

namespace geometryLib
{
    public class Circle : Curve, IArea
    {
        public Vector Normal { get; set; }

        public double Radius { get; set; }

        public Point CenterPoint { get; set; }

        public double Length
        {
            get { return Math.PI * 2 * Radius; }
        }

        public double Area => Math.PI * (Math.Pow(Radius, 2));

        public Circle()
        {

        }
        public Circle(Point centerPoint, double radius)
        {

            this.Radius = radius;
            this.CenterPoint = centerPoint;
        }

        public override void Draw(Graphics g)
        {
            Rectangle kreis = new Rectangle((int)(this.CenterPoint.X - this.Radius), (int)(this.CenterPoint.Y - this.Radius), (int)this.Radius * 2, (int)this.Radius * 2);
            g.DrawEllipse(DrawPen, kreis);

        }

        public static ClickResult ClickHandler(System.Drawing.Point pt, MouseButtons but, ref Curve curElement)
        {
            //MessageBox.Show("Circle");


            if (but == MouseButtons.Right)
            {
                return ClickResult.canceled;
            }


            else if (but == MouseButtons.Left)


            {
                var center = new Point(pt.X, pt.Y);

                if (curElement == null || curElement.GetType() != typeof(Circle)) // prüft ob es nur Circle ist
                {

                    curElement = new Circle(center, 0);


                    return ClickResult.created;

                }


                else
                {
                    var endPoint = new Point(pt.X, pt.Y);

                    Circle circle = curElement as Circle;
                    double r = circle.CenterPoint.DistanceTo(endPoint);
                    //Line l2 = new Line(circle.CenterPoint.X, circle.CenterPoint.Y, endPoint.X, endPoint.Y);
                    circle.Radius = r;



                    return ClickResult.finished;

                }

            }

            return ClickResult.canceled;
        }

    }
}
