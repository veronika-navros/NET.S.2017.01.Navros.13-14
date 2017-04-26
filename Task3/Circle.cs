using System;

namespace Task3
{
    /// <summary>
    /// Describes circle instance.
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Creates new Circle instance.
        /// </summary>
        public Circle() : this(0) { }

        /// <summary>
        /// Creates new Circle instance and initializes it with the specified radius.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <exception cref="ArgumentException"></exception>
        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentException();

            Radius = radius;
        }

        /// <summary>
        /// Circle radius.
        /// </summary>
        public double Radius { get; set; }
    }
}
