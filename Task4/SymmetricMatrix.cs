using System;

namespace Task4
{
    /// <summary>
    /// Represents symmetric matrix with base functionality.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        #region Properties

        /// <summary>
        /// Allows to access matrix instance as array.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        /// <returns>Matrix element.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public override T this[int i, int j]
        {
            get
            {
                return MatrixArray[i, j];
            }
            set
            {
                if (i < 0 || j < 0 || i >= Dimension || j >= Dimension)
                    throw new IndexOutOfRangeException();

                MatrixArray[i, j] = value;
                MatrixArray[j, i] = value;
                React(this, new ElementChangeEventArgs(i, j));
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates new emty matrix instance.
        /// </summary>
        public SymmetricMatrix() { }

        /// <summary>
        /// Cerates new matrix instance of the specified dimension.
        /// </summary>
        /// <param name="dimension">Matrix dimension.</param>
        public SymmetricMatrix(int dimension) : base(dimension) { }

        /// <summary>
        /// Creates new matrix of the specified dimension and initializes it with the specified array elements.
        /// </summary>
        /// <param name="dimension">Matrix dimension.</param>
        /// <param name="array">Source array.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public SymmetricMatrix(int dimension, T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();

            if (dimension * dimension != array.Length)
                throw new ArgumentException();

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (i != j && !Equals(array[i, j], array[j, i]))
                        throw new ArgumentException();
                }
            }

            Array.Copy(array, MatrixArray, array.Length);
        }

        #endregion
    }
}
