using System;

namespace Task4
{
    /// <summary>
    /// Provides matrix manager.
    /// </summary>
    public class MatrixManager
    {
        /// <summary>
        /// Contains methods which are invoked when the matrix element is changed.
        /// </summary>
        public event EventHandler<ElementChangeEventArgs> ElementChange = delegate { };

        /// <summary>
        /// Changes the element.
        /// </summary>
        /// <param name="row">Element's row index.</param>
        /// <param name="column">Element's column index.</param>
        public void ChangeElement(int row, int column) => OnElementChange(new ElementChangeEventArgs(row, column));

        /// <summary>
        /// Executes some actions on element change.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnElementChange(ElementChangeEventArgs e)
        {
            EventHandler<ElementChangeEventArgs> elementChange = ElementChange;
            elementChange?.Invoke(this, e);
        }

    }
}
