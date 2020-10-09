using System.Drawing;
using Point = vectorLib.Point;

namespace geometryLib
{
    public abstract class Curve
    {

        public virtual double Length { get; }
        public Pen DrawPen { get; set; } = new Pen(Color.Red);

        public abstract void Draw(Graphics g);

        public Point TransformScreen2World(System.Drawing.Point screenPoint)
        {
            return new Point(screenPoint.X, -(screenPoint.Y - 5));
        }



    }
}
