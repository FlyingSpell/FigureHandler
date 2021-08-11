using NUnit.Framework;
using FigureHandler;
using FigureHandler.Figures;
using FigureHandler.FigureCreators;

namespace UnitTests
{
    public class CircleCreatorTests
    {
        [TestCase(10)]
        public void CircleCreator_WasInitializedWithCorrectValue_ReturnCorrectFigure(double radius)
        {
            IFigureCreator figureCreator = new CircleCreator();

            IFigure figure = figureCreator.CreateFigure(new double[] { radius });

            Assert.IsNotNull(figure);
            Assert.AreEqual(typeof(Circle), figure.GetType());
            Assert.AreEqual(true, figure.IsValid);
        }

        [TestCase(10, 12)]
        public void CircleCreator_WasInitializedWithWrongValues_ReturnNull(double a, double b)
        {
            IFigureCreator figureCreator = new CircleCreator();

            IFigure figure = figureCreator.CreateFigure(new double[] { a, b });

            Assert.IsNull(figure);
        }
    }
}