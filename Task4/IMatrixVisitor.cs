namespace Task4
{
    /// <summary>
    /// Provides interface for visitor pattern for matrix hierarchy.
    /// </summary>
    public interface IMatrixVisitor<T>
    {
        /// <summary>
        /// Finds some parameter for two specified Square matrix.
        /// </summary>
        /// <param name="matrix1">First square matrix instance.</param>
        /// <param name="matrix2">Second square matrix instance.</param>
        /// <param name="adder">IAdder object that sums two elements.</param>
        /// <returns>Calculated paramater.</returns>
        SquareMatrix<T> Visit(SquareMatrix<T> matrix1, SquareMatrix<T> matrix2, IAdder<T> adder);

        /// <summary>
        /// Finds some parameter for specified Symmetric matrix and Square matrix.
        /// </summary>
        /// <param name="matrix1">Square matrix instance.</param>
        /// <param name="matrix2">Symmetric matrix instance.</param>
        /// <param name="adder">IAdder object that sums two elements.</param>
        /// <returns>Calculated paramater.</returns>
        SquareMatrix<T> Visit(SymmetricMatrix<T> matrix1, SquareMatrix<T> matrix2, IAdder<T> adder);

        /// <summary>
        /// Finds some parameter for specified Diagonal matrix and Square matrix.
        /// </summary>
        /// <param name="matrix1">Square matrix instance.</param>
        /// <param name="matrix2">Diagonal matrix instance.</param>
        /// <param name="adder">IAdder object that sums two elements.</param>
        /// <returns>Calculated paramater.</returns>
        SquareMatrix<T> Visit(DiagonalMatrix<T> matrix1, SquareMatrix<T> matrix2, IAdder<T> adder);
    }
}
