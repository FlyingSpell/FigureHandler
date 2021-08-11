using System;

namespace FigureHandler.Misc
{
    public class ValueTypeReference<T> where T : struct
    {
        private T value;

        public Action<T> ValueChanged;

        public T Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;

                ValueChanged?.Invoke(value);
            }
        }

        public ValueTypeReference(T value)
        {
            Value = value;
        }
    }
}
