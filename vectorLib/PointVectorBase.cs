using System;

namespace vectorLib
{
    public abstract class PointVectorBase
    {


        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double Tolerance = Math.Pow(1, -6);

        // ctor default 
        public PointVectorBase()
        {

        }

        // ctor x,y,z
        public PointVectorBase(double x, double y, double z = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

        }

        // copy constructor 
        public PointVectorBase(PointVectorBase source)
        {
            this.X = source.X;
            this.Y = source.Y;
            this.Z = source.Z;
        }

        public double CalculateDistanceTo(PointVectorBase pvb)
        {

            double xAchsis = pvb.X - this.X;
            double yAchsis = pvb.Y - this.Y;
            double zAchsis = pvb.Z - this.Z;

            double distance = Math.Sqrt(Math.Pow(xAchsis, 2) + Math.Pow(yAchsis, 2) + Math.Pow(zAchsis, 2));

            return distance;

        }

        public void CalculateProduct(double factor)
        {

            this.X *= factor;
            this.Y *= factor;
            this.Z *= factor;


        }

        public void CalculateSum(params PointVectorBase[] pvbs)
        {

            foreach (var pvb in pvbs)
            {
                this.X += pvb.X;
                this.Y += pvb.Y;
                this.Z += pvb.Z;
            }

            Console.WriteLine(this.X + this.Y + this.Z);

        }

        // == overloading 
        public static bool operator ==(PointVectorBase pvb1, PointVectorBase pvb2)
        {
            if (!(pvb1 is PointVectorBase && pvb2 is PointVectorBase))
                return false;

            bool isX = pvb1.X == pvb2.X;
            bool isY = pvb1.Y == pvb2.Y;
            bool isZ = pvb1.Z == pvb2.Z;

            return (isX && isY && isZ);

        }

        // != overloading 
        public static bool operator !=(PointVectorBase pvb1, PointVectorBase pvb2)
        {
            if (!(pvb1 is PointVectorBase && pvb2 is PointVectorBase))
                return false;

            bool isX = pvb1.X != pvb2.X;
            bool isY = pvb1.Y != pvb2.Y;
            bool isZ = pvb1.Z != pvb2.Z;

            return (isX | isY | isZ);

        }



        public override string ToString()
        {
            return $"X = {Math.Round(X, 2)}, Y = {Math.Round(Y, 2)}, Z = {Math.Round(Z, 2)}";
        }

        public override bool Equals(object obj)
        {
            var casting = (PointVectorBase)obj;

            if (!(obj is PointVectorBase))
                return false;


            bool isXEqual = this.X == casting.X;
            bool isYEqual = this.Y == casting.Y;
            bool isZequal = this.Z == casting.Z;

            return (isXEqual && isYEqual && isZequal);

        }

        public override int GetHashCode()
        {
            // this is the base 
            //return this.ToString().GetHashCode();

            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

        }


    }
}
