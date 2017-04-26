using System;

namespace Task4
{
    /// <summary>
    /// Provides arguments for matrix element change event.
    /// </summary>
    public class ElementChangeEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// Element's row index.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Element's column index.
        /// </summary>
        public int Column { get; }

        #endregion

        /// <summary>
        /// Initializes ElementChangeEventArgs instance with the specified row and column indexes.
        /// </summary>
        /// <param name="row">Element's row index</param>
        /// <param name="column">Element's column index</param>
        public ElementChangeEventArgs(int row, int column)
        {
            Row = row;
            Column = column;
        }

    }
}
