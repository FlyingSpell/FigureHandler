using System;
using NUnit.Framework;
using FigureHandler.Figures;

namespace UnitTests
{
    public class CircleTests
    {
        [TestCase(10)]
        public void Circle_WasInitialized_ReturnSameValue(double radius)
        {
            Circle circle = new Circle(radius);

            Assert.AreEqual(radius, circle.Radius);
        }

        [TestCase(10)]
        public void Circle_WasInitialized_ChangedValueCorrect(double radius)
        {
            Circle circle = new Circle(radius);

            Assert.AreEqual(radius, circle.Radius);

            circle.Radius = 5;

            Assert.AreEqual(5, circle.Radius);
            Assert.AreEqual(Math.PI * 25, circle.Area);
        }

        [TestCase(10)]
        public void Circle_WasInitializedCorrect_AllFieldsAreCorrect(double radius)
        {
            double area = Math.PI * radius * radius;

            Circle circle = new Circle(radius);

            Assert.AreEqual(area, circle.Area);
            Assert.AreEqual(true, circle.IsValid);
        }

        [TestCase(-10)]
        public void Circle_WasNotInitializedCorrect_AllFieldsAreCorrect(double radius)
        {
            Circle circle = new Circle(radius);

            Assert.AreEqual(radius, circle.Radius);
            Assert.AreEqual(0, circle.Area);
            Assert.AreEqual(false, circle.IsValid);
        }
    }
}