using System;

namespace Task3
{
    /// <summary>
    /// Describes rectangle instance.
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        /// Creates new Rectangle instance.
        /// </summary>
        public Rectangle() : this(0, 0) { }

        /// <summary>
        /// Creates new Rectangle instance and initializes it with the specified length and width.
        /// </summary>
        /// <param name="length">Rectangle length.</param>
        /// <param name="width">Rectangle width.</param>
        /// <exception cref="ArgumentException"></exception>
        public Rectangle(double length, double width)
        {
            if (width < 0 || length < 0)
                throw new ArgumentException();

            Length = length;
            Width = width;
        }

        /// <summary>
        /// Rectangle length.
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Rectangle width.
        /// </summary>
        public double Width { get; set; }
    }
}
