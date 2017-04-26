using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    /// <summary>
    /// Represents diagonal matrix with base functionality.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region Properties

        /// <summary>
        /// Allows to access matrix instance as array.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        /// <returns>Matrix element.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
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

                if (i != j)
                    throw new ArgumentException();

                MatrixArray[i, j] = value;
                React(this, new ElementChangeEventArgs(i, j));
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates new emty matrix instance.
        /// </summary>
        public DiagonalMatrix() { }

        /// <summary>
        /// Cerates new matrix instance of the specified dimension.
        /// </summary>
        /// <param name="dimension">Matrix dimension.</param>
        public DiagonalMatrix(int dimension) : base(dimension) { }

        /// <summary>
        /// Cerates new matrix instance and initializes it with the specified elements.
        /// </summary>
        /// <param name="diagonal">Collection of elements for matrix diagonal.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DiagonalMatrix(IEnumerable<T> diagonal)
        {
            if (ReferenceEquals(diagonal, null))
                throw new ArgumentNullException();

            var diagonalList = diagonal as IList<T> ?? diagonal.ToList();
            Dimension = diagonalList.Count();
            MatrixArray = new T[Dimension, Dimension];
            for (int i = 0; i < Dimension; i++)
            {
                MatrixArray[i, i] = diagonalList.ToList()[i];
            }
        }

        /// <summary>
        /// Creates new matrix of the specified dimension and initializes it with the specified array elements.
        /// </summary>
        /// <param name="dimension">Matrix dimension.</param>
        /// <param name="array">Source array.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public DiagonalMatrix(int dimension, T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();

            if (dimension * dimension != array.Length)
                throw new ArgumentException();

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (i != j && !Equals(array[i, j], default (T)))
                        throw new ArgumentException();
                }
            }

            Array.Copy(array, MatrixArray, array.Length);
        }

        #endregion
    }
}
