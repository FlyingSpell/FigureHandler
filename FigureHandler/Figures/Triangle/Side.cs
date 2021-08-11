using System;
using FigureHandler.Misc;

namespace FigureHandler.Figures
{
    public partial class Triangle
    {
        public class Sides
        {
            private readonly ValueTypeReference<double> aRef;
            private readonly ValueTypeReference<double> bRef;
            private readonly ValueTypeReference<double> cRef;

            private ValueTypeReference<double>          theLongestSideRef;
            private ValueTypeReference<double>          firstRemainingSideRef;
            private ValueTypeReference<double>          secondRemainingSideRef;

            public Action SideValueChanged;

            public double A
            {
                get
                {
                    return aRef.Value;
                }

                set
                {
                    aRef.Value = value;
                }
            }
            public double B
            {
                get
                {
                    return bRef.Value;
                }

                set
                {
                    bRef.Value = value;
                }
            }
            public double C
            {
                get
                {
                    return cRef.Value;
                }

                set
                {
                    cRef.Value = value;
                }
            }

            public double TheLongestSide
            {
                get
                {
                    return theLongestSideRef?.Value ?? 0;
                }
            }

            public double FirstRemainingSide
            {
                get
                {
                    return firstRemainingSideRef?.Value ?? 0;
                }
            }
            public double SecondRemainingSide
            {
                get
                {
                    return secondRemainingSideRef?.Value ?? 0;
                }
            }

            public bool AllSidesAreValid { get; private set; }

            public bool IsRight { get; private set; }

            protected Sides(double a, double b, double c)
            {
                aRef = new ValueTypeReference<double>(a);
                bRef = new ValueTypeReference<double>(b);
                cRef = new ValueTypeReference<double>(c);

                CheckAndUpdate();

                aRef.ValueChanged += OnSideValueChanged;
                bRef.ValueChanged += OnSideValueChanged;
                cRef.ValueChanged += OnSideValueChanged;
            }

            private void OnSideValueChanged(double dummy)
            {
                CheckAndUpdate();

                SideValueChanged?.Invoke();
            }

            private void CheckAndUpdate()
            {
                AllSidesAreValid = Validate(aRef.Value, bRef.Value, cRef.Value);

                UpdateRefs();

                IsRight = CalculateIfRight();
            }

            private bool Validate(double a, double b, double c)
            {
                bool sidesArePositive = a > 0 && b > 0 && c > 0;

                bool inequalityStatesAreCorrect = (a < b + c) && (b < a + c) && (c < a + b);

                return sidesArePositive && inequalityStatesAreCorrect;
            }

            private void UpdateRefs()
            {
                if(!AllSidesAreValid)
                {
                    theLongestSideRef = null;
                    firstRemainingSideRef = null;
                    secondRemainingSideRef = null;

                    return;
                }

                FindTheLongestSide();
                FindOthersSide();
            }

            private void FindTheLongestSide()
            {
                double max = Math.Max(aRef.Value, Math.Max(bRef.Value, cRef.Value));

                if(aRef.Value == max)
                {
                    theLongestSideRef = aRef;
                }
                else if(bRef.Value == max)
                {
                    theLongestSideRef = bRef;
                }
                else
                {
                    theLongestSideRef = cRef;
                }
            }

            private void FindOthersSide()
            {
                if(theLongestSideRef == aRef)
                {
                    firstRemainingSideRef = bRef;
                    secondRemainingSideRef = cRef;
                }
                else if(theLongestSideRef == bRef)
                {
                    firstRemainingSideRef = aRef;
                    secondRemainingSideRef = cRef;
                }
                else
                {
                    firstRemainingSideRef = aRef;
                    secondRemainingSideRef = bRef;
                }
            }

            private bool CalculateIfRight()
            {
                if(!AllSidesAreValid)
                {
                    return false;
                }

                return firstRemainingSideRef.Value * firstRemainingSideRef.Value +
                       secondRemainingSideRef.Value * secondRemainingSideRef.Value ==
                       theLongestSideRef.Value * theLongestSideRef.Value;
            }
        }

        private class SidesInitializer : Sides
        {
            public SidesInitializer(double a, double b, double c) : base(a, b, c)
            { 
            }
        }
    }
}
