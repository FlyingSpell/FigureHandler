using NUnit.Framework;
using FigureHandler.Misc;

namespace UnitTests
{
    public class ValueTypeReferenceTests
    {
        [TestCase(5)]
        public void ValueTypeReference_WasInitialized_ReturnSameValue(int value)
        {
            ValueTypeReference<int> intRef = new ValueTypeReference<int>(value);

            Assert.AreEqual(value, intRef.Value);
        }

        [Test]
        public void ValueTypeReference_WasInitialized_NotifyValueChanged()
        {
            ValueTypeReference<int> intRef = new ValueTypeReference<int>(1);

            intRef.ValueChanged += OnValueChanged;

            intRef.Value = 5;
        }

        private void OnValueChanged(int newValue)
        {
            Assert.AreEqual(5, newValue);
        }
    }
}