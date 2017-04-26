using System;
using System.Collections;
using System.Collections.Generic;

namespace Task5
{
    /// <summary>
    /// Represents Binary tree.
    /// </summary>
    /// <typeparam name="T">Type of tree elements.</typeparam>
    public sealed class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node<T> _root;

        /// <summary>
        /// Represents algoritm of comparison of two elements of the collection.
        /// </summary>
        public readonly Comparison<T> Comparison;

        #region Constructors

        /// <summary>
        /// Creates new Binary tree and initializes it with the specified elements and comparator instance.
        /// </summary>
        /// <param name="elements">Elements for tree initialization.</param>
        /// <param name="comparator">Comparator instance.</param>
        public BinarySearchTree(IEnumerable<T> elements, IComparer<T> comparator) : this(elements, comparator.Compare) { }

        /// <summary>
        /// Creates new Binary tree and initializes it with the specified elements and comparison instance.
        /// </summary>
        /// <param name="elements">Elements for tree initialization.</param>
        /// <param name="comparison">Comparison instance.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public BinarySearchTree(IEnumerable<T> elements, Comparison<T> comparison)
        {
            if (ReferenceEquals(comparison, null) || ReferenceEquals(elements, null))
                throw new ArgumentNullException();

            Comparison = comparison;

            foreach (var element in elements)
            {
                if (ReferenceEquals(_root, null))
                    _root = new Node<T>(element);
                else
                    Add(element);
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Returns the IEnumerator instance while inorder walk.
        /// </summary>
        /// <returns>IEnumerator instance while inorder walk.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumeratorInorder().GetEnumerator();
        }

        /// <summary>
        /// Walks the tree in inorder.
        /// </summary>
        /// <returns>Collection of tree elements.</returns>
        public IEnumerable<T> GetEnumeratorInorder()
        {
            return WalkInorder(_root);
        }

        /// <summary>
        /// Walks the tree in preorder.
        /// </summary>
        /// <returns>Collection of tree elements.</returns>
        public IEnumerable<T> GetEnumeratorPreorder()
        {
            return WalkPreorder(_root);
        }

        /// <summary>
        /// Walks the tree in postorder.
        /// </summary>
        /// <returns>Collection of tree elements.</returns>
        public IEnumerable<T> GetEnumeratorPostorder()
        {
            return WalkPostorder(_root);
        }

        /// <summary>
        /// Adds element to the tree.
        /// </summary>
        /// <param name="element">Element for adding.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(T element)
        {
            if (ReferenceEquals(element, null))
                throw new ArgumentNullException();

            var currentNode = _root;

            while (true)
            {
                if (Comparison(element, currentNode.Value) > 0)
                {
                    if (ReferenceEquals(currentNode.Right, null))
                    {
                        currentNode.Right = new Node<T>(element);
                        break;
                    }
                    currentNode = currentNode.Right;
                }
                else
                {
                    if (ReferenceEquals(currentNode.Left, null))
                    {
                        currentNode.Left = new Node<T>(element);
                        break;
                    }
                    currentNode = currentNode.Left;
                }
            }
        }

        /// <summary>
        /// Removes the specified element from the tree.
        /// </summary>
        /// <param name="element">The element to remove.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Remove(T element)
        {
            if (ReferenceEquals(element, null))
                throw new ArgumentNullException();

            var temp1 = _root;
            Node<T> temp2 = null;

            while (temp1 != null)
            {
                var compare = Comparison(element, temp1.Value);
                if (compare == 0)
                    break;

                temp2 = temp1;
                temp1 = compare < 0 ? temp1.Left : temp1.Right;
            }

            if (temp1 == null)
                throw new ArgumentException();

            if (temp1.Right == null)
            {
                if (temp2 == null)
                    _root = temp1.Left;
                else
                {
                    if (temp1 == temp2.Left)
                        temp2.Left = temp1.Left;
                    else
                        temp2.Right = temp1.Left;
                }
            }
            else if (temp1.Left == null)
            {
                if (temp2 == null)
                    _root = temp1.Right;
                else
                {
                    if (temp1 == temp2.Right)
                        temp2.Right = temp1.Right;
                    else
                        temp2.Left = temp1.Right;
                }
            }
            else
            {
                var tempNode = temp1.Right;
                temp2 = null;

                while (tempNode.Left != null)
                {
                    temp2 = tempNode;
                    tempNode = tempNode.Left;
                }

                if (temp2 != null)
                    temp2.Left = tempNode.Right;
                else
                    temp1.Right = tempNode.Right;

                temp1.Value = tempNode.Value;
            }
        }

        /// <summary>
        /// Finds mimimum element in the tree.
        /// </summary>
        /// <returns>Minimum element of the tree.</returns>
        public T Min()
        {
            Node<T> node = _root;
            while (node.Left != null)
                node = node.Left;
            return node.Value;
        }

        /// <summary>
        /// Finds maximum element in the tree.
        /// </summary>
        /// <returns>Maximum element of the tree.</returns>
        public T Max()
        {
            Node<T> node = _root;
            while (node.Right != null)
            {
                node = node.Right;
            }
            return node.Value;
        }

        /// <summary>
        /// Searches for the specified element in the tree.
        /// </summary>
        /// <param name="searchElement">Element for search.</param>
        /// <returns>Element if it is found; otherwise default value.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T Search(T searchElement)
        {
            if (ReferenceEquals(searchElement, null))
                throw new ArgumentNullException();

            foreach (T element in this)
            {
                if (Comparison(searchElement, element) == 0)
                    return searchElement;
            }
            return default(T);
        }

        /// <summary>
        /// Finds out if the tree contains the specified element.
        /// </summary>
        /// <param name="element">Element for search.</param>
        /// <returns>True if tree contins the element; otherwise false.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Contains(T element)
        {
            if (ReferenceEquals(element, null))
                throw new ArgumentNullException();

            if (Comparison(element, Search(element)) == 0)
                return true;
            return false;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Walks the tree in inorder.
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>Collection of the tree elements one by one.</returns>
        private IEnumerable<T> WalkInorder(Node<T> node)
        {
            if (node == null)
                yield break;

            foreach (var element in WalkInorder(node.Left))
                yield return element;
            yield return node.Value;

            foreach (var element in WalkInorder(node.Right))
                yield return element;
        }

        /// <summary>
        /// Walks the tree in preorder.
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>Collection of the tree elements one by one.</returns>
        private IEnumerable<T> WalkPreorder(Node<T> node)
        {
            if (node == null)
                yield break;
            yield return node.Value;

            foreach (var element in WalkPreorder(node.Left))
                yield return element;

            foreach (var element in WalkPreorder(node.Right))
                yield return element;
        }

        /// <summary>
        /// Walks the tree in postorder.
        /// </summary>
        /// <param name="node">Current node.</param>
        /// <returns>Collection of the tree elements one by one.</returns>
        private IEnumerable<T> WalkPostorder(Node<T> node)
        {
            if (node == null)
                yield break;

            foreach (var element in WalkPostorder(node.Left))
                yield return element;

            foreach (var element in WalkPostorder(node.Right))
                yield return element;
            yield return node.Value;
        }

        /// <summary>
        /// Gets the IEnumerator of the collection.
        /// </summary>
        /// <returns>IEnumerator instance.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion      
    }
}