using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MazeGenerator
{
    /// <summary>
    /// A crappy & uber simplified vector class used by ShapeNode. 
    /// Written because I was unable to find an off the shelf class.
    /// </summary>
    class Vector2D
    {
        public Vector2D(float ax, float ay, float bx, float by)
        {
            a = new PointF(ax, ay);
            b = new PointF(bx, by);
        }

        public Vector2D(PointF A, PointF B)
        {            
            a = A;
            b = B;
        }

        public PointF a, b;        

        public static bool operator == (Vector2D v1, Vector2D v2)
        {
            return (v1.a == v2.a) && (v1.b == v2.b);
        }

        public static bool operator != (Vector2D v1, Vector2D v2)
        {
            return (v1.a != v2.a) || (v1.b != v2.b);
        }

        /*public void Multiply(float scale)
        {
            PointF p = new PointF(b.X - a.X, b.Y - a.Y);
            p.X *= scale;
            p.Y *= scale;

            b = a;
            b.X += p.X;
            b.Y += p.Y;
        }*/

        public double Length()
        {
            PointF p = new PointF(b.X - a.X, b.Y - a.Y);

            p.X = Math.Abs(p.X);
            p.Y = Math.Abs(p.Y);

            double d;
            d = (p.X * p.X) + (p.Y * p.Y);

            return Math.Sqrt(d); // slooow
        }

        public Vector2D Normalized()
        {
            float l;
            l = (float)Length();

            PointF p = new PointF(b.X - a.X, b.Y - a.Y);

            if (l > 0)
            {
                p.X /= l;
                p.Y /= l;
            }

            Vector2D result = new Vector2D(new PointF(0,0), p);

            return result;
        }

        // Appease warning CS0660
        public override bool Equals(object obj)
        {
            // If this and obj do not refer to the same type, then they are not equal.
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return (this == (Vector2D)obj);            
        }

        // Appease warning CS0661
        public override int GetHashCode()
        {
            return 0;
        }

    }
}
