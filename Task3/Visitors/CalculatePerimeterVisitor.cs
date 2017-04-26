using System;

namespace Task3.Visitors
{
    /// <summary>
    /// Calculates figures' perimeters.
    /// </summary>
    public class CalculatePerimeterVisitor :IShapeVisitor
    {
        /// <summary>
        /// Calculates circle perimeter.
        /// </summary>
        /// <param name="circle">Circle instance.</param>
        /// <returns>Calculated circle perimeter.</returns>
        /// /// <exception cref="ArgumentNullException"></exception>
        public double Visit(Circle circle)
        {
            if (ReferenceEquals(circle, null))
                throw new ArgumentNullException();

            return 2 * Math.PI * circle.Radius;
        }

        /// <summary>
        /// Calculates square perimeter.
        /// </summary>
        /// <param name="square">Square instance.</param>
        /// <returns>Calculated square perimeter.</returns>
        /// /// <exception cref="ArgumentNullException"></exception>
        public double Visit(Square square)
        {
            if (ReferenceEquals(square, null))
                throw new ArgumentNullException();

            return square.Side * 4;
        }

        /// <summary>
        /// Calculates rectangle perimeter.
        /// </summary>
        /// <param name="rectangle">Rectangle instance.</param>
        /// <returns>Calculated rectangle perimeter.</returns>
        /// /// <exception cref="ArgumentNullException"></exception>
        public double Visit(Rectangle rectangle)
        {
            if (ReferenceEquals(rectangle, null))
                throw new ArgumentNullException();

            return (rectangle.Length + rectangle.Width) * 2;
        }

        /// <summary>
        /// Calculates triangle perimeter.
        /// </summary>
        /// <param name="triangle">Triangle instance.</param>
        /// <returns>Calculated triangle perimeter.</returns>
        /// /// <exception cref="ArgumentNullException"></exception>
        public double Visit(Triangle triangle)
        {
            if (ReferenceEquals(triangle, null))
                throw new ArgumentNullException();

            return triangle.A + triangle.B + triangle.C;
        }
    }
}
