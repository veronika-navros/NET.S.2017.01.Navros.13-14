using System;
using NUnit.Framework;

namespace Task3.Tests
{
    public class AreaTests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = Math.PI)]
        [TestCase(2, ExpectedResult = Math.PI * 4)]
        [TestCase(3, ExpectedResult = Math.PI * 9)]
        public double Area_CircleArea(double radius) => (new Circle(radius)).Area();

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 4)]
        [TestCase(3, ExpectedResult = 9)]
        public double Area_SquareArea(double side) => (new Square(side)).Area();

        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 2, ExpectedResult = 0)]
        [TestCase(3, 0, ExpectedResult = 0)]
        [TestCase(1, 2, ExpectedResult = 2)]
        [TestCase(3, 2, ExpectedResult = 6)]
        public double Area_RectangleArea(double length, double width) => (new Rectangle(length, width)).Area();

        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(4, 2, 2, ExpectedResult = 0)]
        [TestCase(5, 4, 3, ExpectedResult = 6)]
        public double Area_TriangleArea(double a, double b, double c) => (new Triangle(a, b, c)).Area();
    }
}
