using System;
using NUnit.Framework;
using FigureHandler.Figures;

namespace UnitTests
{
    public class TriangleTests
    {
        [TestCase(3, 4, 5, 6)]
        public void Triangle_WasInitializedCorrect_AllFieldsAreCorrect(double a, double b, double c, double area)
        {
            Triangle triangle = new Triangle(a, b, c);

            Assert.AreEqual(true, triangle.IsRight);
            Assert.AreEqual(true, triangle.IsValid);
            Assert.AreEqual(area, triangle.Area, 0.01);
        }

        [TestCase(-3, 4, 5)]
        public void Triangle_WasNotInitializedCorrect_AllFieldsAreCorrect(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);

            Assert.AreEqual(false, triangle.IsRight);
            Assert.AreEqual(false, triangle.IsValid);
            Assert.AreEqual(0, triangle.Area);
        }

        [TestCase(4, 5, 6, 9.92)]
        [TestCase(3, 4, 5, 6)]
        [TestCase(5.77, 11.55, 10, 28.85)]
        public void Triangle_WasInitialized_ReturnArea(double a, double b, double c, double area)
        {
            Triangle triangle = new Triangle(a, b, c);

            Assert.AreEqual(area, triangle.Area, 0.01);
        }

        [Test]
        public void Triangle_ChangedSides_ReturnNewArea()
        {
            Triangle triangle = new Triangle(3, 4, 5);

            Assert.AreEqual(6, triangle.Area, 0.01);

            triangle.Side.A = 5;
            triangle.Side.B = 12;
            triangle.Side.C = 13;

            Assert.AreEqual(30, triangle.Area, 0.01);
        }
    }
}
