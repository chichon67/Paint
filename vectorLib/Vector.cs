using System;

namespace vectorLib
{
    public class Vector : PointVectorBase
    {
        public static Vector XDir { get; set; }
        public static Vector YDir { get; set; }
        public static Vector ZDir { get; set; }

        public Point AsPoint
        {
            get
            {
                Point point = new Point();
                point.X = this.X;
                point.Y = this.Y;
                point.Z = this.Z;

                return point;
            }
        }


        // default ctor 
        public Vector()
        {

        }

        //x,y,z ctor
        public Vector(double x, double y, double z) : base(x, y, z)
        {

        }

        // ctor source
        public Vector(Vector source) : base(source)
        {

        }


        public Vector Add(params Vector[] vecs)
        {
            Vector source = new Vector(this);

            foreach (var items in vecs)
            {
                source.X += items.X;
                source.Y += items.Y;
                source.Z += items.Z;
            }

            return source;
        }

        public Vector MutliplyBy(double fac)
        {
            var source = new Vector(this);

            source.X *= fac;
            source.Y *= fac;
            source.Z *= fac;

            return source;
        }

        public double DotProduct(Vector vector)
        {
            var source = new Vector(this);

            double product = source.X * vector.X + source.Y * vector.Y + source.Z * vector.Z;

            return product;

        }

        public Vector CrossProduct(Vector vector)
        {
            Vector vec = new Vector();

            vec.X = ((this.Y * vector.Z) - (this.Z * vector.Y));
            vec.Y = ((this.Z * vector.X) - (this.X * vector.Z));
            vec.Z = ((this.X * vector.Y) - (this.Y * vector.X));

            return vec;

        }

        public Vector Normalize()
        {
            var source = new Vector(this);

            // 1) length 

            double length = Math.Sqrt(Math.Pow(source.X, 2) + (Math.Pow(source.Y, 2)) + (Math.Pow(source.Z, 2)));

            // 2) divide xyz by its length 

            source.X /= length;
            source.Y /= length;
            source.Z /= length;

            return source;
        }

        public bool AreCollinear(params Vector[] vecs)
        {
            var source = new Vector(this);

            foreach (Vector vector in vecs)
            {
                var facX = source.X / vector.X;
                var facY = source.Y / vector.Y;
                var facZ = source.Z / vector.Z;

                if (facX == facY)           // why can't I write (facX == facY == facZ) => true : false
                    if (facX == facZ)
                        return true;

            }
            return false;
        }

        // addition of two vectors
        public static Vector operator +(Vector vec1, Vector vec2)           // int a =1     int b = 2   Console.WriteLine(a+b)
                                                                            // Vector vector = new.(1,2,3)      vecteur vecteur2 = new(2,3,4)    Console.WriteLine(vector + vecteur2)
        {
            double xx = vec1.X + vec2.X;
            double yy = vec1.Y + vec2.Y;
            double zz = vec1.Z + vec2.Z;

            return new Vector(xx, yy, zz);
        }

        // substraction of two vectors
        public static Vector operator -(Vector vec1, Vector vec2)
        {
            double xx = vec1.X - vec2.X;
            double yy = vec1.Y - vec2.Y;
            double zz = vec1.Z - vec2.Z;

            return new Vector(xx, yy, zz);
        }

        // scalar by vector 
        public static Vector operator *(Vector vector, double fac) => new Vector(vector.X * fac, vector.Y * fac, vector.Z * fac);


        // == overloading 
        public static bool operator ==(Vector vector1, Vector vector2)
        {
            if (!(vector1 is Vector && vector2 is Vector))
                return false;

            bool isX = vector1.X == vector2.X;
            bool isY = vector1.Y == vector2.Y;
            bool isZ = vector1.Z == vector2.Z;

            return (isX && isY && isZ);

        }

        // != overloading 
        public static bool operator !=(Vector vector1, Vector vector2)
        {
            if (!(vector1 is Vector && vector2 is Vector))
                return false;

            bool isX = vector1.X != vector2.X;
            bool isY = vector1.Y != vector2.Y;
            bool isZ = vector1.Z != vector2.Z;

            return (isX | isY | isZ);

        }



        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
