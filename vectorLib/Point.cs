using System;

namespace vectorLib
{
    public class Point : PointVectorBase
    {
        public Vector AsVector
        {
            get
            {
                Vector v = new Vector();
                v.X = this.X;
                v.Y = this.Y;
                v.Z = this.Z;

                return v;
            }
        }



        public Point()
        {

        }

        public Point(double x, double y, double z = 0) : base(x, y, z)
        {

        }

        public Point(Point source) : base(source)
        {

        }

        /// <summary>
        /// return the addition of all the points  
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public Point Add(params Point[] points)
        {
            Point source = new Point(this);

            CalculateSum(points);
            return source;
        }


        public double DistanceTo(Point point2)
        {
            Point source = new Point(this);

            double distance = Math.Sqrt(Math.Pow(point2.X - source.X, 2) + Math.Pow(point2.Y - source.Y, 2) + Math.Pow(point2.Z - source.Z, 2));

            return distance;
        }



        // addition of one point and one vector 
        public static Point operator +(Point p1, Vector v1)
        {
            double xCoordinate = p1.X + v1.X;
            double yCoordinate = p1.Y + v1.Y;
            double zCoordinate = p1.Z + v1.Z;

            return (new Point(xCoordinate, yCoordinate, zCoordinate));
        }

        // addition of two points
        public static Point operator +(Point point1, Point point2)
        {
            double xx = point1.X + point2.X;
            double yy = point1.Y + point2.Y;
            double zz = point1.Z + point2.Z;

            return new Point(xx, yy, zz);
        }

        // substraction of two points
        public static Point operator -(Point point1, Point point2)
        {
            double xx = point1.X - point2.X;
            double yy = point1.Y - point2.Y;
            double zz = point1.Z - point2.Z;

            return new Point(xx, yy, zz);
        }

        // == overloading 
        public static bool operator ==(Point point1, Point point2)
        {
            if (!(point1 is Point && point2 is Point))
                return false;

            bool isX = point1.X == point2.X;
            bool isY = point1.Y == point2.Y;
            bool isZ = point1.Z == point2.Z;

            return (isX && isY && isZ);

        }



        // != overloading 
        public static bool operator !=(Point point1, Point point2)
        {
            if (!(point1 is Point && point2 is Point))
                return false;

            bool isX = point1.X != point2.X;
            bool isY = point1.Y != point2.Y;
            bool isZ = point1.Z != point2.Z;

            return (isX | isY | isZ);

        }


        // equals tostring gethashcode
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
