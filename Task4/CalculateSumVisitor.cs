using System;

namespace Task4
{
    /// <summary>
    /// Calculates sum of two matrix.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class CalculateSumVisitor<T> : IMatrixVisitor<T>
    {
        #region Public methods

        /// <summary>
        /// Finds sum of two specified Square matrix.
        /// </summary>
        /// <param name="matrix1">First square matrix instance.</param>
        /// <param name="matrix2">Second square matrix instance.</param>
        /// <param name="adder">IAdder object that sums two elements.</param>
        /// <returns>New matrix which is the sum of the source matrixes.</returns>
        public SquareMatrix<T> Visit(SquareMatrix<T> matrix1, SquareMatrix<T> matrix2, IAdder<T> adder)
        {
            if (ReferenceEquals(matrix1, null) || ReferenceEquals(matrix2, null))
                throw new ArgumentNullException();

            if (matrix1.Dimension != matrix2.Dimension)
                throw new ArgumentException();

            return Sum(matrix1, matrix2, adder);
        }

        /// <summary>
        /// Finds sum of specified Symmetric matrix and Square matrix.
        /// </summary>
        /// <param name="matrix1">First square matrix instance.</param>
        /// <param name="matrix2">Second square matrix instance.</param>
        /// <param name="adder">IAdder object that sums two elements.</param>
        /// <returns>New matrix which is the sum of the source matrixes.</returns>
        public SquareMatrix<T> Visit(SymmetricMatrix<T> matrix1, SquareMatrix<T> matrix2, IAdder<T> adder)
        {
          if (ReferenceEquals(matrix1, null) || ReferenceEquals(matrix2, null))
              throw new ArgumentNullException();

            if (matrix1.Dimension != matrix2.Dimension)
                throw new ArgumentException();

            return Sum(matrix1, matrix2, adder);
        }

        /// <summary>
        /// Finds sum of specified Diagonal matrix and Square matrix.
        /// </summary>
        /// <param name="matrix1">First square matrix instance.</param>
        /// <param name="matrix2">Second square matrix instance.</param>
        /// <param name="adder">IAdder object that sums two elements.</param>
        /// <returns>New matrix which is the sum of the source matrixes.</returns>
        public SquareMatrix<T> Visit(DiagonalMatrix<T> matrix1, SquareMatrix<T> matrix2, IAdder<T> adder)
        {
           if(ReferenceEquals(matrix1, null) || ReferenceEquals(matrix2, null))
               throw new ArgumentException();

            if (matrix1.Dimension != matrix2.Dimension)
                throw new ArgumentException();

            return Sum(matrix1, matrix2, adder);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Sums two specified matrixes.
        /// </summary>
        /// <param name="matrix1">First matrix.</param>
        /// <param name="matrix2">Second matrix.</param>
        /// <param name="adder">IAdder object that sums two elements.</param>
        /// <returns>New matrix which is the sum of the source matrixes.</returns>
        private SquareMatrix<T> Sum(SquareMatrix<T> matrix1, SquareMatrix<T> matrix2, IAdder<T> adder)
        {
            var resultMatrix = new SquareMatrix<T>(matrix1.Dimension);
            for (int i = 0; i < matrix1.Dimension; i++)
            {
                for (int j = 0; j < matrix1.Dimension; j++)
                {
                    resultMatrix[i, j] = adder.Sum(matrix1[i, j], matrix2[i, j]);
                }
            }
            return resultMatrix;
        }

        #endregion
    }
}
