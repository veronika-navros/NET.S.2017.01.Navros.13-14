using Task3.Visitors;

namespace Task3
{
    /// <summary>
    /// Contains extension methods for Figure class.
    /// </summary>
    public static class FigureExtensions
    {
        /// <summary>
        /// Calculates figure perimeter.
        /// </summary>
        /// <param name="figure">Specified figure.</param>
        /// <returns>Figure perimeter.</returns>
        public static double Perimeter(this Figure figure) => figure.Accept(new CalculatePerimeterVisitor());

        /// <summary>
        /// Calculates figure area.
        /// </summary>
        /// <param name="figure">Specified figure.</param>
        /// <returns>Figure area.</returns>
        public static double Area(this Figure figure) => figure.Accept(new CalculateAreaVisitor());
    }
}
