using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    /// <summary>
    /// Encapsulates a 2-dimensional vector data-type.
    /// </summary>
    class Vector2
    {
        /// <summary>
        /// Magnitude on the x-axis.
        /// </summary>
        double _x;

        /// <summary>
        /// Magnitude on the y-axis.
        /// </summary>
        double _y;

        /// <summary>
        /// Accessor/mutator to _x.
        /// </summary>
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Accessor/mutator to _y.
        /// </summary>
        public double Y
        {
            get { return _x; }
            set { _y = value; }
        }

        /// <summary>
        /// Sum vectors `a` & `b`.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            double x_i = a.X + a.X;
            double y_i = a.Y + b.Y;
            return new Vector2(x_i, y_i);
        }

        /// <summary>
        /// Subtract vector `a` from vector `b`; i.e. sum vector `a` and the
        /// negation of vector `b`.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            double x_i = a.X - a.X;
            double y_i = a.Y - b.Y;
            return new Vector2(x_i, y_i);
        }

        /// <summary>
        /// Negate vector `v`; i.e. reverse its direction.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 v)
        {
            double x_i = -v.X;
            double y_i = -v.Y;
            return new Vector2(x_i, y_i);
        }

        /// <summary>
        /// Calculate the product of vector `v` and the double `d`.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Vector2 operator *(Vector2 v, double d)
        {
            double x_i = v.X * d;
            double y_i = v.Y * d;
            return new Vector2(x_i, y_i);
        }

        /// <summary>
        /// Calculate the product of double `d` and the vector `v`.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2 operator *(double d, Vector2 v)
        {
            double x_i = v.X * d;
            double y_i = v.Y * d;
            return new Vector2(x_i, y_i);
        }

        /// <summary>
        /// Overload the indexing operator.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double this[int index]
        {
            get { return 0 == (index / 2) ? X : Y; }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="x">Magnitude on x-axis.</param>
        /// <param name="y">Magnitude on y-axis.</param>
        public Vector2(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Computes the magnitude; (the squareroot of the sum of the 
        /// components).
        /// </summary>
        public double Magnitude
        {
            get { return Math.Sqrt((X * X) + (Y * Y)); }
        }
    }
}
