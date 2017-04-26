using System;
using Task3.Visitors;

namespace Task3
{
    /// <summary>
    /// Provides base functionality for figures.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Accepts specific visitor that calculates required figure parameter.
        /// </summary>
        /// <param name="visitor">Calculates specific figure parameter.</param>
        /// <returns>Calculated value.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public double Accept(IShapeVisitor visitor)
        {
            if(ReferenceEquals(visitor, null))
                throw new ArgumentNullException();

            return visitor.Visit((dynamic) this);
        }
    }
}
