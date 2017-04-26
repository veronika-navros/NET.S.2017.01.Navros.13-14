using System;

namespace Task4
{
    /// <summary>
    /// Represents square matrix with base functionality.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class SquareMatrix<T> : IEquatable<SquareMatrix<T>>
    {
        #region Protected fields

        protected T[,] MatrixArray;

        #endregion

        #region Properties

        /// <summary>
        /// Matrix dimension.
        /// </summary>
        public int Dimension { get; protected set; }

        /// <summary>
        /// Allows to access matrix instance as array.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        /// <returns>Matrix element.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public virtual T this[int i, int j]
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
                React(this, new ElementChangeEventArgs(i, j));
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates new emty matrix instance.
        /// </summary>
        public SquareMatrix() : this(0) { }

        /// <summary>
        /// Cerates new matrix instance of the specified dimension.
        /// </summary>
        /// <param name="dimension">Matrix dimension.</param>
        /// <exception cref="ArgumentException"></exception>
        public SquareMatrix(int dimension)
        {
            if (dimension < 0)
                throw new ArgumentException();

            Dimension = dimension;
            MatrixArray = new T[dimension, dimension];
        }

        /// <summary>
        /// Creates new matrix of the specified dimension and initializes it with the specified array elements.
        /// </summary>
        /// <param name="dimension">Matrix dimension.</param>
        /// <param name="array">Source array.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public SquareMatrix(int dimension, T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();

            if (dimension * dimension != array.Length)
                throw new ArgumentException();

            Dimension = dimension;
            Array.Copy(array, MatrixArray, Dimension);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Accepts specific visitor and other matrix for performing calculations.
        /// </summary>
        /// <param name="visitor">Matrix visitor.</param>
        /// <param name="matrix">Other matrix.</param>
        /// <param name="adder">IAdder object that sums two elements.</param>
        /// <returns>New matrix which is the sum of two source matrixes.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public SquareMatrix<T> Accept(IMatrixVisitor<T> visitor, SquareMatrix<T> matrix, IAdder<T> adder)
        {
            if (ReferenceEquals(visitor, null) || ReferenceEquals(matrix, null))
                throw new ArgumentNullException();

            return visitor.Visit((dynamic)this, matrix, adder);
        }

        /// <summary>
        /// Compares elements of current matrix with elements of the specified matrix for equality.
        /// </summary>
        /// <param name="matrix">Matrix to compare with.</param>
        /// <returns>True if matrixes are equal; otherwise false.</returns>
        public bool Equals(SquareMatrix<T> matrix)
        {
            if (ReferenceEquals(matrix, null))
                return false;

            if (Dimension != matrix.Dimension)
                return false;

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (!Equals(this[i, j], matrix[i, j]))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Subscribes current instance to the specified matrix manager.
        /// </summary>
        /// <param name="manager">Manager for subscription.</param>
        public void Register(MatrixManager manager) => manager.ElementChange += React;

        /// <summary>
        /// Unsubscribes current instance from the specified matrix manager.
        /// </summary>
        /// <param name="manager">Manager for unsubscription.</param>
        public void Unregister(MatrixManager manager) => manager.ElementChange -= React;

        #endregion

        #region Protected methods

        /// <summary>
        /// Defines actions that must be done when element is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">An object that contains event data.</param>
        protected virtual void React(object sender, ElementChangeEventArgs eventArgs)
        {
            Console.WriteLine("Element in row " + eventArgs.Row + ", column " + eventArgs.Column + " is changed");
        }

        #endregion

    }
}
