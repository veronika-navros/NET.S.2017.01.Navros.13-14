using System;

namespace Task3
{
    /// <summary>
    /// Describes square instance.
    /// </summary>
    public class Square : Figure
    {
        /// <summary>
        /// Creates new Square instance.
        /// </summary>
        public Square() : this(0) { }

        /// <summary>
        /// Creates new Circle instance and initializes it with the specified side length.
        /// </summary>
        /// <param name="side">Square side length.</param>
        /// <exception cref="ArgumentException"></exception>
        public Square(double side)
        {
            if(side < 0)
                throw new ArgumentException();

            Side = side;
        }

        /// <summary>
        /// Square side.
        /// </summary>
        public double Side { get; set; }
    }
}
