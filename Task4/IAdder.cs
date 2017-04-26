namespace Task4
{
    /// <summary>
    /// Represents interface for finding sum of two elements.
    /// </summary>
    /// <typeparam name="T">Type of summing elements.</typeparam>
    public interface IAdder<T>
    {
        /// <summary>
        /// Finds sum of two specified elements.
        /// </summary>
        /// <param name="element1">First element.</param>
        /// <param name="element2">Second element.</param>
        /// <returns>Sum of two source elements.</returns>
        T Sum(T element1, T element2);
    }
}
