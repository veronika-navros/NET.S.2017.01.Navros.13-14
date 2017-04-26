using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    /// <summary>
    /// Provides functionality for working woth Set instance.
    /// </summary>
    /// <typeparam name="T">Type of Set elements.</typeparam>
    public class Set<T> : IEquatable<Set<T>>, IEnumerable<T> where T : class
    {
        private T[] _array;

        /// <summary>
        /// Set's capacity
        /// </summary>
        public int Capacity => _array.Length;

        #region Constructors

        /// <summary>
        /// Creates new Set instance.
        /// </summary>
        public Set() : this(0) { }

        /// <summary>
        /// Creates new Set instance of the specified capacity.
        /// </summary>
        /// <param name="capacity">Set's capacity.</param>
        public Set(int capacity)
        {
            _array = new T[capacity];
        }

        /// <summary>
        /// Creates new Set instance and initializes it with values of the specified array.
        /// </summary>
        /// <param name="array">Array for set's initialization.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Set(IEnumerable<T> array)
        {
            if (ReferenceEquals(null, array))
                throw new ArgumentNullException();

            _array = new T[array.Count()];

            for (int i = 0; i < Capacity; i++)
            {
                _array[i] = array.ToArray()[i];
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Indicates whether the current sET is equal to another Set.
        /// </summary>
        /// <param name="set">A set to compare with current Set.</param>
        /// <returns>True if the current Set is equal to the specified Set; otherwise, false.</returns>
        public bool Equals(Set<T> set)
        {
            if (ReferenceEquals(null, set) || set.Capacity != Capacity)
                return false;

            if (ReferenceEquals(set, _array))
                return true;

            T[] sourceSet = new T[Capacity];
            T[] compareSet = new T[set.Capacity];

            _array.CopyTo(sourceSet, 0);
            int index = 0;
            foreach (var element in set)
            {
                compareSet[index++] = element;
            }
            Array.Sort(sourceSet);
            Array.Sort(compareSet);

            for (int i = 0; i < sourceSet.Length; i++)
            {
                if (!sourceSet[i].Equals(compareSet[i]))
                    return false; 
            }

            return true;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in _array)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current set.
        /// </summary>
        /// <param name="obj">The object to compare with the current set.</param>
        /// <returns>True if the specified object  is equal to the current set; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            Set<T> set = obj as Set<T>;
            if (ReferenceEquals(null, set))
                return false;

            return Equals(set);
        }

        /// <summary>
        /// Returns a string that represents the Set.
        /// </summary>
        /// <returns>A string that represents the set.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override string ToString()
        {
            if (ReferenceEquals(null, _array))
                throw new ArgumentNullException();

            string set = "{ ";
            foreach (T elem in _array)
            {
                set += elem + " ";
            }
            set += "}";

            return set;
        }

        /// <summary>
        /// Serves as the default hash function.
        ///  </summary>
        /// <returns>A hash code for the Set.</returns>
        public override int GetHashCode()
        {
            int hashConst = 42;
            foreach (var item in _array)
            {
                hashConst = hashConst * 13 + item.GetHashCode();
            }

            return hashConst;
        }

        /// <summary>
        /// Compares two sets.
        /// </summary>
        /// <param name="set1">First Set.</param>
        /// <param name="set2">Second Set.</param>
        /// <returns>True if sets are equal; otherwise false.</returns>
        public static bool operator ==(Set<T> set1, Set<T> set2)
        {
            if (ReferenceEquals(null, set1) || ReferenceEquals(null, set2))
                return false;

            return set1.Equals(set2);
        }

        /// <summary>
        /// Compares two sets.
        /// </summary>
        /// <param name="set1">First Set.</param>
        /// <param name="set2">Second Set.</param>
        /// <returns>True if sets are not equal; otherwise false.</returns>
        public static bool operator !=(Set<T> set1, Set<T> set2)
        {
            return !(set1 == set2);
        }

        /// <summary>
        /// Adds an element to the Set.
        /// </summary>
        /// <param name="element">Element that is added to the Set.</param>
        public void Add(T element)
        {
            foreach (T elem in _array)
            {
                if (element.Equals(elem))
                    throw new ArgumentException("Element exists!");
            }

            Array.Resize(ref _array, _array.Length + 1);
            _array[_array.Length - 1] = element;
        }

        /// <summary>
        /// Removes an element from the Set.
        /// </summary>
        /// <param name="element">Element to remove from the Set.</param>
        public void Remove(T element)
        {
            T[] resultArray = new T[_array.Length];

            int leftElementsAmount = 0;
            foreach (T elem in _array)
            {
                if (!element.Equals(elem))
                    resultArray[leftElementsAmount++] = elem;
            }

            Array.Resize(ref resultArray, leftElementsAmount);
            Array.Resize(ref _array, leftElementsAmount);
            resultArray.CopyTo(_array, 0);
        }

        /// <summary>
        /// Checks if the element is in the Set.
        /// </summary>
        /// <param name="element">Cheking element/</param>
        /// <returns>True if the element isin the Set; otherwise false.</returns>
        public bool Contains(T element)
        {
            if (_array.Contains(element))
                return true;
            return false;
        }

        /// <summary>
        /// Clears the Set.
        /// </summary>
        public void Clear()
        {
            Array.Resize(ref _array, 0);
        }

        /// <summary>
        /// Intersects two Sets.
        /// </summary>
        /// <returns>New Set that is an intersection of the two source ones.</returns>
        public Set<T> Intersect(Set<T> set)
        {
            T[] array = new T[0];
            foreach (var element in set)
            {
                if (_array.Contains(element))
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = element;
                }
            }

            return new Set<T>(array);
        }

        /// <summary>
        /// Unions two Sets.
        /// </summary>
        /// <returns>New Set that is a union of the two source ones.</returns>
        public Set<T> Union(Set<T> set)
        {

            T[] array = new T[_array.Length];
            _array.CopyTo(array, 0);
            foreach (var element in set)
            {
                if (!_array.Contains(element))
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = element;
                }
            }

            return new Set<T>(array);
        }

        /// <summary>
        /// Find the difference between the two sets.
        /// </summary>
        /// <returns>Returns a new object of type of set.</returns>
        public Set<T> Difference(Set<T> set)
        {
            var array = new T[0];

            foreach (var element in set)
            {
                if (!_array.Contains(element))
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = element;
                }
            }

            foreach (var element in _array)
            {
                if (!set.Contains(element))
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = element;
                }
            }

            return new Set<T>(array);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
