using System;

namespace Task3.Visitors
{
    /// <summary>
    /// Calculates figures' areas.
    /// </summary>
    public class CalculateAreaVisitor : IShapeVisitor
    {
        /// <summary>
        /// Calculates circle area.
        /// </summary>
        /// <param name="circle">Circle instance.</param>
        /// <returns>Calculated circle area.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public double Visit(Circle circle)
        {
            if (ReferenceEquals(circle, null))
                throw new ArgumentNullException();

            return Math.PI * circle.Radius * circle.Radius;
        }

        /// <summary>
        /// Calculates square area.
        /// </summary>
        /// <param name="square">Square instance.</param>
        /// <returns>Calculated square area.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public double Visit(Square square)
        {
            if (ReferenceEquals(square, null))
                throw new ArgumentNullException();

            return square.Side * square.Side;
        }

        /// <summary>
        /// Calculates rectangle area.
        /// </summary>
        /// <param name="rectangle">Rectangle instance.</param>
        /// <returns>Calculated rectangle area.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public double Visit(Rectangle rectangle)
        {
            if(ReferenceEquals(rectangle, null))
                throw new ArgumentNullException();

            return rectangle.Length * rectangle.Width;
        }

        /// <summary>
        /// Calculates triangle area.
        /// </summary>
        /// <param name="triangle">Triangle instance.</param>
        /// <returns>Calculated triangle area.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public double Visit(Triangle triangle)
        {
            if (ReferenceEquals(triangle, null))
                throw new ArgumentNullException();

            var halfPerimeter = triangle.Accept(new CalculatePerimeterVisitor()) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - triangle.A)
                * (halfPerimeter - triangle.B) * (halfPerimeter - triangle.C));
        }
    }
}
