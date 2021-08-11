using NUnit.Framework;
using FigureHandler.Figures;

namespace UnitTests
{
    public class SidesTests
    {
        private class SidesInitializer : Triangle.Sides
        {
            public SidesInitializer(double a, double b, double c) : base(a, b, c)
            {
            }
        }

        [TestCase(4, 5, 6)]
        [TestCase(-4, 0, double.MaxValue)]
        public void Sides_WasInitialized_ReturnValues(double a, double b, double c)
        {
            Triangle.Sides sides = new SidesInitializer(a, b, c);

            Assert.AreEqual(a, sides.A);
            Assert.AreEqual(b, sides.B);
            Assert.AreEqual(c, sides.C);
        }

        [TestCase(3, 4, 5)]
        [TestCase(5, 12, 13)]
        public void Sides_WasInitializedWithRightValues_AllPropertiesAreValid(double a, double b, double c)
        {
            Triangle.Sides sides = new SidesInitializer(a, b, c);

            Assert.AreEqual(true, sides.AllSidesAreValid);
            Assert.AreEqual(true, sides.IsRight);
            Assert.AreEqual(c, sides.TheLongestSide);
            Assert.AreEqual(a, sides.FirstRemainingSide);
            Assert.AreEqual(b, sides.SecondRemainingSide);
        }

        [TestCase(101, 152, 78)]
        public void Sides_WasInitializedWithNotRightValues_AllPropertiesAreValid(double a, double b, double c)
        {
            Triangle.Sides sides = new SidesInitializer(a, b, c);

            Assert.AreEqual(true, sides.AllSidesAreValid);
            Assert.AreEqual(false, sides.IsRight);
            Assert.AreEqual(b, sides.TheLongestSide);
            Assert.AreEqual(a, sides.FirstRemainingSide);
            Assert.AreEqual(c, sides.SecondRemainingSide);
        }

        [TestCase(-1, 5, 10)]
        [TestCase(1, 0, 10)]
        [TestCase(7, 8, 100)]
        public void Sides_WasInitializedWithWrongValues_NotValid(double a, double b, double c)
        {
            Triangle.Sides sides = new SidesInitializer(a, b, c);

            Assert.AreEqual(false, sides.AllSidesAreValid);
            Assert.AreEqual(false, sides.IsRight);
            Assert.AreEqual(0, sides.TheLongestSide);
            Assert.AreEqual(0, sides.FirstRemainingSide);
            Assert.AreEqual(0, sides.SecondRemainingSide);
        }

        [TestCase(7, 8, 100)]
        public void Sides_WasChangedSideValue_NotifySideChanged(double a, double b, double c)
        {
            Triangle.Sides sides = new SidesInitializer(a, b, c);

            sides.SideValueChanged += OnValueChanged;

            double newValue = 10;

            sides.A = newValue;

            Assert.AreEqual(newValue, sides.A);
        }

        private void OnValueChanged()
        {
            Assert.Pass();
        }
    }
}