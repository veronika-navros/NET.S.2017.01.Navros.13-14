using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Task5.Tests
{
    public class BinarySearchTreeTests
    {
        #region Comparers

        public static int IntegerComparer(int integer1, int integer2) => integer1 - integer2;

        public static int StringComparer(string string1, string string2) => string1.Length - string2.Length;

        public static int BookComparer(Book book1, Book book2) => book1.Edition - book2.Edition;

        public struct Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public static int PointComparer(Point point1, Point point2) => point1.X - point2.X;

        #endregion

        #region Source collections

        private static readonly BinarySearchTree<int> Integers =
           new BinarySearchTree<int>(new List<int> { 5, -6, 10, 7, 18 }, Comparer<int>.Default);
        private static readonly BinarySearchTree<int> IntegersWithComparer =
            new BinarySearchTree<int>(new List<int> {5, -6, 10, 7, 18}, IntegerComparer);

        private static readonly BinarySearchTree<string> Strings =
            new BinarySearchTree<string>(new List<string> { "liquor", "honey", "whiskey", "kitty", "melody" }, Comparer<string>.Default);
        private static readonly BinarySearchTree<string> StringsWithComparer =
            new BinarySearchTree<string>(new List<string> { "liquor", "honey", "whiskey", "kitty", "melody" }, StringComparer);

        private static readonly Book Book1 =
            new Book("The master and Margarita", "M.A.Bulgakov", 10, "Mysticism", "YMCA Press");
        private static readonly Book Book2 =
            new Book("Harry Potter and the Chamber of Secrets", "J.K.Rowling", 3, "Fantasy", "Bloomsbury Publishing");
        private static readonly Book Book3 =
            new Book("Romeo and Juliet", "W.Shakespeare", 5, "Tragedy", "Thomas Creede");
        private static readonly BinarySearchTree<Book> Books =
            new BinarySearchTree<Book>(new List<Book> { Book1, Book2, Book3 }, Comparer<Book>.Default);
        private static readonly BinarySearchTree<Book> BooksWithComparer =
           new BinarySearchTree<Book>(new List<Book> { Book1, Book2, Book3 }, BookComparer);

        private static readonly Point Point1 = new Point(10, 18);
        private static readonly Point Point2 = new Point(7, -5);
        private static readonly Point Point3 = new Point(15, 3);
        private static readonly BinarySearchTree<Point> Points =
            new BinarySearchTree<Point>(new List<Point> { Point1, Point2, Point3 }, PointComparer);

        #endregion

        #region Expected collections

        private static readonly List<int> IntegersInorder = new List<int> {-6, 5, 7, 10, 18};
        private static readonly List<int> IntegersPreorder = new List<int> {5, -6, 10, 7, 18};
        private static readonly List<int> IntegersPostorder = new List<int> {-6, 7, 18, 10, 5};

        private static readonly List<string> StringsInorder = new List<string> {"honey", "kitty", "liquor", "melody", "whiskey"};
        private static readonly List<string> StringsPreorder = new List<string> { "liquor", "honey", "kitty", "whiskey", "melody" };
        private static readonly List<string> StringsPostorder = new List<string> {"kitty", "honey", "melody", "whiskey", "liquor"};

        private static readonly List<Book> BooksInorder = new List<Book> {Book2, Book3, Book1};
        private static readonly List<Book> BooksPreorder = new List<Book> {Book1, Book2, Book3};
        private static readonly List<Book> BooksPostorder = new List<Book> {Book3, Book2, Book1};

        private static readonly List<Point> PointsInorder = new List<Point> {Point2, Point1, Point3};
        private static readonly List<Point> PointsPreorder = new List<Point> {Point1, Point2, Point3};
        private static readonly List<Point> PointsPostorder = new List<Point> {Point2, Point3, Point1};

        #endregion

        #region Test cases

        [Test, TestCaseSource(typeof(TestsData),
            nameof(TestsData.InorderIntegers))]
        public void InorderIntegersTests(BinarySearchTree<int> source,
            List<int> expected) => Assert.AreEqual(expected, source.GetEnumeratorInorder());

        [Test, TestCaseSource(typeof(TestsData),
            nameof(TestsData.PreorderIntegers))]
        public void PreorderIntegersTests(BinarySearchTree<int> source,
            List<int> expected) => Assert.AreEqual(expected, source.GetEnumeratorPreorder());

        [Test, TestCaseSource(typeof(TestsData),
            nameof(TestsData.PostorderIntegers))]
        public void PostorderIntegersTests(BinarySearchTree<int> source,
            List<int> expected) => Assert.AreEqual(expected, source.GetEnumeratorPostorder());

        [Test, TestCaseSource(typeof(TestsData),
            nameof(TestsData.InorderIntegersWithComparer))]
        public void InorderIntegersWithComparerTests(BinarySearchTree<int> source,
            List<int> expected) => Assert.AreEqual(expected, source.GetEnumeratorInorder());

        [Test, TestCaseSource(typeof(TestsData),
            nameof(TestsData.PreorderIntegersWithComparer))]
        public void PreorderIntegersWithComparerTests(BinarySearchTree<int> source,
            List<int> expected) => Assert.AreEqual(expected, source.GetEnumeratorPreorder());

        [Test, TestCaseSource(typeof(TestsData),
            nameof(TestsData.PostorderIntegersWithComparer))]
        public void PostorderIntegersWithComparerTests(BinarySearchTree<int> source,
            List<int> expected) => Assert.AreEqual(expected, source.GetEnumeratorPostorder());

        [Test, TestCaseSource(typeof(TestsData),
          nameof(TestsData.InorderStrings))]
        public void InorderStringsTests(BinarySearchTree<string> source,
          List<string> expected) => Assert.AreEqual(expected, source.GetEnumeratorInorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.PreorderStrings))]
        public void PreorderStringsTests(BinarySearchTree<string> source,
           List<string> expected) => Assert.AreEqual(expected, source.GetEnumeratorPreorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.PostorderStrings))]
        public void PostorderStringsTests(BinarySearchTree<string> source,
           List<string> expected) => Assert.AreEqual(expected, source.GetEnumeratorPostorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.InorderStringsWithComparer))]
        public void InorderStringsWithComparerTests(BinarySearchTree<string> source,
           List<string> expected) => Assert.AreEqual(expected, source.GetEnumeratorInorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.PreorderStringsWithComparer))]
        public void PreorderStringsWithComparerTests(BinarySearchTree<string> source,
           List<string> expected) => Assert.AreEqual(expected, source.GetEnumeratorPreorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.PostorderStringsWithComparer))]
        public void PostorderStringsWithComparerTests(BinarySearchTree<string> source,
           List<string> expected) => Assert.AreEqual(expected, source.GetEnumeratorPostorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.InorderBooks))]
        public void InorderBooksTests(BinarySearchTree<Book> source,
           List<Book> expected) => Assert.AreEqual(expected, source.GetEnumeratorInorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.PreorderBooks))]
        public void PreorderBooksTests(BinarySearchTree<Book> source,
           List<Book> expected) => Assert.AreEqual(expected, source.GetEnumeratorPreorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.PostorderBooks))]
        public void PostorderBooksTests(BinarySearchTree<Book> source,
           List<Book> expected) => Assert.AreEqual(expected, source.GetEnumeratorPostorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.InorderBooksWithComparer))]
        public void InorderBooksWithComparerTests(BinarySearchTree<Book> source,
           List<Book> expected) => Assert.AreEqual(expected, source.GetEnumeratorInorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.PreorderBooksWithComparer))]
        public void PreorderBooksWithComparerTests(BinarySearchTree<Book> source,
           List<Book> expected) => Assert.AreEqual(expected, source.GetEnumeratorPreorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.PostorderBooksWithComparer))]
        public void PostorderBooksWithComparerTests(BinarySearchTree<Book> source,
           List<Book> expected) => Assert.AreEqual(expected, source.GetEnumeratorPostorder());

        [Test, TestCaseSource(typeof(TestsData),
          nameof(TestsData.InorderPoints))]
        public void InorderPointsTests(BinarySearchTree<Point> source,
          List<Point> expected) => Assert.AreEqual(expected, source.GetEnumeratorInorder());

        [Test, TestCaseSource(typeof(TestsData),
           nameof(TestsData.PreorderPoints))]
        public void PreorderPointsTests(BinarySearchTree<Point> source,
           List<Point> expected) => Assert.AreEqual(expected, source.GetEnumeratorPreorder());

        [Test, TestCaseSource(typeof(TestsData),
          nameof(TestsData.PostorderPoints))]
        public void PostorderPointsTests(BinarySearchTree<Point> source,
          List<Point> expected) => Assert.AreEqual(expected, source.GetEnumeratorPostorder());

        #endregion

        #region Tests data

         public class TestsData
        {
            public static IEnumerable InorderIntegers
            {
                get { yield return new TestCaseData(Integers, IntegersInorder); }
            }

            public static IEnumerable PreorderIntegers
            {
                get { yield return new TestCaseData(Integers, IntegersPreorder); }
            }
            public static IEnumerable PostorderIntegers
            {
                get { yield return new TestCaseData(Integers, IntegersPostorder); }
            }

            public static IEnumerable InorderIntegersWithComparer
            {
                get { yield return new TestCaseData(Integers, IntegersInorder); }
            }

            public static IEnumerable PreorderIntegersWithComparer
            {
                get { yield return new TestCaseData(Integers, IntegersPreorder); }
            }
            public static IEnumerable PostorderIntegersWithComparer
            {
                get { yield return new TestCaseData(Integers, IntegersPostorder); }
            }

            public static IEnumerable InorderStrings
            {
                get { yield return new TestCaseData(Strings, StringsInorder); }
            }

            public static IEnumerable PreorderStrings
            {
                get { yield return new TestCaseData(Strings, StringsPreorder); }
            }

            public static IEnumerable PostorderStrings
            {
                get { yield return new TestCaseData(Strings, StringsPostorder); }
            }

            public static IEnumerable InorderStringsWithComparer
            {
                get { yield return new TestCaseData(Strings, StringsInorder); }
            }

            public static IEnumerable PreorderStringsWithComparer
            {
                get { yield return new TestCaseData(Strings, StringsPreorder); }
            }

            public static IEnumerable PostorderStringsWithComparer
            {
                get { yield return new TestCaseData(Strings, StringsPostorder); }
            }

            public static IEnumerable InorderBooks
            {
                get { yield return new TestCaseData(Books, BooksInorder); }
            }

            public static IEnumerable PreorderBooks
            {
                get { yield return new TestCaseData(Books, BooksPreorder); }
            }

            public static IEnumerable PostorderBooks
            {
                get { yield return new TestCaseData(Books, BooksPostorder); }
            }

            public static IEnumerable InorderBooksWithComparer
            {
                get { yield return new TestCaseData(Books, BooksInorder); }
            }

            public static IEnumerable PreorderBooksWithComparer
            {
                get { yield return new TestCaseData(Books, BooksPreorder); }
            }

            public static IEnumerable PostorderBooksWithComparer
            {
                get { yield return new TestCaseData(Books, BooksPostorder); }
            }

            public static IEnumerable InorderPoints
            {
                get { yield return new TestCaseData(Points, PointsInorder); }
            }

            public static IEnumerable PreorderPoints
            {
                get { yield return new TestCaseData(Points, PointsPreorder); }
            }

            public static IEnumerable PostorderPoints
            {
                get { yield return new TestCaseData(Points, PointsPostorder); }
            }
        }

        #endregion
    }
}
