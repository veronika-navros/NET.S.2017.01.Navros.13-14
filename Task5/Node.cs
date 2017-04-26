using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// Represents the tree node of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of the node.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Node's value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// A reference to the left node.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// A reference to the right node.
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// Initializes a new instance of the Node class with a specified value.
        /// </summary>
        /// <param name="value">The element value.</param>
        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}
