using System;

namespace FigureHandler.Figures
{
    public partial class Triangle : IFigure
    {
        private readonly Sides sides;
         
        public double Area { get; private set; }

        public bool IsValid
        {
            get
            {
                return sides.AllSidesAreValid;
            }
        }

        public bool IsRight
        {
            get
            {
                return sides.IsRight;
            }
        }

        public Sides Side
        {
            get
            {
                return sides;
            }
        }

        public Triangle(double a, double b, double c)
        {
            sides = new SidesInitializer(a, b, c);

            CalculateArea();

            sides.SideValueChanged += OnSideValueChanged;
        }

        private void OnSideValueChanged()
        {
            CalculateArea();
        }

        private void CalculateArea()
        {
            if(!IsValid)
            {
                Area = 0;
                return;
            }

            if(IsRight)
            {
                Area = sides.FirstRemainingSide * sides.SecondRemainingSide / 2;
                return;
            }

            double p = (sides.A + sides.B + sides.C) / 2;
            Area = Math.Sqrt(p * (p - sides.A) * (p - sides.B) * (p - sides.C));
        }
    }
}
