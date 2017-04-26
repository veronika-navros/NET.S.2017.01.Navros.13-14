using System;

namespace Task3
{
    /// <summary>
    /// Describes triangle instance.
    /// </summary>
    public class Triangle : Figure
    {
        /// <summary>
        /// Creates new Triangle instance.
        /// </summary>
        public Triangle() : this(0, 0, 0) { }

        /// <summary>
        /// Creates new Triangle instance and initializes it with the specified side lengths.
        /// </summary>
        /// <param name="a">First side length.</param>
        /// <param name="b">Second side length.</param>
        /// <param name="c">Third side length.</param>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
                throw new ArgumentException();
            if (a + b < c || a + c < b || c + b < a)
                throw new ArgumentException();

            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// First triangle side.
        /// </summary>
        public double A { get; set; }

        /// <summary>
        /// Second triangle side.
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Third triangle side.
        /// </summary>
        public double C { get; set; }
    }
}
