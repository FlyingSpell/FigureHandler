using System;

namespace FigureHandler.Figures
{
    public class Circle : IFigure
    {
        private double radius;
        public double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                radius = value;

                CheckAndUpdate();
            }
        }
        public double Area { get; private set; }

        public bool IsValid { get; private set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        private double CalculateArea(double radius)
        {
            return Math.PI * radius * radius;
        }

        private void CheckAndUpdate()
        {
            if(radius < 0)
            {
                IsValid = false;
                Area = 0;

                return;
            }

            IsValid = true;
            Area = CalculateArea(radius);
        }
    }
}
