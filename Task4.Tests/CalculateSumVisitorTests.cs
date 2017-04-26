using NUnit.Framework;

namespace Task4.Tests
{
    public class CalculateSumVisitorTests
    {
        #region Adders

        public class IntegerAdder : IAdder<int>
        {
            public int Sum(int element1, int element2) => element1 + element2;
        }

        public class StringAdder : IAdder<string>
        {
            public string Sum(string element1, string element2) => string.Concat(element1, element2);
        }

        #endregion

        #region Source matrix

        public static readonly SquareMatrix<int> SquareMatrix = 
            new SquareMatrix<int>(3, new[,]
                {
                    {1, 2, 3 },
                    {2, 3, 4 },
                    {3, 2, 1 }
                });

        public static readonly DiagonalMatrix<int> DiagonalMatrix =
            new DiagonalMatrix<int>(3, new[,]
                {
                    {1, 0, 0 },
                    {0, 3, 0 },
                    {0, 0, 2 }
                });

        public static readonly SymmetricMatrix<int> SymmetricMatrix =
            new SymmetricMatrix<int>(3, new[,]
                {
                    {1, 2, 3 },
                    {2, 3, 4 },
                    {3, 4, 1 }
                });

        #endregion

        #region Expected matrix

        public static readonly SquareMatrix<int> SquarePlusSquareMatrix =
            new SquareMatrix<int>(3, new[,]
                {
                    {2, 4, 6 },
                    {4, 6, 8 },
                    {6, 4, 2 }
                });

        public static readonly SquareMatrix<int> DiagonalPlusSquareMatrix =
            new SquareMatrix<int>(3, new[,]
                {
                    {2, 2, 3 },
                    {2, 6, 4 },
                    {3, 2, 3 }
                });

        public static readonly SquareMatrix<int> SymmetricPlusSquareMatrix =
            new SquareMatrix<int>(3, new[,]
                {
                    {2, 4, 6 },
                    {4, 6, 8 },
                    {6, 6, 2 }
                });

        public static readonly SquareMatrix<int> SymmetricPlusDiagonalMatrix =
            new SquareMatrix<int>(3, new[,]
                {
                    {2, 2, 3 },
                    {2, 6, 4 },
                    {3, 4, 3 }
                });

        #endregion

        #region Test cases

        [TestCase()]
        public bool Sum_SquarePlusSquareMatrix()
            =>
                SquareMatrix.Accept(new CalculateSumVisitor<int>(), SquareMatrix, new IntegerAdder())
                    .Equals(SquarePlusSquareMatrix);

        [TestCase()]
        public bool Sum_DiagonalPlusSquareMatrix()
            =>
                DiagonalMatrix.Accept(new CalculateSumVisitor<int>(), SquareMatrix, new IntegerAdder())
                    .Equals(DiagonalPlusSquareMatrix);

        [TestCase()]
        public bool Sum_SymmetricPlusSquareMatrix()
            =>
                SymmetricMatrix.Accept(new CalculateSumVisitor<int>(), SquareMatrix, new IntegerAdder())
                    .Equals(SymmetricPlusSquareMatrix);

        [TestCase()]
        public bool Sum_SymmetricPlusDiagonalMatrix()
            =>
                SymmetricMatrix.Accept(new CalculateSumVisitor<int>(), DiagonalMatrix, new IntegerAdder())
                    .Equals(SymmetricPlusDiagonalMatrix);

        #endregion
    }
}
