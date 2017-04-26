namespace Task3.Visitors
{
    /// <summary>
    /// Provides interface for visitor pattern for figures hierarchy.
    /// </summary>
    public interface IShapeVisitor
    {
        /// <summary>
        /// "Visits" Circle instance and calculates it's specific parameter.
        /// </summary>
        /// <param name="circle">Circle instance.</param>
        /// <returns>Calculated circle parameter.</returns>
        double Visit(Circle circle);

        /// <summary>
        /// "Visits" CircSquarele instance and calculates it's specific parameter.
        /// </summary>
        /// <param name="square">Square instance.</param>
        /// <returns>Calculated square parameter.</returns>
        double Visit(Square square);

        /// <summary>
        /// "Visits" Rectangle instance and calculates it's specific parameter.
        /// </summary>
        /// <param name="rectangle">Rectangle instance.</param>
        /// <returns>Calculated rectangle parameter.</returns>
        double Visit(Rectangle rectangle);

        /// <summary>
        /// "Visits" Triangle instance and calculates it's specific parameter.
        /// </summary>
        /// <param name="triangle">Triangle instance.</param>
        /// <returns>Calculated triangle parameter.</returns>
        double Visit(Triangle triangle);
    }
}

